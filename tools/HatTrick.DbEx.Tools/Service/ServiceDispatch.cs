using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Service
{
    public static class ServiceDispatch
    {
        #region internals
        private static CommandService _command;
        private static FeedbackService _feedback;
        private static IOService _io;
        private static TypeMapService _typeMap;
        #endregion

        #region inteface
        public static CommandService Command => _command ?? (_command = new CommandService());

        public static FeedbackService Feedback => _feedback ?? (_feedback = new FeedbackService());

        public static IOService IO => _io ?? (_io = new IOService());

        public static TypeMapService TypeMap => _typeMap ?? (_typeMap = new TypeMapService());
        #endregion
    }
}
