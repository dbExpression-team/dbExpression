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
            ConfigureForMsSqlVersion(version);

            var settings = DbExConfigurationSettings.Settings;

            ITerminationExpressionBuilder exp = 

                db.SelectOne(sec.Person.Id)
                    .From(sec.Person)
                    .Where(sec.Person.Id > 0);

            ExpressionSet expressionSet = (exp as IExpressionProvider).GetExpression();
            IAppender appender = settings.AppenderFactory.CreateAppender(settings.AssemblerConfiguration);
            ISqlParameterBuilder parameterBuilder = settings.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = settings.StatementBuilderFactory.CreateSqlStatementBuilder(settings.AssemblerConfiguration, expressionSet, appender, parameterBuilder);
            string whereClause;

            //when
            builder.AppendPart(expressionSet.Where.Expression.LeftPart, new AssemblerContext());
            whereClause = builder.Appender.ToString();

            //then
            whereClause.Should().NotBeNullOrWhiteSpace();
            whereClause.Should().Be($"[sec].[Person].[Id] > @P1");

            parameterBuilder.Parameters.Should().ContainSingle()
                .Which.ParameterName.Should().Be("@P1");
        }
    }
}
