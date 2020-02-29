using HatTrick.DbEx.Sql.Assembler;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public class InsertExpressionSet : 
        IDbExpression, IDbExpressionSet<InsertExpression>, IAssemblyPart
    {
        #region interface
        public IList<InsertExpression> Expressions { get; } = new List<InsertExpression>();
        #endregion

        #region constructors
        internal InsertExpressionSet()
        { 
        
        }

        public InsertExpressionSet(IList<InsertExpression> fields)
        {
            Expressions = fields?.ToList() ?? throw new ArgumentNullException($"{nameof(fields)} is required.");
        }

        public InsertExpressionSet(params InsertExpression[] fields)
        {
            Expressions = fields?.ToList() ?? throw new ArgumentNullException($"{nameof(fields)} is required.");
        }

        public InsertExpressionSet(InsertExpression insertExpression)
        {
            Expressions.Add(insertExpression ?? throw new ArgumentNullException($"{nameof(insertExpression)} is required."));
        }

        public InsertExpressionSet(InsertExpression aInsertExpression, InsertExpression bInsertExpression)
        {
            Expressions.Add(aInsertExpression ?? throw new ArgumentNullException($"{nameof(aInsertExpression)} is required."));
            Expressions.Add(bInsertExpression ?? throw new ArgumentNullException($"{nameof(bInsertExpression)} is required."));
        }
        #endregion

        #region to string
        public override string ToString() => $"{(string.Join(", ", Expressions.Select(e => e.ToString())))}";
        #endregion

        #region logical & operator
        public static InsertExpressionSet operator &(InsertExpressionSet aSet, InsertExpression b)
        {
            if (aSet == null)
            {
                aSet = new InsertExpressionSet(b);
            }
            else
            {
                aSet.Expressions.Add(b);
            }
            return aSet;
        }

        public static InsertExpressionSet operator &(InsertExpressionSet aSet, InsertExpressionSet bSet)
        {
            if (aSet == null)
            {
                aSet = new InsertExpressionSet(bSet.Expressions);
            }
            else
            {
                foreach (var b in bSet.Expressions)
                    aSet.Expressions.Add(b);
            }
            return aSet;
        }
        #endregion
    }

}
