namespace HatTrick.DbEx.ObjectMap
{
    public abstract class Relationship
    {
        #region internals
        #endregion

        #region interface properties
        public virtual string Name { get; set; }

        public virtual string ReferencedEntity { get; set; }

        public virtual string ReferencedField { get; set; }

        public virtual string LocalEntity { get; set; }

        public virtual string LocalField { get; set; }
        #endregion

        #region constructors
        #endregion

        #region methods
        public override string ToString() => $"{this.Name} As [{this.LocalEntity}].[{this.LocalField}] FK of [{this.ReferencedEntity}].[{this.ReferencedField}]";
        #endregion
    }
}
