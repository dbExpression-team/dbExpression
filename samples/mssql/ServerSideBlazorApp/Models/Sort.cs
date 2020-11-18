namespace ServerSideBlazorApp.Models
{
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
