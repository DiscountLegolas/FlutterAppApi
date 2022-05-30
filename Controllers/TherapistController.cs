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
    public class TherapistController: ControllerBase
    {
        private IMapper _mapper;
        private ITherapistService _therapistservice;
        public TherapistController(IMapper mapper,ITherapistService therapistService)
        {
            _therapistservice = therapistService;
            _mapper = mapper;
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] TherapistLogin therapistLogin)
        {
            Therapist therapist=_mapper.Map<Therapist>(therapistLogin);
            bool a=_therapistservice.Login(therapist);
            if (a)
            {
                therapist=_therapistservice.GetTherapists().Single(x=>(x.EMail==therapist.EMail&&x.Password==therapist.Password));
                TherapistDto therapistDto=_mapper.Map<TherapistDto>(therapist);
                return Ok(therapistDto);
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpGet]
        [Route("GetTherapist/{tıd}")]
        public IActionResult GetTherapist(int tıd)
        {
            try
            {
                TherapistDto therapist=_mapper.Map<TherapistDto>(_therapistservice.GetTherapists().First(x=>x.TherapistId==tıd));
                return Ok(therapist);
            }
            catch (System.Exception)
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpGet]
        [Route("GetTherapists")]
        public IActionResult GetTherapists(string? filtertext="")
        {
            try
            {
                List<TherapistDto> therapists=_mapper.Map<List<TherapistDto>>(_therapistservice.GetTherapists());
                return Ok(therapists.Where(x=>x.Name.Contains(filtertext)||x.Surname.Contains(filtertext)));
            }
            catch (System.Exception)
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpPost]
        [Route("Therapist")]
        public IActionResult AddTherapist([FromBody] TherapistSignUp_UpdateDto therapistsignupdto)
        {
            Therapist therapist=_mapper.Map<Therapist>(therapistsignupdto);
            bool executedsucccesfully=_therapistservice.AddTherapist(therapist);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("Therapist/{tıd}")]
        [HttpPut]
        public IActionResult UpdateTherapist(int tıd,[FromBody] TherapistSignUp_UpdateDto therapistsignupdto)
        {
            Therapist therapist=_mapper.Map<Therapist>(therapistsignupdto);
            bool executedsucccesfully=_therapistservice.UpdateTherapist(tıd,therapist);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [Route("{tıd}")]
        [HttpDelete]
        public IActionResult DeleteTherapist(int tıd)
        {
            bool executedsucccesfully=_therapistservice.DeleteTherapist(tıd);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpPost]
        [Route("TherapistMessage")]
        public IActionResult SendMessageToUser([FromBody] SendTherapistMessageRequestDto messageRequestDto)
        {
            bool executedsucccesfully=_therapistservice.MessageFromTherapistToUser(messageRequestDto.UserId,messageRequestDto.TherapistId,messageRequestDto.Body);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpPost]
        [Route("AddPost")]
        public IActionResult AddPost([FromBody] AddPostRequestDto addPost)
        {
            Post post=_mapper.Map<Post>(addPost);
            bool executedsucccesfully=_therapistservice.AddPost(post);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpPut]
        [Route("UpdatePost")]
        public IActionResult UpdatePost(int postıd,[FromBody] UpdatePostRequestDto updatePost)
        {
            Post post=_mapper.Map<Post>(updatePost);
            bool executedsucccesfully=_therapistservice.UpdatePost(postıd,post);
            if (executedsucccesfully)
            {
                return Ok();
            }
            else
            {
                return Problem("Something Went Wrong");
            }
        }
        [HttpDelete]
        [Route("DeletePost")]
        public IActionResult DeletePost(int postıd)
        {
            bool executedsucccesfully=_therapistservice.DeletePost(postıd);
            if (executedsucccesfully)
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