using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringFieldExpression<TEntity> : 
        StringFieldExpression,
        IEquatable<StringFieldExpression<TEntity>>
        where TEntity : IDbEntity
    {
        #region internals
        public FilterExpression LikePhrase { get; set; }
        #endregion

        #region constructors
        public StringFieldExpression(string identifier, EntityExpression entity) : base(identifier, entity)
        {

        }

        private StringFieldExpression(string identifier, EntityExpression entity, string alias) : base(identifier, entity, alias)
        {

        }
        #endregion
        
        #region as
        public StringFieldExpression<TEntity> As(string alias)
            => new StringFieldExpression<TEntity>(base.identifier, base.entity, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase) 
            => new FilterExpression(new StringExpressionMediator(this), new StringExpressionMediator(new LiteralExpression<string>(phrase)), FilterExpressionOperator.Like);
        #endregion

        #region equals
        public bool Equals(StringFieldExpression<TEntity> obj)
            => obj is StringFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
