using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Activities.Base;

namespace UserPlatform.Application.Managers;

public interface IActivityManager
{
    public void SetBaseActivity(IBaseActivity baseActivity);
    public string GetDescription();
    public ActivityDto SetActivityType(ActivityDto activityDto);
}
