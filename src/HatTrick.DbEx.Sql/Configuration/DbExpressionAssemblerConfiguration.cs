namespace HatTrick.DbEx.Sql.Configuration
{
    public class DbExpressionAssemblerConfiguration
    {
        public bool IncludeSchemaName { get; set; } = true;
        public bool PrependCommaOnSelectClauseParts { get; set; } = false;
        public bool Minify { get; set; } = true;
        public Delimeters IdentifierDelimiter { get; set; } = new Delimeters('[', ']');

        public class Delimeters
        {
            public char Begin { get; set; } = '[';
            public char End { get; set; } = ']';

            public Delimeters(char begin, char end)
            {
                Begin = begin;
                End = end;
            }
        }
    }
}
