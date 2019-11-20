  
var vmNavMenu = new Vue({
    el: "#Menu",
    data: {
        id: 0,
        emergencyReports: false,

        //Login
        paswword: "",
        dni:""
    },
    directives: {

        
    },
    methods: {
         
    }

});
 
$("#reportModal").on("hidden.bs.modal", function () { 
    vmNavMenu.$data.emergencyReports = false;
});