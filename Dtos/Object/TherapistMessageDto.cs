namespace Api.Dtos.Object
{
    public class TherapistMessageDto
    {
        public string Body {get;set;}
        public DateTime DateTime {get;set;}
        public int UserId {get;set;}
        public int TherapistId {get;set;}
    }
}