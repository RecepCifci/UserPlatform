using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Domain.Activities;

public class LoginActivity : IBaseActivity
{
    public Activity SetActivityType(Activity activity)
    {
        activity.Type = Enums.ActivityTypes.Login;
        return activity;
    }
}
