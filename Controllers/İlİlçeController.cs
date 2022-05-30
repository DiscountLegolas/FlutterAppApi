using Api.RepositoryPattern.Services.Interface;
using Api.RepositoryPattern.Repos.Interface;
using Microsoft.AspNetCore.Mvc;
using Api.Ef.Models;
namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class İlİlçeController:ControllerBase
    {
        private IİlRepo _ilrepo;
        private IİlçeRepo _ilçerepo;
        public İlİlçeController(IİlRepo ilRepo,IİlçeRepo ilçeRepo)
        {
            _ilrepo=ilRepo;
            _ilçerepo=ilçeRepo;
        }
        [Route("Getİls")]
        [HttpGet]
        public IActionResult Getİlswithilçes(){
            return Ok(_ilrepo.GetİlsWithİlçes());
        }
        [Route("Getİlçesofil/{ilıd}")]
        [HttpGet]
        public IActionResult Getİlçesofil(int ilıd){
            return Ok(_ilrepo.GetİlsWithİlçes().Single(x=>x.İlId==ilıd).İlçeler.ToList());
        }
        [Route("Getİlofilçe/{ilçeıd}")]
        [HttpGet]
        public IActionResult Getİlofilçe(int ilçeıd){
            return Ok(_ilçerepo.GetİlçeWithItsİl(ilçeıd));
        }
    }
}