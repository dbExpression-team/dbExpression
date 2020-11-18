using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionAliasingTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_select_expression_skip_aliasing_by_default(int version, string alias = "Name")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp =

                db.SelectOne(dbo.Person.FirstName.As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = (exp as IQueryExpressionProvider<SelectQueryExpression>).Expression;
            IAppender appender = database.AppenderFactory.CreateAppender();
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, queryExpression, appender, parameterBuilder);
            var context = new AssemblyContext(new SqlStatementAssemblerConfiguration());

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().NotEndWith($"AS [{alias}]{System.Environment.NewLine}");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_select_expression_alias_correctly(int version, string alias = "Name")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp =

                db.SelectOne(dbo.Person.FirstName.As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = (exp as IQueryExpressionProvider<SelectQueryExpression>).Expression;
            IAppender appender = database.AppenderFactory.CreateAppender();
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, queryExpression, appender, parameterBuilder);
            var context = new AssemblyContext(new SqlStatementAssemblerConfiguration());
            context.PushAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]{System.Environment.NewLine}");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_composite_select_expression_alias_correctly(int version, string alias = "Name")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp =

                db.SelectOne((dbo.Person.FirstName + " " + dbo.Person.LastName).As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = (exp as IQueryExpressionProvider<SelectQueryExpression>).Expression;
            IAppender appender = database.AppenderFactory.CreateAppender();
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, queryExpression, appender, parameterBuilder);
            var context = new AssemblyContext(new SqlStatementAssemblerConfiguration());
            context.PushAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]{System.Environment.NewLine}");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_group_by_expression_suppress_alias_correctly(int version, string alias = "Name")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var table = dbo.Person.As("dboPerson");

            ITerminationExpressionBuilder exp =

                db.SelectOne(db.fx.Count(table.FirstName).As(alias))
                    .From(table)
                    .GroupBy(table.FirstName);

            SelectQueryExpression queryExpression = (exp as IQueryExpressionProvider<SelectQueryExpression>).Expression;
            IAppender appender = database.AppenderFactory.CreateAppender();
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.AssemblyPartAppenderFactory, database.AssemblerConfiguration, queryExpression, appender, parameterBuilder);
            var context = new AssemblyContext(new SqlStatementAssemblerConfiguration());
            context.PushAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.GroupBy, context);
            var groupBy = builder.Appender.ToString();

            //then
            groupBy.Should().NotContain($"AS [{alias}]");
        }
    }
}
