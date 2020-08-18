namespace HatTrick.DbEx.Sql.Assembler
{
    public interface IAssemblyPartAppenderFactory
    {
        IAssemblyPartAppender CreatePartAppender(object part);
    }
}
