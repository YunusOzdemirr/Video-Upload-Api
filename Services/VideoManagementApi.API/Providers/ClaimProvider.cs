using VideoManagementApi.Application.Interfaces.Services;

namespace VideoManagementApi.API.Providers;

public class ClaimProvider : IClaimProvider
{
    private IHttpContextAccessor _contextAccessor;

    public ClaimProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public async Task<string> GetIpAddress()
    {
        return await Task.FromResult(_contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString());
    }
}