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
        public static IFromExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>> SelectOne<T>()
            where T : class, IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.Get }) 
                as IFromExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(FieldExpression<T> field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(IDbExpressionColumnExpression field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(IDbExpressionColumnExpression field1, IDbExpressionColumnExpression field2, params IDbExpressionColumnExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> (new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetDynamic });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        #region select all
        public static IListFromExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>> SelectAll<T>()
            where T : IDbEntity
        {
            return new MsSqlExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetList })
                as IListFromExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(FieldExpression<T> field)
             where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(IDbExpressionColumnExpression field)
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectAll(IDbExpressionColumnExpression field1, IDbExpressionColumnExpression field2, params IDbExpressionColumnExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.GetDynamicList });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.Update });
            foreach (var field in fields)
                builder.Expression &= field;
            return builder as IUpdateFromExpressionBuilder;
        }

        public static IDeleteFromExpressionBuilder Delete()
        {
            return new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.Delete })
                as IDeleteFromExpressionBuilder;
        }

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(new ExpressionSet { ExecutionContext = SqlStatementExecutionType.Insert, Instance = instance })
                as IInsertExpressionBuilder<T>;
        }

        #region coalesce
        public static CoalesceFunctionExpression Coalesce<T>(IDbExpressionColumnExpression<T> field1, IDbExpressionColumnExpression<T> field2, params IDbExpressionColumnExpression<T>[] fields)
            where T : IComparable
        {
            var parts = new List<IDbExpressionColumnExpression>(fields == null ? 2 : 2 + fields.Length);
            parts.Add(field1);
            parts.Add(field2);
            foreach (var f in fields)
                parts.Add(f);
            return new CoalesceFunctionExpression(parts);
        }
        #endregion

        #region isnull
        public static IsNullFunctionExpression IsNull<T>(IDbExpressionColumnExpression<T> field, T value)
            where T : IComparable
        {
            return new IsNullFunctionExpression<T>(field, value);
        }

        public static IsNullFunctionExpression IsNull<T>(IDbExpressionColumnExpression<T> field1, IDbExpressionColumnExpression<T> field2)
            where T : IComparable
        {
            return new IsNullFunctionExpression<T>(field1, field2);
        }
        #endregion

        #region average
        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);
        #endregion

        #region minimum
        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<string> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<Guid> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<DateTime> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionColumnExpression<DateTimeOffset> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);
        #endregion

        #region maximum
        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<string> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<Guid> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<DateTime> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionColumnExpression<DateTimeOffset> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);
        #endregion

        #region count
        public static CountFunctionExpression Count()
            => new CountFunctionExpression();

        public static CountFunctionExpression Count<T>(FieldExpression<T> field, bool distinct = false)
            => new CountFunctionExpression(field, distinct);
        #endregion

        #region sum
        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);
        #endregion

        #region standard deviation
        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region standard deviation p
        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region variance
        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);
        #endregion

        #region variance p
        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<byte> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<short> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<int> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<long> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<double> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<decimal> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionColumnExpression<float> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);
        #endregion
    }
}
