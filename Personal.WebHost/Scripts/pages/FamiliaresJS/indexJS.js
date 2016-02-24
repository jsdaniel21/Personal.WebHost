/// <reference path="../../_references.js" />

(function (ajax) {
    ajax = new ajax();

    var familysJS = {}

    var ws = {

        listTypeFamily: function (callback) {
            ajax.ajax('/Familiares/typeFamily', null, function (e) {
                callback(e);
            })
        }
    }

    familysJS.index = {
        initialize: function () {
            this.references();
        },
        references: function () {
            //instancia auna funcion construtora
            var tag = new this.tag();
            tag.initialize();
        }
        ,
        tag: function () {
            this.initialize = function () {
                this.handle.initialize(this.control)
            }
            this.control = {
                codTipoSistemaDOM: pedidos.codTipoSistemaDOM.val(),
                username: pedidos.username.val(),
                codMenu: $('#codMenu').val(),
                back: $('div.footer-command ul > li:first-child'),
                contentPage: $('div.content-Pages'),
                contengHomeMenu: $('div.content-menu-employees'),
                contentPagesAjax: $('#content-page-ajax'),
                gridList: $('#gridQueryFamilys'),
                itemOptions: $('div.itemList > ul')
            }
            this.handle = {
                initialize: function (ctrl) {
                    this.ctrl = ctrl;
                    this.handleLoad();
                },
                handleLoad: function () {
                    var bottomOption = new pedidos.menusJs.tag();
                    bottomOption.handle.footerMenuOptions(this.ctrl.codTipoSistemaDOM, this.ctrl.username, this.ctrl.codMenu,
                       function () {
                           this.eventsAfterLoadOtions();
                           this.ctrl.back.show();
                       }.bind(this))
                },
                loadAfterPopupVars: function () {
                    this.ctrl.guardar = $('#038-GUAR');
                    this.ctrl.item = $('div[class="combo-details-body"]:not([data-value="event"])')
                    this.ctrl.itemInput = $('table.table-control > tbody input');
                    this.ctrl.contentBody = $('div[class="combo-details-body"]')
                    this.ctrl.tableControl = $('table.table-control')
                }
                ,
                eventsAfterLoadOtions: function () {
                    this.loadAfterPopupVars();
                    this.loadAfterPopupVars();
                    this.handleKeyTextInput(this.ctrl.itemInput);
                    this.handleFocusItemInput(this.ctrl.itemInput)
                    this.handleHoverItem(this.ctrl.tableControl.find('tbody > tr[data-edit="true"]'))
                    this.loadTypefamily();
                    this.handleSaveData();
                },
       
              
                loadTypefamily: function () {

                    ws.listTypeFamily(function (e) {
                        this.ctrl.tableControl.find('tbody > tr > td:nth-child(0n+5)').each(function () {
                            var element = $(this).find('div[class~="umIEB"] div[class="listbox-content"]')
                            pedidos.listbox.initialize(element, e, "I_COD_TIPO_FAMILIAR", "V_DES_TIPO_FAMILIAR")
                            pedidos.listbox.handleClickListboxt(element, function () {
                                //    pedidos.listbox.handleResetAfterItem(this.ctrl.listInstancia, 2)
                                //    this.loadArea();
                            }.bind(this), null)

                        })

                    }.bind(this))
                }
                ,
                handleKeyTextInput: function (element) {

                    element.unbind('keydown')
                    element.keydown(function (e) {
                        //$(e.target).parents('div.combo-details-body').removeAttr('data-value'                  
                        if ($(e.target).parents('tr').attr('data-event') == 'true') {
                            $(e.target).parents('tr').attr('data-edit', 'true')
                            $(e.target).parents().removeAttr('data-event')

                            this.addItemRow($(e.target).parents('tr').html())
                            $(e.target).parents('tr').find('td:first-child').css('background', '#c84fd7')
                        }

                        $(e.target).css({
                            'font-style': 'normal',
                            'text-transform': 'lowercase',
                            'color': '#0C0A0A'
                        })
                    }.bind(this))
                },

                addItemRow: function (html) {
                    this.ctrl.tableControl.append('<tr data-event="true">' + html + '</tr>');
                    this.handleKeyTextInput(this.ctrl.tableControl.find('tbody > tr:last-child'))
                    this.handleFocusItemInput(this.ctrl.tableControl.find('tbody > tr:last-child input'))
                    this.handleHoverItem(this.ctrl.tableControl.find('tbody > tr:last-child'))
                    //this.eventsAfterContentPagesAjax();
                },
                handleFocusItemInput: function (element) {

                    var currentRow = 0;
                    var blurCurrentRow = 0;
                    var handleHoverItem = this.handleHoverItem;
                    var elementParameter = this.ctrl.contentBody
                    element.unbind('focus')
                    element.focus(function (e) {
                        //Si al poner el foco esta fila esta con estado no editado en true
                        // se pone falso --> pero al entrar se verifica si hay
                        // alguna fila en estado false para luego ponerla en true
                        if ($(this).parents('tr').attr('data-edit') == 'true') {
                            $(e.target).parents('tbody').find('tr[data-edit="false"] input').addClass('input-convert-cell')
                            $(e.target).parents('tbody').find('tr[data-edit="false"] input').removeAttr('style')
                            $(e.target).parents('tbody').find('tr[data-edit="false"]').attr('data-edit', 'true')
                            $(e.target).parents('tr').attr('data-edit', "false");
                            $(e.target).parents('tr').find('input').removeClass('input-convert-cell');
                            $(e.target).parents('tr').find('input').css({ 'border-color': '#a6a6a6', 'font-style': 'normal', 'text-transform': 'lowercase', 'color': '#0C0A0A' })
                        } else if ($(this).parents('tr').attr('data-event') == 'true') {
                            $(e.target).parents('tbody').find('tr[data-edit="false"] input').addClass('input-convert-cell')
                            $(e.target).parents('tbody').find('tr[data-edit="false"] input').removeAttr('style')
                            $(e.target).parents('tbody').find('tr[data-edit="false"]').attr('data-edit', 'true')
                        }
                        return false
                    })
                    //cuando salga del foco
                    //element.unbind('blur')

                },

                handleHoverItem: function (element) {
                    element.mouseover(function (e) {
                        if ($(this).attr('data-edit') == 'true') {
                            $(this).find('input').removeClass('input-convert-cell')
                            $(this).find('input').css({ 'border-color': '#a6a6a6', 'font-style': 'normal', 'text-transform': 'lowercase', 'color': '#0C0A0A' })

                        }
                    })

                    element.mouseout(function () {
                        if ($(this).attr('data-edit') == 'true') {
                            $(this).find('input').addClass('input-convert-cell')
                            $(this).find('input').css('border-color', 'transparent')
                        }

                        return false;
                    })
                },
                handleSaveData: function () {
                    this.ctrl.guardar.click(function () {
                        alert('dff')
                        //pedidos.slidePoint.initialize();
                    })
                }
            }

        }
    }

    $(document).ready(function () {
        familysJS.index.initialize();
    })
})(pedidos.ajax);



