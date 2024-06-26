#region license
// Copyright (c) dbExpression.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DbExpression.Tools.Service
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
            =>  $"Message:{Environment.NewLine}{_ex.Message}{Environment.NewLine}Stack Trace:{Environment.NewLine}{_ex.StackTrace}";
        #endregion

        #region to json string
        public string ToJsonString()
        {
            var obj = new ExceptionFeedbackDescriptor
            {
                Message = $"{_ex.Message}{Environment.NewLine}{_ex.GetBaseException().Message}",
                StackTrace = _ex.GetBaseException().StackTrace,
                Source = _ex.GetBaseException().Source
            };

            return JsonSerializer.Serialize(obj);
        }
        #endregion
    }
}
