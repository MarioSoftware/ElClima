
var validator = $("#loginForm").validate({
    rules: {
        dni: {
            required: true 
        },
        password: {  
            required: true
        },
        email: {
            required: true,
            isEmail: true
        }
    },
    messages: {
        dni: {
            required: "Ingresa tu DNI"
        },
        password: {
            required: "Ingresa la contraseña"
        },
        email: {
            required: "Ingresa el Email",
            isEmail: "Email inválido"
        }
    },

    ignore: "",

    submitHandler: function (form) {
        form.submit();
    },

    invalidHandler: function () {
    }
});  
 