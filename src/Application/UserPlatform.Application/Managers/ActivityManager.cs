using AutoMapper;
using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Application.Managers;

public class ActivityManager(IBaseActivity _baseActivity, IMapper mapper) : IActivityManager
{
    public string GetDescription()
    {
        return _baseActivity.GetDescription();
    }

    public ActivityDto SetActivityType(ActivityDto activityDto)
    {
        Activity activity = mapper.Map<Activity>(activityDto);
        activity = _baseActivity.SetActivityType(activity);
        return mapper.Map<ActivityDto>(activity);
    }

    public void SetBaseActivity(IBaseActivity baseActivity)
    {
        _baseActivity = baseActivity;
    }
}
