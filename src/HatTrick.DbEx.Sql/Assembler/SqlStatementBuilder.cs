using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder : ISqlStatementBuilder
    {
        public ExpressionSet DBExpression { get; }
        public ISqlStatementAssembler Assembler { get; }
        public Func<Type, IDbExpressionAssemblyPartAssembler> PartAssemblerResolver { get; }
        public Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            ExpressionSet dbExpression,
            ISqlStatementAssembler assembler,
            Func<Type, IDbExpressionAssemblyPartAssembler> partAssemblerResolver,
            Func<Type, IValueTypeFormatter> valueTypeFormatterResolver,
            ISqlParameterBuilder parameterBuilder)
        {
            DBExpression = dbExpression;
            Assembler = assembler;
            PartAssemblerResolver = partAssemblerResolver;
            ValueTypeFormatterResolver = valueTypeFormatterResolver;
            Parameters = parameterBuilder;
        }

        protected virtual IDbExpressionAssemblyPartAssembler<T> ResolvePartAssembler<T>()
            where T : IDbExpression
            => PartAssemblerResolver(typeof(T)) as IDbExpressionAssemblyPartAssembler<T>;

        protected virtual IDbExpressionAssemblyPartAssembler ResolvePartAssembler(Type t)
            => PartAssemblerResolver(t);

        protected virtual IValueTypeFormatter<T> ResolveValueFormatter<T>()
            where T : IComparable
            => ValueTypeFormatterResolver(typeof(T)) as IValueTypeFormatter<T>;

        protected virtual IValueTypeFormatter ResolveValueFormatter(Type t)
            => ValueTypeFormatterResolver(t);

        public string FormatValueType((Type, object) value)
        {
            var formatter = ResolveValueFormatter(value.Item1);
            return formatter.Format(value.Item2);
        }

        public string FormatValueType<T>(object value)
            where T : IComparable
        {
            var formatter = ResolveValueFormatter<T>();
            return formatter.Format(value);
        }

        public SqlStatement CreateSqlStatement()
            => Assembler.Assemble(DBExpression, this);

        public string AssemblePart((Type, object) part) => AssemblePart(part, (AssemblerOverrides)null);

        public string AssemblePart((Type, object) part, AssemblerOverrides overrides)
        {
            var assembler = ResolvePartAssembler(part.Item1);
            return assembler.Assemble(part.Item2, this, overrides);
        }

        public string AssemblePart<T>(object part)
            where T : IDbExpressionAssemblyPart => AssemblePart<T>(part, (AssemblerOverrides)null);

        public string AssemblePart<T>(object part, AssemblerOverrides overrides)
            where T : IDbExpressionAssemblyPart
        {
            var assembler = ResolvePartAssembler(typeof(T));
            return assembler.Assemble(part, this, overrides);
        }
    }
}
