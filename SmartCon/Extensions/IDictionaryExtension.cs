namespace SmartCon.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for string dictionaries.
    /// </summary>
    public static class IDictionaryExtension
    {
        /// <summary>
        /// Checks wether or not the dictionary contains the specified key, case insensitive.
        /// </summary>
        /// <typeparam name="TValue">The type of the dictionary value.</typeparam>
        /// <param name="myDict">The dictionary.</param>
        /// <param name="key">The key to search.</param>
        /// <returns><c>true</c> if the key exisits; <c>false</c> otherwise.</returns>
        public static bool ContainsKeyCI<TValue>(this IDictionary<string, TValue> myDict, string key)
        {
            var keys = myDict
                .Keys
                .Where(k => k.ToLowerInvariant() == key.ToLowerInvariant());
            return keys.Count() == 1;
        }

        /// <summary>
        /// Finds the key matching the specified key, case insensitive.
        /// </summary>
        /// <typeparam name="TValue">The type of the dictionary value.</typeparam>
        /// <param name="myDict">The dictionary.</param>
        /// <param name="key">The key to search.</param>
        /// <returns>The key stored in the dictionay.</returns>
        public static string FindKeyCI<TValue>(this IDictionary<string, TValue> myDict, string key)
        {
            var keys = myDict.Keys.Where(k => k.ToLowerInvariant() == key.ToLowerInvariant());
            if (keys.Count() == 1)
            {
                var found = keys.First();
                return found;
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets the value stored in the dictionary for the specified key, case insensitive.
        /// </summary>
        /// <typeparam name="TValue">The type of the dictionary value.</typeparam>
        /// <param name="myDict">The dictionary.</param>
        /// <param name="key">The key to search.</param>
        /// <param name="value">Out parameter, where the found value will be stored.</param>
        /// <returns><c>true</c> if one matching key exisits; <c>false</c> otherwise.</returns>
        public static bool TryGetValueCI<TValue>(this IDictionary<string, TValue> myDict, string key, out TValue value)
        {
            value = default(TValue);

            try
            {
                value = myDict[myDict.FindKeyCI(key)];
                return true;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }
}