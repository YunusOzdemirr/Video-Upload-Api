using System;
using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.Domain.Common
{
    public interface IResult
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public object Data { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }

    public interface IResult<T> : IResult
    {
    }
}