
jQuery(document).ready(function ($) {
    
    resizeImages();
    hljs.initHighlightingOnLoad();

    /* JQuery Slick - http://www.designchemical.com/lab/jquery-slick-plugin/getting-started/ */

    $('#slick').dcSlick({
        location: 'top',
        align: 'right',
        offset: '40px',
        tabText: 'For Developers',
        autoClose: false
    });

    /* SlideJs - http://www.slidesjs.com/ */
    /* On load, if window is larger than 960, initiate slides - otherwise they will show stacked */
    /* Does not account for resizing */

    $('#slides').slides({
                        preload: true,
                        preloadImage: 'img/loading.gif',
                        play: 5000,
                        pause: 2500,
                        hoverPause: true
                    });

    //function resizeSlider() {

    //    $('#slides').show();

    //    if ($(window).width() > 960) {
    //        if ($('#slides').hasClass('active') != true) {
    //            $('#slides').slides({
    //                preload: true,
    //                preloadImage: 'img/loading.gif',
    //                play: 5000,
    //                pause: 2500,
    //                hoverPause: true
    //            });
    //            $('#slides').addClass('active');
    //        }
    //    }
    //    else {
    //        if ($(window).width() < 960) {
    //            if ($('#slides').hasClass('active'))
    //            {
    //                $('#slides').hide();
    //            }
    //        }
    //    }
    //}

    /* Setting image type max width based on screen size */

    function resizeImages() {
        calculateResize($(".container .eight.columns .widget img"), [220, 344, 400, 280], [440, 344, 400, 280]);
        calculateResize($(".container #leftColumn .eight.columns .widget img"), [110, 344, 400, 280], [310, 344, 400, 280]);
        calculateResize($(".container .one-third.column .widget img"), [140, 216, 400, 280], [280, 216, 400, 280]);
        calculateResize($(".container .four.columns .widget img"), [110, 216, 400, 280], [200, 216, 400, 280]);
    }

    function calculateResize(element, floatedWidths, blockWidths) {
        element.each(function () {

            $(this).removeAttr("width");
            $(this).removeAttr("height");

            var nofillExtra = 20;

            if ($(this).parent().hasClass("fill")) {
                nofillExtra = 0;
            }

            var widths;

            if ($(this).hasClass("right") || $(this).hasClass("left")) {
                widths = [floatedWidths[0] + nofillExtra, floatedWidths[1] + nofillExtra, floatedWidths[2] + nofillExtra, floatedWidths[3] + nofillExtra];
            }
            else {
                widths = [blockWidths[0] + nofillExtra, blockWidths[1] + nofillExtra, blockWidths[2] + nofillExtra, blockWidths[3] + nofillExtra];
            }

            $(this).attr("src", getMaxWidth($(this).attr("src"), widths));
        });        
    }

    function getMaxWidth(source, widths) {

        var split = source.split("?")[0];
            return (split + "?mw=" + widths[0]);
        //else if ($(window).width() <= 940 && $(window).width() >= 750) {
        //    return (split + "?mw=" + widths[1]);
        //}
        //else if ($(window).width() <= 750 && $(window).width() >= 460) {
        //    return (split + "?mw=" + widths[2]);
        //}
        //else if ($(window).width() <= 460) {
        //    return (split + "?mw=" + widths[3]);
        //}
    }

    var imagesTimeOut = false;
    var sliderTimeOut = false;

    $(window).resize(function () {
        if (imagesTimeOut != false)
            clearTimeout(imagesTimeOut);
        imagesTimeOut = setTimeout(resizeImages, 200);

        if (sliderTimeOut != false)
            clearTimeout(sliderTimeOut);
        sliderTimeOut = setTimeout(resizeSlider, 200);
    });

});