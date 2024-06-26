using v2019DbEx.DataService;
using v2019DbEx.secDataService;
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
    [Trait("Clause", "WHERE")]
    public class WhereClauseAssemblerTests : TestBase
    {
        [Theory]
        [InlineData(true, $"[t0].[Id] > @P1")]
        [InlineData(false, $"[p].[Id] > @P1")]
        public void Does_a_single_where_predicate_result_in_valid_clause(bool useSyntheticAliases, string expectedOutput)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));

            ITerminationExpressionBuilder<v2019MsSqlDb> exp = 

                db.SelectOne(sec.Person.Id)
                    .From(sec.Person.As("p"))
                    .Where(sec.Person.As("p").Id > 0);

            SelectQueryExpression queryExpression = ((exp as IQueryExpressionProvider)!.Expression as SelectQueryExpression)!;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            AssemblyContext context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            string whereClause;

            //when
            builder.AppendElement(queryExpression.Where!, context);
            whereClause = builder.Appender.ToString()!;

            //then
            whereClause.Should().NotBeNullOrWhiteSpace();
            whereClause.Should().Be(expectedOutput);

            builder.Parameters.Parameters.Should().ContainSingle()
                .Which.Parameter.ParameterName.Should().Be("@P1");
        }
    }
}
