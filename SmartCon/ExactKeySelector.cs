namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>ExactKeySelector</c> is responsible for selecting an <see cref="ArgumentHandler"/>.
    /// The selector chooses the <c>ArgumentHandler</c> by matching the exact argument.
    /// </summary>
    public class ExactKeySelector : DelegateSelector
    {
        private bool _caseSensitive;

        /// <summary>
        /// Initializes a new instance of the <c>ExactKeySelector</c>.
        /// </summary>
        /// <param name="caseSensitive"><c>true</c> if choosing a delegate happens casesensitive; <c>false</c> otherwise.</param>
        public ExactKeySelector(bool caseSensitiv) : base(caseSensitiv)
        {
            _caseSensitive = caseSensitiv;
        }

        /// <summary>
        /// Finds the handler repsonsible for the specified key.
        /// </summary>
        /// <param name="handlers">A dictionary of available handlers.</param>
        /// <param name="key">The specific key to handle.</param>
        /// <returns>The found <c>ArgumentHandler</c></returns>
        /// <remarks>This method should be overriden be derived classes.</remarks>
        protected override ArgumentHandler FindHandler(IDictionary<string, ArgumentHandler> handlers, string key)
        {
            ArgumentHandler h = null;

            var found = _caseSensitive
                ? handlers.TryGetValue(key, out h)
                : handlers.TryGetValueCI(key, out h);

            return h;
        }
    }
}