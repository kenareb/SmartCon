namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SmartCon.Strategies;

    /// <summary>
    /// The <c>ArgumentProcessor</c> class is responsible for processing and interpretation of the
    /// commandline arguments.
    /// </summary>
    public class ArgumentProcessor : IArgumentProcessor
    {
        /// <summary>
        /// The <c>_argHandler</c> field contains the mapping of the
        /// commandline keys to methods that should be executed.
        /// </summary>
        private ConcurrentDictionary<string, ArgumentHandler> _argHandler = new ConcurrentDictionary<string, ArgumentHandler>();

        /// <summary>
        /// The <c>_postProcessing</c> field contains all methods, that
        /// is going to be executed after the commandlines have been parsed.
        /// </summary>
        private ConcurrentBag<PostProcessHandler> _postProcessing = new ConcurrentBag<PostProcessHandler>();

        /// <summary>
        /// Initializes a new instance of the <c>ArgumentProcessor</c> class.
        /// </summary>
        public ArgumentProcessor()
            : this(CommandLineDescription.DefaultCommandLine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <c>ArgumentProcessor</c> class for the
        /// given CommandLineDescription..
        /// </summary>
        /// <param name="desc">The commandline description, which is used to interpret the arguments.</param>
        public ArgumentProcessor(CommandLineDescription desc)
        {
            CommandLineDescription = desc;
        }

        /// <summary>
        /// Registers a method, which will be executed when a specific <c>key</c>
        /// is provided via the commandline arguments.
        /// </summary>
        /// <param name="key">The commandline key</param>
        /// <param name="handler">A delegate to the method to be executed.</param>
        /// <remarks>
        /// For a commandline like "-f=filename", the key is "f".
        /// </remarks>
        public void RegisterArgument(string key, ArgumentHandler handler)
        {
            _argHandler[key] = handler;
        }

        /// <summary>
        /// Registers a method, that will be clled, after all commandline arguments have been parsed.
        /// </summary>
        /// <param name="handler"></param>
        public void RegisterPostProcessor(PostProcessHandler handler)
        {
            _postProcessing.Add(handler);
        }

        /// <summary>
        /// The <c>CommandLineDescrition</c> property contains the information needed
        /// to interpret the commandline arguments, esp. the commandline style
        /// like "-f=filename", "/f filename" or "--f:filename".
        /// </summary>
        public CommandLineDescription CommandLineDescription { get; set; }

        /// <summary>
        /// Processes the specified commandline arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        public void Process(string[] args)
        {
            var strategy = GetStrategy();
            strategy.Process(args, CommandLineDescription, _argHandler);

            foreach (var handler in _postProcessing)
            {
                handler();
            }
        }

        /// <summary>
        /// Determines the strategy for parsing the arguments,
        /// depending on the current <c>CommandLineDescription</c>
        /// </summary>
        /// <returns>A <c>ProcessingStrategy</c>.</returns>
        protected virtual IProcessingStrategy GetStrategy()
        {
            var strategy = CommandLineDescription.KeyValueSeparator == " "
                ? new WithoutSeparator() as IProcessingStrategy
                : new WithSeparator() as IProcessingStrategy;

            return strategy;
        }
    }
}