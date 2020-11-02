namespace ServerSideBlazorApp.Models
{
    public abstract class PageModel
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public string SearchPhrase { get; set; }
        public Sort Sort {get; set; }


        protected PageModel()
        {
        }

        protected PageModel(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }

        protected PageModel(int offset, int limit, string searchPhrase)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
        }

        protected PageModel(int offset, int limit, string searchPhrase, Sort sort)
        {
            Offset = offset;
            Limit = limit;
            SearchPhrase = searchPhrase;
            Sort = sort;
        }
    }

    public class Sort
    { 
        public string Field { get; set; }
        public bool Ascending { get; set; }

        public Sort()
        {
        }

        public Sort(string field, bool ascending)
        {
            Field = field;
            Ascending = ascending;
        }
    }
}
