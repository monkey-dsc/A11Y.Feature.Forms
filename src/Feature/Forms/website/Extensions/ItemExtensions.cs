using Sitecore.Data;

namespace A11Y.Feature.Forms.Extensions
{
    internal static class ItemExtensions
    {
        public static string GetReferencedFieldValueByFieldName(this string itemId, Database db, string targetFieldName)
        {
            var referencedField = db.GetItem(itemId)?.Fields[targetFieldName];
            if (referencedField == null)
            {
                return string.Empty;
            }

            var value = referencedField.Value;
            return !string.IsNullOrEmpty(value) ? value : string.Empty;
        }
    }
}