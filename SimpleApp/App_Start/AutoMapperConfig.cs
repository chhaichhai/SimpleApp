using SimpleApp.DataLayer.Model;
using SimpleApp.Models;

namespace SimpleApp
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Patient, PatientVM>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Donor, DonorVM>().ReverseMap();
        }
    }
}