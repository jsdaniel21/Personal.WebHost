/// <reference path="../../_references.js" />

(function (ajax) {
    ajax = new ajax();

    var ws = {
        verifychargeActiveForPeople: function (codPersona, callback) {
            ajax.ajax('/Cargo/verifychargeActiveForPeople', JSON.stringify({
                codPersona: codPersona
            }), function (e) {
                callback(e)
            }, true)
        },
        anularChargeForPeople: function (codCargo, observacion, callback) {
            ajax.ajax('/Cargo/anularChargeForPeople', JSON.stringify({
                codCargo: codCargo,
                observacion: observacion
            }), function (e) {
                callback(e);
            }, true)
        },
        submitCreateCharge: function (entity, callback) {
            ajax.ajax('/Cargo/savePeopleCharge', JSON.stringify(entity), function (e) {
                callback(e);
            })
        },
        listarChargePeople: function (callback) {
            ajax.ajax('/Cargo/_listarChargePeople/', JSON.stringify({ codPersona: _codPersona }), function (e) {
                callback(e);
            })
        },
        //Example
        detailsChargeForPeople: function (codPeopleCharge, callback) {
            ajax.ajax('/Cargo/detailsChargeForPeople', JSON.stringify({ codPeopleCharge: codPeopleCharge }), function (e) {
                callback(e);
            })
        },
        //cuando es con Post tienes que mandar serialziado
        actualizarCargoPrincipal: function (codPersona, codPersonaCargo, callback) {
            $.ajax({
                type: 'POST',
                url: '/Cargo/actualizarCargoPrincipal',
                data: JSON.stringify({ codPersona: codPersona, codPersonaCargo: codPersonaCargo }),
                contentType: "application/json;charset=utf-8",
                dataType: 'json',
                success: function (e) {
                    callback(e);
                }
            })

        }
    }

    var _codPersona = $('#C_COD_PERSONA').val();
    var _index = 0;

    var listarCargo = {

        initialize: function () {

            this.references();
        },
        references: function () {
            this.tag = new this.tag();
            this.tag.initialize();
        },
        tag: function () {
            this.initialize = function () {
                this.handle.initialize(this.control);
            }
            , this.control = {
                gridCargos: $('#gridQueryCargos'),
                navPanelLeft: $('#ly-navpane'),
                codTipoSistemaDOM: pedidos.codTipoSistemaDOM.val(),
                username: pedidos.username.val(),
                codMenu: $('#codMenu').val(),
                back: $('div.footer-command ul > li:first-child'),
                contentPage: $('div.content-Pages'),
                contengHomeMenu: $('div.content-menu-employees'),
                SubmitObservation: $('#popup-observacion-submit'),

            },
            this.handle = {
                initialize: function (ctrl) {
                    this.ctrl = ctrl;
                    this.event();
                },
                event: function () {
                    this.handleLoad();
                    this.handleSelected();
                    this.handleBack();
                }
                ,
                loadVariablesOptions: function () {
                    this.ctrl.crear = $('#037-CREA');
                    this.ctrl.anular = $('#021-ANUL')
                    this.ctrl.details = $('#016-LIDT');
                    this.ctrl.principal = $('#042-PRIN');
                }
                ,
                handleLoad: function () {

                    var bottomOption = new pedidos.menusJs.tag();
                     
                    bottomOption.handle.footerMenuOptions(this.ctrl.codTipoSistemaDOM, this.ctrl.username, this.ctrl.codMenu, function () {
                        alert('cargos')
                        this.loadVariablesOptions();
                        this.eventOptions();
                    }.bind(this))
                    this.ctrl.back.show();
                },
                eventOptions: function () {
                    this.handleCreateCharge();
                    this.handleAnularCharge();
                    this.handleSubmitAnular();
                    this.handleShowDetailsCharge();
                    this.cargoPrincipal();
                },
                idGrid: function () {
                    var select = this.ctrl.gridCargos.find('tbody > tr[class="active-row-select"]');
                    return select.find('td:first-child > span').html();
                },
                rowSelect: function () {
                    return this.ctrl.gridCargos.find('tbody > tr[class="active-row-select"]');
                }
                ,
                cargoPrincipal: function () {

                    this.ctrl.principal.click(function () {
                        var idGrid = this.idGrid();
                        var rowSelect = this.rowSelect();
                        if (rowSelect.find('td:last-child span').html().toLowerCase() == 'n') {
                            alert('mensaje de error!! ..  selecciona uno activo')
                            return false;
                        }
                        ws.actualizarCargoPrincipal($('#C_COD_PERSONA').val(), idGrid, function (e) {
                            if (e > 0) {
                                _index = rowSelect.index();
                                this.loadListChargePeople();
                                rowSelect.find('td:last-child span').html('p');
                            }
                        }.bind(this))
                    }.bind(this))
                }
                ,
                handleShowDetailsCharge: function () {
                    this.ctrl.details.click(function () {
                        pedidos.popup.executePopupNoBor("detalle de cargo del empleado", "detalle", "/Cargo/Details?codPeopleCharge=" + this.idGrid(), "800", "550", function () {

                        });
                        //ws.detailsChargeForPeople(this.idGrid(), function (e) 

                        //})
                    }.bind(this))
                }
                ,
                handleCreateCharge: function () {
                    this.ctrl.crear.click(function () {
                        //ws.verifychargeActiveForPeople(_codPersona, function (e) {
                        //    if (e === 0) {
                        var d = new Date();
                        $('body').append(d.toLocaleTimeString() + ':' + d.getMilliseconds() + '<br/>')
                        pedidos.popup.executePopupNoBor("agrege un nuevo cargo", 'asignar un cargo'
                            , '/Cargo/_crear', '500', '525', function () {
                                this.eventAfterPopup();
                            }.bind(this));
                        //    } else {
                        //        alert('usted!! aun tiene un cargo activo porfavor. desactive el cargo actual del empleado')
                        //    }

                        //}.bind(this))

                    }.bind(this))
                },
                handleAnularCharge: function () {
                    this.ctrl.anular.click(function () {
                        this.ctrl.anulacion = $('#inputAnulacion');

                        var select = this.ctrl.gridCargos.find('tbody > tr[class="active-row-select"]');
                        if (select.find('td:last-child > span').html().toString().toUpperCase() == 'S' ||
                            select.find('td:last-child > span').html().toString().toUpperCase() == 'P') {
                            pedidos.popup.personalizePopup('#PopUp-observacion');
                        } else {
                            alert('mensaje de error!! ..  selecciona uno activo')
                        }
                    }.bind(this))
                },
                handleSubmitAnular: function () {
                    this.ctrl.SubmitObservation.click(function () {

                        var select = this.ctrl.gridCargos.find('tbody > tr[class="active-row-select"]');
                        ws.anularChargeForPeople(select.find('td:first-child > span').html(), this.ctrl.anulacion.val(), function (e) {
                            if (e.length > 0) {
                                var date = new Date(parseInt(e.toString().slice(6, -2)));
                                var getDay = date.toLocaleString().slice(0, 2);
                                var day = '0' + getDay.toString().substr(getDay.toString().length - 2);
                                date = day.toString() + date.toLocaleString().slice(2, date.toLocaleString().length);

                                var select = this.ctrl.gridCargos.find('tbody > tr[class="active-row-select"]');
                                select.find('td:last-child span').html('n')
                                select.find('td:last-child').prev().find('span').html(date)
                                pedidos.popup.hidePopup('#PopUp-observacion');
                                this.ctrl.anulacion.val('')
                                //alert('vObservacionIngreso!!!')
                            }
                        }.bind(this))
                    }.bind(this))
                },
                loadVarAfterPopup: function () {

                    this.ctrl.submitCreateCharge = $('#submit');
                    this.ctrl.listInstancia = $('#listbox-instancia')
                    this.ctrl.listboxArea = $('#listbox-area')
                    this.ctrl.listboxCharge = $('#listbox-cargo')

                    this.ctrl.vObservacionIngreso = $('#V_OBSERVACION_INGRESO');
                    this.ctrl.iDia = $('[name=iDia]');
                    this.ctrl.iMes = $('[name=iMes]');
                    this.ctrl.iAño = $('[name=iAno]')
                }
                ,
                eventAfterPopup: function () {
                    this.loadVarAfterPopup();
                    this.handleSubmitCreateCharge();
                }
                ,
                handleSubmitCreateCharge: function () {
                    this.ctrl.submitCreateCharge.click(function () {
                        var entity = {
                            C_COD_PERSONA: $('#C_COD_PERSONA').val(),
                            I_COD_CARGO: this.ctrl.listboxCharge.prev().prev().attr('data-value'),
                            I_COD_INSTANCIA: this.ctrl.listInstancia.prev().prev().attr('data-value'),
                            C_COD_AREA: this.ctrl.listboxArea.prev().prev().attr('data-value'),
                            V_OBSERVACION_INGRESO: this.ctrl.vObservacionIngreso.val(),
                            D_FEC_INGRESO: this.ctrl.iDia.val() + '/' + this.ctrl.iMes.val() + '/' + this.ctrl.iAño.val()
                        }

                        ws.submitCreateCharge(entity, this.loadListChargePeople.bind(this))
                    }.bind(this))
                },
                JSReloj: function (date) {
                    var tiempo = date
                    var hora = tiempo.getHours()
                    var minutos = tiempo.getMinutes()
                    var segundos = tiempo.getSeconds()
                    var temp = "" + ((hora > 12) ? hora - 12 : hora)
                    if (hora == 0)
                        temp = "12";
                    temp += ((minutos < 10) ? ":0" : ":") + minutos
                    temp += ((segundos < 10) ? ":0" : ":") + segundos
                    temp += (hora >= 12) ? " P.M." : " A.M."
                    return temp
                }, loadListChargePeople: function () {

                    ws.listarChargePeople(function (e) {
                        //pedidos.popup.hidePopup('.PopUp');
                        var table = this.ctrl.gridCargos.find('tbody');
                        table.html('');
                        var tbodyContent = "";
                        for (var i = 0; i < e.length; i++) {
                            var cls = 'class="not-active-row-td"';
                            if (i == _index) {
                                cls = 'class="active-row-select"';
                            }
                            var date = new Date(parseInt(e[i].clsPeopleCharge.D_FEC_BAJA.toString().slice(6, -2)));
                            if (parseInt(e[i].clsPeopleCharge.D_FEC_BAJA.toString().slice(6, -2)) < 0) {
                                date = "";
                            } else {
                                var getDay = date.toLocaleString().slice(0, 2);
                                var day = '0' + getDay.toString().substr(getDay.toString().length - 2);
                                date = day.toString() + date.toLocaleString().slice(2, date.toLocaleString().length);
                            }

                            var milli = "/Date(1245398693390)/".replace(/\/Date\((-?\d+)\)\//, '$1');
                            var d = new Date(parseInt(milli));

                         
                            var tr = "<tr " + cls + ">"
                            var td = '<td class="active-row-td"><span class="rowId select" style="display: none;">'
                            td += e[i].clsPeopleCharge.I_COD_PERSONA_CARGO + '</span>'
                            td += '<span class="select">' + e[i].clsInstancia.V_DES_INSTANCIA + '</span></td>'
                            td += '<td><span>' + e[i].clsArea.V_ABREV_FUNCIONES + '</span></td>'
                            td += '<td><span>' + e[i].clsCargo.V_DES_CARGO + '</span></td>'
                            td += '<td><span>' + e[i].clsPeopleCharge.D_FEC_REGISTRO+ '</span></td>'
                            td += '<td><span>' + d.toDateString() + '</span></td>'
                            td += '<td><span>' + date + '</span></td>'
                            td += '<td><span>' + e[i].clsPeopleCharge.C_ACTIVO + '</span></td>'
                            tr += td;
                            tr += "</tr>"

                            tbodyContent += tr;
                        }
                        _index = 0;
                        table.html(tbodyContent);
                        pedidos.popup.hidePopup('#PopUp');
                        this.handleSelected();
                        this.handleAnularCharge();
                    }.bind(this))
                }
                          ,
                handleSelected: function () {
                    var gridCargos = this.ctrl.gridCargos;
                    gridCargos.find('tbody tr > td:first-child').click(function () {
                        gridCargos.find('tbody tr').attr('class', 'not-active-row-td')
                        $(this).parents('tr').attr('class', 'active-row-select')
                    })
                },
                handleBack: function () {
                    this.ctrl.back.click(function () {
                        $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
                        $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
                        this.ctrl.contengHomeMenu.fadeIn('slow');
                        this.ctrl.contentPage.html('');
                    }.bind(this))
                }

            }
        }

    }

    $(document).ready(function () {
        listarCargo.initialize();
    })


})(pedidos.ajax);