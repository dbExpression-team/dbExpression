using DataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Assembler
{
    [Trait("Statement", "SELECT")]
    [Trait("Clause", "WHERE")]
    public class WhereClauseAssemblerTests : TestBase
    {
        [Theory]
        [InlineData(2014)]
        public void Does_a_single_where_predicate_result_in_valid_clause(int version)
        {
            //given
            var database = ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp = 

                db.SelectOne(sec.Person.Id)
                    .From(sec.Person)
                    .Where(sec.Person.Id > 0);

            ExpressionSet expressionSet = (exp as IDbExpressionSetProvider).Expression;
            IAppender appender = database.AppenderFactory.CreateAppender(database.AssemblerConfiguration);
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.AssemblerConfiguration, expressionSet, appender, parameterBuilder);
            string whereClause;

            //when
            builder.AppendPart(expressionSet.Where.Expression.LeftPart, new AssemblyContext());
            whereClause = builder.Appender.ToString();

            //then
            whereClause.Should().NotBeNullOrWhiteSpace();
            whereClause.Should().Be($"[sec].[Person].[Id] > @P1");

            parameterBuilder.Parameters.Should().ContainSingle()
                .Which.Parameter.ParameterName.Should().Be("@P1");
        }
    }
}
