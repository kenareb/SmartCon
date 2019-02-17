using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCon
{
    public class SubKeyFinder : ArgumentHandlerFinder
    {
        private bool _caseSensitive;

        public SubKeyFinder(IDictionary<string, ArgumentHandler> handlers, bool caseSensitiv) : base(handlers, caseSensitiv)
        {
            _caseSensitive = caseSensitiv;
        }

        protected override ArgumentHandler FindHandler(string key)
        {
            ArgumentHandler h = null;

            var lowerKey = key.ToLower();

            if (ArgHandles.ContainsKey(_caseSensitive ? key : lowerKey))
            {
                h = ArgHandles[_caseSensitive ? key : lowerKey];
            }

            if (h == null)
            {
                var possibleHandles = _caseSensitive
                    ? ArgHandles.Where(a => a.Key.StartsWith(key))
                    : ArgHandles.Where(a => a.Key.ToLower().StartsWith(key.ToLower()));

                if (possibleHandles.Count() == 1)
                {
                    h = possibleHandles.First().Value;
                }
            }

            return h;
        }
    }
}