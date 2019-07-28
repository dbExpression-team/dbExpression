using System;
using System.Collections.Generic;
using System.Text;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

namespace HatTrick.DbEx.Tools.Service
{
    public class UsageExecutionContext : ExecutionContext
    {
        #region constructors
        public UsageExecutionContext(string command) : base(command)
        {
        }
        #endregion

        #region execute
        public override void Execute()
        {
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"«Usage:  »Green");
            svc.Feedback.Push(To.ConsoleOnly, $"dbex [command] [options]");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Commands:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}generate|gen");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}makeconfig|mkconfig|mkc");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Run the following for specific command help:");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex <command> -?");
        }
        #endregion
    }
}
