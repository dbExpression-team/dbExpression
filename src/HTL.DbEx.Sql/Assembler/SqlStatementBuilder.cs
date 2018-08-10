using HTL.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace HTL.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder : ISqlStatementBuilder
    {
        public DBExpressionSet DBExpression { get; }
        public ISqlStatementAssembler Assembler { get; }
        public Func<Type, ISqlPartAssembler> PartAssemblerResolver { get; }
        public Func<Type, IValueTypeFormatter> ValueTypeFormatterResolver { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            DBExpressionSet dbExpression,
            ISqlStatementAssembler assembler,
            Func<Type, ISqlPartAssembler> partAssemblerResolver,
            Func<Type, IValueTypeFormatter> valueTypeFormatterResolver,
            ISqlParameterBuilder parameterBuilder)
        {
            DBExpression = dbExpression;
            Assembler = assembler;
            PartAssemblerResolver = partAssemblerResolver;
            ValueTypeFormatterResolver = valueTypeFormatterResolver;
            Parameters = parameterBuilder;
        }

        protected virtual ISqlPartAssembler<T> ResolvePartAssembler<T>()
            where T : IDBExpression
            => PartAssemblerResolver(typeof(T)) as ISqlPartAssembler<T>;

        protected virtual ISqlPartAssembler ResolvePartAssembler(Type t)
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

        public (string,IList<DbParameter>) CreateSqlStatement()
            => Assembler.Assemble(DBExpression, this);

        public string AssemblePart((Type, object) part)
        {
            var assembler = ResolvePartAssembler(part.Item1);
            return assembler.Assemble(part.Item2, this);
        }

        public string AssemblePart<T>(object part)
            where T : ISqlAssemblyPart
        {
            var assembler = ResolvePartAssembler(typeof(T));
            return assembler.Assemble(part, this);
        }
    }
}
