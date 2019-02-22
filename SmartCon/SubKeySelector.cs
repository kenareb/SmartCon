namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The <c>SubKeySelector</c> is responsible for selecting an <see cref="ArgumentHandler"/>.
    /// The selector chooses the <c>ArgumentHandler</c> by matching a substring of the argument.
    /// </summary>
    public class SubKeySelector : DelegateSelector
    {
        private bool _caseSensitive;

        /// <summary>
        /// Initializes a new instance of the <c>SubKeySelector</c> class
        /// </summary>
        /// <param name="caseSensitive"><c>true</c> if choosing a delegate happens casesensitive; <c>false</c> otherwise.</param>
        public SubKeySelector(bool caseSensitiv) : base(caseSensitiv)
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

            var possibleHandles = _caseSensitive
                ? handlers.Where(a => a.Key.StartsWith(key))
                : handlers.Where(a => a.Key.ToLower().StartsWith(key.ToLower()));

            if (possibleHandles.Count() == 1)
            {
                h = possibleHandles.First().Value;
            }

            return h;
        }
    }
}