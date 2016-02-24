/// <reference path="../../_references.js" />


(function (menu) {



    var ws = {
        guardar: function (callback) {
            $.ajax({
                type: 'post',
                url: '/' + pedidos.controller + '/guardar',
                dataType: 'json',
                data: $('form').serialize(),
                success: function (e) {
                    callback(e)
                }

            })
        }
    }

    var ctrl = {
        update: null,
        delete: null,
        guardar: null,
        aceptar: $('#aceptar'),
        gridQueryDOM: $('#gridQueryDOM')
    }

    var tags = function () {
        var that = this;

        this.setBottomFooter = function () {
            ctrl.update = $('#023-MODI');
            ctrl.delete = $('#014-ELIM')
            ctrl.guardar = $('#015-GUAR')
        }
        this.setEventsTags = function () {
            ctrl.aceptar.click(this.form.save)
            ctrl.update.click(this.callActions)
            ctrl.delete.click(this.callActions)
        }


        this.isPopup = function () {
            var bit = true;
            if ($('#PopUp').length == 0) {
                bit = false
            }
            return bit;
        }
        this.redirectionPage = function (action) {
            location.href = "/" + _private.returController() + '/' + action;
        }

        this.rowSelectID = function () {
            var id = ctrl.gridQueryDOM.find('tr.active-row-select > td:first-child > span:first-child').html();
            return id;
        }
        this.isEdit = function () {
            if (_private.returnAction().indexOf('edit') > 0) {
                ctrl.delete.remove();
                ctrl.update.remove();
                this.guardarSubmit();
            } else {
                ctrl.guardar.remove();
            }
        }

        this.guardarSubmit = function () {
            ctrl.guardar.click(function () {
                $('form').submit();
            })
        }

        var _private = {
            returController: function () {
                var url = document.URL.replace("https", "http");
                url = url.substring(7, url.length)
                url = url.substring(url.indexOf('/') + 1, url.length)
                var t = /(index|edit)/
                if (t.test(url)) {
                    url = url.substr(0, url.indexOf('/'));
                }

                return url;
            },
            returnAction: function () {
                var url = document.URL.replace("https", "http");
                url = url.substring(7, url.length)
                url = url.substring(url.indexOf('/') + 1, url.length)
                return url;
            }
        }
    }
    var events = function () {
        var that = this;
        tags.call(this)
        var _listener = {
            initilize: function () {
                op = "in";
                if (typeof (pedidos.controller) == 'undefined')
                    menu.initialize(this.load)
                else
                    this.load();
            },
            load: function () {
                //asigna los valores de los elementos que fueron creados despues de llamar al menu 
                that.setBottomFooter();
                that.setEventsTags();
                that.isEdit();
            },
            save: function (e) {
                switch (op) {
                    case 'in':
                        ws.guardar(function (e) {
                            pedidos.hideItemsOptionsFooter(function () {
                                alert('se guardo correctamente')
                            });
                        })
                        break;
                    default:

                }
            },
            callActions: function () {
                switch ($(this).attr('id')) {
                    case '023-MODI':
                        op = "up"
                        if (that.isPopup() == false)
                            that.redirectionPage("edit?id=" + that.rowSelectID())
                        break;
                    case '014-ELIM':
                        op = "el"
                        if (that.isPopup() == false)
                            that.redirectionPage("delete?id=" + that.rowSelectID())
                        break;
                    default:

                }
            }
        }

        this.form = { save: _listener.save }
        this.callActions = _listener.callActions;

        this.initialize = function () {
            _listener.initilize();
        }
    }
    events.prototype = new tags();
    events.prototype.constructor = events;

    $(document).ready(function () {
        var x = new events();
        x.initialize();
    })

})(pedidos.menusJs);