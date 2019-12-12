using AutoMapper;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;

namespace ErrorCenter.Application.Mapping
{
    public class AutoMappingViewModelToDomain : Profile
    {
        public AutoMappingViewModelToDomain()
        {
            CreateMap<EnvironmentViewModel, Environment>();
        }
    }
}
