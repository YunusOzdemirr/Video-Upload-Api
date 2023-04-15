FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 9090
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/VideoManagementApi.API/VideoManagementApi.API.csproj", "Services/VideoManagementApi.API/"]
COPY ["Business/VideoManagementApi.Application/VideoManagementApi.Application.csproj", "Business/VideoManagementApi.Application/"]
COPY ["Business/VideoManagementApi.Domain/VideoManagementApi.Domain.csproj", "Business/VideoManagementApi.Domain/"]
COPY ["Business/VideoManagementApi.Infrastructure/VideoManagementApi.Infrastructure.csproj", "Business/VideoManagementApi.Infrastructure/"]

RUN dotnet restore "Services/VideoManagementApi.API/VideoManagementApi.API.csproj"
COPY . .
WORKDIR "/VideoManagementApi.API"
RUN dotnet build "/src/Services/VideoManagementApi.API/VideoManagementApi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/Services/VideoManagementApi.API/VideoManagementApi.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /src
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoManagementApi.API.dll"]


