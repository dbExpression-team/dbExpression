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

﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DbExpression.Tools.Service
{
    public class CommandService
    {
        #region assemble command
        public static string Assemble(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains(' '))
                {
                    args[i] = $"\"{args[i]}\"";
                }
            }
            string command = string.Join(" ", args);
            return command;
        }
        #endregion

        #region is known
        public static bool IsKnown(string commandLine, out string? command, out string? options)
        {
            int idx = commandLine.IndexOf(' ');

            command = (idx == -1) 
                ? commandLine 
                : commandLine[..idx];

            options = (++idx > 0) //add 1 to the idx to get past first space...
                ? commandLine[idx..]
                : null;

            bool isknown = string.IsNullOrEmpty(command)    //usage
                || command == "gen"                         //code generation
                || command == "generate"                    //code generation
                || command == "mkc"                         //make config
                || command == "mkconfig"                    //make config
                || command == "makeconfig"                  //make config 
                || command == "ver"                         //version
                || command == "version";                    //version

            return isknown;
        }
        #endregion

        #region ensure command
        public ExecutionContext EnsureCommand(string[] args)
        {
            string commandLine = Assemble(args);
            if (!IsKnown(commandLine, out string? command, out string? options))
            {
                throw new CommandException($"Encountered unknown command: {commandLine}");
            }
            return GetExecutionContext(command!, options);
        }
        #endregion

        #region get execution context
        public static ExecutionContext GetExecutionContext(string command, string? options)
        {
            ExecutionContext? context;

            if (string.IsNullOrEmpty(command))
            {
                context = new UsageExecutionContext(command);
            }
            else if (RenderVersionInfoExecutionContext.CommandTextValues.Contains(command))
            {
                context = new RenderVersionInfoExecutionContext(command, options);
            }
            else if (MakeConfigExecutionContext.CommandTextValues.Contains(command))
            {
                context = new MakeConfigExecutionContext(command, options);
            }
            else if (CodeGenerateExecutionContext.CommandTextValues.Contains(command))
            {
                context = new CodeGenerateExecutionContext(command, options);
            }
            else
            {
                throw new CommandException($"Encountered unknown command: {command}");
            }

            return context;
        }
        #endregion
    }
}
