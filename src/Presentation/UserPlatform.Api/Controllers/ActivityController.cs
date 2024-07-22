using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserPlatform.Application.Dtos;
using UserPlatform.Application.Managers;
using UserPlatform.Application.Services;
using UserPlatform.Domain.Activities;
using UserPlatform.Domain.Activities.Base;
using UserPlatform.Domain.Enums;

namespace UserPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController(IActivityManager activityManager, IActivityService activityService, IUserService userService, IValidator<ActivityDto> _activityDtoValidator) : ControllerBase
    {
        [HttpPost]
        public IResult Post(ActivityDto activity)
        {
            var validator = _activityDtoValidator.Validate(activity);
            if (!validator.IsValid) throw new Exception(string.Join("\n", validator.Errors));

            bool isUserExists = userService.CheckUserWithIdIfExists(activity.UserId);
            if (!isUserExists) throw new Exception($"{activity.UserId} id li kullanıcı bulunamadı");

            IBaseActivity baseActivity = activity.Type switch
            {
                ActivityTypes.Login => baseActivity = new LoginActivity(),
                ActivityTypes.Paging => baseActivity = new PagingActivity(),
                ActivityTypes.ViewReport => baseActivity = new DownloadReportActivity(),
                ActivityTypes.DownloadReport => baseActivity = new ViewReportActivity(),
                _ => throw new Exception("Invalid Activity Type"),
            };

            activityManager.SetBaseActivity(baseActivity);

            activityService.CreateActivity(activity);
            return Results.Ok(activityManager.GetDescription());
        }

        [HttpGet]
        public IResult GetActivities()
        {
            return Results.Ok(activityService.GetActivityList());
        }
    }
}
