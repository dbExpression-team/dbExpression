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
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an expression element appender factory."); ;
        }
        #endregion

        #region methods
        public IExpressionElementAppender CreateElementAppender(IExpressionElement element)
            => factory(element?.GetType()) ?? throw new DbExpressionConfigurationException($"Could not resolve an expression element appender for type '{element?.GetType()?.Name}', please ensure an appender has been registered.");
        #endregion
    }
}
