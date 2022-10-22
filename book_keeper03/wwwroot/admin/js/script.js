/* ==================================
            Mobile Menu
====================================*/
$(function () {

    // Show Mobile nav
    $("#mobile-nav-open-btn").click(function () {
        $("#mobile-nav").css("height", "100%");
    });

    // Hide Mobile nav
    $("#mobile-nav-close-btn").click(function () {
        $("#mobile-nav").css("height", "0");
    });


});


/* ================================================
                    Pagination
===================================================*/
$(function () {

    $('.next').click(function () {
        $('.pagination').find('.pgno.active').next().addClass('active');

        $('.pagination').find('.pgno.active').prev().removeClass('active');
    });

    $('.prev').click(function () {
        $('.pagination').find('.pgno.active').prev().addClass('active');

        $('.pagination').find('.pgno.active').next().removeClass('active');
    });

    $('.pgno').click(function () {
        $('.pagination').find('.pgno').removeClass('active');
        $('.pagination').find(this).addClass('active');
    });


});
