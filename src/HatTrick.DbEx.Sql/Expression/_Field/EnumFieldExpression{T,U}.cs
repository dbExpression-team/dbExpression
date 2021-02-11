using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class EnumFieldExpression<TEntity, TEnum> : EnumFieldExpression<TEnum>,
        IEquatable<EnumFieldExpression<TEntity, TEnum>>
        where TEntity : class, IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, typeof(TEnum), entity)
        {

        }
        #endregion

        #region as
        public override EnumElement<TEnum> As(string alias)
            => new EnumSelectExpression<TEnum>(this).As(alias);
        #endregion

        #region in value set
        public override FilterExpressionSet In(params TEnum[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<TEnum>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<TEnum> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<TEnum>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region equals
        public bool Equals(EnumFieldExpression<TEntity, TEnum> obj)
            => obj is EnumFieldExpression<TEntity, TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumFieldExpression<TEntity, TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumFieldExpression<TEntity, TEnum> a) => new EnumExpressionMediator<TEnum>(a);
        #endregion

        #region filter operators
        #region TEnum
        public static FilterExpressionSet operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpressionSet(new FilterExpression<TEnum?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpressionSet(new FilterExpression<TEnum?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
