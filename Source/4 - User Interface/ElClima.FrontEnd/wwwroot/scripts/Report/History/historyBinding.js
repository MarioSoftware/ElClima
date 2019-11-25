var WebApiBaseUrl = "/api/History";
var momentDateFormat = "D/M/YYYY";
var vm = new Vue({
    el: "#history",
    data: { 
        id: 0, 
        descripcion: "",  
        observacion: "",
        fechaHoraCreada:"",
        idPersona: 0,
        aportarImagen:false,
        ubicacion: {
            id: 0,
            latitud: 0,
            longitud: 0,
            direccion: ""
        },

        p_ObservationContent:false,

        p_selectedLocation: {
            id: 0,
            latitud: -31.40939075600147,
            longitud: -64.19578217022752,
            direccion: ""
        },

        p_ValidationCredentials:[],
        p_ErrorMessage: "", 
        p_SuccessMessage: "",
        p_ValidationMessage:"",
        p_geolocationMapShowView:false
    },
    
    methods: { 

        OpenMap: function () {  
            vm.$data.p_geolocationMapShowView = true;
            window.DrawMap();
        }
        
       
        
    },
    watch: {
        observacion: function (newVal, oldVal) {
            if (vm.$data.p_ObservationContent && !newVal.length)
                vm.$data.p_ObservationContent = false;
        }
    },
    computed: {
        
    }

}); 

function HydrateFields(data) {
    vm.$data.apellido = data.apellido;
    vm.$data.nombre = data.nombre;
    vm.$data.dni = data.dni;
    vm.$data.idSexo = data.idSexo;
    vm.$data.fechaNacimiento = data.fechaNacimiento;
    vm.$data.email = data.email;

    vm.$data.domicilio.idProvincia = data.domicilio.idProvincia; 
    vm.$data.domicilio.calle = !data.domicilio.calle ? "" : data.domicilio.calle;
    vm.$data.domicilio.numero = !data.domicilio.numero ? "" : data.domicilio.numero;
    vm.$data.domicilio.piso = data.domicilio.piso;
    vm.$data.domicilio.departamento= data.domicilio.departamento;
    vm.$data.domicilio.barrio = data.domicilio.barrio;
    vm.$data.p_comboProvincia = data.domicilio.comboProvincia; 

    if (data.domicilio.localidad !== null)
        vm.$data.domicilio.localidad = data.domicilio.localidad;
    if (data.domicilio.ubicacion !== null && data.domicilio.ubicacion)
        vm.$data.domicilio.ubicacion = data.domicilio.ubicacion;
    
}
 