using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class İlçe
    {
        public int İlçeId{get;set;}
        [Required]
        public string Name{get;set;}
        public int İlId {get;set;}
        public virtual İl İl {get;set;}
    }
}