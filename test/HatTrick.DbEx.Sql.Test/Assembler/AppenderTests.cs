using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;
using Xunit;

namespace HatTrick.DbEx.Sql.Test.Assembler
{
    public class AppenderTests
    {
        [Fact]
        public void Does_appender_write_value()
        {
            //given
            var appender = new Appender();

            //when
            appender.Write("hello");

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_increasing_indent_level_increment_indentation_level()
        {
            //given
            var appender = new Appender();

            //when
            appender.Indentation++;

            //then
            Assert.Equal(1, appender.Indentation.CurrentLevel);
        }

        [Fact]
        public void Does_decreasing_indent_level_decrement_indentation_level()
        {
            //given
            var appender = new Appender();
            appender.Indentation.CurrentLevel = 1;

            //when
            appender.Indentation--;

            //then
            Assert.Equal(0, appender.Indentation.CurrentLevel);
        }

        [Fact]
        public void Does_indentation_level_of_1_result_in_tab()
        {
            //given
            var appender = new Appender();
            appender.Indentation++;

            //when
            appender.Indent();

            //then
            Assert.Equal("\t", appender.ToString());
        }

        [Fact]
        public void Does_line_break_result_in_new_line()
        {
            //given
            var appender = new Appender();

            //when
            appender.LineBreak();

            //then
            Assert.Equal(Environment.NewLine, appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_append_value()
        {
            //given
            var appender = new Appender();

            //when
            appender.If(true, a => a.Write("hello"));

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_append_value_when_value_is_not_empty()
        {
            //given
            var appender = new Appender();

            //when
            appender.IfNotEmpty("test", a => a.Write("hello"));

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_skip_appending_value_when_value_is_empty()
        {
            //given
            var appender = new Appender();

            //when
            appender.IfNotEmpty(null, a => a.Write("hello"));

            //then
            Assert.Empty(appender.ToString());
        }
    }
}
