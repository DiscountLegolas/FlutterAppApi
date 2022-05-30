using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class TherapistMessage
    {
        [Key]
        public int MessageId {get;set;}
        public string Body {get;set;}
        public DateTime DateTime {get;set;}
        public int UserId {get;set;}
        public virtual User User {get;set;}
        public int TherapistId {get;set;}
        public virtual Therapist Therapist {get;set;}
    }
}