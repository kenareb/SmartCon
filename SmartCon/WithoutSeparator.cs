namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <c>WithoutSeparator</c> class is a <c>ProcessingStrategy</c> for
    /// interpreting commandline styles without a separator.
    /// </summary>
    public sealed class WithoutSeparator : ProcessingStrategy
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
            var argsleft = true;
            var i = 0;

            while (argsleft)
            {
                if (i >= args.Length)
                {
                    argsleft = false;
                    break;
                }

                var key = args[i];
                var value = i + 1 < args.Length
                    ? args[i + 1]
                    : string.Empty;

                if (key.StartsWith(desc.KeyPrefix))
                {
                    string v = null;
                    var k = key.Substring(desc.KeyPrefix.Length);

                    if (!value.StartsWith(desc.KeyPrefix))
                    {
                        v = value;
                        i += 2;
                    }
                    else
                    {
                        v = null;
                        i++;
                    }

                    var finder = _cache.GetCachedSelector(desc);
                    var h = finder.Find(handlers, k);
                    if (h != null) { h(v); }
                }
                else
                {
                    // Unknown argument. Don't do anything...
                    i++;
                }

                argsleft = i <= args.Length - 1;
            }
        }
    }
}