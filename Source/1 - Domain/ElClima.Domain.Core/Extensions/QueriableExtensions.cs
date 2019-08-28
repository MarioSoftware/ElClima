using ElClima.Domain.Core.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ElClima.Domain.Core.Extensions
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class QueriableExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(
           this IQueryable<T> query,
           int pageIndex,
           int pageSize,
           int total)
        {
            var list = query.ToList();
            return new PaginatedList<T>(list, pageIndex, pageSize, total);
        }

        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize)
        {
            if (pageSize < 0) pageSize = 0;

            if (pageIndex >= 1)
            {
                var entities = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                return entities;
            }
            else
            {
                var entities = query.Take(pageSize);
                return entities;
            }
        }
    }
}
