  
var vmNavMenu = new Vue({
    el: "#navMenu",
    data: {
        id: 0,
        emergencyReports: false        
    },
    directives: {

        
    },
    methods: {
         
    }

});
 
$("#reportModal").on("hidden.bs.modal", function () { 
    vmNavMenu.$data.emergencyReports = false;
});