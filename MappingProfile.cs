using AutoMapper;
using AFI.Dtos;
using AFI.Models;

namespace AFI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForCreationDto>();
            CreateMap<CustomerForCreationDto, Customer>();
        }
    }
}
