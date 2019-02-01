namespace SmartCon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WithoutSeparator : ProcessingStrategy
    {
        public override void Process(string[] args, CommandLineDescription desc, IDictionary<string, ArgumentHandler> handlers)
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

                    if (handlers.ContainsKey(k))
                    {
                        handlers[k](v);
                    }
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