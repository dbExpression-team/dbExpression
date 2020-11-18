using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateExpressionElementAppenderFactory : IExpressionElementAppenderFactory
    {
        #region internals
        private readonly Func<IExpressionElementAppenderFactory> factory;
        #endregion

        #region constructors
        public DelegateExpressionElementAppenderFactory(Func<IExpressionElementAppenderFactory> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an Assembly Part Appender Factory."); ;
        }
        #endregion

        #region methods
        public IExpressionElementAppender CreateElementAppender(IExpressionElement element)
            => factory().CreateElementAppender(element);
        #endregion
    }
}
