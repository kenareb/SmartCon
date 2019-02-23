namespace SmartCon.Strategies
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The <c>DelegateSelector</c> is responsible for choosing the delegate to handle
    /// a specific argument.
    /// </summary>
    public abstract class DelegateSelector : IDelegateSelector
    {
        /// <summary>
        /// Determines, if the chooser is casesensitive or not.
        /// </summary>
        private bool _caseSensitive = true;

        /// <summary>
        /// Initializes a new instance of thr <c>DelegateSelector</c> class.
        /// </summary>
        /// <param name="caseSensitive"><c>true</c> if choosing a delegate happens casesensitive; <c>false</c> otherwise.</param>
        protected DelegateSelector(bool caseSensitive)
        {
            _caseSensitive = caseSensitive;
        }

        /// <summary>
        /// Finds the handler repsonsible for the specified key.
        /// </summary>
        /// <param name="handlers">A dictionary of available handlers.</param>
        /// <param name="key">The specific key to handle.</param>
        /// <returns>The found <c>ArgumentHandler</c></returns>
        public ArgumentHandler Find(IDictionary<string, ArgumentHandler> handlers, string key)
            => FindHandler(handlers, key);

        /// <summary>
        /// Finds the handler repsonsible for the specified key.
        /// </summary>
        /// <param name="handlers">A dictionary of available handlers.</param>
        /// <param name="key">The specific key to handle.</param>
        /// <returns>The found <c>ArgumentHandler</c></returns>
        /// <remarks>This method should be overriden be derived classes.</remarks>
        protected abstract ArgumentHandler FindHandler(IDictionary<string, ArgumentHandler> handlers, string key);
    }
}