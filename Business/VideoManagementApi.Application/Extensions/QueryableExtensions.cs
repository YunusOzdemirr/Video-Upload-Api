﻿using System;
using VideoManagementApi.Application.Exceptions;

namespace VideoManagementApi.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber,
            int pageSize) where T : class
        {
            if (source is null) throw new ApiException();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = source.Count();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }

        //public static IQueryable<T> Specify<T>(this IQueryable<T> query, ISpecification<T> spec) where T : class ,IEntity
        //{
        //    var queryableResultWithIncludes = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        //    var secondaryResult = spec.IncludeStrings.Aggregate(queryableResultWithIncludes, (current, include) => current.Include(include));
        //    return secondaryResult.Where(spec.Criteria);
        //}
    }
}