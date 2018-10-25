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

        public AppenderIndentation(IAppender appender, Action increase, Action decrease)
        {
            this.appender = appender;
            this.increase = increase;
            this.decrease = decrease;
        }

        public static AppenderIndentation operator ++(AppenderIndentation a)
        {
            a.increase();
            return a;
        }

        public static AppenderIndentation operator --(AppenderIndentation a)
        {
            a.decrease();
            return a;
        }

        public IAppender Append(string value)
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
        private int _currentIndentationLevel;
        private string _currentIndentationValue = string.Empty;

        public AppenderIndentation IndentLevel { get; set; }

        public Appender(DbExpressionAssemblerConfiguration config)
        {
            minify = config.Minify;
            IndentLevel = new AppenderIndentation(this, () => IncreaseIndent(), () => DecreaseIndent());
        }

        public IAppender LineBreak()
        {
            if (minify)
                builder.Append(" ");
            else
                builder.Append(Environment.NewLine);

            return this;
        }

        public IAppender Write(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            builder.Append(value);

            return this;
        }

        public IAppender Indent()
        {
            if (string.IsNullOrWhiteSpace(_currentIndentationValue))
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
            _currentIndentationLevel++;
            if (!minify)
                _currentIndentationValue += "\t";

            return this;
        }

        private Appender DecreaseIndent()
        {
            if (_currentIndentationLevel > 0)
                _currentIndentationLevel--;

            if (!minify)
            {
                _currentIndentationValue = string.Empty;
                for (var i = 0; i < _currentIndentationLevel; i++)
                    _currentIndentationValue += "\t";
            }

            return this;
        }

        public override string ToString() => builder.ToString();
    }

    public interface IAppender
    {
        AppenderIndentation IndentLevel { get; set; }

        IAppender LineBreak();

        IAppender Write(string value);

        IAppender Indent();

        IAppender If(bool append, params Action<Appender>[] values);

        IAppender IfNotEmpty(string test, params Action<Appender>[] values);

        string ToString();
    }
}
