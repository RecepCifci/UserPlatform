using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserPlatform.Application.Dtos;
using UserPlatform.Application.Services;

namespace UserPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController(IActivityService activityService, IUserService userService, IValidator<ActivityDto> _activityDtoValidator) : ControllerBase
    {
        [HttpPost]
        public IResult Post(ActivityDto activity)
        {
            var validator = _activityDtoValidator.Validate(activity);
            if (!validator.IsValid) throw new Exception(string.Join("\n", validator.Errors));

            bool isUserExists = userService.CheckUserIfExists(activity.UserId);
            if (!isUserExists) throw new Exception($"{activity.UserId} id li kullanıcı bulunamadı");

            activityService.CreateActivity(activity);
            return Results.Ok();
        }

        [HttpGet]
        public IResult GetActivities()
        {
            return Results.Ok(activityService.GetActivityList());
        }
    }
}
