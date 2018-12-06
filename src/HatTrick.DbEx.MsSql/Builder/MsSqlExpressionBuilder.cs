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
            return new MsSqlExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.Get }) 
                as IFromExpressionBuilder<T, ITypeContinuationBuilder<T>, ITypeContinuationBuilder<T, ITypeContinuationBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(FieldExpression<T> field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>> SelectOne<T>(IDbExpressionSelectClausePart field)
            where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValue });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IFromExpressionBuilder<T, IValueContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, IValueContinuationExpressionBuilder<T>>>;
        }

        public static IFromExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> SelectOne(IDbExpressionSelectClausePart field1, IDbExpressionSelectClausePart field2, params IDbExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>, IValueContinuationExpressionBuilder<ExpandoObject, IValueContinuationExpressionBuilder<ExpandoObject>>> (new ExpressionSet { ExecutionContext = ExecutionContext.GetDynamic });
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
            return new MsSqlExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetList })
                as IListFromExpressionBuilder<T, ITypeListContinuationBuilder<T>, ITypeListContinuationBuilder<T, ITypeListContinuationBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(FieldExpression<T> field)
             where T : IComparable
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>> SelectAll<T>(IDbExpressionSelectClausePart field)
        {
            var builder = new MsSqlExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetValueList });
            builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>, IValueListContinuationExpressionBuilder<T, IValueListContinuationExpressionBuilder<T>>>;
        }

        public static IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>> SelectAll(IDbExpressionSelectClausePart field1, IDbExpressionSelectClausePart field2, params IDbExpressionSelectClausePart[] fields)
        {
            var builder = new MsSqlExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>(new ExpressionSet { ExecutionContext = ExecutionContext.GetDynamicList });
            builder.Expression.Select.Expressions.Add((field1.GetType(), field1));
            builder.Expression.Select.Expressions.Add((field2.GetType(), field2));
            foreach (var field in fields)
                builder.Expression.Select.Expressions.Add((field.GetType(), field));
            return builder as IListFromExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>, IValueListContinuationExpressionBuilder<ExpandoObject, IValueListContinuationExpressionBuilder<ExpandoObject>>>;
        }
        #endregion

        public static IUpdateFromExpressionBuilder Update(params AssignmentExpression[] fields)
        {
            var builder = new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = ExecutionContext.Update });
            foreach (var field in fields)
                builder.Expression &= field;
            return builder as IUpdateFromExpressionBuilder;
        }

        public static IDeleteFromExpressionBuilder Delete()
        {
            return new MsSqlExpressionBuilder(new ExpressionSet { ExecutionContext = ExecutionContext.Delete })
                as IDeleteFromExpressionBuilder;
        }

        public static IInsertExpressionBuilder<T> Insert<T>(T instance)
            where T : class, IDbEntity
        {
            return new MsSqlInsertBuilder<T>(new ExpressionSet { ExecutionContext = ExecutionContext.Insert, Instance = instance })
                as IInsertExpressionBuilder<T>;
        }

        #region coalesce
        public static CoalesceFunctionExpression Coalesce<T>(IDbExpressionSelectClausePart<T> field1, IDbExpressionSelectClausePart<T> field2, params IDbExpressionSelectClausePart<T>[] fields)
            where T : IComparable
        {
            var parts = new List<IDbExpressionSelectClausePart>(fields == null ? 2 : 2 + fields.Length);
            parts.Add(field1);
            parts.Add(field2);
            foreach (var f in fields)
                parts.Add(f);
            return new CoalesceFunctionExpression(parts);
        }
        #endregion

        #region isnull
        public static IsNullFunctionExpression IsNull<T>(IDbExpressionSelectClausePart<T> field, T value)
            where T : IComparable
        {
            return new IsNullFunctionExpression<T>(field, value);
        }

        public static IsNullFunctionExpression IsNull<T>(IDbExpressionSelectClausePart<T> field1, IDbExpressionSelectClausePart<T> field2)
            where T : IComparable
        {
            return new IsNullFunctionExpression<T>(field1, field2);
        }
        #endregion

        #region average
        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);

        public static AverageFunctionExpression Avg(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new AverageFunctionExpression(field, distinct);
        #endregion

        #region minimum
        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<string> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<Guid> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<DateTime> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);

        public static MinimumFunctionExpression Min(IDbExpressionSelectClausePart<DateTimeOffset> field, bool distinct = false)
            => new MinimumFunctionExpression(field, distinct);
        #endregion

        #region maximum
        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<string> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<Guid> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<DateTime> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);

        public static MaximumFunctionExpression Max(IDbExpressionSelectClausePart<DateTimeOffset> field, bool distinct = false)
            => new MaximumFunctionExpression(field, distinct);
        #endregion

        #region count
        public static CountFunctionExpression Count()
            => new CountFunctionExpression();

        public static CountFunctionExpression Count<T>(FieldExpression<T> field, bool distinct = false)
            => new CountFunctionExpression(field, distinct);
        #endregion

        #region sum
        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);

        public static SumFunctionExpression Sum(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new SumFunctionExpression(field, distinct);
        #endregion

        #region standard deviation
        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);

        public static StandardDeviationFunctionExpression StDev(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new StandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region standard deviation p
        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);

        public static PopulationStandardDeviationFunctionExpression StDevP(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new PopulationStandardDeviationFunctionExpression(field, distinct);
        #endregion

        #region variance
        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);

        public static VarianceFunctionExpression Var(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new VarianceFunctionExpression(field, distinct);
        #endregion

        #region variance p
        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<byte> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<short> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<int> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<long> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<double> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<decimal> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);

        public static PopulationVarianceFunctionExpression VarP(IDbExpressionSelectClausePart<float> field, bool distinct = false)
            => new PopulationVarianceFunctionExpression(field, distinct);
        #endregion
    }
}
