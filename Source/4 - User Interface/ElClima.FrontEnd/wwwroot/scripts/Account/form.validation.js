var validator = $("#accountForm").validate({

    rules: {
        dni: {
            required: true,
            maxlength:8
        },
        contrasenia: {
            minlength: 8,
            maxlength: 16,
            required:true
        },
        contraseniaRepetir: {
            minlength: 8,
            maxlength: 16,
            required: true,
            equalTo:"#contrasenia"
        }
    },

    messages: {
        dni: {
            required: "Ingresa el DNI",
            maxlength:"Debe contener 8 digitos"
        },
        contrasenia: {
            required: "Ingresa una contraseña", 
            minlength: "La contraseña debe ser mayor a 8 digitos",
            maxlength: "La contraseña debe ser menor a 16 digitos"
        },
        contraseniaRepetir: {
            required: "Ingresa una contraseña",            
            minlength: "La contraseña debe ser mayor a 8 digitos",
            maxlength: "La contraseña debe ser menor a 16 digitos",
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