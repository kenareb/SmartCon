namespace SmartCon.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VisitorStrategy : ProcessingStrategy
    {
        /// <summary>
        /// The <c>VisitorStrategy</c> is a command line processing strategy, which
        /// calls all registered argument handlers for each input argument.
        /// </summary>
        /// <param name="args">The command line arguments to process.</param>
        /// <param name="desc">ignored</param>
        /// <param name="handlers">The mapping of the keys to the handlers.</param>
        /// <remarks>The <c>VisitorStrategy</c> handles the mapping slightly different than the
        /// regular strategies. The strategy tries not to build a key-value map from the arguments.
        /// Instead, each handler in the dictionary is called independently of the keys.
        /// However, the keys are used for ordering the invocations of the handler.</remarks>
        protected override void CallHandlers(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
        {
            foreach (var argument in args)
            {
                foreach (var handle in handlers.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value))
                {
                    handle(argument);
                }
            }
        }
    }
}