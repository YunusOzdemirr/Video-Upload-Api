namespace VideoManagementApi.Application.Interfaces.Services;

public interface IClaimProvider
{
    Task<string> GetIpAddress();
}