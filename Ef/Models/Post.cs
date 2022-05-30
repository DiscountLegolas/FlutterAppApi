using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class Post
    {
        public int PostId {get;set;}
        [Required,MinLength(20)]
        public string Title {get;set;}
        [Required,MinLength(200)]
        public string Content {get;set;}
        public DateTime DateTime {get;set;}
        public bool Approved {get;set;}
        public string Topic {get;set;}
        [ForeignKey("Publisher")]
        public int TherapistId {get;set;}
        public virtual Therapist Publisher {get;set;}
    }
}