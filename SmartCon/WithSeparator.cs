namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class WithSeparator : ProcessingStrategy
    {
        public override void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
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

                if (handlers.ContainsKey(k))
                {
                    handlers[k](v);
                }
            }
        }
    }
}