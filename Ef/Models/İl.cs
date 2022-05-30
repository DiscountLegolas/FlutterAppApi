using System.ComponentModel.DataAnnotations;
namespace Api.Ef.Models
{
    public class İl
    {
        public int İlId{get;set;}
        [Required]
        public string Name{get;set;}
        public virtual ICollection<İlçe> İlçeler{get;set;}
    }
}