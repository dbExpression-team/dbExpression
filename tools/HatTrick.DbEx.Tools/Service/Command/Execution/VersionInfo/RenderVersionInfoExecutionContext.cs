using System;
using System.Collections.Generic;
using System.Text;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

namespace HatTrick.DbEx.Tools.Service
{
    public class RenderVersionInfoExecutionContext : ExecutionContext
    {
        #region internals
        private readonly string[] OPTION_KEYS = new string[]
        {
            "--help", "-?",     // help
        };
        #endregion

        #region interface
        public static string[] CommandTextValues { get; } = new string[] { "version", "ver" };
        #endregion

        #region constructors
        public RenderVersionInfoExecutionContext(string command) : this(command, null)
        {
               
        }

        public RenderVersionInfoExecutionContext(string command, string options) : base(command, options)
        {
            base.EnsureOptions(OPTION_KEYS);
        }
        #endregion

        #region execute
        public override void Execute()
        {
            base.Execute();

            if (base.HelpOptionExists())
            {
                //render execution context help
                this.PushHelpFeedback();
            }
            else
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                svc.Feedback.Push(To.ConsoleOnly, $"HatTrick Labs dbex cli version [{version}]");
                svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            }

            base.Complete();
        }
        #endregion

        #region push help feedback
        private void PushHelpFeedback()
        {
            svc.Feedback.Push(To.ConsoleOnly, "«Usage:  »Green");
            svc.Feedback.Push(To.ConsoleOnly, "dbex version");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Notes:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}renders package version and assembly version.");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
        }
        #endregion
    }
}
