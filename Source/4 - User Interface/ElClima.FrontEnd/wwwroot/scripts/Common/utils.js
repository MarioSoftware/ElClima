function ExcludePrivateFields(key, value) {
    if (key && typeof (key) === "string" && key.substring(0, 2) === "p_")
        return undefined;
    return value;
}