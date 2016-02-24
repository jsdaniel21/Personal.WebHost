/// <reference path="../../_references.js" />

(function () {

    var _pageCurrent = 1;
    var _opcion = "";

    var array = new Array(3);
    array["yes"] = "ico-popup-yes.png";
    array["next"] = "icon-next-popup.png";
    array["prev"] = "icon-prev-popup.png";

    var ws = {
        delete: function (id, target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: JSON.stringify({ id: id }),
                url: '/Domicilio/_delete',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        actualizar: function (target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: $('form').serialize(),
                url: '/Domicilio/_actualizar',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        register: function (target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: $('form').serialize(),
                url: '/Domicilio/_register',
                success: function (e) {
                    callback(target, e)
                }
            })
        }, fillDepartamentoCb: function (target, codPais, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'JSON',
                data: { codPais: codPais },
                url: '/Domicilio/fillDepartamentoCb',
                success: function (e) {
                    callback(target, e);
                }
            })
        }, fillProvinciaCb: function (target, codPais, codDepartamento, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { codPais: parseInt(codPais), codDepartamento: codDepartamento },
                contentType: 'application/json; charset=utf-8',
                url: '/Domicilio/fillProvinciaCb',
                success: function (e) {
                    callback(target, e)
                }
            })
        }, fillDistritoCb: function (target, codPais, codDepartamento, codProvincia, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { codPais: parseInt(codPais), codDepartamento: codDepartamento, codProvincia: codProvincia },
                contentType: 'application/json; charset=utf-8',
                url: '/Domicilio/fillDistritoCb',
                success: function (e) {
                    callback(target, e)
                }
            })
        }
    }


    var ctrl = {
        codMenu: $('#codMenu').val(),
        atras: $('[data-static="true"]'),
        contentPageAjax: $('#content-page-ajax'),
        gridQueryDOM: $('#gridQueryDOM'),
        d_containerIcoPopup: null,
        create: null,
        update: null,
        delete: null,
        h2_TitlePopup: null,
        page: null,
        ifraMaps: null,
        codDepartamento: null,
        codPais: null,
        codProvincia: null,
        codDistrito: null,
        back: $('div.footer-command ul > li:first-child'),
        contengHomeMenu: $('div.content-menu-employees'),
        contentPage: $('div.content-Pages'),
    }

    var tags = function () {
        var that = this;
        this.showAtras = function () {
            ctrl.atras.show();
        }


        this.setBottomFooter = function () {
            ctrl.create = $('#037-CREA');
            ctrl.update = $('#023-MODI');
            ctrl.delete = $('#014-ELIM')
        }

        this.setEventsTags = function () {
            ctrl.create.click(this.eventMant.Mantclick)
            ctrl.update.click(this.eventMant.Mantclick);
            ctrl.delete.click(this.eventMant.Mantclick);
            ctrl.back.click(this.eventMant.back)
        }
        this.setEventGrid = function () {
            ctrl.gridQueryDOM.find('tbody tr > td:first-child').click(this.grid.handleSelected)
        }
        this.showPopup = function (e) {
            switch ($(e).attr('id')) {
                case "037-CREA":
                    _private.showCreateAJAX();
                    _opcion = "in";
                    break;
                case "023-MODI":
                    _private.showUpdateAJAX();
                    _opcion = "up";
                    break;
                case "014-ELIM":
                    _opcion = "del";
                    this.pagination.save();
                    break;
                default:

            }
        }

        this.getOperation = function (e) {

            var id = $(e).attr('id');
            if (id == 'next' && _pageCurrent <= 2) {
                _pageCurrent++;
            } else if (id == 'prev' && _pageCurrent > 1) {
                _pageCurrent--;
            }
            _private.removeIcoPage(id);
        }
        this.showPageContainer = function () {
            ctrl.page.hide();
            ctrl.page.each(function (i) {
                if ($(this).attr('data-page') == _pageCurrent) {

                    $(this).fadeIn('slow');
                }
            })
        };

        this.setPageCount = function () {
            $('#pageCount').html(_pageCurrent)
        }

        this.fillSelect = function (target, e) {
            var option = "";
            target.find('option:not(:first-child)').remove();
            //cuando en MVC se retornar un selectlist maneja un Text y un Value
            for (var i = 0; i < e.length; i++) {
                option += "<option  value=" + e[i].Value + ">" + e[i].Text + "</option>"
            }
            target.append(option)
        }
        this.callbackRegister = function (target, e) {
            target.removeAttr('disabled');
            if (e > 0) {
                that.hidePopup();
                that.showListDomicilio();
            }
        }
        this.showListDomicilio = function () {
            //cada vez que se cre un  elemento po JS es recomendable conforme se esta creando enlazandolo al evento
            ctrl.contentPageAjax.load('/Domicilio/_listarDomicilio/?codPersona=' + $('#codPersona').val(), function () {
                _private.resetVarGlobals();
                this.setAfterList();
                this.setEventGrid();
            }.bind(this))
        }
        this.hidePopup = function () {
            pedidos.popup.hidePopUpExecute();
        }

        this.setAfterList = function () {
            ctrl.gridQueryDOM = $('#gridQueryDOM')
        }
        this.rowSelectID = function () {
            var id = ctrl.gridQueryDOM.find('tr.active-row-select > td:first-child > span:first-child').html();
            return id;
        }

        var _private = {
            removeIcoPage: function (id) {

                if (_pageCurrent === 2 && id == 'next') {
                    this.createIcoPopup("prev");
                }
                else if (_pageCurrent == 1 && id == 'prev') {
                    $('#' + id).remove();
                } else if (_pageCurrent == 3) {

                    this.createIcoPopup("yes");
                    this.createIcoPopup("prev");

                    ctrl.h2_TitlePopup.hide()

                    $('#' + id).hide();
                    $('#prev').remove();

                } else if (_pageCurrent == 3 - 1 && id == 'prev') {
                    $('#' + 'next').show();
                    $('#' + 'yes').remove();
                }
            },
            setEventsAfterPOPUP: function () {
                ctrl.codPais.change(that.select.changeItem)
                ctrl.codDepartamento.change(that.select.changeItem);
                ctrl.codProvincia.change(that.select.changeItem);
            },
            afterShowAjax: function () {
                this.resetVarGlobals();
                this.setCtrlPopup();
                this.clearIcoPopup();
                this.createIcoPopup('next', '')
                this.changeHeaderTitle();
                this.changeSizeifraMaps();
                this.setEventsAfterPOPUP();
                this.setCodPersona();

            },

            showUpdateAJAX: function () {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Modificar Domicilio Seleccionado", 'Actualizar Domicilio'
                   , '/Domicilio/_update/?id=' + that.rowSelectID(), '680', '577', function () {
                       thatPrivate.afterShowAjax();
                   })
            }
            ,
            showCreateAJAX: function (callback) {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Crear nuevo Domicilio", 'Agregar Domicilio'
                      , '/Domicilio/_create/', '680', '577', function () {
                          thatPrivate.afterShowAjax();
                          if (callback != null) {
                              callback();
                          }

                      })
            },
            resetVarGlobals: function () {
                _pageCurrent = 1;
            }
            ,
            setCtrlPopup: function () {
                ctrl.d_containerIcoPopup = $('#PopUp div.popup-footer-ico');
                ctrl.h2_TitlePopup = $('#PopUp h2.PopUp-title-form');
                ctrl.page = $('[data-page]');
                ctrl.ifraMaps = $('#ifraMaps');
                ctrl.codDepartamento = $('#C_COD_DEPARTAMENTO'),
                ctrl.codPais = $('#I_COD_PAIS'),
                ctrl.codProvincia = $('#C_COD_PROVINCIA')
                ctrl.codDistrito = $('#C_COD_DISTRITO')

            },
            setCodPersona: function () {
                $('#codPersona').val($('#C_COD_PERSONA').val())
            }
            ,
            changeSizeifraMaps: function () {
                ctrl.ifraMaps.css({ 'width': '100%', 'height': '400px' })
            }
            ,
            changeHeaderTitle: function () {
                ctrl.h2_TitlePopup.before(this.createParagrah())
            },
            createParagrah: function () {
                var p = document.createElement('p');
                p.innerHTML = "<span style='font-weight:bold'>Page <span id='pageCount'>1</span> of <span>" + this.PageSize() + "</span></span>"
                return p;
            },
            PageSize: function () {
                return ctrl.page.length
            }
            ,
            clearIcoPopup: function () {
                ctrl.d_containerIcoPopup.html('')
            },
            createIcoPopup: function (name, text) {
                var divContentIco = $('<div />');
                divContentIco.css('float', 'right');
                var contentButton = $('<div />');
                contentButton.addClass('ico-popup-yes')
                contentButton.css({
                    'background': "url('../../Images/" + array[name] + "')",
                    width: '37px',
                    height: '37px',
                    opacity: '0.7'
                })
                contentButton.html(text)
                divContentIco.append(contentButton);
                divContentIco.attr('id', name)
                divContentIco.click(name == 'yes' ? that.pagination.save : that.pagination.clickPopUpIco);

                ctrl.d_containerIcoPopup.append(divContentIco);
            }
        }
    }

    var handles = function () {
        tags.call(this)
        that = this;

        var _listener = {
            initialize: function () {
                var bottomOption = new pedidos.menusJs.tag();
                bottomOption.handle.footerMenuOptions(pedidos.codTipoSistemaDOM.val(), pedidos.username.val()
                  , ctrl.codMenu, this.load)
            },
            load: function () {

                that.showAtras();
                that.setBottomFooter();
                that.setEventsTags();
                that.setEventGrid();
            },
            handleSelected: function () {
                var gridTables = ctrl.gridQueryDOM;
                gridTables.find('tbody tr').attr('class', 'not-active-row-td')
                $(this).parents('tr').attr('class', 'active-row-select')
            }
            ,
            Mantclick: function (e) {
                that.showPopup(this);
            },
            clickPopUpIco: function () {
                that.getOperation(this)
                that.showPageContainer(this);
                that.setPageCount();
            },
            changeItem: function () {
                switch ($(this).attr('id')) {
                    case 'I_COD_PAIS':
                        ws.fillDepartamentoCb(ctrl.codDepartamento, ctrl.codPais.val(), that.fillSelect)
                        break;
                    case 'C_COD_DEPARTAMENTO':
                        ws.fillProvinciaCb(ctrl.codProvincia, ctrl.codPais.val(), ctrl.codDepartamento.val(), that.fillSelect)
                        break;
                    case 'C_COD_PROVINCIA':
                        ws.fillDistritoCb(ctrl.codDistrito, ctrl.codPais.val(), ctrl.codDepartamento.val(), ctrl.codProvincia.val(), that.fillSelect)
                        break;
                    default:
                }
            }, back: function () {
                $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
                $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
                ctrl.contengHomeMenu.fadeIn('slow');
                ctrl.contentPage.html('');
            }
            ,
            save: function () {
                $(this).attr('disabled', 'disabled');
                switch (_opcion) {
                    case "in":
                        ws.register($(this), that.callbackRegister);
                        break;
                    case 'up':
                        ws.actualizar($(this), that.callbackRegister);
                        break;
                    case 'del':
                        ws.delete(that.rowSelectID(), $(this), that.callbackRegister);
                        break;
                    default:
                        break;
                }
                _opcion = "";
                _pageCurrent = 1;
            }
        }

        this.eventMant = { Mantclick: _listener.Mantclick, back: _listener.back }

        this.pagination = { clickPopUpIco: _listener.clickPopUpIco, save: _listener.save }

        this.select = { changeItem: _listener.changeItem }

        this.grid = { handleSelected: _listener.handleSelected }
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