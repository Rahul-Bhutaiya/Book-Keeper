/* ================================================
                    Navigation
===================================================*/
/*
function sticky_header() {
    var header_height = jQuery('.site-header').innerHeight() / 2;
    var scrollTop = jQuery(window).scrollTop();;
    if (scrollTop > header_height) {
        jQuery('body').addClass('sticky-header');
    } else {
        jQuery('body').removeClass('sticky-header');
    }
}

jQuery(document).ready(function () {
    sticky_header();
});

jQuery(window).scroll(function () {
    sticky_header();
});
jQuery(window).resize(function () {
    sticky_header();
});

*/
/* jquery ready start
$(document).ready(function () {

    $(window).scroll(function () {
        if ($(this).scrollTop() > 0) {

            $('#navbar_top').addClass("fixed-top");

        } else {
            $('#navbar_top').removeClass("fixed-top");

        }
    });
})*/
/* ==================================
            Navigation
====================================*/

/* Show & Hide White Navigation */
//$(function () {

//    // show/hide nav on page load
//    showHideNav();

//    $(window).scroll(function () {

//        showHideNav();

//    });

//    function showHideNav() {

//        if ($(window).scrollTop() > 50) {

//            //Show White nav
//            $(".navbar-movable").addClass("white-nav-top");

//            // Show dark logo
//            // $(".navbar-movable .navbar-brand img").attr("src", "images/logo/logo.png");
//            $(".navbar-header img").attr("src", "images/logo/logo.png");
//            //alert('change')

//        } else {

//            // Hide White nav
//            $(".navbar-movable").removeClass("white-nav-top");

//            // Show logo
//            $(".navbar-header img").attr("src", "images/logo/white-logo.png");
//            // $(".navbar-movable .navbar-brand img").attr("src", "images/logo/top-logo.png");

//        }
//    }
//});

//$(document).ready(function () {

//    // loader
//    var loader = $('body');
//    loader.addClass('notLoaded');
//    setTimeout(function () {
//        loader.removeClass('notLoaded');
//    }, 1000);;
//    setInterval(function () {
//        $("#loader").fadeOut();
//    }, 1000)


//    $(window).scroll(function () {
//        if ($(window).scrollTop > 50) {
//            $('.navbar-header img').attr('src', '~/user/images/logo/logo.png')
//        }
//        else {
//            $('.navbar-header img').attr('src', '~/user/images/logo/white-logo.png')

//        }
//    })


    


//})

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
                    Add Review
===================================================*/
$(function () {
    $("a[class='Update']").click(function () {
        $("#review_popup").modal("show");
        return false;
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

/* ================================================
                    FAQ
===================================================*/

$(document).ready(function () {
    $('.accordion-toggle').click(function () {
        /In Anchor tag Click first resetting all the background colors & padding to hack the BootStrap look n feel/

        /* $('.accordion-toggle').parent().css('background-color', '#f5f5f5');
         $('.accordion-toggle').parent().parent().removeClass('panel-heading');
         $('.accordion-toggle').parent().css('padding', '10px 15px');
         /If the respective content panel is visible, updating its background color/*/
        if (!$($(this).attr('href')).is(':visible')) {
            $(this).parent().css('background-color', '#fff');

        } else {
            $(this).parent().css('background-color', '#f5f5f5');
        }
    });
});
$(document).ready(function () {
    // Add minus icon for collapse element which is open by default
    $(".collapse.show").each(function () {
        $(this).prev(".panel-heading").find(".icon").addClass("minus-i").removeClass("add-i");
    });

    // Toggle plus minus icon on show hide of collapse element
    $(".collapse").on('show.bs.collapse', function () {
        $(this).prev(".panel-heading").find(".add-i").removeAttr("src", "images/icon-image/add.png").attr("src", "images/icon-image/minus.png");

    });
    $(".collapse").on('hide.bs.collapse', function () {
        $(this).prev(".panel-heading").find(".minus-i").removeAttr("src", "images/icon-image/add.png").attr("src", "images/icon-image/add.png");
    });
});
