namespace SmartCon
{
    /// <summary>
    /// Contract for the registration of argument processors.
    /// </summary>
    public interface ICommandRegistry
    {
        /// <summary>
        /// Registers a command.
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        /// <param name="processor">The <c>ArgumentProcessor</c> handling the arguments passed to the command.</param>
        void RegisterCommand(string commandName, IArgumentProcessor processor);
    }
}