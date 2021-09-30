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
            CreateMap<ExameViewModel, Exame>();
            CreateMap<PacienteViewModel, Paciente>();
            CreateMap<ConsultaViewModel, Consulta>();
            CreateMap<TipoExameViewModel, TipoExame>();
        }
    }
}