// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function handsradioUniverstiy(name) {
    debugger;
    if (name == "1") {
       
        $('#idcreate').removeClass('d-none');
        $('#idupdate').addClass('d-none');
       
    }
    if (name == "2") {
        $('#idupdate').removeClass('d-none');
        $('#idcreate').addClass('d-none');
        
    }
}