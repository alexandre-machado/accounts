using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Common.Pagination
{
    public static partial class ExtensionsMethods
    {
        public static IEnumerable<T> ToPaginated<T>(this IEnumerable<T> list, Pagination paginacao)
        {
            var paginatedList = list.AsQueryable();

            return ToPaginatedList<T>(paginacao, ref paginatedList);
        }

        public static IEnumerable<T> ToPaginated<T>(this IQueryable<T> list, Pagination paginacao)
        {
            var paginatedList = list;

            return ToPaginatedList<T>(paginacao, ref paginatedList);
        }

        public static List<T> ToPaginatedList<T>(this IEnumerable<T> q, Pagination paginacao)
        {
            return q.ToPaginated<T>(paginacao).ToList();
        }

        private static IEnumerable<T> ToPaginatedList<T>(Pagination paginacao, ref IQueryable<T> paginatedList)
        {
            if (!string.IsNullOrEmpty(paginacao.orderByName))
                paginatedList = paginatedList.OrderBy(paginacao.orderByName, paginacao.orderByType == "asc");
            else
                paginatedList = paginatedList.OrderBy(o => o);

            if (paginacao.pageSize != 0)
                paginatedList = paginatedList.Skip(paginacao.pageIndex * paginacao.pageSize);

            if (paginacao.pageSize != 0)
                paginatedList = paginatedList.Take(paginacao.pageSize);

            return paginatedList;
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]
    public class Pagination
    {
        public virtual int pageIndex { get; set; }

        public virtual int pageSize { get; set; }

        public virtual string orderByName { get; set; }

        public virtual string orderByType { get; set; }

        public virtual string search { get; set; }
    }
}
