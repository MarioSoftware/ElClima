 
function FormBinding(id, queryRelatedEntityId) {

    vm.$data.p_ErrorMessage = "";
    vm.$data.p_SuccessMessage = "";
 
    var url = queryRelatedEntityId
        ? window.WebApiBaseUrl + "/Edit/" + id + queryRelatedEntityId
        : window.WebApiBaseUrl + "/Edit/" + id;

    $.getJSON(url, { __: new Date().getTime() }) // con el getTime() evitamos que IE cachee la web api
        .done(function (data) {
            if (data === null) {
                vm.$data.p_ErrorMessage = "Entity not found";
                $("input").attr("disabled", "true");
                $("textarea").attr("disabled", "true");
                $("select").attr("disabled", "true");
                $("button").attr("disabled", "true");
                return;
            }
              
            HydrateFields(data); 
        })
        .fail(ExceptionCatcher)
        .always();
}



function ExceptionCatcher(ex) {

    $("button[type='submit']").attr("disabled", false);
    if (ex.status === 404) { 
            vm.$data.p_ErrorMessage = "Web Api no encontrada"; 
        return;
    }
    if (ex.status === 401) { 
            vm.$data.p_ErrorMessage = "No tienes suficientes permisos para ingresar a este recurso."; 
        return;
    }
    if (ex.status === 403) { 
            vm.$data.p_ErrorMessage = "No tienes permiso para realizar esta operacion."; 
        return;
    }
    if (ex.status === 500) {
        //var errorObj = JSON.parse(ex.responseText);
   
        //Example for custom errors
        //if (errorObj.error.indexOf("DELETE statement conflicted with the REFERENCE constraint") !== -1) {
        //    vm.$data.p_ErrorMessage = "No se puede eliminar este registro. Hay datos que dependen de él";
        //    return;
        //}

        vm.$data.p_ErrorMessage = "Falla de servicio";

        //vm.$data.p_ErrorMessage = errorObj.error;
        return;
    }
    vm.$data.p_ErrorMessage = ex;
}