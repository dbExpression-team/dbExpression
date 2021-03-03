using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateExpressionElementAppenderFactory : IExpressionElementAppenderFactory
    {
        #region internals
        private readonly Func<Type, IExpressionElementAppender> factory;
        #endregion

        #region constructors
        public DelegateExpressionElementAppenderFactory(Func<Type, IExpressionElementAppender> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public IExpressionElementAppender CreateElementAppender(IExpressionElement element)
            => factory(element?.GetType()) ?? throw new ArgumentNullException(nameof(factory));
        #endregion
    }
}
