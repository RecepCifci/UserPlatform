using UserPlatform.Domain.Entities;

namespace UserPlatform.Domain.Activities.Base;

public interface IBaseActivity
{
    public Activity SetActivityType(Activity activity);
}
