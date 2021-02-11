using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringFieldExpression<TEntity> :
        StringFieldExpression,
        IExpressionElement<string>,
        IEquatable<StringFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region internals
        public FilterExpression LikePhrase { get; set; }
        #endregion

        #region constructors
        public StringFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override StringElement As(string alias)
            => new StringSelectExpression(this).As(alias);
        #endregion

        #region like
        public FilterExpressionSet Like(string phrase) 
            => new FilterExpressionSet(new FilterExpression(this, new LikeExpression(phrase), FilterExpressionOperator.None));
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
