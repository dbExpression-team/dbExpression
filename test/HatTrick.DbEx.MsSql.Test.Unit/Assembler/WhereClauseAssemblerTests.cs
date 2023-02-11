using DbEx.DataService;
using DbEx.secDataService;
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
    [Trait("Clause", "WHERE")]
    public class WhereClauseAssemblerTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_a_single_where_predicate_result_in_valid_clause(int version)
        {
            //given
            var (db, serviceProvider) = Configure<MsSqlDb>().ForMsSqlVersion(version);

            ITerminationExpressionBuilder<MsSqlDb> exp = 

                db.SelectOne(sec.Person.Id)
                    .From(sec.Person)
                    .Where(sec.Person.Id > 0);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            AssemblyContext context = serviceProvider.GetServiceProviderFor<MsSqlDb>().GetRequiredService<AssemblyContext>();
            string whereClause;

            //when
            builder.AppendElement(queryExpression.Where!, context);
            whereClause = builder.Appender.ToString()!;

            //then
            whereClause.Should().NotBeNullOrWhiteSpace();
            whereClause.Should().Be($"[Person].[Id] > @P1");

            builder.Parameters.Parameters.Should().ContainSingle()
                .Which.Parameter.ParameterName.Should().Be("@P1");
        }
    }
}
