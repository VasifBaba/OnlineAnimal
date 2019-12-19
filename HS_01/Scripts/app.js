//import * as FilePond from 'filepond';

//FilePond.registerPlugin(FilePondPluginImagePreview);

//const inputElement = document.querySelector('#myPont')
//const filepondTest = FilePond.create(
//    inputElement,
//    {

//        allowDrop: true,
//        allowMultiple: true,
//        maxFiles: 3,
//        allowImagePreview: true,
//        labelIdle: 'Drag & Drop your files or <span class="filepond--label-action"> Browse </span>'
//    }
//);

//FilePond.setOptions({
//    server: {
//        url: 'Home/ElanYerlesdirme',
//        process: {
//            method: 'POST',
//                data: { "filepond":val },

//            onload: (response) => {
//                var val = $("#myPont").val();
//                (val == '') ? $("#FileIDs").val(response) : $("#FileIDs").val(val + "," + response);
//                console.log(val);
//            }
//        }
//    }
//});

$(document).ready(function () {
    $(".owl-carousel").owlCarousel();
});


$('.owl-carousel').owlCarousel({
    loop: true,
    margin: 10,
    responsiveClass: true,
    responsive: {
        0: {
            items: 2,
            nav: true
        },
        600: {
            items: 3,
            nav: false
        },
        1000: {
            items: 5,
            nav: true,
            loop: false
        }
    }
});

var container = document.getElementById("image-container");
function change_img(image) {
    container.src = image.src;
}



//$(function () {
//    $('.selectpicker').selectpicker();
//});

