using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public static class dbex
    {
        public static AliasExpression Alias(string tableName, string fieldName)
            => new AliasExpression(tableName, fieldName);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableBooleanElement Coerce(BooleanElement element)
            => new NullableBooleanExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteElement Coerce(ByteElement element)
            => new NullableByteExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableByteArrayElement Coerce(ByteArrayElement element)
            => new NullableByteArrayExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeElement Coerce(DateTimeElement element)
            => new NullableDateTimeExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDateTimeOffsetElement Coerce(DateTimeOffsetElement element)
            => new NullableDateTimeOffsetExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDecimalElement Coerce(DecimalElement element)
            => new NullableDecimalExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableDoubleElement Coerce(DoubleElement element)
            => new NullableDoubleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableEnumElement<TEnum> Coerce<TEnum>(EnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumExpressionMediator<TEnum>(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableGuidElement Coerce(GuidElement element)
            => new NullableGuidExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt16Element Coerce(Int16Element element)
            => new NullableInt16ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt32Element Coerce(Int32Element element)
            => new NullableInt32ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableInt64Element Coerce(Int64Element element)
            => new NullableInt64ExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableSingleElement Coerce(SingleElement element)
            => new NullableSingleExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableStringElement Coerce(StringElement element)
            => new NullableStringExpressionMediator(element);

        /// <summary>
        /// Change the encapsulated type of an element to a nullable.
        /// </summary>
        public static NullableTimeSpanElement Coerce(TimeSpanElement element)
            => new NullableTimeSpanExpressionMediator(element);

        /// <summary>
        /// Start constructing a list of <see cref="EntityFieldAssignment"/> containing update assignments for an <typeparamref name="TEntity"/> based on the differences between two <typeparamref name="TEntity"/> entities.  
        /// The completion of this fluent builder is useful for building an UPDATE query expression for updating an <typeparamref name="TEntity"/> entity.
        /// </summary>
        /// <returns><see cref="EntityFieldAssignmentsContinuation{TEntity}"/>, a fluent continuation for the construction of a list of <see cref="EntityFieldAssignment"/>s.</returns>
        public static EntityFieldAssignmentsContinuation<TEntity> BuildAssignmentsFor<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity
            => new EntityComparisonAssignmentBuilder<TEntity>(entity);
    }
#pragma warning restore IDE1006 // Naming Styles
}
