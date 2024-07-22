using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserPlatform.Application.Dtos;
using UserPlatform.Application.Services;

namespace UserPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IActivityService activityService, IUserService userService, IValidator<UserDto> _userDtoValidator) : ControllerBase
    {
        [HttpGet("{userId}/activities")]
        public IResult GetUserActivities(int userId)
        {
           return Results.Ok(activityService.GetUserActivityList(userId));
        }
        [HttpPost]
        public IResult Post(UserDto userDto)
        {
            var validator = _userDtoValidator.Validate(userDto);
            if (!validator.IsValid) throw new Exception(string.Join("\n", validator.Errors));

            bool isUserExists = userService.CheckUserWithEmailAndPasswordIfExists(userDto.Email);
            if (isUserExists) throw new Exception($"{userDto.Email} email bilgisi ile sistemde kullanıcı bulunmaktadır");

            userService.CreateUser(userDto);
            return Results.Ok();
        }

    }
}
