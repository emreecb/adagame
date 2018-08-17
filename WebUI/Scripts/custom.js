$(document).ready(function () {
    $(".owl-carousel").owlCarousel({
        autoPlay: 3000,

        items: 4,
        itemsDesktop: [1199, 3],
        itemsDesktopSmall: [979, 3]
    });      
});



$(document).ready(function () {
    $("#BitisTarih").datepicker({ dateFormat: 'DD.MM.YYYY' });
    $("#BitisTarih").datepicker('setDate', new Date());
    $("#BaslangicTarih").datepicker({ dateFormat: 'DD.MM.YYYY' });
    $("#BaslangicTarih").datepicker('setDate', new Date());
});