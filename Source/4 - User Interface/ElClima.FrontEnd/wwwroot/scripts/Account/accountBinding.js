var WebApiBaseUrl = "/api/Persons";
var momentDateFormat = "D/M/YYYY";
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
            localidad: {},
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
            },
            p_SuggestionsBoxEstado: 1,
            p_LocalidadesSuggestions: [],
            p_SuggestionsBoxTimer: 0
        },
        contrasenia:"",
        contraseniaRepetir:"", 
        p_chekingPersonExist:false,

        p_addressShowView: false,  
        p_geolocationMapShowView: false,
        p_credentialsShowView:true,

        p_loadingLocalities: false,

        p_comboProvincia: [],
        p_comboLocalidad: [],

        p_ErrorMessage: "",
        p_SuccessMessage: ""
        
    },
    watch: {
        'domicilio.idProvincia': function (newVal, oldVal) {
            if (newVal !== 0)
                this.domicilio.localidad = {};
        } 
    },
    methods: {
        //GetLocalities: function () { 
        //    vm.$data.p_loadingLocalities = true; 
        //    $.ajax({
        //        url: WebApiBaseUrl + "/GetLocalities/" + vm.$data.domicilio.idProvincia,
        //        type: "GET",
        //        contentType: "application/json;chartset=utf-8"
        //    }).done(function (data) {
        //        if (data !== null) {
        //            this.p_comboLocalidad = [];
        //            this.p_comboLocalidad = data;
        //        }
        //    }).fail(function (err) {
        //    }).always(function () {
        //        vm.$data.p_loadingLocalities = false;
        //    }); 

        //}, 

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

        CheckPersonExist: async function () {  
            //if ($("#credentialsForm").valid()) {
                vm.$data.p_chekingPersonExist = true;
                BlockButtons(true);
                $.ajax({
                    url: WebApiBaseUrl + "/Exist/" + this.dni,
                    type: "GET",
                    async: true
                }).done(function (data) {
                    if (data !== null) {
                        vm.$data.p_credentialsShowView = data;  
                    }

                }).fail(function (err) {
                }).always(function () {
                    vm.$data.p_chekingPersonExist = false;
                    BlockButtons(false);
                });  
            //} 
        },

        PersonalDataValidate: function () { 
            //if ($("#personalDataForm").valid()) {
                vm.$data.p_addressShowView = true;
            //}
        },

        UpdateSuggestionsBox: function (entity, query) {
            window.UpdateSuggestionBox(entity, query);
        },

        FillLocalidadFields: function (entity, localidadSuggestion) {
            window.FillLocalidadFields(entity, localidadSuggestion);
        }
    },
    computed: {
        validDni: function () {
            if (this.dni !== null)
                return this.dni.length !== 8;

                return true;
        }
    }

}); 

function HydrateFields(data) {
    vm.$data.apellido = data.apellido;
    vm.$data.nombre = data.nombre;
    vm.$data.dni = data.dni;
    vm.$data.idSexo = data.idSexo;
    vm.$data.fechaNacimiento = data.fechaNacimiento;

    vm.$data.domicilio.idProvincia = data.domicilio.idProvincia; 
    vm.$data.domicilio.calle = !data.domicilio.calle ? "" : data.domicilio.calle;
    vm.$data.domicilio.numero = !data.domicilio.numero ? "" : data.domicilio.numero;
    vm.$data.domicilio.piso = data.domicilio.piso == 0 ? "" : data.domicilio.piso;
    vm.$data.domicilio.departamento= data.domicilio.departamento;
    vm.$data.domicilio.barrio = data.domicilio.barrio;
    vm.$data.p_comboProvincia = data.domicilio.comboProvincia; 

    if (data.domicilio.localidad !== null)
        vm.$data.domicilio.localidad = data.domicilio.localidad;
    if (data.domicilio.ubicacion !== null && data.domicilio.ubicacion)
        vm.$data.domicilio.ubicacion = data.domicilio.ubicacion;
    
}
 