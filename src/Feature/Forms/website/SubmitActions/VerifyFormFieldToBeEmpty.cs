using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using A11Y.Feature.Forms.SubmitActions.Data;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;

namespace A11Y.Feature.Forms.SubmitActions
{
    public class VerifyFormFieldToBeEmpty : SubmitActionBase<HoneypotFieldData>
    {
        public VerifyFormFieldToBeEmpty(
            ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool Execute(HoneypotFieldData data, FormSubmitContext formSubmitContext)
        {
            Assert.ArgumentNotNull(formSubmitContext, nameof(formSubmitContext));
            Assert.ArgumentNotNull(data, nameof(data));
            try
            {
                if (data.FieldHoneypotId == null)
                {
                    return true;
                }

                var field = GetFieldById(data.FieldHoneypotId.Value, formSubmitContext.Fields);
                var fieldValue = GetValue(field).FirstOrDefault();

                if (string.IsNullOrEmpty(fieldValue))
                {
                    return true;
                }

                Logger.Warn("Spam submit action has stopped submission");
                return false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                return false;
            }
        }


        private static IViewModel GetFieldById(Guid id, IList<IViewModel> fields)
        {
            return fields.FirstOrDefault(f => Guid.Parse(f.ItemId) == id);
        }

        private static IEnumerable<string> GetValue(object field)
        {
            var valueObject = field?.GetType()?.GetProperty("Value")?.GetValue(field, null);
            if (valueObject == null)
            {
                return new List<string>();
            }

            if (valueObject is IList list)
            {
                return from object valueItemObject in list select valueItemObject.ToString();
            }

            return new List<string> { valueObject.ToString() };
        }
    }
}