using AutoMapper;
using PinewoodDMS.Application.DTOs.Customers;
using PinewoodDMS.Domain;

namespace PinewoodDMS.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            #region Customers Mappings

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Customer, CreateCustomerDto>().ReverseMap();

            #endregion Customers
        }
    }
}
