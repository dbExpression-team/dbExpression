using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using svc = HatTrick.DbEx.Tools.Service.ServiceDispatch;

namespace HatTrick.DbEx.Tools.Service
{
    public abstract class ExecutionContext
    {
        #region internals
        private string _command;
        private string _options;
        private Stopwatch _stopWatch;
        private readonly string _tab = new string(' ', 2);
        #endregion

        #region interface
        public string Command => _command;

        public Dictionary<string, string> Options { get; private set; }

        public string WorkingDirectory { get; private set; }

        public string Tab => _tab;
        #endregion

        #region constructor
        public ExecutionContext(string command) : this(command, null)
        {
        }

        public ExecutionContext(string command, string options)
        {
            _command = command;
            _options = options;
            this.WorkingDirectory = Directory.GetCurrentDirectory();
        }
        #endregion

        #region execute
        public virtual void Execute()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }
        #endregion

        #region ensure options
        protected void EnsureOptions(params string[] validOptions)
        {
            if (_options != null)
            {
                List<string> options = new List<string>();
                Tokenizer tokenizer = new Tokenizer(new char[] { ' ' });
                tokenizer.Emit += (t) =>
                {
                    options.Add(t);
                };
                tokenizer.Parse(_options);

                if (options.Count > 0)
                {
                    this.Options = new Dictionary<string, string>();
                    string key = null;
                    string value = null;

                    for (int i = 0; i < options.Count; i++)
                    {
                        key = options[i];
                        if (!Array.Exists(validOptions, (o) => o == key))
                        {
                            throw new CommandException($"Encountered unknown command option: {key}");
                        }
                        if (options.Count > (i + 1) && !options[i + 1].StartsWith('-'))
                        {
                            value = options[++i];
                        }
                        this.Options.Add(key, value ?? "true");
                        key = null;
                        value = null;
                    }
                }
            }
        }
        #endregion

        #region requested help
        public bool HelpOptionExists()
        {
            return this.TryGetOption(out string v, out string ku, "--help", "-?");
        }
        #endregion

        #region try get option 
        public bool TryGetOption(out string value, out string keyUsed, params string[] key)
        {
            value = null;
            keyUsed = null;
            bool found = false;
            if (this.Options != null)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    found = this.Options.TryGetValue(key[i], out value);
                    if (found)
                    {
                        keyUsed = key[i];
                        break;
                    }
                }
            }
            return found;
        }
        #endregion

        #region push feedback
        protected void PushProgressFeedback(string progressMessage)
        {
            int milliseconds = (int)_stopWatch.ElapsedMilliseconds;
            svc.Feedback.Push(To.Info, $"@ {milliseconds} ms\t-->\t{progressMessage}");
        }
        #endregion

        #region complete
        public void Complete()
        {
            _stopWatch.Stop();
        }
        #endregion
    }
}
