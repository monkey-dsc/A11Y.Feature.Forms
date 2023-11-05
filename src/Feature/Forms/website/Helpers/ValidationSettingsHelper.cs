using A11Y.Feature.Forms.Models.Interfaces;
using Sitecore;
using Sitecore.Data.Items;

namespace A11Y.Feature.Forms.Helpers
{
    internal class ValidationSettingsHelper : IFormSettingsHelper<IValidationSettings>
    {
        public void InitItemProperties(Item item, IValidationSettings settings)
        {
            if (settings == null)
            {
                return;
            }

            settings.RequiredFieldMessage = StringUtil.GetString(item.Fields["Required Field Message"]);
        }

        public void UpdateItemFields(Item item, IValidationSettings settings)
        {
            if (settings == null)
            {
                return;
            }

            item.Fields["Required Field Message"]?.SetValue(settings.RequiredFieldMessage ?? string.Empty, false);
        }
    }
}