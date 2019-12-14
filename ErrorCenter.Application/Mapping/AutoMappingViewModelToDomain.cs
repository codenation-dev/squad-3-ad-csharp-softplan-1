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

            CreateMap<ErrorOccurrenceViewModel, ErrorOccurrence>();
            CreateMap<ErrorViewModel, Error>();
            CreateMap<LevelViewModel, Level>();
            CreateMap<SituationViewModel, Situation>();
            CreateMap<UserViewModel, User>();

        }
    }
}
