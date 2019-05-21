using HatTrick.DbEx.Sql.Assembler;
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
            var appender = new Appender(true);

            //when
            appender.Write("hello");

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_increasing_indent_level_increment_indentation_level()
        {
            //given
            var appender = new Appender(true);

            //when
            appender.Indentation++;

            //then
            Assert.Equal(1, appender.Indentation.CurrentLevel);
        }

        [Fact]
        public void Does_decreasing_indent_level_decrement_indentation_level()
        {
            //given
            var appender = new Appender(true);
            appender.Indentation.CurrentLevel = 1;

            //when
            appender.Indentation--;

            //then
            Assert.Equal(0, appender.Indentation.CurrentLevel);
        }

        [Fact]
        public void Does_indentation_level_of_1_result_in_single_tab_when_minify_is_false()
        {
            //given
            var appender = new Appender(false);
            appender.Indentation++;

            //when
            appender.Indent();

            //then
            Assert.Equal("\t", appender.ToString());
        }

        [Fact]
        public void Does_indentation_level_of_1_result_in_empty_string_when_minify_is_true()
        {
            //given
            var appender = new Appender(true);
            appender.Indentation++;

            //when
            appender.Indent();

            //then
            Assert.Empty(appender.ToString());
        }

        [Fact]
        public void Does_line_break_result_in_empty_string_when_minify_is_true()
        {
            //given
            var appender = new Appender(true);

            //when
            appender.LineBreak();

            //then
            Assert.Equal(" ", appender.ToString());
        }

        [Fact]
        public void Does_line_break_result_in_new_line_when_minify_is_false()
        {
            //given
            var appender = new Appender(false);

            //when
            appender.LineBreak();

            //then
            Assert.Equal(Environment.NewLine, appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_append_value_when_true()
        {
            //given
            var appender = new Appender(true);

            //when
            appender.If(true, a => a.Write("hello"));

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_skip_appending_value_when_false()
        {
            //given
            var appender = new Appender(false);

            //when
            appender.If(false, a => a.Write("hello"));

            //then
            Assert.Empty(appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_append_value_when_value_is_not_empty()
        {
            //given
            var appender = new Appender(false);

            //when
            appender.IfNotEmpty("test", a => a.Write("hello"));

            //then
            Assert.Equal("hello", appender.ToString());
        }

        [Fact]
        public void Does_where_predicate_skip_appending_value_when_value_is_empty()
        {
            //given
            var appender = new Appender(false);

            //when
            appender.IfNotEmpty(null, a => a.Write("hello"));

            //then
            Assert.Empty(appender.ToString());
        }
    }
}
