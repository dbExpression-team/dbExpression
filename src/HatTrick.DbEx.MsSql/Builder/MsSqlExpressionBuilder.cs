using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlExpressionBuilder : SqlExpressionBuilder
    {
        #region constructors
        public MsSqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
        #endregion

        #region select one
        public static IFromExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>> SelectOne<T>()
            where T : class, IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneType }) 
                as IFromExpressionBuilder<T, ITypeContinuationExpressionBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>> SelectOne<TEntity, TValue>(ISupportedForSelectEntityExpression<TEntity, TValue> field)
            where TEntity : IDbEntity
            where TValue : IComparable
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>, IValueContinuationExpressionBuilder<TValue, IValueContinuationExpressionBuilder<TValue>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(ISupportedForExpression<SelectExpression> field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(ISupportedForExpression<SelectExpression> field1, ISupportedForExpression<SelectExpression> field2, params ISupportedForExpression<SelectExpression>[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> (new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectOneDynamic });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        #region select all
        public static IListFromExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>> SelectAll<T>()
            where T : IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectAllType })
                as IListFromExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>, ITypeListContinuationExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>> SelectAll<TValue>(ISupportedForSelectFieldExpression<TValue> field)
            where TValue : IComparable
        {
            var builder = new MsSqlExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectAllValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>, IValueListContinuationExpressionBuilder<TValue, IValueListContinuationExpressionBuilder<TValue>>>;
        }

        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectAll(ISupportedForExpression<SelectExpression> field1, ISupportedForExpression<SelectExpression> field2, params ISupportedForExpression<SelectExpression>[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.SelectAllDynamic });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Update });
            foreach (var field in fields)
                builder.Expression.Assign.Expressions.Add(field);
            return builder as IUpdateFromExpressionBuilder;
        }

        public static IDeleteFromExpressionBuilder Delete()
        {
            return new MsSqlExpressionBuilder(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Delete })
                as IDeleteFromExpressionBuilder;
        }

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(new ExpressionSet { StatementExecutionType = SqlStatementExecutionType.Insert, Instance = instance })
                as IInsertExpressionBuilder<T>;
        }

        #region concat
        public static ConcatFunctionExpression Concat(ISupportedForFunctionExpression<ConcatFunctionExpression, string> field1, ISupportedForFunctionExpression<ConcatFunctionExpression, string> field2, params ISupportedForFunctionExpression<ConcatFunctionExpression, string>[] fields)
        {
            var parts = new List<ISupportedForFunctionExpression<ConcatFunctionExpression, string>>(fields == null ? 2 : 2 + fields.Length);
            parts.Add(field1);
            parts.Add(field2);
            foreach (var f in fields)
                parts.Add(f);
            return new ConcatFunctionExpression(parts);
        }
        #endregion

        #region coalesce
        public static CoalesceFunctionExpression<bool> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, bool> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, bool>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<byte> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, byte> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, byte>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<DateTime> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTime>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<DateTimeOffset> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, DateTimeOffset>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<decimal> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, decimal>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<double> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, double> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, double> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, double>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<TEnum> Coalesce<TEnum>(ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, TEnum>[] fields)
            where TEnum : struct, Enum, IComparable
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<float> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, float> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, float>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<Guid> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, Guid>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<short> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, short> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, short>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<int> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, int> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, int>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        public static CoalesceFunctionExpression<long> Coalesce(ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, long> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, long>[] fields)
            => BuildCoalesceFunctionExpression(field1, field2, fields);

        private static CoalesceFunctionExpression<T> BuildCoalesceFunctionExpression<T>(ISupportedForFunctionExpression<CoalesceFunctionExpression, T> field1, ISupportedForFunctionExpression<CoalesceFunctionExpression, T> field2, params ISupportedForFunctionExpression<CoalesceFunctionExpression, T>[] fields)
            where T : IComparable
        {
            var parts = new List<ISupportedForFunctionExpression<CoalesceFunctionExpression, T>>(fields == null ? 2 : 2 + fields.Length);
            parts.Add(field1);
            parts.Add(field2);
            foreach (var f in fields)
                parts.Add(f);
            return new CoalesceFunctionExpression<T>(parts);
        }
        #endregion

        #region cast
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression> function)
            => new CastFunctionExpressionBuilder(function);
        #endregion

        #region isnull
        public static IsNullFunctionExpression<T> IsNull<T>(ISupportedForFunctionExpression<IsNullFunctionExpression, T> field, T value)
            where T : IComparable
            => new IsNullFunctionExpression<T>(field, value);

        public static IsNullFunctionExpression<bool> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, bool> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, bool> field2)
            => new IsNullFunctionExpression<bool>(field1, field2);

        public static IsNullFunctionExpression<byte> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, byte> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, byte> field2)
            => new IsNullFunctionExpression<byte>(field1, field2);

        public static IsNullFunctionExpression<DateTime> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, DateTime> field2)
            => new IsNullFunctionExpression<DateTime>(field1, field2);

        public static IsNullFunctionExpression<decimal> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, decimal> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, decimal> field2)
            => new IsNullFunctionExpression<decimal>(field1, field2);

        public static IsNullFunctionExpression<double> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, double> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, double> field2)
            => new IsNullFunctionExpression<double>(field1, field2);

        public static IsNullFunctionExpression<Enum> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Enum> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, Enum> field2)
            => new IsNullFunctionExpression<Enum>(field1, field2);

        public static IsNullFunctionExpression<float> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, float> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, float> field2)
            => new IsNullFunctionExpression<float>(field1, field2);

        public static IsNullFunctionExpression<Guid> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, Guid> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, Guid> field2)
            => new IsNullFunctionExpression<Guid>(field1, field2);

        public static IsNullFunctionExpression<short> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, short> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, short> field2)
            => new IsNullFunctionExpression<short>(field1, field2);

        public static IsNullFunctionExpression<int> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, int> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, int> field2)
            => new IsNullFunctionExpression<int>(field1, field2);

        public static IsNullFunctionExpression<long> IsNull(ISupportedForFunctionExpression<IsNullFunctionExpression, long> field1, ISupportedForFunctionExpression<IsNullFunctionExpression, long> field2)
            => new IsNullFunctionExpression<long>(field1, field2);
        #endregion

        #region literal
        public static LiteralExpression<TValue> Literal<TValue>(TValue value)
            where TValue : IComparable
            => new LiteralExpression<TValue>(value);
        #endregion

        #region average
        public static AverageFunctionExpression Avg(ISupportedForFunctionExpression<AverageFunctionExpression> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);
        #endregion

        #region minimum
        public static MinimumFunctionExpression Min(ISupportedForFunctionExpression<MinimumFunctionExpression> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);
        #endregion

        #region maximum
        public static MaximumFunctionExpression Max(ISupportedForFunctionExpression<MaximumFunctionExpression> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);
        #endregion

        #region count
        public static CountFunctionExpression Count()
            => new CountFunctionExpression();

        public static CountFunctionExpression Count(ISupportedForFunctionExpression<CountFunctionExpression> field, bool distinct = false)
            => new CountFunctionExpression(field, distinct);
        #endregion

        #region sum
        public static SumFunctionExpression Sum(ISupportedForFunctionExpression<SumFunctionExpression> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);
        #endregion

        #region standard deviation
        public static StandardDeviationFunctionExpression StDev(ISupportedForFunctionExpression<StandardDeviationFunctionExpression> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region standard deviation p
        public static PopulationStandardDeviationFunctionExpression StDevP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region variance
        public static VarianceFunctionExpression Var(ISupportedForFunctionExpression<VarianceFunctionExpression> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);
        #endregion

        #region variance p
        public static PopulationVarianceFunctionExpression VarP(ISupportedForFunctionExpression<PopulationStandardDeviationFunctionExpression> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);
        #endregion
    }
}
