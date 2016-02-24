/// <reference path="../_references.js" />


(function (ajax, menu) {
    ajax = new ajax();
    'use strict';
    var ws = {


    }

    var bottomOption = new pedidos.menusJs.tag();

    var employees = {

        initialize: function () {
            this.references();
        },
        references: function () {
            var tag = new this.tag();
            tag.initialize();
        },
        tag: function () {

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
                    this.handleSelecteRow();
                }.bind(this))
            },

            handleGenerateMenu: function (callback) {
                menu.initialize(callback)
            },
            handleSelecteRow: function () {
                this.ctrl.gridQuerysEmployees.find('tbody tr').dblclick(function () {
                    var codigo = $(this).find('[class~="rowId"] input').val();
                    var sitem = pedidos.codTipoSistemaDOM.val();
                    window.location.href = "/Employees/Avatar?codPersona=" + codigo + "&codTipoSistema=" + sitem;
                })
                bottomOption.handle.footerMenuOptions(pedidos.codTipoSistemaDOM.val(),
                pedidos.username.val(), $('#newData').attr('data-parent'), null)
            }
        }


        }


    }

    $(document).ready(function () {
        employees.initialize();
    })
})(pedidos.ajax, pedidos.menusJs);