namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public delegate void ArgumentHandler(string value);

    public delegate void PostProcessHandler();

    public class ArgumentProcessor
    {
        private ConcurrentDictionary<string, ArgumentHandler> _argHandler = new ConcurrentDictionary<string, ArgumentHandler>();
        private ConcurrentBag<PostProcessHandler> _postProcessing = new ConcurrentBag<PostProcessHandler>();

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

        public void RegisterPostProcessor(PostProcessHandler handler)
        {
            _postProcessing.Add(handler);
        }

        public CommandLineDescription CommandLineDescription { get; set; }

        public void Process(string[] args)
        {
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

                if (_argHandler.ContainsKey(k))
                {
                    _argHandler[k](v);
                }
            }

            foreach (var handler in _postProcessing)
            {
                handler();
            }
        }
    }
}