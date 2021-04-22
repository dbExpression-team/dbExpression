#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using System;
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
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, $"«Usage:  »Green");
            svc.Feedback.Push(To.ConsoleOnly, $"dbex [command] [options]");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Commands:»Green");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}ver|version");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}generate|gen");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}makeconfig|mkconfig|mkc");
            svc.Feedback.Push(To.ConsoleOnly, string.Empty);
            svc.Feedback.Push(To.ConsoleOnly, "Run the following for specific command help:");
            svc.Feedback.Push(To.ConsoleOnly, $"{base.Tab}dbex <command> -?");
        }
        #endregion
    }
}
