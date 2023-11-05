using Sitecore.Data;

namespace A11Y.Feature.Forms.Shared.Constants
{
    public struct Templates
    {
        public struct FormEMailDatasourceFolder
        {
            public static ID TemplateId = new ID("{FB0C1AC4-BC1D-4F54-A770-F35FA14E9116}");
        }

        public struct FormEMailDatasourceEntry
        {
            public static ID TemplateId = new ID("{C90F88D1-106A-4AAB-B153-F2747E2E016B}");

            public struct Fields
            {
                public static ID Text = new ID("{48ACCD53-0602-46A8-839C-45C65B816F56}");

                public static ID EMailRecipients = new ID("{6FCAF9C9-4D4F-4E9B-9D2A-ED09F37800A2}");
            }
        }

        public struct LabelSettings
        {
            public struct Fields
            {
                public static ID TitleId = new ID("{71FFD7B2-8B09-4F7B-8A66-1E4CEF653E8D}");
            }
        }
    }
}