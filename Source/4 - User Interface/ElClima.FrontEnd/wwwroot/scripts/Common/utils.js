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