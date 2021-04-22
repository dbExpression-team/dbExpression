﻿using DbEx.DataService;
using DbEx.secDataService;
using FluentAssertions;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Code.Assembler
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
            var database = ConfigureForMsSqlVersion(version);

            ITerminationExpressionBuilder exp = 

                db.SelectOne(sec.Person.Id)
                    .From(sec.Person)
                    .Where(sec.Person.Id > 0);

            SelectQueryExpression expressionSet = (exp as IQueryExpressionProvider).Expression as SelectQueryExpression;
            IAppender appender = database.AppenderFactory.CreateAppender();
            ISqlParameterBuilder parameterBuilder = database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database.MetadataProvider, database.ExpressionElementAppenderFactory, database.AssemblerConfiguration, expressionSet, appender, parameterBuilder);
            string whereClause;

            //when
            builder.AppendElement(expressionSet.Where.LeftArg, new AssemblyContext(new SqlStatementAssemblerConfiguration()));
            whereClause = builder.Appender.ToString();

            //then
            whereClause.Should().NotBeNullOrWhiteSpace();
            whereClause.Should().Be($"[sec].[Person].[Id] > @P1");

            parameterBuilder.Parameters.Should().ContainSingle()
                .Which.Parameter.ParameterName.Should().Be("@P1");
        }
    }
}
