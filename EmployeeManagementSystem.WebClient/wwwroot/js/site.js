// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).on('click', '.nav-link', function () {
    $(".nav-item").find(".active").removeClass("active");
})

$(document).ready(function () {
    $('a[href="' + location.pathname + '"]').closest('.nav-item').addClass('active');
});

