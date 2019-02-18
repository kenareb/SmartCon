using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCon
{
    public class SubKeyFinder : ArgumentHandlerFinder
    {
        private bool _caseSensitive;

        public SubKeyFinder(bool caseSensitiv) : base(caseSensitiv)
        {
            _caseSensitive = caseSensitiv;
        }

        protected override ArgumentHandler FindHandler(IDictionary<string, ArgumentHandler> handlers, string key)
        {
            ArgumentHandler h = null;

            var lowerKey = key.ToLower();

            if (handlers.ContainsKey(_caseSensitive ? key : lowerKey))
            {
                h = handlers[_caseSensitive ? key : lowerKey];
            }

            if (h == null)
            {
                var possibleHandles = _caseSensitive
                    ? handlers.Where(a => a.Key.StartsWith(key))
                    : handlers.Where(a => a.Key.ToLower().StartsWith(key.ToLower()));

                if (possibleHandles.Count() == 1)
                {
                    h = possibleHandles.First().Value;
                }
            }

            return h;
        }
    }
}