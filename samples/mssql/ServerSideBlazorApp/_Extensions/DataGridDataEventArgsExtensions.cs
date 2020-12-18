using Blazorise;
using Blazorise.DataGrid;
using ServerSideBlazorApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServerSideBlazorApp
{
    public static class DataGridDataEventArgsExtensions
    {
        public static PageRequestModel BuildPageRequestModel<T>(this DataGridReadDataEventArgs<T> args, IEnumerable<DataGridColumnInfo> currentSorting, (DataGridColumnInfo column, SortDirection direction) defaultSort)
        { 
            //args.Columns is assumed to be every column in the grid
            var model = new PageRequestModel
            {
                Offset = (args.Page - 1) * args.PageSize, //Blazorise paging is 1 based
                Limit = args.PageSize
            };

            var sorting = currentSorting?.ToList() ?? new List<DataGridColumnInfo>();
            var updated = args.Columns.ToList();
            var @new = new List<DataGridColumnInfo>(updated.Count);

            foreach (var column in updated.Where(c => c.Direction != SortDirection.None))
            {
                var match = sorting?.SingleOrDefault(s => s.Field == column.Field);
                if (match is object)
                {
                    @new.Insert(column.Direction != match.Direction ? 0 : sorting.IndexOf(match), column);
                }
                else
                {
                    @new.Insert(0, column);
                }
                model.Offset = 0;
            }

            model.Sorting = sorting.Select(s => new Sort(s.Field, s.Direction == SortDirection.Ascending));

            if (defaultSort != default && model.Sorting.SingleOrDefault(c => c.Field == defaultSort.column.Field) == null)
                model.Sorting = model.Sorting.Concat(new Sort[1] { new Sort(defaultSort.column.Field, defaultSort.direction == SortDirection.Ascending) });

            return model;
        }
    }
}
