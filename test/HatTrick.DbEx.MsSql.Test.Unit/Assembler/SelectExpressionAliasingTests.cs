using DbEx.DataService;
using DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    [Trait("Statement", "SELECT")]
    public class SelectExpressionAliasingTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_select_expression_alias_correctly(int version, string alias = "Name")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            ITerminationExpressionBuilder<MsSqlDb> exp =

                db.SelectOne(dbo.Person.FirstName.As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = new AssemblyContext();
            context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_composite_select_expression_alias_correctly(int version, string alias = "Name")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);

            ITerminationExpressionBuilder<MsSqlDb> exp =

                db.SelectOne((dbo.Person.FirstName + " " + dbo.Person.LastName).As(alias))
                    .From(dbo.Person);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
            var context = new AssemblyContext();
            context.PushFieldAppendStyle(FieldExpressionAppendStyle.Declaration);

            //when
            builder.AppendElement(queryExpression.Select, context);
            var select = builder.Appender.ToString();

            //then
            select.Should().EndWith($"AS [{alias}]");
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_group_by_expression_suppress_alias_correctly(int version, string alias = "Name")
        {
            //given
            var (db, serviceProvider) = ConfigureForMsSqlVersion<MsSqlDb>(version);
            var table = dbo.Person.As("dboPerson");

            ITerminationExpressionBuilder<MsSqlDb> exp =

                db.SelectOne(db.fx.Count(table.FirstName).As(alias))
                    .From(table)
                    .GroupBy(table.FirstName);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder<MsSqlDb>>();
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
