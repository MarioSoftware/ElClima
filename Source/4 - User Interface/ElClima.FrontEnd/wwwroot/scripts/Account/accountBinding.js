var WebApiBaseUrl = "/api/Persons";

var vm = new Vue({
    el: "#accountForm",
    data: {
        addAddress:false,
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
            ubicacion: {}
        },

        loadingLocalities:false,

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
            vm.$data.loadingLocalities = true;
            $.getJSON(WebApiBaseUrl + "/GetLocalities/" + vm.$data.domicilio.idProvincia, { __: new Date().getTime() })
                .done(function (data) {
                    if (data !== null) {
                        this.p_comboLocalidad = [];
                        this.p_comboLocalidad = data;
                    }
                })
                .fail(function () {
                })
                .always(function () {
                    vm.$data.loadingLocalities = false;
                });


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