namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>ProcessingStrategy</c> is the base class for all strategies
    /// to process commandline arguments.
    /// </summary>
    public abstract class ProcessingStrategy
    {
        private ArgumentHandlerFinder _finder;

        /// <summary>
        /// Processes the given commandline arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The <c>CommandLineDescription</c>.</param>
        /// <param name="handlers">The registered handlers.</param>
        public void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
        {
            CallHandlers(args, desc, handlers);
        }

        /// <summary>
        /// Calls the handlers according to the <c>CommandLineDescription</c>. Must be implemented by inherting classes.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The <c>CommandLineDescription</c>.</param>
        /// <param name="handlers">The registered handlers.</param>
        protected abstract void CallHandlers(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers);

        protected virtual ArgumentHandlerFinder GetFinder(CommandLineDescription desc)
        {
            if (_finder == null)
            {
                _finder = desc.MatchSubstringIfPossible
                    ? (ArgumentHandlerFinder)new SubKeyFinder(desc.CaseSensitive)
                    : new ArgumentHandlerFinder(desc.CaseSensitive);
            }

            return _finder;
        }
    }
}