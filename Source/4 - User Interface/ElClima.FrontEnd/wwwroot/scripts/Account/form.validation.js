
var validator = $("#credentialsForm").validate({
    rules: {
        dni: {
            required: true,
            maxlength: 8
        },
        contrasenia: {
            minlength: 8,
            maxlength: 16,
            required: true
        },
        contraseniaRepetir: {
            required: true,
            equalTo: "#contrasenia"
        }
    },
    messages: {
        dni: {
            required: "Ingresa el DNI",
            maxlength: "Debe contener 8 digitos"
        },
        contrasenia: {
            required: "Ingresa una contraseña",
            minlength: "La contraseña debe ser mayor a 8 digitos",
            maxlength: "La contraseña debe ser menor a 16 digitos"
        },
        contraseniaRepetir: {
            required: "Confirma la contraseña",
            equalTo: "Las contraseñas no coinciden"
        }
    },

    ignore: "",

    submitHandler: function (form) {
        form.submit();
    },

    invalidHandler: function () {
    }
}); 


var validator2 = $("#personalDataForm").validate({
    rules: {
        apellido: {
            required: true
        },
        nombre: { 
            required: true
        },
        fechaNacimiento: {
            required: true,
            anyDate: true
        }
    },
    messages: {
        apellido: {
            required: "Ingresa apellido"
        },
        nombre: {
            required: "Ingresa nombre"
        },
        fechaNacimiento: {
            required: "Ingresa tu fecha de nacimiento",
            anyDate: "Fecha inválida"
        }
    },

    ignore: "",

    submitHandler: function (form) {
        form.submit();
    },

    invalidHandler: function () {
    }
});
