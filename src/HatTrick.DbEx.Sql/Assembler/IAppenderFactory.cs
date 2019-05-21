namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(bool minify);
    }
}
