
using AutoMapper;
using ElClima.ApplicationServices.Services.Comun;
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
                    cfg.CreateMap<Ubicacion, UbicacionDto>().ReverseMap();

                    cfg.CreateMap<Historia, HistoriaDto>()
                     .ForMember(dest => dest.idPersona, opt => opt.MapFrom(org => org.persona == null ? 0 : org.persona.id))
                     .ForMember(dest => dest.fechaHoraCreada, opt => opt.MapFrom(org => org.fechaHoraCreada == DateTime.MinValue ? "" : org.fechaHoraCreada.ToShortDateString()))
                     .ForMember(dest => dest.ubicacion, opt => opt.MapFrom(org => org.ubicacion == null ? new Ubicacion() : org.ubicacion))
                     .ReverseMap()
                     .ForMember(dest => dest.ubicacion, opt => opt.Ignore())
                     .ForMember(dest => dest.persona, opt => opt.Ignore());

                }).CreateMapper();
            }
        }
        public Historia GetEntityFromDto(HistoriaDto dto)
        {
            var entity = _mapper.Map<Historia>(dto);

            entity.ubicacion = new Ubicacion {
                id =dto.ubicacion.id,
                latitud =dto.ubicacion.latitud,
                longitud =dto.ubicacion.longitud,
                direccion = dto.ubicacion.direccion};

            entity.persona = new Service<Persona>(UnitOfWork).GetOne(dto.idPersona);

            return entity;
        }

        public void InsertDto(HistoriaDto dto)
        {
            dto.id = 0;

            var item = GetEntityFromDto(dto);

            UnitOfWork.SetAsAdded(item);
            UnitOfWork.SetAsAdded(item.ubicacion);
            UnitOfWork.SetAsAdded(item.persona);
            Insert(item);
        }
    }
}
