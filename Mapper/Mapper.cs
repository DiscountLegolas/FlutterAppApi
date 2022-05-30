using Api.Ef.Models;
using Api.Dtos.Request;
using Api.Dtos.Object;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Api.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            Func<User,List<UserMessageDto>> allusermessages= a=>
            {
                List<UserMessageDto> userMessageDtos=new List<UserMessageDto>();
                List<UserMessage> userMessages=a.User1Messages.ToList();
                userMessages.AddRange(a.User2Messages);
                foreach (UserMessage user in userMessages)
                {
                    UserMessageDto userMessageDto=new UserMessageDto(){Body=user.Body,DateTime=user.DateTime,User1Id=user.User1Id,User2Id=user.User2Id};
                    userMessageDtos.Add(userMessageDto);
                }
                return userMessageDtos;
            };
            CreateMap<UserSignUp_UpdateDto,User>();
            CreateMap<UserLogin,User>();
            CreateMap<TherapistLogin,Therapist>();
            CreateMap<TherapistSignUp_UpdateDto,Therapist>();
            CreateMap<AddPostRequestDto,Post>().ForMember(a=>a.TherapistId,m=>m.MapFrom(x=>x.Therapistıd));
            CreateMap<UpdatePostRequestDto,Post>();
            CreateMap<Therapist,TherapistDto>().ForMember(X=>X.TherapistMessages,m=>m.MapFrom(b=>b.Messages)).ForMember(X=>X.İl,m=>m.MapFrom(b=>b.İlçe.İl.Name)).ForMember(X=>X.İlçe,m=>m.MapFrom(b=>b.İlçe.Name));
            CreateMap<Post,PostDto>().ForMember(x=>x.Therapist,m=>m.MapFrom(t=>t.Publisher));
            CreateMap<UserMessage,UserMessageDto>();
            CreateMap<TherapistMessage,TherapistMessageDto>();
            CreateMap<User,UserDto>().ForMember(a=>a.UserMessages,m=>m.MapFrom(b=>allusermessages(b))).ForMember(t=>t.TherapistMessages,m=>m.MapFrom(e=>e.TherapistMessages));

        }   
    }
}