using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListTerminationExpressionBuilder<T> :
        IExpressionBuilder<T>,
        ITerminationExpressionBuilder
    {
    }
}
