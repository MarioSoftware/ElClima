using AutoMapper;
using ElClima.ApplicationServices.Services.Comun;
using ElClima.ApplicationServices.Services.Social.Sujeto.Dtos;
using ElClima.Domain.Model.Models.Comun;
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
                     .ForMember(dest => dest.idSexo, opt => opt.MapFrom(org => org.sexo == null ? 0 : org.sexo.id))
                     .ForMember(dest => dest.fechaNacimiento, opt => opt.MapFrom(org => org.fechaNacimiento == DateTime.MinValue ? "" : org.fechaNacimiento.ToShortDateString()))
                     .ForMember(dest => dest.domicilio, opt => opt.Ignore())
                     .ForMember(dest => dest.ubicacion, opt => opt.Ignore())
                     .ReverseMap();

                    cfg.CreateMap<Ubicacion, UbicacionDto>().ReverseMap();

                    cfg.CreateMap<Domicilio, DomicilioDto>()
                    .ForMember(dest => dest.idLocalidad, opt => opt.MapFrom(org => org.localidad == null ? 0 : org.localidad.id))
                    .ForMember(dest => dest.idProvincia, opt => opt.MapFrom(org => org.provincia == null ? 0 : org.provincia.id))
                    .ReverseMap();

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
                    i => i.ubicacion,
                    i =>i.domicilio);
            }
            else
                entity = _mapper.Map<Persona>(dto);

            return entity;
        }

        public void InsertDto(PersonaDto dto)
        {

            TrimUniqueFields(dto);

            dto.id = 0;
            var item = GetEntityFromDto(dto); 

            UnitOfWork.SetAsAdded(item);
            UnitOfWork.SetAsAdded(item.domicilio);

            Insert(item);
        }

        public PersonaDto GetDto(int id)
        {
            var persona = id == -1 ? new Persona()
                : GetOneIncluding(id,
                i => i.ubicacion,
                i => i.sexo,
                i => i.domicilio);



            var ret = _mapper.Map<PersonaDto>(persona);

            if(ret.domicilio == null)
            {
                ret.domicilio = new DomicilioDto { comboProvincia = new Service<Provincia>(UnitOfWork).GetAll()}; 
            } 

            return ret;

        }

        public List<LocalidadLiteDto> GetComboLocalities(int idProvince)
        {
            var result = new Service<Localidad>(UnitOfWork).GetByFilterBySelector(
                 l => new LocalidadLiteDto
                 {
                     id = l.id,
                     nombre = l.nombre
                 },
                 f=> f.provincia.id == idProvince                 
                );

            return result;
        }

        private static void TrimUniqueFields(PersonaDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.dni))
                dto.dni = dto.dni.Trim();
        }

        public bool ExistPerson(string dni)
        {
            var exist = false;
            if (!string.IsNullOrWhiteSpace(dni))
            {
                var personas = GetByFilter(f => f.dni == dni);

                exist = personas.Count != 0;
            }
            return exist;
        }
    }
}