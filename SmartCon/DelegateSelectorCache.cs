namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>DelegateSelectorCache</c> is responsible for creating and caching the <c>DelegateSelector</c>.
    /// </summary>
    public sealed class DelegateSelectorCache
    {
        /// <summary>
        /// Internal cache to avoid creating multiple instances of the <c>DelegateSelector</c>.
        /// </summary>
        private Dictionary<CommandLineDescription, DelegateSelector> _selectors = new Dictionary<CommandLineDescription, DelegateSelector>();

        /// <summary>
        /// Gets a previously cached <c>DelegateSelector</c> or creates a new one if not cached.
        /// </summary>
        /// <param name="desc">The specific <c>CommandLineDescription</c> used to identitfy the <c>DelegateSelector</c>.</param>
        /// <returns>A <c>DelegateSelector</c>.</returns>
        public DelegateSelector GetCachedSelector(CommandLineDescription desc)
        {
            DelegateSelector selector;
            if (!_selectors.ContainsKey(desc))
            {
                selector = GetSelector(desc);
                _selectors[desc] = selector;
            }

            selector = _selectors[desc];
            return selector;
        }

        /// <summary>
        /// Creates a <c>DelegateSelector</c> for the specified <see cref="CommandLineDescription"/>.
        /// </summary>
        /// <param name="desc">The specific <c>CommandLineDescription</c> used to identitfy the <c>DelegateSelector</c>.</param>
        /// <returns>A <c>DelegateSelector</c> depending on the specified <see cref="CommandLineDescription"/>.returns>
        public static DelegateSelector GetSelector(CommandLineDescription desc)
        {
            var selector = desc.MatchSubstringIfPossible
                    ? (DelegateSelector)new SubKeySelector(desc.CaseSensitive)
                    : new ExactKeySelector(desc.CaseSensitive);

            return selector;
        }
    }
}