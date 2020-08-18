using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateAssemblyPartAppenderFactory : IAssemblyPartAppenderFactory
    {
        #region internals
        private readonly Func<IAssemblyPartAppenderFactory> factory;
        #endregion

        #region constructors
        public DelegateAssemblyPartAppenderFactory(Func<IAssemblyPartAppenderFactory> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize an Assembly Part Appender Factory."); ;
        }
        #endregion

        #region methods
        public IAssemblyPartAppender CreatePartAppender(object part)
            => factory().CreatePartAppender(part);
        #endregion
    }
}
