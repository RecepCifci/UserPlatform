using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Domain.Activities;

public class DownloadReportActivity : IBaseActivity
{
    public Activity SetActivityType(Activity activity)
    {
        activity.Type = Enums.ActivityTypes.DownloadReport;
        return activity;
    }
}
