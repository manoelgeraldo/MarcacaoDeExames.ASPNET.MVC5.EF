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
            CreateMap<PacienteViewModel, Paciente>()
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date.ToString("d")));
            CreateMap<ConsultaViewModel, Consulta>()
                .ForMember(d => d.DataConsulta, o => o.MapFrom(x => x.DataConsulta.Date.ToString("d")))
                .ForMember(d => d.HorarioConsulta, o => o.MapFrom(x => x.HorarioConsulta.ToString("t")));

            CreateMap<TipoExameViewModel, TipoExame>();
        }
    }
}