namespace HatTrick.DbEx.CodeTemplating.Model
{
    public class TypeModel<T> : TypeModel
    {
        public TypeModel(string alias)
            : base(typeof(T), alias)
        {
        }

        public TypeModel(string name, string alias)
            : base(typeof(T), name, alias)
        { 
        }
    }
}
