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
    public class AssemblyContextAppendStylesTests : TestBase
    {
        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_both_field_and_entity_append_styles_set_to_Declaration_append_correctly(int version, string expected = "[dbo].[Person].[Id]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.Id;
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_None_and_entity_append_style_of_Declaration_append_correctly(int version, string expected = "[dbo].[Person]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var entity = dbo.Person;
            QueryExpression queryExpression = db.SelectOne(dbo.Person.Id).From(entity).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(entity)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_Declaration_and_entity_append_style_of_None_append_correctly(int version, string expected = "[Id]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.Id;
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_both_field_and_entity_append_styles_set_to_None_append_correctly(int version, string expected = "[dbo].[Person]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var entity = dbo.Person;
            QueryExpression queryExpression = db.SelectOne(dbo.Person.Id).From(entity).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(entity)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_both_field_and_entity_append_styles_set_to_Alias_append_correctly(int version, string fieldAlias = "fieldAlias", string entityAlias = "entityAlias", string expected = "[entityAlias].[Id] AS [fieldAlias]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.As(entityAlias).Id.As(fieldAlias);
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_None_and_entity_append_style_of_Alias_append_correctly(int version, string fieldAlias = "fieldAlias", string entityAlias = "entityAlias", string expected = "[entityAlias]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var entity = dbo.Person.As(entityAlias);
            QueryExpression queryExpression = db.SelectOne(dbo.Person.Id.As(fieldAlias)).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(entity)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_Alias_and_entity_append_style_of_None_append_correctly(int version, string fieldAlias = "fieldAlias", string entityAlias = "entityAlias", string expected = "[Id] AS [fieldAlias]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.As(entityAlias).Id.As(fieldAlias);
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person.As(entityAlias)).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_Declaration_and_entity_append_style_of_Alias_append_correctly(int version, string fieldAlias = "fieldAlias", string entityAlias = "entityAlias", string expected = "[entityAlias]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var entity = dbo.Person.As(entityAlias);
            QueryExpression queryExpression = db.SelectOne(entity.Id.As(fieldAlias)).From(entity).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(entity)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [MsSqlVersions.AllVersions]
        public void Does_field_style_of_Alias_and_entity_append_style_of_Declaration_append_correctly(int version, string fieldAlias = "fieldAlias", string expected = "[dbo].[Person].[Id] AS [fieldAlias]")
        {
            //given
            var database = ConfigureForMsSqlVersion(version);
            var field = dbo.Person.Id.As(fieldAlias);
            QueryExpression queryExpression = db.SelectOne(field).From(dbo.Person).Expression;
            ISqlStatementBuilder builder = database.StatementBuilderFactory.CreateSqlStatementBuilder(database, queryExpression);
            IExpressionElementAppender appender = database.ExpressionElementAppenderFactory.CreateElementAppender(field)!;

            var context = database.AssemblerConfiguration.ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }
    }
}
