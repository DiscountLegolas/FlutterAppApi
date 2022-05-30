namespace Api.Dtos.Request
{
    public class TherapistSignUp_UpdateDto
    {
        public string Name {get;set;}
        public string Surname {get;set;}
        public string Password {get;set;}
        public string EMail {get;set;}
        public string? Telefon {get;set;}
        public string Adres {get;set;}
        public int İlçeId {get;set;}
    }
}