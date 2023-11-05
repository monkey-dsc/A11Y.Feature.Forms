using System;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace A11Y.Feature.Forms.Models
{
    [Serializable]
    public class A11YHoneypotFieldViewModel : InputViewModel<string>
    {
        protected override void InitItemProperties(Item item)
        {
            base.InitItemProperties(item);
            Value = StringUtil.GetString(item.Fields["Default Value"]);
        }

        protected override void UpdateItemFields(Item item)
        {
            base.UpdateItemFields(item);
            item.Fields["Default Value"]?.SetValue(Value, true);
        }

        protected override void InitializeValue(object value) => Value = value?.ToString();
    }
}