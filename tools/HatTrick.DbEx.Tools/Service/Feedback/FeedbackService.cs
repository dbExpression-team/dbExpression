using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Tools.Service
{
    public class FeedbackService
    {
        #region internals
        private Action<To, string> _receivers;
        #endregion

        #region register
        public void Register(To to, Action<string> receiver)
        {
            Action<To, string> wrap = (t, m) =>
            {
                if (t == to)
                {
                    receiver(m);
                };
            };
            _receivers += wrap;
        }
        #endregion

        #region push
        public void Push(To to, string msg)
        {
            _receivers?.Invoke(to, msg);
        }

        public void PushException(ExceptionFeedback exfeedback)
        {
            _receivers?.Invoke(To.Fatal, exfeedback.ToJsonString());
        }
        #endregion
    }

    public enum To
    {
        ConsoleOnly = -1,
        Trace = 0,
        Debug = 1,
        Info = 2,
        Warn = 3,
        Error = 4,
        Fatal = 5
    }
}
