var WebApiBaseUrl = "/api/Persons";

var vm = new Vue({
    el: "#accountForm",
    data: { 
        id: 0,
        apellido: "",
        nombre: "",
        dni: "",
        fechaNacimiento:"",
        idSexo: 1, 
        domicilio: {
            idProvincia: 0,
            idLocalidad:0,
            calle: "",
            numero: "",
            piso: "",
            departamento: "",
            barrio: "",
            ubicacion: {
                id:0,
                latitud: 0,
                longitud: 0,
                direccion:""
            }
        },
        contrasenia:"",
        contraseniaRepetir:"",

        p_addressShowView: false,  
        p_geolocationMapShowView: false,
        p_credentialsShowView:true,

        p_loadingLocalities: false,

        p_comboProvincia: [{ id: 1, nombre: "Cordoba" }, { id: 2, nombre: "Bs As" }, { id: 3, nombre: "Salta" }],
        p_comboLocalidad: [],

        p_ErrorMessage: "",
        p_SuccessMessage: ""
        
    },
    watch: {
        'domicilio.idProvincia': function (newVal,oldVal) {
            if (newVal !== 0)
                this.GetLocalities();
        } 
    },
    methods: {
        GetLocalities: function () { 
            vm.$data.p_loadingLocalities = true; 
            $.ajax({
                url: WebApiBaseUrl + "/GetLocalities/" + vm.$data.domicilio.idProvincia,
                type: "GET",
                contentType: "application/json;chartset=utf-8"
            }).done(function (data) {
                if (data !== null) {
                    this.p_comboLocalidad = [];
                    this.p_comboLocalidad = data;
                }
            }).fail(function (err) {
            }).always(function () {
                vm.$data.p_loadingLocalities = false;
            }); 

        }, 
        SavePerson: function () {

            var entityJson = JSON.stringify(vm.$data, ExcludePrivateFields);

            $.ajax({
                url: WebApiBaseUrl + "/Add",
                type: "POST",
                data: entityJson,
                contentType: "application/json;chartset=utf-8",
                processData:true
            }).done(function (data) {
            }).fail(function (err) {
            }).always(function () {
            });

        },
        OpenMap: function () { 
            this.p_geolocationMapShowView = true;
            if (!map) {
                DrawMap();
                this.domicilio.ubicacion.direccion = this.domicilio.calle + " " + this.domicilio.numero;
            }   
        },
        CheckPersonExist: function () { 
            this.p_credentialsShowView = false; 
        }
    }

}); 

function HydrateFields(data) {
    vm.$data.apellido = data.apellido;
    vm.$data.nombre = data.nombre;
    vm.$data.dni = data.dni;
    vm.$data.idSexo = data.idSexo;
    vm.$data.fechaNacimiento = data.fechaNacimiento;

}