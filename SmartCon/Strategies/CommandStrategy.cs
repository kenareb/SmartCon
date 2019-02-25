namespace SmartCon.Strategies
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>CommandStrategy</c> implements a strategy, which interprets the first argument a command,
    /// calls this command and passes the following arguments as arguments to this command.
    /// </summary>
    public class CommandStrategy : ProcessingStrategy, ICommandRegistry
    {
        /// <summary>
        /// Internal mapping of command name to processor.
        /// </summary>
        private IDictionary<string, IArgumentProcessor> _commands = new ConcurrentDictionary<string, IArgumentProcessor>();

        /// <summary>
        /// Calls the handlers according to the <c>CommandLineDescription</c>. Must be implemented by inherting classes.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The <c>CommandLineDescription</c>.</param>
        /// <param name="handlers">The registered handlers.</param>
        protected override void CallHandlers(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
        {
            Queue<string> q = new Queue<string>(args);
            var found = false;
            while (!found)
            {
                if (q.Count > 0)
                {
                    var commandName = q.Dequeue();
                    var command = GetCommand(commandName);

                    if (command != null)
                    {
                        found = true;
                        var residuum = q.ToArray();
                        command.Process(residuum);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Registers a command.
        /// </summary>
        /// <param name="commandName">The name of the command.</param>
        /// <param name="processor">The <c>ArgumentProcessor</c> representing the command.</param>
        public void RegisterCommand(string commandName, IArgumentProcessor processor)
        {
            _commands[commandName] = processor;
        }

        /// <summary>
        /// Gets the <c>ArgumentProcessor for the specified command.</c>
        /// </summary>
        /// <param name="name">The name of the command.</param>
        /// <returns>An <c>ArgumentProcessor</c> to handle this command.</returns>
        private IArgumentProcessor GetCommand(string name)
        {
            IArgumentProcessor command = null;
            if (_commands.ContainsKey(name))
            {
                command = _commands[name];
            }

            return command;
        }
    }
}