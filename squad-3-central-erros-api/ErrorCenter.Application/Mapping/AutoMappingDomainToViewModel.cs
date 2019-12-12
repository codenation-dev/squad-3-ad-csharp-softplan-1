using AutoMapper;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Domain.Models;

namespace ErrorCenter.Application.Mapping
{
    public class AutoMappingDomainToViewModel : Profile
    {
        public AutoMappingDomainToViewModel()
        {
            CreateMap<Environment, EnvironmentViewModel>();
            CreateMap<ErrorOccurrence, ErrorOccurrenceViewModel>();
            CreateMap<Error, ErrorViewModel>();
            CreateMap<Level, LevelViewModel>();
            CreateMap<Situation, SituationViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
