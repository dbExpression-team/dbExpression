using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public static class dbex
    {
        public static AliasExpression alias(string tableName, string fieldName)
            => new AliasExpression(tableName, fieldName);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableBooleanElement coerce(BooleanElement element)
            => new NullableBooleanExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteElement coerce(ByteElement element)
            => new NullableByteExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteArrayElement coerce(ByteArrayElement element)
            => new NullableByteArrayExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeElement coerce(DateTimeElement element)
            => new NullableDateTimeExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeOffsetElement coerce(DateTimeOffsetElement element)
            => new NullableDateTimeOffsetExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDecimalElement coerce(DecimalElement element)
            => new NullableDecimalExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDoubleElement coerce(DoubleElement element)
            => new NullableDoubleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableEnumElement<TEnum> coerce<TEnum>(EnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumExpressionMediator<TEnum>(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableGuidElement coerce(GuidElement element)
            => new NullableGuidExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt16Element coerce(Int16Element element)
            => new NullableInt16ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt32Element coerce(Int32Element element)
            => new NullableInt32ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt64Element coerce(Int64Element element)
            => new NullableInt64ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableSingleElement coerce(SingleElement element)
            => new NullableSingleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableStringElement coerce(StringElement element)
            => new NullableStringExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableTimeSpanElement coerce(TimeSpanElement element)
            => new NullableTimeSpanExpressionMediator(element);

        /// <summary>
        /// Start constructing a list of <see cref="EntityFieldAssignment"/> containing update assignments for an <typeparamref name="TEntity"/> based on the differences between two <typeparamref name="TEntity"/> entities.  
        /// The completion of this fluent builder is useful for building an UPDATE query expression for updating an <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns><see cref="EntityFieldAssignmentsContinuation{TEntity}"/>, a fluent continuation for the construction of a list of <see cref="EntityFieldAssignment"/>s.</returns>
        public static EntityFieldAssignmentsContinuation<TEntity> BuildAssignmentsFor<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity
        {
            return new EntityComparisonAssignmentBuilder<TEntity>(entity);
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}
