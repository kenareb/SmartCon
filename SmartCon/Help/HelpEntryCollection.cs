namespace SmartCon.Help
{
    using System.Configuration;

    /// <summary>
    /// The <c>HelpEntryCollection</c> contains a list of configuration elements describing commandline arguments.
    /// </summary>
    public class HelpEntryCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Creates a new <see cref="HelpEntryElement"/>.
        /// </summary>
        /// <returns>A new <see cref="HelpEntryElement"/></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new HelpEntryElement();
        }

        /// <summary>
        /// Gets key from the specified <see cref="ConfigurationElement"/>.
        /// </summary>
        /// <param name="element">The configuration element to get the key from.</param>
        /// <returns>The key of the specified <c>HelpEntryElement</c>; null if the element is not of the type <c>HelpEntryElement</c>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            var help = element as HelpEntryElement;
            return help?.Key;
        }
    }
}