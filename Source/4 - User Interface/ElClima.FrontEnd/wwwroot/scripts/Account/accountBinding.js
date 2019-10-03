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
            Idprovincia: 0,
            idLocalidad:0,
            calle: "",
            numero: 0,
            piso: 0,
            numeroDepartamento: "",
            barrio: "",
            ubicacion: {}
        },
         
        comboProvincia: [],
        comboLocalidad: [],

        p_ErrorMessage: "",
        p_SuccessMessage: ""
        
    },
    directives: {


    },
    methods: {

    }

}); 

function HydrateFields(data) {
    vm.$data.apellido = data.apellido;
    vm.$data.nombre = data.nombre;
    vm.$data.dni = data.dni;
    vm.$data.idSexo = data.idSexo;
    vm.$data.fechaNacimiento = data.fechaNacimiento;
}