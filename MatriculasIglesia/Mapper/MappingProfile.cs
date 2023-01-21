

using AutoMapper;
using Library.Data.Models;
using Library.Service.Common;
using MatriculasIglesia.Dtos.Actividades;
using MatriculasIglesia.Dtos.Matriculas;
using MatriculasIglesia.Dtos.Participaciones;
using MatriculasIglesia.Dtos.Personas;
using MatriculasIglesia.Dtos.Proyectos;
using MatriculasIglesia.Mapper.Iglesias;

namespace MatriculasIglesia.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Actividad
            CreateMap<Actividad, CreateEditActividadDto>()
                .ReverseMap();
            CreateMap<Actividad, ActividadDto>()
              .ForMember(dto => dto.TipoActividad, opt => opt.MapFrom(e => e.TipoActividad.Nombre))
              .ReverseMap();
            // End Actividad

            // Proyectos
            CreateMap<Proyecto, CreateEditProyectoDto>()
                .ReverseMap();
            CreateMap<Proyecto, ProyectoDto>()
              .ForMember(dto => dto.Iglesia, opt => opt.MapFrom(e => e.Iglesia.Nombre))
              .ForMember(dto => dto.Coordinador, opt => opt.MapFrom(e => e.Coordinador.FullName))
              .ForMember(dto => dto.Administrador, opt => opt.MapFrom(e => e.Administrador.FullName))
              .ReverseMap();
            // End Proyectos

            // Persona Mayor
            CreateMap<PersonaMayor, CreateEditPersonaMayorDto>()
                .ReverseMap();
            CreateMap<PersonaMayor, PersonaMayorDto>()
              .ForMember(dto => dto.FechaNac, opt => opt.MapFrom(e => e.FechaNac.ToString("yyyy-MM-dd")))
              .ForMember(dto => dto.SexoText, opt => opt.MapFrom(e => e.Sexo.ToString()))
              .ForMember(dto => dto.GradoEscolar, opt => opt.MapFrom(e => e.GradoEscolar.Nombre))
              .ForMember(dto => dto.Edad, opt => opt.MapFrom(e => Util.GetAge(e.FechaNac)))
              .ReverseMap();
            // End Persona Mayor

            // Nino
            CreateMap<Nino, CreateEditNinoDto>()
                .ReverseMap();
            CreateMap<Nino, NinoDto>()
              .ForMember(dto => dto.FechaNac, opt => opt.MapFrom(e => e.FechaNac.ToString("yyyy-MM-dd")))
              .ForMember(dto => dto.SexoText, opt => opt.MapFrom(e => e.Sexo.ToString()))
              .ForMember(dto => dto.GradoEscolar, opt => opt.MapFrom(e => e.GradoEscolar.Nombre))
              .ForMember(dto => dto.Edad, opt => opt.MapFrom(e => Util.GetAge(e.FechaNac)))
              .ForMember(dto => dto.CentroMadre, opt => opt.MapFrom(e => (e.Madre is PersonaMayor) ? (e.Madre as PersonaMayor).CentroTrabajo : null))
              .ForMember(dto => dto.CentroPadre, opt => opt.MapFrom(e => (e.Padre is PersonaMayor) ? (e.Padre as PersonaMayor).CentroTrabajo : null))
              .ForMember(dto => dto.NombreMadre, opt => opt.MapFrom(e => e.Madre.FullName))
              .ForMember(dto => dto.NombrePadre, opt => opt.MapFrom(e => e.Padre.FullName))
              .ReverseMap();
            // End Nino

            // Participacion
            CreateMap<Participacion, CreateEditParticipacionDto>()
                .ReverseMap();
            CreateMap<Participacion, ParticipacionDto>()
              .ForMember(dto => dto.Fecha, opt => opt.MapFrom(e => e.Fecha.ToString("yyyy-MM-dd")))
              .ForMember(dto => dto.Actividad, opt => opt.MapFrom(e => e.Actividad.Nombre))
              .ForMember(dto => dto.Nino, opt => opt.MapFrom(e => e.Nino.FullName))
              .ForMember(dto => dto.PersonaMayor, opt => opt.MapFrom(e => e.PersonaMayor.FullName))
              .ReverseMap();
            // End Participacion

            // Matriculas
            CreateMap<Matricula, CreateEditMatriculaDto>()
                .ReverseMap();
            CreateMap<Matricula, MatriculaDto>()
              .ForMember(dto => dto.Fecha, opt => opt.MapFrom(e => e.Fecha.ToString("yyyy-MM-dd")))
              .ForMember(dto => dto.Proyecto, opt => opt.MapFrom(e => e.Proyecto.Nombre))
              .ForMember(dto => dto.Nino, opt => opt.MapFrom(e => e.Nino.FullName))
              .ForMember(dto => dto.Responsable, opt => opt.MapFrom(e => e.Responsable.FullName))
              .ForMember(dto => dto.Horario, opt => opt.MapFrom(e => e.Horario.Rango))
              .ReverseMap();
            // End Matriculas
        }

        public static List<Profile> GetProfiles()
        {

            return new List<Profile>
            {
                new IglesiaToDto(),
                new IglesiaToEditDto(),
                new IglesiaToCreateDto(),
                new MappingProfile()
        };

        }

    }
}