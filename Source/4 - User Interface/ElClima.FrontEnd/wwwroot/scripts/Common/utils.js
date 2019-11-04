function ExcludePrivateFields(key, value) {
    if (key && typeof (key) === "string" && key.substring(0, 2) === "p_")
        return undefined;
    return value;
}

function BlockButtons(block) { 
    if (block) {
        $("button").attr("disabled", true); 
    } else {
        $("button").attr("disabled", false); 
    } 
}

function UpdateSuggestionBox(entity, query) {
    if (!query || query.length < 3) {
        //clearTimeout(entity.p_SuggestionsBoxTimer);     TODO:   WHAT THE FUCK IS THIS ? !!!!!!
        entity.p_LocalidadesSuggestions = [];
        entity.p_SuggestionsBoxEstado = 1;
        vm.$forceUpdate();
        return;
    } else {
        //clearTimeout(entity.p_SuggestionsBoxTimer);    TODO:   WHAT THE FUCK IS THIS ? !!!!!!
        entity.p_SuggestionsBoxEstado = 2;
        vm.$forceUpdate();
        entity.p_SuggestionsBoxTimer = setTimeout(function () {
            $.getJSON("/api/Persons/GetLocalities/" + entity.idProvincia + "/" + query,
                function (json) {
                    if (json.length === 0) {
                        entity.p_SuggestionsBoxEstado = 1;
                        vm.$forceUpdate();
                        return;
                    }
                    entity.p_LocalidadesSuggestions = json;
                    entity.p_SuggestionsBoxEstado = 3;
                    vm.$forceUpdate();
                    return;
                });
        }, 1000);
    }
}

function FillLocalidadFields(entity, localidadSuggestion) {
    entity.p_SuggestionsBoxEstado = 1;
    entity.localidad = localidadSuggestion; 
}