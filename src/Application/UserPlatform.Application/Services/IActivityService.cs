using UserPlatform.Domain.Entities;

namespace UserPlatform.Application.Services;

public interface IActivityService
{
    public void CreateActivity(Activity activity);
    public List<Activity> GetUserActivityList(int userId);
    public List<Activity> GetActivityList();
}
