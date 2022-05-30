namespace Api.Dtos.Request
{
    public class AddPostRequestDto
    {
        public string Title {get;set;}
        public string Content {get;set;}
        public string Topic {get;set;}
        public int Therapistıd {get;set;}
    }
    public class UpdatePostRequestDto
    {
        public string Title {get;set;}
        public string Content {get;set;}
        public string Topic {get;set;}

    }
}