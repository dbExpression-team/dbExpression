namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionAssemblerConfiguration
    {
        public bool IncludeSchemaName { get; set; } = true;
        public bool PrependCommaOnSelectClauseParts { get; set; } = false;
        public bool Minify { get; set; } = true;
    }
}
