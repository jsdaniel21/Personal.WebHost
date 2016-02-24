/// <reference path="../_references.js" />


(function (ajax, menu) {
    ajax = new ajax();
    'use strict';
    var ws = {
        getTipoEmpleados: function (callback) {
            $.ajax({
                url: '/MaTipoEmpleado/tipoEmpleados',
                type: 'get',
                data: null,
                dataType: 'json',
                success: function (d) {
                    callback(d);
                }
            })
        },
        tipoModalidadPorTipoEmpleado: function (callback, iCodigoTipoEmpleado) {
            $.ajax({
                url: '/Modalidad/tipoModalidadPorTipoEmpleado',
                type: 'get',
                data: { iCodigoTipoEmpleado: iCodigoTipoEmpleado },
                dataType: 'json',
                success: function (d) {
                    callback(d);
                }
            })
        },
        gradoMilitar: function (callback, iCodigoInstitucion) {
            $.ajax({
                url: '/MaGradoMilitar/listarGradoMilitarXinstitucion',
                type: 'GET',
                data: { iCodigoInstitucion: iCodigoInstitucion },
                dataType: 'json',
                success: function (d) {
                    callback(d);
                }
            })
        },
        empleados: function (callback, iCodigoTipoEmpleado, iCodigoTipoModalidad, iCodigoInstitucion, vCodigoGradoMilitar, iCodigoSituacionMilitar, iCodigoInstancia) {

            $.ajax({
                url: '/Employees/empleados',
                type: 'GET',
                data: {
                    iCodigoTipoEmpleado: iCodigoTipoEmpleado,
                    iCodigoTipoModalidad: iCodigoTipoModalidad,
                    iCodigoInstitucion: iCodigoInstitucion,
                    vCodigoGradoMilitar: vCodigoGradoMilitar,
                    iCodigoSituacionMilitar: iCodigoSituacionMilitar,
                    iCodigoInstancia: iCodigoInstancia
                },
                dataType: 'json',
                success: function (d) {
                    callback(d);
                }
            })
        }
    }

    var ctrl = {
        divFilters: $('#divFilters'),
        cboTipoModalidad: $('#cboTipoModalidadFilter'),
        cboInstitucion: $('#cboInstitucionFilter'),
        cboGradoMilitar: $('#cboGradoMilitarFilter'),
        cboSituacionMilitar: $('#cboSituacionMilitarFilter'),
        codTipoSistemaDOM: $('#hidden-codTipoSistema').val(),
        codUserDOM: $('#hidden-username').val(),
        codMenu: null,
        btnBuscar: $('#btnBuscar'),
        gridQuerysEmployees: $('#gridQuerysEmployees'),
        menuLeftParent: $('#ly-navpane-scroll-items > nav'),
        cboTribunales: $('#cboTribunales')
    }
    var bottomOption = new pedidos.menusJs.tag();

    var employees = {

        initialize: function () {
            this.references();
            this.fillMenuLef();
            this.clearEvents();
            this.setEvents();
            this.disabledAllSelect();
        },
        footerMenuOptions: function () {
            bottomOption.handle.footerMenuOptions(ctrl.codTipoSistemaDOM, ctrl.codUserDOM, ctrl.codMenu, function () {
                employees.setAfterMenuOptions();
                employees.setAfterMenuEvents();
            })
        },
        setAfterMenuParent: function () {
            ctrl.codMenu = $('li[data-parent-select=true]').attr('data-parent');
        }
        ,
        setAfterMenuOptions: function () {
            ctrl.divImpr = $('#018-IMPR')

        },
        setAfterMenuEvents: function () {

            ctrl.divImpr.click(listener.click_impresion);
        }
        ,
        setEvents: function () {
            ctrl.cboInstitucion.change(listener.selectItem_cboInstitucion);
            ctrl.btnBuscar.click(listener.click_btnBuscar);
            ctrl.cboGradoMilitar.change(listener.selectItem_cboGradoMilitar);
        },
        disabledAllSelect: function () {
            //employees.selectDisabled(ctrl.cboInstitucion)
            employees.selectDisabled(ctrl.cboGradoMilitar)
            employees.selectDisabled(ctrl.cboSituacionMilitar)
        }
        ,
        fillMenuLef: function () {
            ws.getTipoEmpleados(employees.afterLoadDataTipoEmpleado)
        },
        afterLoadDataTipoEmpleado: function (d) {
            var menuLeft = new employees.MenuLeft(d);
            menuLeft.initialize();
        },
        hideDivFilters: function () {
            ctrl.divFilters.css('visibility', 'hidden')
        }
        ,
        showDivFilters: function () {
            ctrl.divFilters.removeAttr('style')
        },
        clearEvents: function () {
            $('#ly-navpane-scroll-items > nav').find('li a').unbind('click');
        },
        fillTipoModalidad: function (id) {
            ws.tipoModalidadPorTipoEmpleado(function (d) {
                employees.select(ctrl.cboTipoModalidad, d);

            }, id)
        },
        clearSelect: function (select) {
            select.find('option:not(:first-child)').remove();
        }
        ,
        select: function (select, data) {
            employees.clearSelect(select);
            for (var i = 0; i < data.length; i++) {

                select.append("<option value='" + data[i].Value + "'>" + data[i].Text + "</option>");
            }
        },
        selectDisabled: function (select) {
            select.css('background', '#E6E6E6')
            select.attr('disabled', 'disabled');
        }
        ,
        selectAvalibity: function (select) {
            select.removeAttr('disabled');
            select.removeAttr('style');
        }
        ,
        fillGradoXinstitucion: function () {

            ws.gradoMilitar(function (d) {
                employees.select(ctrl.cboGradoMilitar, d)
            }, ctrl.cboInstitucion.val().trim() == '' ? 0 : ctrl.cboInstitucion.val())
        },
        fillEmployees: function (iCodigoTipoEmpleado) {

            ws.empleados(employees.changeDataTable,
               iCodigoTipoEmpleado.trim() == '' ? 0 : parseInt(iCodigoTipoEmpleado),
                ctrl.cboTipoModalidad.val().trim() == '' ? 0 : ctrl.cboTipoModalidad.val(),
                ctrl.cboInstitucion.val().trim() == '' ? 0 : ctrl.cboInstitucion.val(),
                ctrl.cboGradoMilitar.val(),
                ctrl.cboSituacionMilitar.val().trim() == '' ? 0 : ctrl.cboSituacionMilitar.val(),
                 ctrl.cboTribunales.val().trim() == '' ? 0 : ctrl.cboTribunales.val());
        },
        changeDataTable: function (data) {
            var rows = {
                tr: function () {
                    var tr = $('<tr/>');
                    tr.addClass('not-active-row-td');
                    return tr;
                },
                td: function () {
                    var td = $('<td />');
                    return td;
                },
                spanPrimary: function (inputValue) {
                    var span = $('<span />');
                    span.addClass('rowId select');
                    span.hide();
                    var input = $('<input/>');
                    input.val(inputValue);
                    input.hide();
                    span.append(input);
                    return span;
                },
                spanHtml: function (html) {
                    var span = $('<span/>');
                    span.html(html)
                    return span;
                }
                ,
                body: function () {
                    ctrl.gridQuerysEmployees.find('tbody').html('');

                    for (var i = 0; i < data.length; i++) {
                        var parentTr = this.tr();
                        var td = this.td();
                        td.addClass('active-row-td')
                        var span = this.spanHtml();
                        span.addClass('select')
                        span.html(data[i].V_APELLIDO_PATERNO)
                        td.append(this.spanPrimary(data[i].C_COD_PERSONA));
                        td.append(span);
                        parentTr.append(td);
                        parentTr.append(this.td().append(this.spanHtml(data[i].V_APELLIDO_MATERNO)));
                        parentTr.append(this.td().append(this.spanHtml(data[i].V_NOMBRES)));
                        parentTr.append(this.td().append(this.spanHtml(data[i].C_ACTIVO)));

                        ctrl.gridQuerysEmployees.find('tbody').append(parentTr);
                    }
                }
            }

            rows.body();
            listener.click_ItemTable();
        }
       ,
        MenuLeft: function (data) {
            var that = this;

            this.initialize = function () {
                this.contents.fillData();
            }
            this.contents = {
                li: function () {
                    var li = $('<li />');
                    li.click(this.listeners.click_li);
                    return li;
                }
                , a: function (href) {
                    var a = $('<a />');
                    a.attr('href', href)
                    a.unbind('click');
                    a.click(function (event) {
                        event.preventDefault();
                    })

                    return a;
                }
                , span: function (text) {
                    var span = $('<span />');
                    span.html(text);
                    return span;
                },
                fillData: function () {
                    var ul = $('<ul/>');
                    var liFirst = this.li();
                    liFirst.attr({ 'data-select': 'true', 'data-id': '' });
                    liFirst.html(this.a("").append(this.span('Todos')));
                    ul.append(liFirst);
                    for (var i = 0; i < data.length; i++) {
                        var a = this.a("#");
                        a.unbind('click');
                        var li = this.li();
                        li.attr('data-id', data[i].I_COD_TIPO_EMPLEADO)
                        li.append(a.append(this.span(data[i].V_DES_TIPO_EMPLEADO)));
                        ul.append(li);
                    }
                    ctrl.menuLeftParent.html(ul);
                    pedidos.menuleft.showMenu();
                    this.liSelect();
                    // employees.hideDivFilters();

                },
                liSelect: function () {
                    ctrl.menuLeftParent.find('li[data-select=true]').css({
                        'background': '#fff'
                    })
                    ctrl.menuLeftParent.find('li[data-select=true] span').css('color', 'rgb(57, 68, 76)');
                },
                removeSelect: function () {
                    var element = ctrl.menuLeftParent.find('li[data-select=true]');
                    element.removeAttr('style');
                    element.removeAttr('data-select');
                    element.find('span').removeAttr('style');
                }
                ,
                listeners: {
                    click_li: function () {
                        that.contents.removeSelect();
                        $(this).attr('data-select', 'true');
                        that.contents.liSelect();
                        if ($(this).find('span').html().trim().toLowerCase() != 'todos') {
                            ctrl.cboTipoModalidad.show();
                            that.contents.fillGrillaXtipoEmpleado(parseInt($(this).attr('data-id')));
                            employees.fillTipoModalidad($(this).attr('data-id'));
                            //employees.showDivFilters();
                        } else {
                            ctrl.cboTipoModalidad.hide();
                            that.contents.fillGrillaXtipoEmpleado(parseInt($(this).attr('data-id')));
                            //employees.hideDivFilters();
                        }

                        return false;
                    }
                },
                fillGrillaXtipoEmpleado: function (iCodigoTipoEmpleado) {
                    ctrl.cboTribunales.val('');
                    ctrl.cboSituacionMilitar.val('');
                    ctrl.cboTipoModalidad.val('');

                    employees.disabledAllSelect();
                    employees.clearSelect(ctrl.cboGradoMilitar);

                    switch (iCodigoTipoEmpleado) {
                        case 100:
                            employees.selectAvalibity(ctrl.cboSituacionMilitar)
                            employees.selectDisabled(ctrl.cboInstitucion)
                            ctrl.cboInstitucion.val(40);
                            employees.fillGradoXinstitucion();
                            employees.selectAvalibity(ctrl.cboGradoMilitar);
                            break;
                        case 200:

                            employees.selectAvalibity(ctrl.cboInstitucion)
                            ctrl.cboInstitucion.find('option').each(function () {
                                if ($(this).val() == 40) {
                                    $(this).hide();
                                }
                            })
                            ctrl.cboInstitucion.val('');

                            break;
                        default:
                            employees.selectAvalibity(ctrl.cboInstitucion);
                            ctrl.cboInstitucion.find('option').show();
                            ctrl.cboInstitucion.val('');
                            break;
                    }
                    employees.fillEmployees(ctrl.menuLeftParent.find('li[data-select=true]').attr('data-id'));
                }
            }
        }
        ,
        references: function () {
            var tagHandles = new this.tagHandles();
            tagHandles.initialize();
        },
        tagHandles: function () {

            this.initialize = function () {
                this.handle.initialize(this.control)
            },
            this.control = {
                gridQuerysEmployees: $('#gridQuerysEmployees')

            },
        this.handle = {
            initialize: function (ctrl) {
                this.ctrl = ctrl;
                this.handleLoad();
            },
            handleLoad: function () {
                this.handleGenerateMenu(function () {
                    employees.setAfterMenuParent();
                    employees.footerMenuOptions();
                    this.handleSelecteRow();
                }.bind(this))
            },

            handleGenerateMenu: function (callback) {
                menu.initialize(callback)
            },
            handleSelecteRow: function () {
                listener.click_ItemTable();

            }
        }


        }


    }

    var listener = {
        selectItem_cboInstitucion: function () {
            if ($(this).val() != '') {
                employees.selectAvalibity(ctrl.cboSituacionMilitar);
                employees.selectAvalibity(ctrl.cboGradoMilitar);
            } else {
                employees.selectDisabled(ctrl.cboSituacionMilitar);
                employees.selectDisabled(ctrl.cboGradoMilitar);
                ctrl.cboGradoMilitar.val('');
            }

            ctrl.cboSituacionMilitar.val('');
            employees.fillGradoXinstitucion();
        },
        selectItem_cboGradoMilitar: function () {
            if ($(this).val() != '') {
                employees.selectAvalibity(ctrl.cboSituacionMilitar);
            } else {
                // employees.selectDisabled(ctrl.cboSituacionMilitar);
                ctrl.cboSituacionMilitar.val('');
            }
        }
        ,
        click_btnBuscar: function () {
            var iCodigoTipoEmpleado = ctrl.menuLeftParent.find('li[data-select=true]').attr('data-id');
            employees.fillEmployees(iCodigoTipoEmpleado);
        },
        click_ItemTable: function () {
            ctrl.gridQuerysEmployees.find('tbody tr').dblclick(function () {
                var codigo = $(this).find('[class~="rowId"] input').val();
                var sitem = pedidos.codTipoSistemaDOM.val();
                window.location.href = "/Employees/Avatar?codPersona=" + codigo + "&codTipoSistema=" + sitem;
            })
        },
        click_impresion: function () {
            pedidos.popup.executePopupNoBor(""
                       , '', '/Reports/_OptionsPrintDialog', '400', '200', function () {
                           pedidos.popup.hideButton();
                       },"","no");
            //window.location.href = "/Reports/ViewPdf"
        }
    }

    $(document).ready(function () {
        employees.initialize();

    })
})(pedidos.ajax, pedidos.menusJs);