using System;

namespace HatTrick.DbEx.Sql.Assembler
{
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
