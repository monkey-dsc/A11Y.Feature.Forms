using Sitecore.Data.Items;

namespace A11Y.Feature.Forms.Helpers
{
    public interface IFormSettingsHelper<T>
    {
        void UpdateItemFields(Item item, T settings);

        void InitItemProperties(Item item, T settings);
    }
}