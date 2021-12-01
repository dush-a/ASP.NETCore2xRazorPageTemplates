// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {

    'use strict';
    shrinkNavbarOnScroll();
    multiLevelDropDown();
  
    scrollToUp();
    getScreenWidthAndHeight();
    getViewPortWidthAndHeight();
    //setupCarouselSliders();
   
    //scrolltoTop();
    // jQuery to shrink the navbar on scroll
    function shrinkNavbarOnScroll() {
        $(window).scroll(function () {
            if ($(".navbar").offset().top > 80) {
                $(".navbar-expand-sm").addClass("top-nav-shrink");
                $("a.navbar-brand").addClass("top-nav-brand-shrink");
                $("a.nav-link").addClass("nav-link-shrink");
            } else {
                $(".navbar-expand-sm").removeClass("top-nav-shrink");
                $("a.navbar-brand").removeClass("top-nav-brand-shrink");
                $("a.nav-link").removeClass("nav-link-shrink");
            }
        });

        //$('.toTop').on('click', function (event) {
        //    event.preventDefault();
        //    $('html, body').animate({ scrollTop: 0 }, 'slow');
        //});
    }

    //Show screen width & height for development stage
    function getScreenWidthAndHeight() {
        $('.screen-width').html($(window).width());
        $('.screen-height').html($(window).height());

        $(window).resize(function () {
            var viewportWidth = $(window).width();
            var viewportHeight = $(window).height();
            $('.screen-width').html(viewportWidth);
            $('.screen-height').html(viewportHeight);
        });
    }

    function getViewPortWidthAndHeight() {
        $('.viewport-width').html(viewportSize.getWidth());
        $('.viewport-height').html(viewportSize.getHeight());

        $(window).resize(function () {
            var viewportWidth = viewportSize.getWidth();
            var viewportHeight = viewportSize.getHeight();
            $('.viewport-width').html(viewportWidth);
            $('.viewport-height').html(viewportHeight);
        });
    }

});

function scrollToUp() {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 80) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 400);
        return false;
    });
}

function scrolltoTop() {
    $.scrollUp({
        scrollName: 'scrollUp',      // Element ID
        scrollDistance: 400,         // Distance from top/bottom before showing element (px)
        scrollFrom: 'top',           // 'top' or 'bottom'
        scrollSpeed: 300,            // Speed back to top (ms)
        easingType: 'linear',        // Scroll to top easing (see http://easings.net/)
        animation: 'fade',           // Fade, slide, none
        animationSpeed: 200,         // Animation speed (ms)
        scrollTrigger: false,        // Set a custom triggering element. Can be an HTML string or jQuery object
        scrollTarget: false,         // Set a custom target element for scrolling to. Can be element or number
        scrollText: 'Scroll to top', // Text for element, can contain HTML
        scrollTitle: false,          // Set a custom <a> title if required.
        scrollImg: false,            // Set true to use image
        activeOverlay: false,        // Set CSS color to display scrollUp active point, e.g '#00FFFF'
        zIndex: 2147483647           // Z-Index for the overlay
    });
}

function multiLevelDropDown() {
    // ------------------------------------------------------- //
    // Multi Level dropdowns
    // ------------------------------------------------------ //
    $("ul.dropdown-menu [data-toggle='dropdown']").on("click", function (event) {
        event.preventDefault();
        event.stopPropagation();

        $(this).siblings().toggleClass("show");


        if (!$(this).next().hasClass('show')) {
            $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        }
        $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
            $('.dropdown-submenu .show').removeClass("show");
        });

    });
}

function setupCarouselSliders() {
    //var homeCarouselId = $('#home-main-carousel');
   // CarouselSlider('#home-main-carousel');
    //var partialCarouselId = $('#myCarousel');
    CarouselSlider('#carouselExampleIndicators');
    //var carousel_example_genericId = $('#carousel-example-generic');
   // CarouselSlider('#carousel-example-generic');

    function CarouselSlider(carouselId) {
        var timeout_time;
        var start = $(carouselId).find('.carousel-inner > .carousel-item.active').attr('data-interval');
        timeout_time = setTimeout("$(" + carouselId + ").carousel({interval: 1000});", start - 1000);

        $(carouselId).on('slid.bs.carousel', function (e) {
            clearTimeout(timeout_time);
            var $animatingElems = $(e.target).find('.carousel-inner > .carousel-item.active').attr('data-interval');

            var duration = $(this).find('.carousel-inner > .carousel-item.active').attr('data-interval');

            $(carouselId).carousel('pause');
            timeout_time = setTimeout("$(" + carouselId + ").carousel();", duration - 1000);
        })

        $(carouselId + '.carousel-control-prev').on('click', function () {
            clearTimeout(timeout_time);
        });

        $(carouselId + 'carousel-control-next').on('click', function () {
            clearTimeout(timeout_time);
        });
    }
}