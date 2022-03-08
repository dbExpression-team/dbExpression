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

﻿namespace HatTrick.DbEx.Tools.Service
{
    public static class ServiceDispatch
    {
        #region internals
        private static CommandService? _command;
        private static FeedbackService? _feedback;
        private static IOService? _io;
        #endregion

        #region interface
        public static CommandService Command => _command ??= new();

        public static FeedbackService Feedback => _feedback ??= new();

        public static IOService IO => _io ??= new();
        #endregion
    }
}
