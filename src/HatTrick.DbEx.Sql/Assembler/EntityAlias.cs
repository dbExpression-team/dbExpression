using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class EntityAlias
    {
        #region interface
        public EntityExpression Entity { get; set; }
        public string Alias { get; set; }
        #endregion

        #region constructors
        public EntityAlias(EntityExpression entity, string alias)
        {
            Entity = entity;
            Alias = alias;
        }
        #endregion
    }
}
