using Blazorise;
using Blazorise.DataGrid;
using ServerSideBlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp
{
    public static class DataGridDataEventArgsExtensions
    {
        public static PagingParameters CreatePageRequestModel<T>(this DataGridReadDataEventArgs<T> args, PagingParameters previous, Sort defaultSort)
        {
            //args.Columns is assumed to be every column in the grid
            var model = new PagingParameters
            {
                Offset = (args.Page - 1) * args.PageSize, //Blazorise paging is 1 based
                Limit = args.PageSize
            };
            if (args.PageSize != previous.Limit) //page size is changing
            {
                model.Offset = args.PageSize;
                model.Offset = 0;
            }

            var requestedSorting = args.Columns.Where(c => c.Direction != SortDirection.None).Select(r => new Sort(r.Field, r.Direction.ConvertSortDirection().Value)).ToList();
            var previousSorting = previous.Sorting?.Where(s => s != defaultSort).ToList() ?? new List<Sort>();
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

            return model;
        }
    }
}
