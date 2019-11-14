vm = new Vue({
    el: "#login",
    data: {
        dni: "",
        password: "",

        p_ErrorMessage:""
    }

});

function Login(returnUrl) {

    vm.$data.p_ErrorMessage = "";

    var token = window.GenerateToken();
    var token2 = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(token),
        r2345ij2k345234jh234i2u3423iu4,
        ikj123h4k12j3h412343lk45j,
        {
            keySize: 128,
            iv: jhg2345iu23y4df52345jh234k56jh,
            mode: CryptoJS.mode.CBC,
            padding: CryptoJS.pad.Pkcs7
        }).toString();

    var url = "/api/Account/GetKey/" + Base64.encode(token2);

    $.getJSON(url, { __: new Date().getTime() })
        .done(
            function (data) {

                if (data === null) {
                    vm.$data.p_ErrorMessage = "Imposible contactar con el servidor.";
                    return;
                }

                var plaintextArray = CryptoJS.AES.decrypt(data.Key,
                    e235f242a46d67eeb74aabc37d5e5d05,
                    ikj123h4k12j3h412343lk45j,
                    {
                        keySize: 128,
                        iv: jhg2345iu23y4df52345jh234k56jh,
                        mode: CryptoJS.mode.CBC,
                        padding: CryptoJS.pad.Pkcs7
                    });

                var data2 = hex2a(plaintextArray.toString());

                // I take the data            
                var password = vm.$data.password;
                var dni = vm.$data.dni;

                // I encript the data 
                dni = CryptoJS.AES.encrypt(
                    CryptoJS.enc.Utf8.parse(dni),
                    data2,
                    ikj123h4k12j3h412343lk45j,
                    {
                        keySize: 128,
                        iv: jhg2345iu23y4df52345jh234k56jh,
                        mode: CryptoJS.mode.CBC,
                        padding: CryptoJS.pad.Pkcs7
                    }).toString();

                password = CryptoJS.AES.encrypt(
                    CryptoJS.enc.Utf8.parse(password),
                    data2,
                    ikj123h4k12j3h412343lk45j,
                    {
                        keySize: 128,
                        iv: jhg2345iu23y4df52345jh234k56jh,
                        mode: CryptoJS.mode.CBC,
                        padding: CryptoJS.pad.Pkcs7
                    }).toString();

                var data3 = JSON.stringify(
                    {
                        'data': Base64.encode(dni + "[---0---]" + password)
                    });

                $.ajax({
                    url: "/api/Account/Login/",
                    type: "PUT",
                    data: data3,
                    contentType: "application/json;chartset=utf-8", 
                    processData: true,
                    error: LoginExceptionCatcher
                }).done(
                    function () {
                        window.location.assign("/Account/RedirectFromLogin?ReturnUrl=" + returnUrl);
                    });
            })
        .error(LoginExceptionCatcher)
        .always();
}

function LoginExceptionCatcher(ex) {

    if (ex.status === 404) { 
            vm.$data.p_ErrorMessage = "Web Api no encontrada."; 
        return;
    }
    if (ex.status === 401) { 
            vm.$data.p_ErrorMessage = "No tienes permisos suficientes para acceder a este recurso.";
        
        return;
    }
    if (ex.status === 500) {
        var errorObj = JSON.parse(ex.responseText);
        vm.$data.p_ErrorMessage = errorObj.error;
        return;
    }

    vm.$data.p_ErrorMessage = ex;
}