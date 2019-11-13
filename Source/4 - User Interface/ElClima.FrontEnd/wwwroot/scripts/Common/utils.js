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

//----Special Cryptography functions-----

/*
CryptoJS v3.1.2
code.google.com/p/crypto-js
(c) 2009-2013 by Jeff Mott. All rights reserved.
code.google.com/p/crypto-js/wiki/License
*/

var ikj123h4k12j3h412343lk45j = CryptoJS.enc.Utf8.parse('AMINHAKEYTEM32NYTES1234567891234'); var jhg2345iu23y4df52345jh234k56jh = CryptoJS.enc.Utf8.parse('7061737323313233'); var e235f242a46d67eeb74aabc37d5e5d05 = "23ko4uj5o23k4u5klewj23oi4uy5234"; var r2345ij2k345234jh234i2u3423iu4 = "30ce8e7a4a34jjkh4ddhjs99a4";
var Base64 = { _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) { var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9\+\/\=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/\r\n/g, "\n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t } }
function GenerateToken() { var text = ""; var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; for (var i = 0; i < 10; i++)text += possible.charAt(Math.floor(Math.random() * possible.length)); return text; }
function hex2a(hex) { var str = ''; for (var i = 0; i < hex.length; i += 2) str += String.fromCharCode(parseInt(hex.substr(i, 2), 16)); return str; }