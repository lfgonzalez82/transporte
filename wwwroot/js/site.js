// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function abrirAgendamentos(id) {
    if ($("#seta" + id).attr('class') === 'fas fa-angle-right') {
        $("#seta" + id).removeClass('fas fa-angle-right');
        $("#seta" + id).addClass('fas fa-angle-down');
        $("#"+id).show()
    }
    else{
        $("#seta" + id).removeClass('fas fa-angle-down');
        $("#seta" + id).addClass('fas fa-angle-right');
        $("#"+id).hide();
    }
 } 
