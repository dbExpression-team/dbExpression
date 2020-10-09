using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Tools.Service
{
    public class CommandService
    {
        #region assemble command
        public string Assemble(string[] args)
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
        public bool IsKnown(string commandLine, out string command, out string options)
        {
            int idx = commandLine.IndexOf(' ');

            command = (idx == -1) 
                ? commandLine 
                : commandLine.Substring(0, idx);

            options = (++idx > 0) //add 1 to the idx to get past first space...
                ? commandLine.Substring(idx, commandLine.Length - idx)
                : null;

            bool isknown = string.IsNullOrEmpty(command)    //usage
                || command == "gen"                         //code generation
                || command == "generate"                    //code generation
                || command == "mkc"                         //make config
                || command == "mkconfig"                    //make config
                || command == "makeconfig";                 //make config 

            return isknown;
        }
        #endregion

        #region ensure command
        public ExecutionContext EnsureCommand(string[] args)
        {
            ExecutionContext executor = null;

            string commandLine = this.Assemble(args);
            string command = null;
            string options = null;
            if (!this.IsKnown(commandLine, out command, out options))
            {
                throw new CommandException($"Encountered unknown command: {commandLine}");
            }

            executor = this.GetExecutionContext(command, options);

            return executor;
        }
        #endregion

        #region get execution context
        public ExecutionContext GetExecutionContext(string command, string options)
        {
            ExecutionContext context = null;

            if (string.IsNullOrEmpty(command))
            {
                context = new UsageExecutionContext(command);
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
