using AutoMapper;
using Domain.Entities;
using Shared.ViewModels;

namespace Application.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<PacienteViewModel, Paciente>();
        }
    }
}