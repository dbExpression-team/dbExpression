using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    [Serializable]
    public abstract class SchemaExpression : IDbExpressionAssemblyPart
    {
        public string SchemaName { get; set; }
        public virtual string ConnectionName { get; set; }

        public SchemaExpression(string schemaName, string connectionName)
        {
            SchemaName = schemaName;
            ConnectionName = connectionName;
        }

        public override string ToString() => ToString("[s]");

        public string ToString(string format)
        {
            string val = null;
            switch (format)
            {
                case "s":
                    val = this.SchemaName;
                    break;
                case "[s]":
                    val = $"[{this.SchemaName}]";
                    break;
                default:
                    throw new ArgumentException("encountered unknown format string");
            }

            return val;
        }
    }
}
