using System;
using A11Y.Feature.Forms.Helpers;
using Sitecore.Data.Items;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace A11Y.Feature.Forms.Models
{
    [Serializable]
    public class A11YStringInputViewModel : StringInputViewModel, IValidationSettings, IAccessibilitySettings
    {
        public string RequiredFieldMessage { get; set; }
        public string AutocompleteItemId { get; set; }
        public string AutocompleteItemValue { get; set; }
        public string AutocompleteCombinedItemId { get; set; }
        public string AutocompleteCombinedItemValue { get; set; }
        public bool HasAutocomplete { get; set; }
        public string AutocompleteValue { get; set; }

        [NonSerialized] private readonly IFormSettingsHelper<IValidationSettings> _validationSettingsHelper;
        [NonSerialized] private readonly IFormSettingsHelper<IAccessibilitySettings> _accessibilitySettingsHelper;

        public A11YStringInputViewModel()
        {
            _validationSettingsHelper = new ValidationSettingsHelper();
            _accessibilitySettingsHelper = new AccessibilitySettingsHelper();
        }

        protected override void InitItemProperties(Item item)
        {
            base.InitItemProperties(item);

            _validationSettingsHelper.InitItemProperties(item, this);
            _accessibilitySettingsHelper.InitItemProperties(item, this);
        }

        protected override void UpdateItemFields(Item item)
        {
            base.UpdateItemFields(item);

            _validationSettingsHelper.UpdateItemFields(item, this);
            _accessibilitySettingsHelper.UpdateItemFields(item, this);
        }
    }
}