using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Pipelines.ExecuteSubmit;

namespace A11Y.Feature.Forms.Pipelines
{
    // ReSharper disable once UnusedMember.Global
    // note: this type is created via sitecore config
    public class ExecuteActionsAtomicly : ExecuteActions
    {
        public override void Process(ExecuteSubmitActionsEventArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            foreach (var submitAction in args.SubmitActions)
            {
                var shouldAbort = args.FormSubmitContext.Canceled || args.FormSubmitContext.HasErrors;
                if (shouldAbort)
                {
                    return;
                }

                submitAction.SubmitAction.ExecuteAction(args.FormSubmitContext, submitAction.Parameters);
            }
        }
    }
}