namespace SmartCon.Help
{
    using System.Configuration;

    /// <summary>
    /// The <c>HelpSection</c> describes a configuration section element, containing command descriptions.
    /// </summary>
    public class HelpSection : ConfigurationSection
    {
        /// <summary>
        /// The name of the section.
        /// </summary>
        public const string SectionName = "Help";

        /// <summary>
        /// The name of the commands collection.
        /// </summary>
        private const string HelpEntryCollectionName = "Commands";

        /// <summary>
        /// The collection property for accessing the commands stored in the configuration element.
        /// </summary>
        [ConfigurationProperty(HelpEntryCollectionName)]
        [ConfigurationCollection(typeof(HelpEntryCollection), AddItemName = "add")]
        public HelpEntryCollection HelpEntries
        {
            get
            {
                return (HelpEntryCollection)base[HelpEntryCollectionName];
            }
        }
    }
}