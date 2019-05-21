namespace HatTrick.DbEx.Sql.Assembler
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(bool minify) => new Appender(minify);
    }
}
