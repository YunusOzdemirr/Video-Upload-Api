using System;
using System.Reflection;
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
            Type myType = request.GetType();
            //Get request values
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                var propValue = prop.GetValue(request, null)!;
                _logger.LogInformation("IpAddress: {IpAddress}, Property: {Property} : {@Value}", prop.Name, propValue,
                    await _claimProvider.GetIpAddress());
            }

            //Response
            var response = await next();
            return response;
        }
    }
}