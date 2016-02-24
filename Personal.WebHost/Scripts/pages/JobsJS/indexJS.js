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
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: { id: id },
                url: '/Experiencias/_delete',
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
                url: '/Experiencias/_actualizar',
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
                url: '/Experiencias/_register',
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

        this.callbackRegister = function (target, e) {
            target.removeAttr('disabled');
            if (e > 0) {
                that.hidePopup();
                that.showListDomicilio();
            }
        }
        this.showListDomicilio = function () {
            //cada vez que se cre un  elemento po JS es recomendable conforme se esta creando enlazandolo al evento
            ctrl.contentPageAjax.load('/Experiencias/_listarExperiencias?codPersona=' + (typeof ($('input[data-name').val()) == 'undefined' ? $('#C_COD_PERSONA').val() : $('input[data-name').val()), function () {
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
            afterShowAjax: function () {
                this.resetVarGlobals();
                this.setCtrlPopup();
                this.setCodPersona();
                this.setEventsTags();

            },
            setEventsTags: function () {
                $('#submit').click(that.pagination.save)
            }
            ,
            showUpdateAJAX: function () {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Modificar Domicilio Seleccionado", 'Actualizar Trabajo'
                   , '/Experiencias/_Edit/?id=' + that.rowSelectID(), '680', '577', function () {
                       thatPrivate.afterShowAjax();
                   })
            }
            ,
            showCreateAJAX: function (callback) {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Crear nuevo trabajo", 'Agregar Experiencia'
                      , '/Experiencias/_create/', '680', '577', function () {
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
            },
            setCodPersona: function () {
                $('input[data-name').val($('#C_COD_PERSONA').val())
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

            back: function () {
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

        this.pagination = { save: _listener.save }

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