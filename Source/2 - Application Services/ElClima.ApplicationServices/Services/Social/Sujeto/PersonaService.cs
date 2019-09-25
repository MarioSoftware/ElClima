using AutoMapper;
using ElClima.ApplicationServices.Services.Comun;
using ElClima.ApplicationServices.Services.Social.Sujeto.Dtos;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElClima.ApplicationServices.Services.Social.Sujeto
{
    public class PersonaService : Service<Persona>
    {
        private static IMapper _mapper;

        public PersonaService() : base()
        {
            if (_mapper == null)
            {
                _mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Persona, PersonaDto>()
                     .ForMember(dest => dest.idSexo, opt => opt.ResolveUsing(org => org.sexo == null ? 0 : org.sexo.id))
                     .ForMember(dest => dest.fechaNacimiento, opt => opt.ResolveUsing(org => org.fechaNacimiento == DateTime.MinValue ? "" : org.fechaNacimiento.ToShortDateString()))
                     .ReverseMap();
                    cfg.CreateMap<Ubicacion, UbicacionDto>().ReverseMap();

                }).CreateMapper();
            }
        }

        public Persona GetEntityFromDto(PersonaDto dto)
        {
            Persona entity = null;

            if (dto.id > 0)
            {
                entity = GetOneIncluding(
                    dto.id,
                    i => i.sexo,
                    i => i.ubicacionActual);
            }
            else
                entity = _mapper.Map<Persona>(dto);

            return entity;
        }

        public void InsertDto(PersonaDto dto)
        { 

            dto.id = 0;
            var item = GetEntityFromDto(dto);
             
             
            UnitOfWork.SetAsAdded(item);
            Insert(item);
        }

        public PersonaDto GetDto(int id)
        {
            var persona = id == -1 ? new Persona() 
                : GetOneIncluding(
                id,
                i=> i.ubicacionActual);

            if (persona == null) return null;

            var ret = _mapper.Map<PersonaDto>(persona);

            return ret;
        }
    }
}
