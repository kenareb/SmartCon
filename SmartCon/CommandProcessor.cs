﻿namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>CommandProcessor</c> is an <see cref="ArgumentProcessor"/> handling commands.
    /// </summary>
    /// <seealso cref="ICommandRegistry"/>
    /// <seealso cref="CommandStrategy"/>
    public class CommandProcessor : ArgumentProcessor, ICommandRegistry
    {
        /// <summary>
        /// The <c>CommandStrategy</c> is used here.
        /// </summary>
        private CommandStrategy _strat = new CommandStrategy();

        /// <summary>
        /// Registers a command.
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        /// <param name="processor">The <c>ArgumentProcessor</c> handling the arguments passed to the command.</param>
        public void RegisterCommand(string commandName, IArgumentProcessor processor)
        {
            _strat.RegisterCommand(commandName, processor);
        }

        /// <summary>
        /// Gets the processing strategy.
        /// </summary>
        /// <returns>The processing strategy to be used.</returns>
        protected override ProcessingStrategy GetStrategy()
        {
            return _strat;
        }
    }
}