using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class IdentifierDelimiterAssemblerTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_non_default_delimiter_assemble_a_fieldy_expression_correctly(int version, string expected = "{dbo}.{Person}.{Id}")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.Id;
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Declaration);
            context.IdentifierDelimiter.Begin = '{';
            context.IdentifierDelimiter.End = '}';

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_non_default_delimiter_assemble_an_entity_expression_correctly(int version, string expected = "{dbo}.{Person}")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var entity = dbo.Person;
            QueryExpression queryExpression = db.SelectOne(dbo.Person.Id).From(entity).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(entity)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Declaration);
            context.IdentifierDelimiter.Begin = '{';
            context.IdentifierDelimiter.End = '}';

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }
    }    
}
