using Microsoft.AspNetCore.Mvc;
using Api.Ef.Models;
using Newtonsoft.Json;
using Api.Dtos.Request;
using Api.Dtos.Object;
using AutoMapper;
using Api.RepositoryPattern.Services.Interface;
using Api.RepositoryPattern.Repos.Interface;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private IMapper _mapper;
    private IPostsService _postsService;
    public PostsController(IMapper mapper,IPostsService postsService)
    {
        _postsService = postsService;
        _mapper = mapper;
    }
    [HttpGet]
    [Route("GetAllPosts")]
    public IActionResult GetAllPosts()
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetAllPosts());
            return Ok(posts);
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
    [HttpGet]
    [Route("GetNewest5Posts")]
    public IActionResult GetNewest5Posts()
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetAllPosts().Where(x=>x.DateTime.Month==DateTime.Now.Month).OrderBy(a=>a.DateTime));
            return Ok(posts.Take(5));
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
    [HttpGet]
    [Route("GetPostsByDate/{dateTime}")]
    public IActionResult GetPostsByDate(DateTime dateTime)
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetPostsByMinDate(dateTime));
            return Ok(posts);
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
    [HttpPost]
    [Route("GetPostsByTopic")]
    public IActionResult GetPostsByTopic([FromBody]TopicRequestDto topicRequest)
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetPostsByTopics(topicRequest.Topics));
            return Ok(posts);
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
    [HttpGet]
    [Route("GetPostsByTherapist/{tıd}")]
    public IActionResult GetPostsByTherapist(int tıd)
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetPostsByTherapist(tıd));
            return Ok(posts);
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
    [HttpGet]
    [Route("GetPostsByTherapistNameSurname/{str}")]
    public IActionResult GetPostsByTherapistNameSurname(string str)
    {
        try
        {
            List<PostDto> posts=_mapper.Map<List<PostDto>>(_postsService.GetAllPosts().Where(x=>x.Publisher.Name.Contains(str)||x.Publisher.Surname.Contains(str)));
            return Ok(posts);
        }
        catch (System.Exception)
        {
            return Problem("Something Went Wrong");
        }
    }
}