

pedidos.popup = {
    initialize: function () {
        this.firstLoad();
        this.close();
    }
    ,
    firstLoad: function () {
        this.executePopup();
    },

    hidePopup: function (id, callback) {
        $(id).fadeOut('slow', function () {
            $('.fxs-modalpresenter-shield').fadeOut('slow', function () {
                if (callback != null) {
                    callback(id);
                }
            });
        })
    },
    hidePopUpExecute: function (callback) {
        $('#PopUp').fadeOut('slow', function () {
            $('.fxs-modalpresenter-shield').fadeOut('slow', function () {
                if (callback != null) {
                    callback();
                }
            });
        })
    }
    ,
    hidePopupPersonality: function (id) {
        $(id).fadeOut('slow', function () {
            $('.fxs-modalpresenter-shield').fadeOut('slow', function () {

            });
        })
    },
    hideButton: function () {
        $('#PopUp #aceptar').hide();
    }
    ,
    backgroundNoBorde: function (id) {
        $('.fxs-modalpresenter-shield').fadeIn(100, function () {
            //var d = new Date();
            //$('body').append(d.toLocaleTimeString()+':'+d.getMilliseconds()+'<br/>')
            $(id).fadeIn()
        });
    }
    ,
    createPopUp: function (noBorder, title, subtitle, href, callback, description, iframe) {

        $('body').find('div#PopUp').remove();
        var divpopup = document.createElement('div');
        divpopup.setAttribute('id', "PopUp");
        divpopup.classList.add('PopUp')
        var container = document.createElement('div');
        container.setAttribute('class', 'PopUp-content-form');


        if (noBorder === true) {
            var divClose = document.createElement('div');
            divClose.setAttribute('class', 'titlefancybox');
            divClose.setAttribute('title', 'cerrar');
            divClose.setAttribute('id', 'popup-close');

        } else {
            var aclosed = document.createElement('div');
            aclosed.setAttribute('title', 'cerrar');
            aclosed.setAttribute('href', '#');
            aclosed.setAttribute('class', 'popUp-Close');
            aclosed.style.cursor = "pointer";
            aclosed.addEventListener('click', function () {
                this.hidePopup('#PopUp', function (id) {

                    $(id).remove();
                })
            }.bind(this))
            var imgsrc = new Image();
            imgsrc.setAttribute('alt', 'cerrar');
            imgsrc.src = "../Images/ico-popup-close.png";
            aclosed.appendChild(imgsrc);
            var p = document.createElement('p')
            p.innerHTML = subtitle;
            p.classList.add('aux-popup-header');

            var h2 = document.createElement('h2');
            h2.setAttribute('class', 'PopUp-title-form');
            h2.style.textTransform = "lowercase";
            h2.innerHTML = title;
            var bodyPoupup = null;

            if (iframe == 'no') {
                bodyPoupup = document.createElement('div');
                bodyPoupup.id = "bodyPoupup";
                $(bodyPoupup).load(href, {}, function (d) {
                    callback();
                });
            } else {
                bodyPoupup = document.createElement('iframe');
                bodyPoupup.id = "bodyPoupup";
                bodyPoupup.src = href;
                bodyPoupup.style.width = "100%";
                bodyPoupup.style.height = "100%";
            }


            //var iframe = document.createElement('iframe');
            //iframe.src = href;
            //iframe.style.width = "100%"
            //iframe.style.height="100%"
            //bodyPoupup.appendChild(iframe)

            //$.ajax({
            //    url: href,
            //    contentType: 'application/html;charset=utf-8',
            //    type: 'get',
            //    dataType: 'html',
            //    //data: {
            //    //    codMenu: parent
            //    //},
            //    success: function (result) {

            //        $(bodyPoupup).append(result);
            //        //$('div#aux-foreground').css({ 'background': '#fff' })
            //        //$(this).parents('div.content-menu-employees').fadeOut(500, function () {
            //        //    contentPage.fadeIn('slow');
            //        //});
            //    }.bind(this)
            //})

            var submit = document.createElement('div');
            submit.classList.add('popup-footer-ico');
            submit.innerHTML = '<div class="content-ico" id="submit"> <div class="ico-popup-yes" title="aceptar" id="aceptar"></div>  </div>';
            container.appendChild(aclosed);
            container.appendChild(p)
            container.appendChild(h2);
            if (description != null) {
                var pdes = document.createElement('p');
                pdes.innerHTML = description;

                container.appendChild(pdes)
            }
            container.appendChild(bodyPoupup);
           
            if (iframe == "yes") {
                callback();
            } else {
                container.appendChild(submit);
            }

        }


        divpopup.appendChild(container);

        if (iframe == "no")
            divpopup.appendChild(submit)


        $('body').append(divpopup);

    }
    ,

    removeBorder: function (id, ancho, height) {

        var margintop = 0;
        var marginleft = 0;

        if (typeof (ancho) === 'undefined') {
            ancho = "680";
            height = "560"
        }
        marginleft = (ancho / 2) + 3
        margintop = height / 2


        $(id).css({
            'margin': '-' + margintop.toString() + 'px 0px 0px -' + marginleft.toString() + 'px',
            'border': '0px solid rgba(230, 229, 229, 0.80)', /*+5*/
            'border-radius': '0px 0px',
            'width': ancho,
            'height': height
        })

        $(id + ' .PopUp-content-form').css({
            'width': ancho - 80,
            'height': height - 112
        })
        $(id + ' .titlefancybox').css('display', 'none')
    },

    executePopupNoBor: function (title, subtitle, href, width, height, callback, description, iframe) {
        this.createPopUp(false, title, subtitle, href, function () {
            this.backgroundNoBorde('#PopUp');
            callback();
        }.bind(this), description, iframe == null ? "no" : iframe);
        this.removeBorder('#PopUp', width, height);

    },

    personalizePopup: function (id) {
        $(id).css('z-index', '9999');
        $(id + ' .titlefancybox').css('display', 'none')
        this.backgroundNoBorde(id);
        //this.hidePopup(id);
        $(id).find('a.popUp-Close').click(function () {
            this.hidePopupPersonality(id);
        }.bind(this))
    }

}

