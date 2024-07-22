using AutoMapper;
using UserPlatform.Application.Dtos;
using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Entities;
using UserPlatform.Infrastructure;
using UserPlatform.Infrastructure.Repository;

namespace UserPlatform.Application.Services;

public class ActivityService(ApplicationDbContext applicationDbContext, IMapper mapper, IBaseActivity baseActivity) : BaseRepository<Activity, ApplicationDbContext>(applicationDbContext), IActivityService
{

    public void CreateActivity(ActivityDto activity)
    {
        Add(mapper.Map<Activity>(activity));
    }
    public List<ActivityDto> GetUserActivityList(int userId)
    {
        return mapper.Map<List<ActivityDto>>(GetList(x => x.UserId == userId).ToList()) ?? throw new Exception($"{userId} idli kullanıcıya ait aktivite bulunamadı");
    }
    public List<ActivityDto> GetActivityList()
    {
        return mapper.Map<List<ActivityDto>>(GetList().ToList()) ?? throw new Exception($"Sistemde aktivite bulunamadı");
    }
    public List<ActivityDto> GetActivityListByType(int type)
    {
        return mapper.Map<List<ActivityDto>>(GetList().ToList()) ?? throw new Exception($"Sistemde aktivite bulunamadı");
    }
}
