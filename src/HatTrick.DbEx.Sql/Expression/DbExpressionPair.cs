using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DbExpressionPair
    {
        public (Type,object) LeftPart { get; private set; }
        public (Type,object) RightPart { get; private set; }

        public DbExpressionPair((Type, object) leftPart, (Type, object) rightPart)
        {
            LeftPart = leftPart;
            RightPart = rightPart;
        }
    }
}
