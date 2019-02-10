namespace SmartCon
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The <c>ArgumentHelpProvider</c> class is fesponsible for keeping track of
    /// the documentation used for the 'Usage' or 'GetHelp' method of a console app.
    /// </summary>
    public sealed class ArgumentHelpProvider
    {
        private ConcurrentDictionary<string, string> _examples = new ConcurrentDictionary<string, string>();
        private ConcurrentDictionary<string, string> _documentation = new ConcurrentDictionary<string, string>();
        private TextIndent _indent = new TextIndent();
        private StringBuilder _builder = new StringBuilder();

        public ArgumentHelpProvider()
        {
            _indent.IncreaseIndentationLevel();
        }

        /// <summary>
        /// Registers a new documentation entry for a commandline argument.
        /// </summary>
        /// <param name="key">The key of the commandline argument.</param>
        /// <param name="example">An example text.</param>
        /// <param name="description">The description for the commandline argument.</param>
        public void RegisterDocumentation(string key, string example, string description)
        {
            _examples[key] = example;
            _documentation[key] = description;
        }

        /// <summary>
        /// Gets the documentation for all registered commandling arguments / keys.
        /// </summary>
        /// <returns></returns>
        public string GetDocumentation()
        {
            _builder.Clear();

            foreach (var kvp in _examples)
            {
                _builder.AppendLine(_examples[kvp.Key]);

                if (_documentation.ContainsKey(kvp.Key))
                {
                    _builder.AppendLine(_indent.IndentInput(_documentation[kvp.Key]));
                    _builder.AppendLine();
                }
            }

            return _builder.ToString();
        }
    }
}