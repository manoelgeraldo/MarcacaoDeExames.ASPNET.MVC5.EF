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
            CreateMap<Consulta, ConsultaViewModel>()
                .ForMember(d => d.DataConsulta, o => o.MapFrom(x => x.DataConsulta.Date.ToString("d")))
                .ForMember(d => d.HorarioConsulta, o => o.MapFrom(x => x.HorarioConsulta.ToString("t")));
            CreateMap<Paciente, PacienteViewModel>()
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date.ToString("d")));
            CreateMap<TipoExame, TipoExameViewModel>();
        }
    }
}