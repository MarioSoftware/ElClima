
var validator = $("#loginForm").validate({
    rules: {
        dni: {
            required: true 
        },
        password: {  
            required: true
        } 
    },
    messages: {
        dni: {
            required: "Ingresa tu DNI"
        },
        password: {
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
 