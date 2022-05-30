namespace Api.Dtos.Object
{
    public class TherapistDto
    {
        public int TherapistId {get;set;}
        public string Name {get;set;}
        public string Surname {get;set;}
        public string EMail {get;set;}
        public string? Telefon {get;set;}
        public string Adres {get;set;}
        public string İl{get;set;}
        public string İlçe{get;set;}
        public ICollection<TherapistMessageDto> TherapistMessages{get;set;}
        
    }
}