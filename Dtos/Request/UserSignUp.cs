namespace Api.Dtos.Request
{
    public class UserSignUp_UpdateDto
    {
        public string UserName {get;set;}
        public string Password {get;set;}
        public string EMail {get;set;}
        public string? Telefon {get;set;}
    }
}