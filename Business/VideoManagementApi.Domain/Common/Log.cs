namespace VideoManagementApi.Domain.Common;

public class Log
{
    public object RequestJson { get; set; }
    public object ResponseJson { get; set; }
    public string RequestDate { get; set; }
    public string IpAddress { get; set; }
}