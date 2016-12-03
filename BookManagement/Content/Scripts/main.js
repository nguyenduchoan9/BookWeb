jQuery(document).ready(function ($) {

    // jQuery sticky Menu

    //$(document).ready(function () {
    //    $('#datetimepicker1').datetimepicker();
    //});

    //fancybox
    //$(document).ready(function () {
    //    $(".various").fancybox({
    //        maxWidth: 800,
    //        maxHeight: 600,
    //        fitToView: false,
    //        width: '70%',
    //        height: '70%',
    //        autoSize: false,
    //        closeClick: false,
    //        openEffect: 'none',
    //        closeEffect: 'none'
    //    });
    //});

    //Check existed e-mail
    $("#txtEmail").change(function () {
        var mail = $(this).val();
        $.ajax({
            url: "/User/GetEmail",
            data: { Mail: mail },
            dataType: "json",
            type: "POST",
            success: function (response) {
                if (response.result == false) {
                    $("#txtEmail").css("borderColor", "#42f465");
                    $("#email_err_mess").hide();
                }
                else {
                    $("#txtEmail").css("borderColor", "#E34234");
                    $("#email_err_mess").show();
                }
            }
        });
    });

    //message
    $("#system_message").removeClass("hide");
    $("#system_message").delay(5000).slideUp(500);
    //check password


    $("#not_matched_pass").hide();
    $("#cPass").change(function () {
        if ($(this).val() != $("#pass").val()) {
            $("#pass").css("borderColor", "#E34234");
            $('#cPass').css("borderColor", "#E34234");
            $("#not_matched_pass").show();
            //alert("ở đây nè!");
        }
        else {
            $("#pass").css("borderColor", "#42f465");
            $('#cPass').css("borderColor", "#42f465");
            $("#not_matched_pass").hide();
        }
    });


    //$(".mainmenu-area").sticky({topSpacing:0});


    //$('.product-carousel').owlCarousel({
    //    loop:true,
    //    nav:true,
    //    margin:20,
    //    responsiveClass:true,
    //    responsive:{
    //        0:{
    //            items:1,
    //        },
    //        600:{
    //            items:3,
    //        },
    //        1000:{
    //            items:5,
    //        }
    //    }
    //});  

    //$('.related-products-carousel').owlCarousel({
    //    loop:true,
    //    nav:true,
    //    margin:20,
    //    responsiveClass:true,
    //    responsive:{
    //        0:{
    //            items:1,
    //        },
    //        600:{
    //            items:2,
    //        },
    //        1000:{
    //            items:2,
    //        },
    //        1200:{
    //            items:3,
    //        }
    //    }
    //});  

    //$('.brand-list').owlCarousel({
    //    loop:true,
    //    nav:true,
    //    margin:20,
    //    responsiveClass:true,
    //    responsive:{
    //        0:{
    //            items:1,
    //        },
    //        600:{
    //            items:3,
    //        },
    //        1000:{
    //            items:4,
    //        }
    //    }
    //});    


    // Bootstrap Mobile Menu fix
    $(".navbar-nav li a").click(function () {
        $(".navbar-collapse").removeClass('in');
    });

    //jQuery Scroll effect
    //$('.navbar-nav li a, .scroll-to-up').bind('click', function(event) {
    //    var $anchor = $(this);
    //    var headerH = $('.header-area').outerHeight();
    //    $('html, body').stop().animate({
    //        scrollTop: $($anchor.attr('href')).offset({top - headerH}) + "px"
    //    }, 1200, 'easeInOutExpo');

    //    event.preventDefault();
    //});    

    // Bootstrap ScrollPSY
    $('body').scrollspy({
        target: '.navbar-collapse',
        offset: 95
    })
});

