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
            id:0,
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
        contrasenia: "",
        email:"",
        //contactos: [],
        //ubicacion:{},

        p_contraseniaRepetir:"", 
        p_chekingPersonExist:false,

        p_addressShowView: false,  
        p_geolocationMapShowView: false,
        p_credentialsShowView:false,

        p_loadingLocalities: false,
        p_personAdded:false,

        p_comboProvincia: [],
        p_comboLocalidad: [],
        
        p_ValidationCredentials:[],
        p_ErrorMessage: "",
        p_SavePersonErrorMessage:"",
        p_SuccessMessage: ""
        
    },
    watch: {
        'domicilio.idProvincia': function (newVal, oldVal) {
            if (newVal !== 0)
                this.domicilio.localidad = {};
        } 
    },
    methods: { 

        PersonalDataValidate: function () { 
            if ($("#personalDataForm").valid()) {
                vm.$data.p_addressShowView = true;
            }
        },
        
        ValidateAddress: function () {
            if ($("#addressForm").valid()) {
                vm.$data.p_credentialsShowView = true;
                vm.$data.p_addressShowView = false;
            }
        }, 

        CheckPersonExist: async function () {  
            if (!vm.$data.p_personAdded) {
                if ($("#credentialsForm").valid()) {
                    vm.$data.p_chekingPersonExist = true;
                    vm.$data.p_ErrorMessage = "";
                    BlockElements(true);
                    $.ajax({
                        url: WebApiBaseUrl + "/Exist/" + this.dni,
                        type: "GET",
                        async: true
                    }).done(function (data) {
                        if (data !== null) {
                            if (data) {
                                vm.$data.p_chekingPersonExist = false;
                                vm.$data.p_ErrorMessage = "Ya tienes un Usuario registrado !, intenta Iniciar Session";
                                BlockElements(false);
                            } else {
                                vm.$options.methods.SavePerson();
                            }
                        }

                    }).fail(function (err) {
                        window.ExceptionCatcher(err);
                        vm.$data.p_chekingPersonExist = false;
                        BlockElements(false);
                    }).always(function () {                       
                      
                    });
                }
            } else {
                this.RegisterUser();
            }
            
        }, 

        OpenMap: function () {
            this.p_geolocationMapShowView = true;
            if (!map) {
                DrawMap();
                this.domicilio.ubicacion.direccion = this.domicilio.calle + " " + this.domicilio.numero;
            }
        },

        SavePerson: function () {
            vm.$data.p_SavePersonErrorMessage = "";
            var entityJson = JSON.stringify(vm.$data, ExcludePrivateFields);
            console.log(entityJson);
            $.ajax({
                url: WebApiBaseUrl + "/Add",
                type: "POST",
                data: entityJson,
                contentType: "application/json;chartset=utf-8",
                processData: true
            }).done(function (data) {
                vm.$data.p_personAdded = true;
                vm.$options.methods.RegisterUser();

            }).fail(function (err) {
                vm.$data.p_SavePersonErrorMessage = err.statusText;
                vm.$data.p_chekingPersonExist = false;
                BlockElements(false);
            }).always(function () {
            });

        }, 

        RegisterUser: function () {

            var dataJson = JSON.stringify(data = { dni: vm.$data.dni, apellido: vm.$data.apellido, nombre: vm.$data.nombre, password: vm.$data.contrasenia, email: vm.$data.email });

            $.ajax({
                url: "/api/Account/Register",
                type: "PUT",
                data: dataJson,
                processData: true,
                contentType: "application/json;chartset=utf-8",
                async: true
            }).done(function (data) { 
                if (data.success) {
                    vm.$data.p_ValidationCredentials=[];
                    window.location.href = "/Account/Login";
                } else {
                    vm.$data.p_ValidationCredentials = data.messages;
                } 
                
            }).fail(function (err) {
                vm.$data.p_ValidationCredentials=[];
                window.ExceptionCatcher(err);
            }).always(function () {
                vm.$data.p_chekingPersonExist = false;
                BlockElements(false);
            });

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
 