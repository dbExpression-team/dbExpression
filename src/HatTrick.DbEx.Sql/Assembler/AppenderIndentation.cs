using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AppenderIndentation
    {
        #region internals
        private readonly IAppender appender;
        #endregion

        #region interface
        public byte CurrentLevel { get; set; }
        #endregion

        #region constructors
        public AppenderIndentation(IAppender appender)
        {
            this.appender = appender;
        }
        #endregion

        #region operators
        public static AppenderIndentation operator ++(AppenderIndentation a)
        {
            a.CurrentLevel++;
            return a;
        }

        public static AppenderIndentation operator --(AppenderIndentation a)
        {
            if (a.CurrentLevel > 0)
            {
                a.CurrentLevel--;
            }
            return a;
        }
        #endregion

        #region methods
        public IAppender Write(string value)
            => appender.Write(value);

        public IAppender Write(char value)
            => appender.Write(value);

        public IAppender If(bool append, params Action<Appender>[] values)
            => appender.If(append, values);

        public IAppender IfNotEmpty(string test, params Action<Appender>[] values)
            => appender.IfNotEmpty(test, values);

        public IAppender Indent()
            => appender.Indent();

        public IAppender LineBreak()
            => appender.LineBreak();
        #endregion
    }
}
