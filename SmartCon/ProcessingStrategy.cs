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
        /// <summary>
        /// Processes the given commandline arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The <c>CommandLineDescription</c>.</param>
        /// <param name="handlers">The registered handlers.</param>
        public abstract void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers);
    }
}