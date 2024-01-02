using AutoMapper;
using SuperSimpleSchedulingSystem.Data.Models;

namespace SuperSimpleSchedulingSystem.Logic.Models.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            this.CreateMap<Class, ClassDto>()
                .ReverseMap();
            this.CreateMap<Student, StudentDto>()
                .ReverseMap();
            this.CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
