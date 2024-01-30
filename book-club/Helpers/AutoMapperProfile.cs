using AutoMapper;
using book_club.Database.Entity;
using book_club.DTOs;

namespace book_club.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<CreateUserDTO, User>();
        }
       
    }
}
