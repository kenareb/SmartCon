namespace SmartCon
{
    using System;
    using System.Linq;

    /// <summary>
    /// Contract for argument processor classes.
    /// </summary>
    public interface IArgumentProcessor
    {
        /// <summary>
        /// Processes the specified commandline arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        void Process(string[] args);

        /// <summary>
        /// Registers a method, that will be clled, after all commandline arguments have been parsed.
        /// </summary>
        /// <param name="handler"></param>
        void RegisterPostProcessor(PostProcessHandler handler);

        /// <summary>
        /// Registers a method, which will be executed when a specific <c>key</c>
        /// is provided via the commandline arguments.
        /// </summary>
        /// <param name="key">The commandline key</param>
        /// <param name="handler">A delegate to the method to be executed.</param>
        /// <remarks>
        /// For a commandline like "-f=filename", the key is "f".
        /// </remarks>
        void RegisterArgument(string key, ArgumentHandler handler);
    }
}