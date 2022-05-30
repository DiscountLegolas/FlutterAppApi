using Microsoft.AspNetCore.Mvc;
using Api.Ef.Models;
using Newtonsoft.Json;
using Api.Dtos.Request;
using Api.Dtos.Object;
using AutoMapper;
using Api.RepositoryPattern.Services.Interface;
using Api.RepositoryPattern.Repos.Interface;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IUserService _userservice;
        public UserController(IMapper mapper,IUserService userservice)
        {
            _userservice = userservice;
            _mapper = mapper;
        }
        [Route("GetUser/{userıd}")]
        [HttpGet]
        public IActionResult GetAllUsersbyId(int userıd)
        {
            UserDto user=_mapper.Map<UserDto>(_userservice.GetUsers().Single(x=>x.UserId==userıd));
            return Ok(user);
        }
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetAllUsersbyName(string? filtertext="")
        {
            List<UserDto> users=_mapper.Map<List<UserDto>>(_userservice.GetUsers().Where(x=>x.UserName.Contains(filtertext)));
            return Ok(users);
        }
        [Route("User")]
        [HttpPost]
        public IActionResult AddUser([FromBody] UserSignUp_UpdateDto usersignupdto)
        {
            User user=_mapper.Map<User>(usersignupdto);
            bool a=_userservice.AddUser(user);
            if (a)
            {
                int userıd=_userservice.GetUsers().Single(x=>(x.UserName==user.UserName&&x.Password==user.Password)||(x.EMail==user.EMail&&x.Password==user.Password)).UserId;
                return Ok(userıd);
            }
            else
            {
              return Problem("Something Went Wrong");
            }
        }
        [Route("User/{userıd}")]
        [HttpPut]
        public IActionResult UpdateUser(int userıd,[FromBody] UserSignUp_UpdateDto usersignupdto)
        {
            User user=_mapper.Map<User>(usersignupdto);
            bool a=_userservice.UpdateUser(userıd,user);
            if (a)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("{userıd}")]
        [HttpDelete]
        public IActionResult DeleteUser(int userıd)
        {
            bool a=_userservice.DeleteUser(userıd);
            if (a)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            User user=_mapper.Map<User>(userLogin);
            bool a=_userservice.Login(user);
            if (a)
            {
                int userıd=_userservice.GetUsers().Single(x=>(x.UserName==user.UserName&&x.Password==user.Password)||(x.EMail==user.EMail&&x.Password==user.Password)).UserId;
                return Ok(userıd);
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("UserMessaging")]
        [HttpPost]
        public IActionResult UserMessaging([FromBody] UserMesssagingDto userMesssaging)
        {
            if (userMesssaging.User1Id==userMesssaging.User2Id)
            {
                return Problem("User Can't sent message to itself");
            }
            bool a=_userservice.SendMessageToUser(userMesssaging.User1Id,userMesssaging.User2Id,userMesssaging.Body);
            if (a)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("TherapistMessaging")]
        [HttpPost]
        public IActionResult TherapistMessaging([FromBody] SendTherapistMessageRequestDto therapistMessageRequestDto)
        {
            bool a=_userservice.SendMessageToTherapist(therapistMessageRequestDto.UserId,therapistMessageRequestDto.TherapistId,therapistMessageRequestDto.Body);
            if (a)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
    }
}
