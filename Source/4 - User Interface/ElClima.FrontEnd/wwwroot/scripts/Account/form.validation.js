﻿
var validatorCredential = $("#credentialsForm").validate({
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
        p_contraseniaRepetir: {
            required: true,
            equalTo: "#contrasenia"
        },
        email: {
            required: {
                depends: function () {
                    if ($(this).val() !== null && $(this).val()[0] === ' ') {
                        $(this).val($.trim($(this).val()));
                        return true;
                    }
                    return true;
                }
            },
            maxlength: 70,
            isEmail: true
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
        p_contraseniaRepetir: {
            required: "Confirma la contraseña",
            equalTo: "Las contraseñas no coinciden"
        },
        email: {
            required: "Ingresa tu correo electronico",
            maxlength: "El email debe tener menos de 70 caracteres",
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

var validatorPersonalData = $("#personalDataForm").validate({
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

var validatorAddress = $("#addressForm").validate({
    rules: {
        barrio: {
            required: true
        },
        calle: {
            required: true
        } 
    },
    messages: {
        barrio: {
            required: "Ingresa el barrio"
        },
        calle: {
            required: "Ingresa la calle"
        } 
    }, 

    ignore: "",

    submitHandler: function (form) { 
        form.submit();
    },

    invalidHandler: function () {
    }
});
