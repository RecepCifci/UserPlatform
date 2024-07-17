using UserPlatform.Domain.Entities;
using UserPlatform.Infrastructure;
using UserPlatform.Infrastructure.Repository;

namespace UserPlatform.Application.Services;

public class ActivityService(ApplicationDbContext applicationDbContext) : BaseRepository<Activity, ApplicationDbContext>(applicationDbContext), IActivityService
{

    public void CreateActivity(Activity activity)
    {
        Add(activity);
    }
    public List<Activity> GetUserActivityList(int userId)
    {
        return GetList(x => x.UserId == userId).ToList() ?? throw new Exception($"{userId} idli kullanıcıya ait aktivite bulunamadı");
    }
    public List<Activity> GetActivityList()
    {
        return GetList().ToList() ?? throw new Exception($"Sistemde aktivite bulunamadı");
    }
}
