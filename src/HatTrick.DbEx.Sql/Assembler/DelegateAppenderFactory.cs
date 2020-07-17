using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateAppenderFactory : IAppenderFactory
    {
        #region internals
        private readonly Func<IAppender> factory;
        #endregion

        #region constructors
        public DelegateAppenderFactory(Func<IAppender> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an Appender Factory."); ;
        }

        public DelegateAppenderFactory(Func<IAppenderFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an Appender Factory.");

            this.factory = new Func<IAppender>(() =>
            {
                var f = factory().CreateAppender();
                if (f is null)
                    throw new DbExpressionException("Cannot create an Appender: The factory returned a null value.");
                return f;
            });
        }
        #endregion
        
        #region methods
        public IAppender CreateAppender() => factory();
        #endregion        
    }
}
