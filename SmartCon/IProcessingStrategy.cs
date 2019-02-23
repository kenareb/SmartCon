namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProcessingStrategy
    {
        /// <summary>
        /// Processes the given commandline arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The <c>CommandLineDescription</c>.</param>
        /// <param name="handlers">The registered handlers.</param>
        void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers);
    }
}