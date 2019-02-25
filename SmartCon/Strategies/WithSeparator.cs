namespace SmartCon.Strategies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>WithSeparator</c> class is a <c>ProcessingStrategy</c> for
    /// interpreting commandline styles containing a separator.
    /// </summary>
    public sealed class WithSeparator : ProcessingStrategy
    {
        private DelegateSelectorCache _cache = new DelegateSelectorCache();

        /// <summary>
        /// Processes the arguments.
        /// </summary>
        /// <param name="args">The commandline arguments.</param>
        /// <param name="desc">The commandline description.</param>
        /// <param name="handlers">The registered handlers.</param>
        protected override void CallHandlers(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
        {
            foreach (var a in args)
            {
                var parts = a.Split(new[] { desc.KeyValueSeparator }, 2, StringSplitOptions.RemoveEmptyEntries);

                var k = parts.Count() > 0
                    ? parts[0]
                    : string.Empty;

                var v = parts.Count() > 1
                    ? parts[1]
                    : string.Empty;

                if (k.StartsWith(desc.KeyPrefix.ToString()))
                {
                    k = k.Substring(desc.KeyPrefix.Length);
                }

                var finder = _cache.GetCachedSelector(desc);
                var h = finder.Find(handlers, k);
                if (h != null) { h(v); }
            }
        }
    }
}