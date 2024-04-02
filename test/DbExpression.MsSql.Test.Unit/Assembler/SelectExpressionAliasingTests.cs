using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DbExpression.MsSql.Test.Unit.Assembler
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionAliasingTests : TestBase
    {
        [Theory]
        [InlineData("Name")]
        public void Does_a_select_expression_alias_correctly(string alias)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            ITerminationExpressionBuilder<v2019MsSqlDb> exp =

                db.SelectOne(dbo.Person.FirstName.As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            var context = new AssemblyContext();
            context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]");
        }

        [Theory]
        [InlineData("Name")]
        public void Does_a_composite_select_expression_alias_correctly(string alias)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();

            ITerminationExpressionBuilder<v2019MsSqlDb> exp =

                db.SelectOne((dbo.Person.FirstName + " " + dbo.Person.LastName).As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            var context = new AssemblyContext();
            context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]");
        }

        [Theory]
        [InlineData("Name")]
        public void Does_a_group_by_expression_suppress_alias_correctly(string alias)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var table = dbo.Person.As("dboPerson");

            ITerminationExpressionBuilder<v2019MsSqlDb> exp =

                db.SelectOne(db.fx.Count(table.FirstName).As(alias))
                    .From(table)
                    .GroupBy(table.FirstName);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            var context = new AssemblyContext();
            context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.GroupBy!, context);
            var groupBy = builder.Appender.ToString();

            //then
            groupBy.Should().NotContain($"AS [{alias}]");
        }
    }
}
