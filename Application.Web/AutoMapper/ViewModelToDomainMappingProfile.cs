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
            CreateMap<Exame, ExameViewModel>();
            CreateMap<Consulta, ConsultaViewModel>();
            CreateMap<Paciente, PacienteViewModel>();
            CreateMap<TipoExame, TipoExameViewModel>();
        }
    }
}