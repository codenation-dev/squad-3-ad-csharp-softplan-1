using AutoMapper;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;

namespace ErrorCenter.Application.Mapping
{
    public class AutoMappingDomainToViewModel : Profile
    {
        public AutoMappingDomainToViewModel()
        {
            //CreateMap<Cliente, ClienteViewModel>();

            CreateMap<Environment, EnvironmentViewModel>();

        }
    }
}
