using v2019DbEx.DataService;
using v2019DbEx.dboDataService;
using FluentAssertions;
using HatTrick.DbEx.MsSql.Configuration;
using HatTrick.DbEx.Sql.Assembler;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HatTrick.DbEx.MsSql.Test.Unit.Assembler
{
    public class IdentifierDelimiterAssemblerTests : TestBase
    {
        [Theory]
        [InlineData("{dbo}.{Person}.{Id}")]
        public void Does_a_non_default_delimiter_assemble_a_field_expression_correctly(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var field = dbo.Person.Id;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(field.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            context.PushAppendStyles(EntityExpressionAppendStyle.Name, FieldExpressionAppendStyle.Declaration);
            context.IdentifierDelimiter.Begin = '{';
            context.IdentifierDelimiter.End = '}';

            appender.AppendElement(field, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }

        [Theory]
        [InlineData("{dbo}.{Person}")]
        public void Does_a_non_default_delimiter_assemble_an_entity_expression_correctly(string expected)
        {
            //given
            var (db, serviceProvider) = Configure<v2019MsSqlDb>();
            var entity = dbo.Person;
            ISqlStatementBuilder builder = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<ISqlStatementBuilder>();
            IExpressionElementAppender appender = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<IExpressionElementAppenderFactory>().CreateElementAppender(entity.GetType())!;

            var context = serviceProvider.GetServiceProviderFor<v2019MsSqlDb>().GetRequiredService<AssemblyContext>();
            context.PushAppendStyles(EntityExpressionAppendStyle.Name, FieldExpressionAppendStyle.Declaration);
            context.IdentifierDelimiter.Begin = '{';
            context.IdentifierDelimiter.End = '}';

            appender.AppendElement(entity, builder, context);

            //when
            var assembled = builder.Appender.ToString()!;

            //then
            assembled.Should().Be(expected);
        }
    }    
}
