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
            DelegateSelector finder;
            if (!_selectors.ContainsKey(desc))
            {
                finder = GetSelector(desc);
                _selectors[desc] = finder;
            }

            finder = _selectors[desc];
            return finder;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="desc"></param>
        /// <returns>A <c>DelegateSelector</c> depending on the specified <see cref="CommandLineDescription"/></returns>
        public static DelegateSelector GetSelector(CommandLineDescription desc)
        {
            var finder = desc.MatchSubstringIfPossible
                    ? (DelegateSelector)new SubKeySelector(desc.CaseSensitive)
                    : new ExactKeySelector(desc.CaseSensitive);

            return finder;
        }
    }
}