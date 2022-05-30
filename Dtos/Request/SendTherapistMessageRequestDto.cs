namespace Api.Dtos.Request
{
    public class SendTherapistMessageRequestDto
    {
        public string Body {get;set;}
        public int TherapistId {get;set;}
        public int UserId {get;set;}
    }
}