using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Extentions
{
    public static class IQuerableExtentions
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source,
            bool condition, 
            Expression<Func<T, bool>> predicate) where T : class
        {
            if (condition)
            {
                return source.Where(predicate);
            }
            return source;
        }

        public static IQueryable<T> FilterText<T>(
            this IQueryable<T> source,
            string TextSeach
            ) where T : NamedEntity
        {
            if (string.IsNullOrEmpty(TextSeach))
            {
                return source;
            }
            var res = source.Where(a =>
            a.NameAr.ToLower().Contains(TextSeach.ToLower()) ||
            a.NameEn.ToLower().Contains(TextSeach.ToLower()) ||
            a.DescriptionAr.ToLower().Contains(TextSeach.ToLower()) ||
            a.DescriptionEn.ToLower().Contains(TextSeach.ToLower())
            );
            return res;
        }
        public static IQueryable<T> OrderGroupBy<T>(
            this IQueryable<T> source,
            List<(bool condition, Expression<Func<T, object>>)> predicate,
            bool IsDescending = false
            ) where T : NamedEntity
        {
            foreach (var item in predicate)
            {
                if (item.condition)
                {
                    if (IsDescending)
                    {
                        source = source.OrderByDescending(item.Item2);
                    }
                    else
                    {
                        source = source.OrderBy(item.Item2);
                    }
                }
            }
            return source;
        }
    }
}
