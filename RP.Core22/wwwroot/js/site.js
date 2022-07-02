// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {
    'use strict';
    $(".navbar").addClass("nav-height");
    shrinkNavbarOnScroll();
    scrollToUp();
    getScreenWidthAndHeight();
    getViewPortWidthAndHeight();

    // jQuery to shrink the navbar on scroll
    function shrinkNavbarOnScroll() {
        $(window).scroll(function () {
            if ($(".navbar").offset().top > 60) {


                $("nav").removeClass("nav-height");
                $("nav").addClass("nav-height-shrink");


                $("nav .container > a").removeClass("navbar-brand");
                $("nav .container > a").addClass("navbar-brand-shrink");

                $("nav li > a").removeClass("nav-link");
                $("nav li > a").addClass("nav-link-shrink");

            } else {

                $("nav").addClass("nav-height");
                $("nav").removeClass("nav-height-shrink");

                $("nav .container > a").addClass("navbar-brand");
                $("nav .container > a").removeClass("navbar-brand-shrink");

                $("nav li > a").addClass("nav-link");
                $("nav li > a").removeClass("nav-link-shrink");

            }
        });

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

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });


    //const animateCSS = (element, animation, prefix = 'animate__') =>
    //    // We create a Promise and return it
    //    new Promise((resolve, reject) => {
    //        const animationName = `${prefix}${animation}`;
    //        const node = document.querySelector(element);

    //        node.classList.add(`${prefix}animated`, animationName);

    //        // When the animation ends, we clean the classes and resolve the Promise
    //        function handleAnimationEnd(event) {
    //            event.stopPropagation();
    //            node.classList.remove(`${prefix}animated`, animationName);
    //            resolve('Animation ended');
    //        }

    //        node.addEventListener('animationend', handleAnimationEnd, { once: true });
    //    });

    //animateCSS('.anim-test1', 'fadeInRight');

}());


