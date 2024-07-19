using Microsoft.AspNetCore.Mvc;
using UserPlatform.Application.Services;

namespace UserPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IActivityService activityService) : ControllerBase
    {
        [HttpGet("{userId}/activities")]
        public IResult GetUserActivities(int userId)
        {
           return Results.Ok(activityService.GetUserActivityList(userId));
        }
    }
}
