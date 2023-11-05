using Sitecore;
using Sitecore.Mvc.Helpers;

namespace A11Y.Feature.Forms.Helpers
{
    public static class HtmlHelper
    {
        public static bool IsExperienceFormsEditMode(this SitecoreHelper helper) => Context.Request.QueryString["sc_formmode"] != null;
    }
}