using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Sitecore.Diagnostics;

namespace A11Y.Feature.Forms.Extensions
{
    public static class HtmlStringExtension
    {
        public static HtmlString GenerateUnobtrusiveValidationAttributes<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> propertyExpression,
            Dictionary<string, bool> removeAttributes)
        {
            Assert.ArgumentNotNull(htmlHelper, nameof(htmlHelper));
            Assert.ArgumentNotNull(removeAttributes, nameof(removeAttributes));
            var name = htmlHelper.NameFor(propertyExpression).ToString();
            var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, htmlHelper.ViewData);
            var attributes = htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata);

            foreach (var item in removeAttributes.Where(item => item.Value))
            {
                attributes.Remove(item.Key);
            }

            return new HtmlString(string.Join(" ", attributes.Select(attr => attr.Key.ToString() + "=\"" + HttpUtility.HtmlEncode(attr.Value) + "\"")));
        }
    }
}