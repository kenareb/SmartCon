namespace SmartCon
{
    using System;
    using System.Collections.Generic;

    public interface IDelegateSelector
    {
        /// <summary>
        /// Finds the handler repsonsible for the specified key.
        /// </summary>
        /// <param name="handlers">A dictionary of available handlers.</param>
        /// <param name="key">The specific key to handle.</param>
        /// <returns>The found <c>ArgumentHandler</c></returns>
        ArgumentHandler Find(IDictionary<string, ArgumentHandler> handlers, string key);
    }
}