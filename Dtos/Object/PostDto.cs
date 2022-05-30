namespace Api.Dtos.Object
{
    public class PostDto
    {
        public int PostId {get;set;}
        public string Title {get;set;}
        public string Content {get;set;}
        public DateTime DateTime {get;set;}
        public string Topic {get;set;}
        public TherapistDto Therapist {get;set;}
    }
}