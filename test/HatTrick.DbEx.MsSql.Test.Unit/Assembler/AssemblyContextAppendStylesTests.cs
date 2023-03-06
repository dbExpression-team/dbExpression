using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class AssemblyContextAppendStylesTests : TestBase
    {
        [Theory]
        [InlineData(true, "[dbo].[Person] AS [t0].[Id]")]
        [InlineData(false, "[dbo].[Person] AS [Person].[Id]")]
        public void Does_both_field_and_entity_append_styles_set_to_Declaration_append_as_expected(bool useSyntheticAliases, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var field = dbo.Person.Id;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "[dbo].[Person] AS [t0]")]
        [InlineData(false, "[dbo].[Person] AS [p]")]
        public void Does_field_style_of_None_and_entity_append_style_of_Declaration_append_correctly_when_alias_is_less_than_4_characters(bool useSyntheticAliases, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person.As("p");
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "[dbo].[Person] AS [t0]")]
        [InlineData(false, "[dbo].[Person] AS [Person]")]
        public void Does_field_style_of_None_and_entity_append_style_of_Declaration_append_correctly_when_alias_is_more_than_4_characters(bool useSyntheticAliases, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData("[Id]")]
        public void Does_field_style_of_Declaration_and_entity_append_style_of_None_append_correctly(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var field = dbo.Person.Id;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData("")]
        public void Does_both_field_and_entity_append_styles_set_to_None_append_correctly(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var entity = dbo.Person;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "fieldAlias", "ea", "[t0].[Id] AS [fieldAlias]")]
        [InlineData(false, "fieldAlias", "ea", "[ea].[Id] AS [fieldAlias]")]
        public void Does_both_field_and_entity_append_styles_set_to_Alias_append_correctly_when_alias_is_less_than_4_characters(bool useSyntheticAliases, string fieldAlias, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var field = dbo.Person.As(entityAlias).Id.As(fieldAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "fieldAlias", "entityAlias", "[t0].[Id] AS [fieldAlias]")]
        [InlineData(false, "fieldAlias", "entityAlias", "[entityAlias].[Id] AS [fieldAlias]")]
        public void Does_both_field_and_entity_append_styles_set_to_Alias_append_correctly_when_alias_is_more_than_4_characters(bool useSyntheticAliases, string fieldAlias, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var field = dbo.Person.As(entityAlias).Id.As(fieldAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "ea", "[t0]")]
        [InlineData(false, "ea", "[ea]")]
        public void Does_field_style_of_None_and_entity_append_style_of_Alias_append_correctly_when_alias_is_less_than_4_characters(bool useSyntheticAliases, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person.As(entityAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "entityAlias", "[t0]")]
        [InlineData(false, "entityAlias", "[entityAlias]")]
        public void Does_field_style_of_None_and_entity_append_style_of_Alias_append_correctly_when_alias_is_more_than_4_characters(bool useSyntheticAliases, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person.As(entityAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.None);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "fieldAlias", "entityAlias", "[Id] AS [fieldAlias]")]
        [InlineData(false, "fieldAlias", "entityAlias", "[Id] AS [fieldAlias]")]
        public void Does_field_style_of_Alias_and_entity_append_style_of_None_append_correctly(bool useSyntheticAliases, string fieldAlias, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var field = dbo.Person.As(entityAlias).Id.As(fieldAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.None, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "ea", "[t0]")]
        [InlineData(false, "ea", "[ea]")]
        public void Does_field_style_of_Declaration_and_entity_append_style_of_Alias_append_correctly_when_alias_is_less_than_4_characters(bool useSyntheticAliases, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person.As(entityAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "entityAlias", "[t0]")]
        [InlineData(false, "entityAlias", "[entityAlias]")]
        public void Does_field_style_of_Declaration_and_entity_append_style_of_Alias_append_correctly_when_alias_is_more_than_4_characters(bool useSyntheticAliases, string entityAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var entity = dbo.Person.As(entityAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData(true, "fieldAlias", "[dbo].[Person] AS [t0].[Id] AS [fieldAlias]")]
        [InlineData(false, "fieldAlias", "[dbo].[Person] AS [Person].[Id] AS [fieldAlias]")]
        public void Does_field_style_of_Alias_and_entity_append_style_of_Declaration_append_correctly(bool useSyntheticAliases, string fieldAlias, string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>(c => c.SqlStatements.Assembly.ConfigureAssemblyOptions(c => c.UseSyntheticAliases = useSyntheticAliases));
            var field = dbo.Person.Id.As(fieldAlias);
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext();
            context.PushAppendStyles(EntityExpressionAppendStyle.Alias, FieldExpressionAppendStyle.Declaration);
            context.PushAppendStyles(EntityExpressionAppendStyle.Declaration, FieldExpressionAppendStyle.Alias);

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }
    }
}
