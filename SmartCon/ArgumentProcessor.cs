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
            var strategy = GetStrategy();
            strategy.Process(args, CommandLineDescription, _argHandler);

            foreach (var handler in _postProcessing)
            {
                handler();
            }
        }

        private ProcessingStrategy GetStrategy()
        {
            ProcessingStrategy strategy = CommandLineDescription.KeyValueSeparator == " "
                ? new WithoutSeparator() as ProcessingStrategy
                : new WithSeparator() as ProcessingStrategy;

            return strategy;
        }
    }
}