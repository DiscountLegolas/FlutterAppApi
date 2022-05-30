namespace Api.Dtos.Object
{
    public class UserDto
    {
        public int UserId {get;set;}
        public string UserName {get;set;}
        public string EMail {get;set;}
        public string? Telefon {get;set;}
        public ICollection<UserMessageDto> UserMessages{get;set;}
        public ICollection<TherapistMessageDto> TherapistMessages{get;set;}
    }
}