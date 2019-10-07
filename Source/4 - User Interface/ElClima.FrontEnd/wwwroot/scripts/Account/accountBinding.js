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
            idprovincia: 0,
            idLocalidad:0,
            calle: "",
            numero: "",
            piso: "",
            numeroDepartamento: "",
            barrio: "",
            ubicacion: {}
        },
         
        p_comboProvincia: [{ id: 1, nombre: "Cordoba" }, { id: 2, nombre: "Bs As" }, { id: 3, nombre: "Salta" }],
        p_comboLocalidad: [],

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