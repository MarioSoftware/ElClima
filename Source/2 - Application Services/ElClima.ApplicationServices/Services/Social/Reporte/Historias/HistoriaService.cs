
using AutoMapper;
using ElClima.ApplicationServices.Services.Social.Reporte.Historias.Dtos;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Reporte.Historia;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;

namespace ElClima.ApplicationServices.Services.Social.Reporte.Historias
{
    public class HistoriaService : Service<Historia>
    {
        private static IMapper _mapper;

        public HistoriaService() : base()
        {
            if (_mapper == null)
            {
                _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Historia, HistoriaDto>()
                     .ForMember(dest => dest.idPersona, opt => opt.MapFrom(org => org.persona == null ? 0 : org.persona.id))
                     .ForMember(dest => dest.fechHoraCreada,opt => opt.MapFrom(org =>org.fechHoraCreada == DateTime.MinValue ? "" : org.fechHoraCreada.ToShortDateString()))
                     .ForMember(dest => dest.idUbicacion, opt =>opt.MapFrom(org => org.ubicacion==null?0:org.ubicacion.id))
                     .ReverseMap();

                }).CreateMapper();
            }
        }
        public Historia GetEntityFromDto(HistoriaDto dto)
        {
            var entity = _mapper.Map<Historia>(dto);
            entity.ubicacion = new Ubicacion { id = dto.idUbicacion };
            entity.persona = new Persona { id = dto.idPersona };

            return entity;
        }

        public void InsertDto(HistoriaDto dto)
        {
            dto.id = 0;

            var item = GetEntityFromDto(dto);

            UnitOfWork.SetAsAdded(item);

            Insert(item);
        }
    }
}
