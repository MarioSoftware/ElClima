 
function FormBinding(id, queryRelatedEntityId) {

    vm.$data.p_ErrorMessage = "";
    vm.$data.p_SuccessMessage = "";
 
    var url = queryRelatedEntityId
        ? window.WebApiBaseUrl + "/Edit/" + id + queryRelatedEntityId
        : window.WebApiBaseUrl + "/Edit/" + id;

    $.getJSON(url, { __: new Date().getTime() }) // con el getTime() evitamos que IE cachee la web api
        .done(function (data) {
            if (data === null) {
                vm.$data.p_ErrorMessage = window.validate_WebApiEntityNotFoundMessage;
                $("input").attr("disabled", "true");
                $("textarea").attr("disabled", "true");
                $("select").attr("disabled", "true");
                $("button").attr("disabled", "true");
                return;
            }
             

            // Se actualizan los campos del model, en base a los datos del webapi
            HydrateFields(data);

        })
        .error(/*ExceptionCatcher*/)
        .always(/*quitPreloader*/);
}
