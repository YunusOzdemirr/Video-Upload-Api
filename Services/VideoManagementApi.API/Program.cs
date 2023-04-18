using System.Reflection;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using VideoManagementApi.API.Extensions.Registration;
using VideoManagementApi.API.Mappings;
using VideoManagementApi.API.Middleware;
using VideoManagementApi.API.Providers;
using VideoManagementApi.Application;
using VideoManagementApi.Application.Extensions;
using VideoManagementApi.Application.Interfaces.Services;
using VideoManagementApi.Domain.Options;
using VideoManagementApi.Infrastructure;
using VideoManagementApi.Infrastructure.Extensions;
using VideoManagementApi.Infrastructure.Utilities.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationRegistration();
builder.Services.ConfigureEventHandlers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IClaimProvider, ClaimProvider>();
builder.Services.AddAutoMapper(typeof(ViewModelMapping));
builder.Services.AddServiceDiscoveryRegistration(builder.Configuration);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }
    );

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        var enumConverter = new JsonStringEnumConverter();
        opts.JsonSerializerOptions.Converters.Add(enumConverter);
        opts.JsonSerializerOptions.DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull;
    });


string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"Configurations/appsettings.json", optional: true)
    .AddJsonFile($"Configurations/appsettings.{env}.json", optional: true)
    .AddJsonFile($"Configurations/serilog.json", optional: true)
    .AddJsonFile($"Configurations/serilog.{env}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddAInfrastructureRegistration(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VideoManagement.API", Version = "0.0.1" }); //auth i�ini ��zd�m olm
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                     Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };

    options.RequireHttpsMetadata = false;
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/portfolio")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});


// builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(@"/Api-Logs/"))
//     .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
//     {
//         EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
//         ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
//     });

// var trimmedContentRootPath = builder.Environment.ContentRootPath.TrimEnd(Path.DirectorySeparatorChar);
// builder.Services.AddDataProtection()
//     .SetApplicationName(trimmedContentRootPath);

builder.Services
    .AddLogging(configure => configure.AddConsole());
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials());
    
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (builder.Environment.ContentRootPath.Contains(@"\"))
    if (!Directory.Exists(builder.Environment.ContentRootPath + @"\wwwroot" + @"\Uploads"))
        Directory.CreateDirectory(builder.Environment.ContentRootPath + @"\wwwroot" + @"\Uploads");

if (builder.Environment.ContentRootPath.Contains(@"/"))
    if (!Directory.Exists(builder.Environment.ContentRootPath + "/wwwroot" + "/Uploads"))
        Directory.CreateDirectory(builder.Environment.ContentRootPath + "/wwwroot" + "/Uploads");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        builder.Environment.ContentRootPath + "/wwwroot" + "/Uploads"),
    //Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads")),
    RequestPath = new PathString("/Uploads"),
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();