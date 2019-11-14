
var validator = $("#loginForm").validate({
    rules: {
        dni: {
            required: true 
        },
        contrasenia: {  
            required: true
        } 
    },
    messages: {
        dni: {
            required: "Ingresa tu DNI"
        },
        contrasenia: {
            required: "Ingresa la contraseña"
        } 
    },

    ignore: "",

    submitHandler: function (form) {
        form.submit();
    },

    invalidHandler: function () {
    }
});  
 