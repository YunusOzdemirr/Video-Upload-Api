using System;

namespace VideoManagementApi.Domain.Common
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}