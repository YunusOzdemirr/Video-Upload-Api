namespace VideoManagementApi.API.Providers;

public interface IClaimProvider
{
    Task<string> GetIpAddress();
}