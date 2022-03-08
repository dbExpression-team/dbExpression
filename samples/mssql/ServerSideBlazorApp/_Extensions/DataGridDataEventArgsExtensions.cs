using Blazorise;
using Blazorise.DataGrid;
using HatTrick.DbEx.Sql.Expression;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp
{
    public static class DataGridDataEventArgsExtensions
    {
        public static T CreatePagingParameters<T,U>(this DataGridReadDataEventArgs<U> args, T previous, Sort defaultSort, Action<T>? additionalConfiguration = null)
             where T : PagingParameters, new()
        {
            //args.Columns is assumed to be every column in the grid
            var model = new T
            {
                Offset = (args.Page - 1) * args.PageSize, //Blazorise paging is 1 based
                Limit = args.PageSize
            };
            if (args.PageSize != previous.Limit) //page size is changing
            {
                model.Offset = 0;
            }

            var requestedSorting = args.Columns.Where(c => c.SortDirection != SortDirection.None).Select(r => new Sort(r.Field, r.SortDirection.ConvertSortDirection() ?? OrderExpressionDirection.ASC)).ToList();
            var previousSorting = previous?.Sorting?.ToList() ?? new List<Sort>();
            var newSorting = new Sort[Math.Max(requestedSorting.Count, previousSorting.Count)];
            var newlyRequestedSorting = new List<Sort>();

            foreach (var requestedSort in requestedSorting)
            {
                var match = previousSorting.SingleOrDefault(s => s.Field == requestedSort.Field);
                if (match is object)
                {
                    newSorting[previousSorting.IndexOf(match)] = requestedSort;
                }
                else
                {
                    newlyRequestedSorting.Add(requestedSort);
                }
            }
            if (newlyRequestedSorting.Any())
            {
                model.Sorting = newlyRequestedSorting.Concat(newSorting.Where(s => s is object));
                model.Offset = 0;  //reset page offset so "first" page will be requested with new sort
            }
            else
            {
                model.Sorting = newSorting.Where(s => s is object);
            }
            if (defaultSort is object && !model.Sorting.Select(s => s.Field).Contains(defaultSort.Field))
            {
                model.Sorting = model.Sorting.Append(defaultSort);
            }

            additionalConfiguration?.Invoke(model);

            return model;
        }

        public static T CreatePagingParameters<T>(this DataGridPageChangedEventArgs args, T previous, Sort defaultSort, Action<T>? additionalConfiguration = null)
            where T : PagingParameters, new()
        {
            //args.Columns is assumed to be every column in the grid
            var model = new T
            {
                Offset = (args.Page - 1) * args.PageSize, //Blazorise paging is 1 based
                Limit = args.PageSize,
                Sorting = previous?.Sorting?.ToList() ?? new List<Sort>() {  defaultSort }
            };

            if (args.PageSize != (previous?.Limit ?? 0)) //page size is changing
            {
                model.Offset = 0;
            }            

            additionalConfiguration?.Invoke(model);

            return model;
        }
    }
}
