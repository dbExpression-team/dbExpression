namespace HTL.DbEx.ObjectMap
{
    public abstract class IndexedField
    {
        #region interface properties
        public string FieldName { get; set; }
        public bool IsDescendingKey { get; set; }
        public bool IsNonKeyInclude { get; set; }
        public byte Ordinal { get; set; }
        #endregion

        #region methods
        public override string ToString() => FieldName;
        #endregion
    }
}
