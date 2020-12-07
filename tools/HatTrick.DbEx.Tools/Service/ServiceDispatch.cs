namespace HatTrick.DbEx.Tools.Service
{
    public static class ServiceDispatch
    {
        #region internals
        private static CommandService _command;
        private static FeedbackService _feedback;
        private static IOService _io;
        #endregion

        #region inteface
        public static CommandService Command => _command ?? (_command = new CommandService());

        public static FeedbackService Feedback => _feedback ?? (_feedback = new FeedbackService());

        public static IOService IO => _io ?? (_io = new IOService());
        #endregion
    }
}
