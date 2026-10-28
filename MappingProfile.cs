using AutoMapper;
using Finall_ASP.NET.DTOs;
using Finall_ASP.NET.Models;

namespace Finall_ASP.NET
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
        }
    }
}