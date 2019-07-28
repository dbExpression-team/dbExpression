using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace HatTrick.DbEx.Tools.Service
{
    public class ExceptionFeedback
    {
        #region internals
        private Exception _ex;
        #endregion

        #region constructors
        public ExceptionFeedback(Exception ex)
        {
            _ex = ex;
        }
        #endregion

        #region to string
        public override string ToString()
        {
            Exception ex = _ex.GetBaseException();
            string msg = $"Message:{Environment.NewLine}   {ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{ex.StackTrace}";
            return msg;
        }
        #endregion

        #region to json string
        public string ToJsonString()
        {
            Exception ex = _ex.GetBaseException();
            var obj = new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                Source = ex.Source
            };

            return JsonConvert.SerializeObject(obj);
        }
        #endregion
    }
}
