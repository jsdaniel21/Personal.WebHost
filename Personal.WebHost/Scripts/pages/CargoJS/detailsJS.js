(function () {
    _pageCurrent = 1;

    var ws = {

    }


    var ctrl = {
        d_containerIcoPopup: $('#PopUp div.popup-footer-ico'),
        h2_TitlePopup: $('#PopUp h2.PopUp-title-form'),
        page: $('[data-page]'),
        anulado: $('#anulado'),
        ingreso: $('#ingreso')
    }

    var tags = function () {

        this.ChangeHeaderPopup = function () {
            ctrl.h2_TitlePopup.before(this.createPagination())
        }

        this.clearIcoPoup = function () {
            ctrl.d_containerIcoPopup.html('')
        }

        this.createPagination = function () {
            var p = document.createElement('p');
            p.innerHTML = "<span style='font-weight:bold'>Page <span id='pageCount'>1</span> of <span>" + this.PageSize() + "</span></span>"
            return p;
        }

        this.createIcoPopup = function (name, text) {
            var divContentIco = $('<div />');
            divContentIco.css('float', 'right');
            var contentButton = $('<div />');
            contentButton.addClass('button-blue-upload')
            contentButton.html(text)
            divContentIco.append(contentButton);
            divContentIco.attr('id', name)
            divContentIco.click(this.page.changePage)
            ctrl.d_containerIcoPopup.append(divContentIco);
        }

        this.PageSize = function () {
            return ctrl.page.length
        }

        this.showPageContainer = function () {
            ctrl.page.hide();
            ctrl.page.each(function (i) {
                if ($(this).attr('data-page') == _pageCurrent) {
                    $(this).fadeIn('slow');
                }
            })
        };

        this.getOperation = function (e) {
            var id = $(e).attr('id');
            if (id == 'next' && _pageCurrent < this.PageSize()) {
                _pageCurrent++;
            } else if (id == 'prev' && _pageCurrent > 1) {
                _pageCurrent--;
            }

            this.changeTitlePopup();
            this.removeIcoPage(id);
        }

        this.changeTitlePopup = function () {
            if (_pageCurrent == 1) {
                ctrl.h2_TitlePopup.html('detalle de cargo del empleado');
            } else if (_pageCurrent == 2) {
                ctrl.h2_TitlePopup.html('Observaciones');
            }
        }
        this.removeIcoPage = function (id) {
            if (_pageCurrent == 1) {
                ctrl.d_containerIcoPopup.html('')
                this.createIcoPopup("next", "Observaciones")
            }
            else if (_pageCurrent == this.PageSize()) {
                ctrl.d_containerIcoPopup.html('')
                this.createIcoPopup("prev", "Atras")
            }
        }

        this.setPageCount = function () {
            $('#pageCount').html(_pageCurrent)
        }

        this.ifObservacion = function () {
            var bit = 0;
            if (ctrl.anulado.val() != "" || ctrl.ingreso.val() != '') {
                bit = 1;
            }
            return bit;
        }
    }

    var handles = function () {
        tags.call(this);
        var that = this;

        var _listener = {
            initialize: function () {
                this.load();
            },
            load: function () {
                that.clearIcoPoup();
                if (that.ifObservacion() === 0) {
                    return false;
                }
                that.ChangeHeaderPopup();
                that.createIcoPopup("next", "Observaciones")
            }
            ,
            changePage: function () {
                that.getOperation(this);
                that.showPageContainer(this);
                that.setPageCount();
            }

        }

        this.page = {
            changePage: _listener.changePage
        }
        this.initialize = function () {
            _listener.initialize();
        }
    }

    handles.prototype = new tags();
    handles.prototype.constructor = handles;

    $(document).ready(function () {
        var x = new handles();
        x.initialize();
    })
})();