using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class User
    {
        public int UserId{get;set;}
        [Required]
        public string UserName {get;set;}
        [Required]
        public string Password {get;set;}
        [Required]
        public string EMail {get;set;}
        public string? Telefon {get;set;}
        public virtual ICollection<UserMessage> User1Messages{get;set;}
        public virtual ICollection<UserMessage> User2Messages{get;set;}
        public virtual ICollection<TherapistMessage> TherapistMessages{get;set;}
    }
}