using System;
using System.Text;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class Appender : IAppender
    {
        #region internals
        private const string t1 = "\t";
        private const string t2 = "\t\t";
        private const string t3 = "\t\t\t";
        private const string t4 = "\t\t\t\t";
        private const string t5 = "\t\t\t\t\t";
        private const string t6 = "\t\t\t\t\t\t";
        private const string t7 = "\t\t\t\t\t\t\t";
        private const string t8 = "\t\t\t\t\t\t\t\t";
        private const string t9 = "\t\t\t\t\t\t\t\t\t";
        private const string t10 = "\t\t\t\t\t\t\t\t\t\t";

        private static readonly string[] tabs = new string[10] { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };

        private readonly StringBuilder builder = new StringBuilder(512);
        #endregion

        #region interface
        public AppenderIndentation Indentation { get; set; }
        #endregion

        #region constructors
        public Appender()
        {
            Indentation = new AppenderIndentation(this);
        }
        #endregion

        #region methods
        public IAppender LineBreak()
        {
            builder.Append(Environment.NewLine);
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
            if (Indentation.CurrentLevel == 0)
                return this;

            if (Indentation.CurrentLevel < tabs.Length)
            {
                builder.Append(tabs[Indentation.CurrentLevel - 1]);
            }
            else
            {
                builder.Append(tabs[tabs.Length - 1]);
                for (var i = tabs.Length; i < Indentation.CurrentLevel; i++)
                    builder.Append("\t");
            }

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

        public override string ToString() => builder.ToString();
        #endregion
    }
}
