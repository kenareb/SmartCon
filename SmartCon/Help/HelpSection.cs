namespace SmartCon.Help
{
    using System.Configuration;

    public class HelpSection : ConfigurationSection
    {
        public const string SectionName = "Help";

        private const string HelpEntryCollectionName = "Commands";

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