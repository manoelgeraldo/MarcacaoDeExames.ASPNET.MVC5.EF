using AutoMapper;
using Domain.Entities;
using Shared.ViewModels;

namespace Application.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<TipoExame, TipoExameViewModel>();
            CreateMap<Exame, ExameViewModel>();
        }
    }
}