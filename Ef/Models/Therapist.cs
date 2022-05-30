using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class Therapist
    {
        public int TherapistId{get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Surname {get;set;}
        [Required]
        public string Password {get;set;}
        [Required]
        public string EMail {get;set;}
        public string? Telefon {get;set;}
        [Required]
        public string Adres {get;set;}
        public bool Aproved {get;set;}
        public int İlçeId {get;set;}
        public virtual İlçe İlçe {get;set;}
        public virtual ICollection<Post> Posts {get;set;}
        public virtual ICollection<TherapistMessage> Messages {get;set;}
    }
}