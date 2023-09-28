using AvoApi.Data;
using AvoApi.Data.Models;

namespace AvoApi.Extensions;

public static class PageableExtension
{

    /// <summary>
    /// Extension method that will automatically return a page of the iqueryable
    /// </summary>
    /// <param name="query"></param>
    /// <param name="page">page number</param>
    /// <returns></returns>
    public static IQueryable<Avocado> Pageable(this IQueryable<Avocado> query, int page)
    {
        return query.Skip(Constants.PAGE_SIZE * page).Take(Constants.PAGE_SIZE);
    }
}