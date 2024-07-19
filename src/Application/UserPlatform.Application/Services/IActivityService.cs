using UserPlatform.Application.Dtos;

namespace UserPlatform.Application.Services;

public interface IActivityService
{
    public void CreateActivity(ActivityDto activity);
    public List<ActivityDto> GetUserActivityList(int userId);
    public List<ActivityDto> GetActivityList();
}
