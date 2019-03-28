using HatTrick.DbEx.Sql.Configuration;
using System;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AppenderIndentation
    {
        private IAppender appender;
        private Action increase;
        private Action decrease;

        public byte CurrentLevel { get; set; }

        public AppenderIndentation(IAppender appender, Action increase, Action decrease)
        {
            this.appender = appender;
            this.increase = increase;
            this.decrease = decrease;
        }

        public static AppenderIndentation operator ++(AppenderIndentation a)
        {
            a.CurrentLevel++;
            a.increase();
            return a;
        }

        public static AppenderIndentation operator --(AppenderIndentation a)
        {
            if (a.CurrentLevel > 0)
            {
                a.CurrentLevel--;
                a.decrease();
            }
            return a;
        }

        public IAppender Write(string value)
            => appender.Write(value);

        public IAppender If(bool append, params Action<Appender>[] values)
            => appender.If(append, values);

        public IAppender IfNotEmpty(string test, params Action<Appender>[] values)
            => appender.IfNotEmpty(test, values);

        public IAppender Indent()
            => appender.Indent();

        public IAppender LineBreak()
            => appender.LineBreak();
    }

    public class Appender : IAppender
    {
        private readonly StringBuilder builder = new StringBuilder();
        private readonly bool minify;
        private string _currentIndentationValue = string.Empty;

        public AppenderIndentation Indentation { get; set; }

        public Appender(DbExpressionAssemblerConfiguration config)
        {
            minify = config.Minify;
            Indentation = new AppenderIndentation(this, () => IncreaseIndent(), () => DecreaseIndent());
        }

        public IAppender LineBreak()
        {
            builder.Append(minify ? " " : Environment.NewLine);
            return this;
        }

        public IAppender Write(string value)
        {
            if (value == null)
                return this;

            builder.Append(value);

            return this;
        }

        public IAppender Write(char value)
        {
            if (value == default)
                return this;

            builder.Append(value);

            return this;
        }

        public IAppender Indent()
        {
            if (!string.IsNullOrEmpty(_currentIndentationValue))
                builder.Append(_currentIndentationValue);
            return this;
        }

        public IAppender If(bool append, params Action<Appender>[] values)
        {
            if (!append)
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        public IAppender IfNotEmpty(string test, params Action<Appender>[] values)
        {
            if (string.IsNullOrWhiteSpace(test))
                return this;

            foreach (var v in values)
                v.Invoke(this);

            return this;
        }

        private Appender IncreaseIndent()
        {
            if (!minify)
                _currentIndentationValue += "\t";

            return this;
        }

        private Appender DecreaseIndent()
        {
            if (!minify)
            {
                _currentIndentationValue = string.Empty;
                for (var i = 0; i < Indentation.CurrentLevel; i++)
                    _currentIndentationValue += "\t";
            }

            return this;
        }

        public override string ToString() => builder.ToString();
    }

    public interface IAppender
    {
        AppenderIndentation Indentation { get; set; }

        IAppender LineBreak();

        IAppender Write(string value);

        IAppender Write(char value);
        IAppender Indent();

        IAppender If(bool append, params Action<Appender>[] values);

        IAppender IfNotEmpty(string test, params Action<Appender>[] values);

        string ToString();
    }
}
