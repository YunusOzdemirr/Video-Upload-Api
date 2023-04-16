using System;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using Newtonsoft.Json;
using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IClaimProvider _claimProvider;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger, IClaimProvider claimProvider)
        {
            _logger = logger;
            _claimProvider = claimProvider;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            //Request
            _logger.LogInformation("Executing {Name} operation...", typeof(TRequest).Name);
            //Type myType = request.GetType();
            //Get request values
            //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            // foreach (PropertyInfo prop in props)
            // {
            //     var propValue = prop.GetValue(request, null)!;
            //     var ipAddress = await _claimProvider.GetIpAddress();
            //     _logger.LogInformation("IpAddress: {IpAddress} Date: {Datetime}, Property: {Property} : {@Value}",
            //         ipAddress,
            //         DateTime.Now.ToString(CultureInfo.InvariantCulture), prop.Name, propValue
            //     );
            // }
            
            //Response
            var response = await next();
            var logModel = new Log()
            {
                RequestJson = request,
                ResponseJson = response,
                RequestDate = DateTime.Now.ToString(),
                IpAddress = await _claimProvider.GetIpAddress(),
            };
            _logger.LogInformation("Request Detail:  {DetailJson}", JsonConvert.SerializeObject(logModel));
            return response;
        }
    }
}