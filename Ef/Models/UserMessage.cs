using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class UserMessage
    {
        [Key]
        public int MessageId {get;set;}
        public string Body {get;set;}
        public DateTime DateTime {get;set;}
        public int User1Id {get;set;}
        public virtual User User1 {get;set;}
        public int User2Id {get;set;}
        public virtual User User2 {get;set;}
    }
}