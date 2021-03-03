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
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion
        
        #region methods
        public IAppender CreateAppender() => factory();
        #endregion        
    }
}
