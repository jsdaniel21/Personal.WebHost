/// <reference path="../../_references.js" />

var travel = {};

(function (ajax) {
    var ajax = new ajax();

    var ws = {
        listPais: function (callback) {
            ajax.ajax('/Viajes/listPais', null, function (e) {
                callback(e)
            })
        },
        registerPeopleTravels: function (callback) {
            var data = $('form').serialize();
            $.post('/Viajes/registerPeopleTravels', data, function (e) {
                callback(e)
            })
        },
        updatePeopleTravels: function (callback) {
            var data = $('form').serialize();
            $.post('/Viajes/updatePeopleTravels', data, function (e) {
                callback(e)
            })
        },
        deleteTravels: function (codPeopleTravels, callback) {
            ajax.ajax('/Viajes/delete', JSON.stringify({
                codPeopleTravels: codPeopleTravels
            }), function (e) {
                callback(e);
            })
        }
    }

    travel.index = {
        initialize: function () {
            this.references();
        },
        references: function () {
            var ref = new this.tag();
            ref.initialize();
        },
        tag: function () {

            this.initialize = function () {

                this.handles.initialize(this.control);
            },
            this.control = {
                codTipoSistemaDOM: pedidos.codTipoSistemaDOM.val(),
                username: pedidos.username.val(),
                codMenu: $('#codMenu').val(),
                back: $('div.footer-command ul > li:first-child'),
                contentPage: $('div.content-Pages'),
                contengHomeMenu: $('div.content-menu-employees'),
                contentPagesAjax: $('#content-page-ajax'),
                gridList: $('#gridQueryTravels')
            }
            this.handles = {
                initialize: function (ctrl) {
                    this.ctrl = ctrl;
                    this.events();
                },
                events: function () {
                    this.handleload();
                    this.handleBack();
                    this.handleSelected();
                },
                handleload: function () {
                    var bottomOption = new pedidos.menusJs.tag();
                    bottomOption.handle.footerMenuOptions(this.ctrl.codTipoSistemaDOM, this.ctrl.username, this.ctrl.codMenu,
                       function () {
                           this.eventsAfterLoadOtions();
                           this.ctrl.back.show();
                       }.bind(this))
                },
                handleBack: function () {
                    this.ctrl.back.click(function () {
                        $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
                        $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
                        this.ctrl.contengHomeMenu.fadeIn('slow');
                        this.ctrl.contentPage.html('');
                    }.bind(this))
                },
                loadOptionsValues: function () {
                    this.ctrl.crear = $('#037-CREA');
                    this.ctrl.update = $('#023-MODI');
                    this.ctrl.delete = $('#014-ELIM');
                },
                eventsAfterLoadOtions: function () {
                    this.loadOptionsValues();
                    this.handleShowPopupAdd();
                    this.handleShowPopupUpdate();
                    this.handleDeleteTravels();

                }
                ,
                handleShowPopupUpdate: function () {
                    this.ctrl.update.click(function () {
                        var codPeopleTravels = this.ctrl.gridList.find('tr.active-row-select > td:first-child > span:first-child').html();
                        pedidos.popup.executePopupNoBor("edite el viaje del personal", 'editando viaje'
                            , '/Viajes/_edit/?codPeopleTravels=' + codPeopleTravels, '580', '517', function () {
                                this.loadAfterPopupValues();
                                this.handleSubmitUpdate();
                                this.eventsAfterPopup();
                            }.bind(this))
                    }.bind(this))
                }
                ,
                handleShowPopupAdd: function () {
                    this.ctrl.crear.click(function () {
                        pedidos.popup.executePopupNoBor("agrege los viajes realizados por el personal"
                       , 'asignar un viaje', '/Viajes/_create', '580', '517', function () {
                           this.loadAfterPopupValues();
                           this.handleSubmitCreate();
                           this.eventsAfterPopup();
                       }.bind(this));
                    }.bind(this))
                },
                loadAfterPopupValues: function () {
                    this.ctrl.listpais = $('#listbox-pais');
                    this.ctrl.submit = $('#submit');
                    this.ctrl.codPersona = $('#_C_COD_PERSONA')
                    this.ctrl.codPersona.val(pedidos.codPersona.val());
                },
                eventsAfterPopup: function () {
                    this.loadPais();

                }
                ,
                loadPais: function () {
                    ws.listPais(function (e) {
                        pedidos.listbox.initialize(this.ctrl.listpais, e, 'I_COD_PAIS', 'V_DES_PAIS')
                        pedidos.listbox.handleClickListboxt(this.ctrl.listpais, function () {

                        }.bind(this))
                    }.bind(this))
                },
                handleSubmitCreate: function () {
                    this.ctrl.submit.click(function () {
                        ws.registerPeopleTravels(function (e) {
                            this.callList();
                        }.bind(this))
                    }.bind(this))
                },
                callList: function () {
                    this.ctrl.contentPagesAjax.load('/Viajes/_listarViajes/?codPersona=' + $('#C_COD_PERSONA').val(), function () {
                        pedidos.popup.hidePopup('#PopUp');
                        this.ctrl.gridList = $('#gridQueryTravels');
                        this.handleSelected();
                    }.bind(this))
                }
                ,
                handleSelected: function () {
                    var gridTables = this.ctrl.gridList;
                    gridTables.find('tbody tr > td:first-child').click(function () {
                        gridTables.find('tbody tr').attr('class', 'not-active-row-td')
                        $(this).parents('tr').attr('class', 'active-row-select')
                    })
                },
                handleSubmitUpdate: function () {
                    this.ctrl.submit.click(function () {
                        ws.updatePeopleTravels(function (e) {
                            this.callList();
                        }.bind(this))
                    }.bind(this))
                },
                handleDeleteTravels: function () {
                    this.ctrl.delete.click(function () {
                        var codPeopleTravels = this.ctrl.gridList.find('tr.active-row-select > td:first-child > span:first-child').html();
                        ws.deleteTravels(codPeopleTravels, function (e) {
                            this.ctrl.gridList.find('tr.active-row-select').remove();
                        }.bind(this))
                    }.bind(this))
                }
            }
        }

    }


    $(document).ready(function () {
        travel.index.initialize();
    })

})(pedidos.ajax);