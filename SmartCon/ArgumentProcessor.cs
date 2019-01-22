namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public delegate ArgumentHandleResult ArgumentHandler(string value);

    public delegate ArgumentHandleResult ProcessHandler();

    public class ArgumentProcessor
    {
        private ConcurrentDictionary<string, ArgumentHandler> _argHandler = new ConcurrentDictionary<string, ArgumentHandler>();
        private ConcurrentDictionary<string, ArgumentHandleResult> _argResults = new ConcurrentDictionary<string, ArgumentHandleResult>();
        private ConcurrentBag<ProcessHandler> _postProcessing = new ConcurrentBag<ProcessHandler>();

        public ArgumentProcessor()
            : this(CommandLineDescription.DefaultCommandLine)
        {
        }

        public ArgumentProcessor(CommandLineDescription desc)
        {
            CommandLineDescription = desc;
        }

        public void RegisterArgument(string key, ArgumentHandler handler)
        {
            _argHandler[key] = handler;
        }

        public void RegisterPostProcessor(ProcessHandler handler)
        {
            _postProcessing.Add(handler);
        }

        public CommandLineDescription CommandLineDescription { get; set; }

        public ArgumentHandleResult Process(string[] args)
        {
            var r = ArgumentHandleResult.Handled;

            foreach (var a in args)
            {
                var parts = a.Split(new[] { CommandLineDescription.KeyValueSeparator }, 2);

                var k = parts.Count() > 0
                    ? parts[0]
                    : string.Empty;

                var v = parts.Count() > 1
                    ? parts[1]
                    : string.Empty;

                if (k.StartsWith(CommandLineDescription.KeyPrefix.ToString()))
                {
                    k = k.Substring(1);
                }

                var r1 = ArgumentHandleResult.UnknownArgument;
                if (_argHandler.ContainsKey(k))
                {
                    r1 = _argHandler[k](v);
                    _argResults[k] = r1;
                }

                r = CombineResults(r, r1);
            }

            foreach (var handler in _postProcessing)
            {
                handler();
            }

            return r;
        }

        private static ArgumentHandleResult CombineResults(ArgumentHandleResult r1, ArgumentHandleResult r2)
        {
            if (r1 == ArgumentHandleResult.Handled && r2 == ArgumentHandleResult.Handled)
            {
                return ArgumentHandleResult.Handled;
            }
            else
            {
                return ArgumentHandleResult.Failed;
            }
        }
    }
}