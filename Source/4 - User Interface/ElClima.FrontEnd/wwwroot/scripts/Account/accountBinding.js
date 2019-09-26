var WebApiBaseUrl = "/api/Persons";

var vm = new Vue({
    el: "#AccountForm",
    data: {
        id: 0,
        apellido: "",
        nombres: "",
        dni: "",
        fechaNacimiento:"",
        sexo: 1,

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
    vm.$data.nombres = data.nombre;
    vm.$data.dni = data.dni;
    vm.$data.sexo = data.idSexo;

}