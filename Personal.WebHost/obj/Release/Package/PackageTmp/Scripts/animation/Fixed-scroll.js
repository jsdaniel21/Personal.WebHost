
//resolucion de content

$(document).ready(function () {

    $(document).scroll(function (e) {
        var int = $(document).scrollLeft();
        $('#ly-headerLayout').css('margin-left', '-' + int + 'px');
        $('#ly-navpane').css('margin-left', '-' + int + 'px');
        $('.footer').css('margin-left', '-' + int + 'px');
        if (int == 0) {
            $('#ly-headerLayout').removeAttr('style');
            $('#ly-navpane').removeAttr('style');
            $('.footer').removeAttr('style');
        }


    });

    //$('.aux-tabcontent').css('height', document.body.scrollHeight)

})