using A11Y.Feature.Forms.Extensions;
using Sitecore;
using Sitecore.Data.Items;

namespace A11Y.Feature.Forms.Helpers
{
    internal class AccessibilitySettingsHelper : IFormSettingsHelper<IAccessibilitySettings>
    {
        public void UpdateItemFields(Item item, IAccessibilitySettings settings)
        {
            if (settings == null)
            {
                return;
            }

            item.Fields["Autocomplete Item Id"]?.SetValue(settings.AutocompleteItemId ?? string.Empty, false);
            item.Fields["Autocomplete Combined Item Id"]?.SetValue(settings.AutocompleteCombinedItemId ?? string.Empty, false);
        }

        public void InitItemProperties(Item item, IAccessibilitySettings settings)
        {
            if (settings == null)
            {
                return;
            }

            settings.AutocompleteValue = string.Empty;
            settings.AutocompleteItemId = StringUtil.GetString(item.Fields["Autocomplete Item Id"]);
            settings.AutocompleteItemValue = settings.AutocompleteItemId.GetReferencedFieldValueByFieldName(item.Database, "Value");
            settings.AutocompleteCombinedItemId = StringUtil.GetString(item.Fields["Autocomplete Combined Item Id"]);
            settings.AutocompleteCombinedItemValue = settings.AutocompleteCombinedItemId.GetReferencedFieldValueByFieldName(item.Database, "Value");
            settings.HasAutocomplete = !string.IsNullOrEmpty(settings.AutocompleteItemValue) || !string.IsNullOrEmpty(settings.AutocompleteCombinedItemValue);
            if (!settings.HasAutocomplete)
            {
                return;
            }

            // Only one token can be taken from the autocomplete settings,
            // so we prefer the single token instead of the combined ones.
            // First we check the combined token...
            if (!string.IsNullOrEmpty(settings.AutocompleteCombinedItemValue))
            {
                settings.AutocompleteValue = settings.AutocompleteCombinedItemValue;
            }

            // ... if a combined token is set, it will be replaced by the single one if set...
            if (!string.IsNullOrEmpty(settings.AutocompleteItemValue))
            {
                settings.AutocompleteValue = settings.AutocompleteItemValue;
            }
        }
    }
}