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

﻿using HatTrick.DbEx.Sql.Assembler;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlExpressionElementAppenderFactory : ExpressionElementAppenderFactory
    {
        private static readonly DateAddFunctionExpressionAppender dateAddFunctionAppender = new DateAddFunctionExpressionAppender();
        private static readonly DateDiffFunctionExpressionAppender dateDiffFunctionAppender = new DateDiffFunctionExpressionAppender();
        private static readonly DatePartFunctionExpressionAppender datePartFunctionAppender = new DatePartFunctionExpressionAppender();
        private static readonly GetDateFunctionExpressionAppender getDateFunctionAppender = new GetDateFunctionExpressionAppender();
        private static readonly GetUtcDateFunctionExpressionAppender getUtcDateFunctionAppender = new GetUtcDateFunctionExpressionAppender();
        private static readonly NewIdFunctionExpressionAppender newIdFunctionAppender = new NewIdFunctionExpressionAppender();
        private static readonly SysDateTimeFunctionExpressionAppender sysDateTimeFunctionAppender = new SysDateTimeFunctionExpressionAppender();
        private static readonly SysDateTimeOffsetFunctionExpressionAppender sysDateTimeOffsetFunctionAppender = new SysDateTimeOffsetFunctionExpressionAppender();
        private static readonly SysUtcDateTimeFunctionExpressionAppender sysUtcDateTimeFunctionAppender = new SysUtcDateTimeFunctionExpressionAppender();
        private static readonly LengthFunctionExpressionAppender lengthFunctionAppender = new LengthFunctionExpressionAppender();
        private static readonly PatIndexFunctionExpressionAppender patIndexFunctionAppender = new PatIndexFunctionExpressionAppender();
        private static readonly CharIndexFunctionExpressionAppender charIndexFunctionAppender = new CharIndexFunctionExpressionAppender();

        public MsSqlExpressionElementAppenderFactory()
        {
            base.RegisterElementAppender(dateAddFunctionAppender);
            base.RegisterElementAppender(dateDiffFunctionAppender);
            base.RegisterElementAppender(datePartFunctionAppender);
            base.RegisterElementAppender(getDateFunctionAppender);
            base.RegisterElementAppender(getUtcDateFunctionAppender);
            base.RegisterElementAppender(newIdFunctionAppender);
            base.RegisterElementAppender(sysDateTimeFunctionAppender);
            base.RegisterElementAppender(sysDateTimeOffsetFunctionAppender);
            base.RegisterElementAppender(sysUtcDateTimeFunctionAppender);
            base.RegisterElementAppender(lengthFunctionAppender);
            base.RegisterElementAppender(patIndexFunctionAppender);
            base.RegisterElementAppender(charIndexFunctionAppender);
        }
    }
}
