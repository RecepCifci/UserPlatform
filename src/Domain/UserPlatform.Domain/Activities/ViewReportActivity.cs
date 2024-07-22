using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Domain.Activities;

public class ViewReportActivity : IBaseActivity
{
    public string GetDescription()
    {
        return "Report Viewed";
    }
    public Activity SetActivityType(Activity activity)
    {
        activity.Type = Enums.ActivityTypes.ViewReport;
        return activity;
    }
}
