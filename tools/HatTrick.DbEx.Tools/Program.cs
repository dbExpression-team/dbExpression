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
using System.IO;
using Newtonsoft.Json;
using HatTrick.DbEx.Tools.Service;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

namespace HatTrick.DbEx.Tools
{
    class Program
    {
        #region console foreground color
        private static ConsoleColor _foregroundColor;
        #endregion

        #region main
        static void Main(string[] args)
        {
            _foregroundColor = Console.ForegroundColor;

            RegisterFeedbackHandlers();

            try
            {
                ExecutionContext exe = svc.Command.EnsureCommand(args);
                exe?.Execute();
            }
            catch (CommandException cex)
            {
                svc.Feedback.Push(To.Error, cex.Message);
            }
            catch (Exception ex)
            {
                var exFeedback = new ExceptionFeedback(ex);
                svc.Feedback.PushException(exFeedback);
            }
#if DEBUG
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
#endif
        }
        #endregion

        #region register feedback handlers
        private static void RegisterFeedbackHandlers()
        {
            svc.Feedback.Register(To.ConsoleOnly, HandleConsoleFeedback);
            svc.Feedback.Register(To.Info, HandleConsoleFeedback);
            svc.Feedback.Register(To.Error, HandleErrorFeedback);
            svc.Feedback.Register(To.Warn, HandleWarningFeedback);
            svc.Feedback.Register(To.Fatal, HandleExceptionFeedback);
        }
        #endregion

        #region handle console feedback
        private static void HandleConsoleFeedback(string msg)
        {
            //» is alt + 175
            int colorAssign = msg.IndexOf('»');
            if (colorAssign > 1)//color assignment provided
            {
                string color = msg.Substring(colorAssign + 1, msg.Length - (colorAssign + 1));
                msg = msg.Substring(0, colorAssign);
                if (Enum.TryParse<ConsoleColor>(color, out ConsoleColor cc))
                {
                    Console.ForegroundColor = cc;
                }
            }
            //« is alt + 174
            if (msg.StartsWith("««")) //blank out current line and write over it...
            {
                Console.Write($"\r{new string(' ', Console.CursorLeft)}\r");
                Console.Write(msg.Substring(2));
            }
            else if (msg.StartsWith("«")) //intend same line continuation
            {
                Console.Write(msg.Substring(1));
            }
            else
            {
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = _foregroundColor;
        }
        #endregion

        #region handle warning feedback
        static void HandleWarningFeedback(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ForegroundColor = _foregroundColor;
        }
        #endregion

        #region handle error feedback
        static void HandleErrorFeedback(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = _foregroundColor;
        }
        #endregion

        #region handle exception feedback
        private static void HandleExceptionFeedback(string json)
        {
            dynamic obj = JsonConvert.DeserializeObject(json);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(obj.Message);
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = _foregroundColor;
            Console.WriteLine(obj.StackTrace);
        }
        #endregion
    }
}
