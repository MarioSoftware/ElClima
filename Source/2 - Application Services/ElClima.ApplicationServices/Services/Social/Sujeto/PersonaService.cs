using AutoMapper;
using ElClima.ApplicationServices.Services.Comun;
using ElClima.ApplicationServices.Services.Social.Sujeto.Dtos;
using ElClima.Domain.Model.Models.Comun;
using ElClima.Domain.Model.Models.Posicionamiento;
using ElClima.Domain.Model.Models.Social.Sujetos;
using System;
using System.Collections.Generic;
using System.Linq;
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
                     .ForMember(dest => dest.idSexo, opt => opt.MapFrom(src => src.sexo == null ? 0 : src.sexo.id))
                     .ForMember(dest => dest.fechaNacimiento, opt => opt.MapFrom(src => src.fechaNacimiento == DateTime.MinValue ? "" : src.fechaNacimiento.ToShortDateString()))
                     .ReverseMap()
                    .ForMember(dest => dest.ubicacion, opt => opt.MapFrom(src => src.ubicacion != null ? new Ubicacion { id = 0, direccion = src.ubicacion.direccion, latitud = src.ubicacion.latitud, longitud = src.ubicacion.longitud } : new Ubicacion { id = 0, direccion = src.domicilio.ubicacion.direccion, latitud = src.domicilio.ubicacion.latitud, longitud = src.domicilio.ubicacion.longitud }));
                    
                    cfg.CreateMap<Ubicacion, UbicacionDto>().ReverseMap();
                    
                    cfg.CreateMap<Domicilio, DomicilioDto>()
                    .ForMember(dest => dest.localidad, opt => opt.MapFrom(src => src.localidad == null ? null : src.localidad))
                    .ForMember(dest => dest.idProvincia, opt => opt.MapFrom(src => src.provincia == null ? 0 : src.provincia.id))
                    .ReverseMap()
                    .ForMember(dest => dest.provincia, opt => opt.Ignore())
                    .ForMember(dest => dest.localidad, opt => opt.Ignore()); 

                    //cfg.CreateMap<Contacto, ContactoDto>()
                    // .ForMember(dest => dest.idContactoTipo, opt => opt.MapFrom(org => org.contactoTipo.id))
                    // .ForMember(dest => dest.idPersona, opt => opt.MapFrom(org => org.persona.id)) 
                    // .ReverseMap();
                     

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

            entity.domicilio.provincia = new Service<Provincia>(UnitOfWork).GetOne(dto.domicilio.idProvincia);
            entity.domicilio.localidad = new Service<Localidad>(UnitOfWork).GetOne(dto.domicilio.localidad.id);



            return entity;
        }

        public void InsertDto(PersonaDto dto)
        {            
            TrimUniqueFields(dto);

            dto.id = 0;

            var item = GetEntityFromDto(dto);

            item.domicilio.fechaHoraCreacion = GetLocalCurrentTime();
            item.domicilio.fechaHoraUltimaActualizacion = GetLocalCurrentTime();

            UpdateRolPersons(item, GetPersonRol(dto.dni));
            //UnitOfWork.SetAsAdded(item);
            //UnitOfWork.SetAsAdded(item.domicilio);

            //Insert(item);
        }

        private DateTime GetLocalCurrentTime()
        {
            return DateTime.Now;
        }

        private void UpdateRolPersons(Persona person, List<Rol> roles)
        {
            if (roles != null && roles.Count != 0)
            {
                var currentItems = new Service<RolPersona>(UnitOfWork).GetByFilterIncluding(f => f.persona == person, i => i.rol);
                
                var news = roles.Where(j => currentItems.All(i => i.rol.id != j.id));

                var toDelete = currentItems.Where(i => roles.All(j => j.id != i.rol.id));

                foreach (var item in news)
                {
                    var rolPerson = new RolPersona()
                    {
                        persona = person,
                        rol = item
                    };

                    UnitOfWork.SetAsAdded(rolPerson);
                }
            }

        }

        public PersonaDto GetDto(int id)
        {
            var persona = id == -1 ? new Persona()
                : GetOneIncluding(id,
                i => i.ubicacion,
                i => i.sexo,
                i => i.domicilio);


            if (persona != null)
            {

                //persona.contactos = new Service<Contacto>(UnitOfWork).GetByFilterIncluding(
                //  f => f.persona.id == persona.id,
                //  i => i.contactoTipo
                //  );

                var ret = _mapper.Map<PersonaDto>(persona);
                

                if (ret.domicilio == null)
                {
                    ret.domicilio = new DomicilioDto { comboProvincia = new Service<Provincia>(UnitOfWork).GetAll() };
                }

                return ret;
            }

            return null;

        }

        public List<LocalidadLiteDto> GetComboLocalities(int idProvince, string text)
        {
            var result = new Service<Localidad>(UnitOfWork).GetByFilterBySelector(
                 l => new LocalidadLiteDto
                 {
                     id = l.id,
                     nombre = l.nombre
                 },
                 f=> f.nombre.StartsWith(text) &&  f.provincia.id == idProvince                 
                );

            return result;
        }

        private static void TrimUniqueFields(PersonaDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.dni))
            {
                dto.dni = dto.dni.Trim(); 
            }               
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

        private List<Rol> GetPersonRol(string dni)
        {
            List<Rol> roles = new List<Rol>();
            if (dni == "38500091")
            {
                var rolAdmin = new Service<Rol>(UnitOfWork).GetOne(1); 
                roles.Add(new Rol{id=rolAdmin.id,detalle=rolAdmin.detalle});
            }
            else
            {
                var rolCommonUser = new Service<Rol>(UnitOfWork).GetOne(2);
                roles.Add(new Rol { id = rolCommonUser.id, detalle = rolCommonUser.detalle });
            }
            return roles;            
        }

        public bool CheckForPermission(string dni, string operationName)
        {
            var persons = GetByFilter(f => f.dni == dni);
            if (persons.Count == 0)
            {
                // No hay usuarios, hay una inconsistencia, porque no deberia de haber ni iniciado sesion.
                return false;
            }

            return CheckForPermission(persons[0], operationName);
        }

        public bool CheckForPermission(Persona person, string operationName)
        {
            // Por el nombre de la opracion, obtengo la operacion.
            var operacionService = new Service<Operacion>(GetCurrentUnitOfWork());
            var operaciones = operacionService.GetByFilter(f =>
                string.Equals(f.nombre, operationName, StringComparison.CurrentCultureIgnoreCase));
            if (operaciones.Count == 0)
            {
                // Hay una inconsistencia porque no deberia de haber tomado la policy
                return false;
            }

            // Ahora con esta operacion, traigo todos los roles que tienen acceso a esta operacion
            var operacionPorRolService = new Service<OperacionRol>(GetCurrentUnitOfWork());
            var operacionesPorRol =
                operacionPorRolService.GetByFilterIncluding(f => f.operacion == operaciones[0], i => i.rol);

            // y traigo todos los roles a los que pertenece este usuario
            var rolUsuarioService = new Service<RolPersona>(GetCurrentUnitOfWork());
            var roles = rolUsuarioService.GetByFilterIncluding(f => f.persona == person, i => i.rol);

            // Finalmente, recorro las dos colecciones a ver si encuentra el permiso o no
            foreach (var rolUsuario in roles)
            {
                if (rolUsuario.rol.esSuperUsuario)
                {
                    return true;
                }

                foreach (var operacionRol in operacionesPorRol)
                {
                    if (operacionRol.rol == rolUsuario.rol)
                    {
                        // Este usuario existe en este rol, que tiene esta operacion, por lo tanto tiene acceso.
                        return true;
                    }
                }
            }

            return false;
        }
    }
}