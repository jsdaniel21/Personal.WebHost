/// <reference path="../_references.js" />

(function (ajax, menu) {

    'use strict';

    var ajax = new ajax();

    var js = {



    }

    var home = {

        initialize: function () {
            this.references();
        },
        references: function () {
            this.tag = new this.tag();
            this.tag.initialize();
        },
        tag: function () {
            this.initialize = function () {
                this.handle.initialize(this.controls)
            }

            this.controls = {
                dom: 'alert'
            }

            this.handle = {
                initialize: function (ctrl) {
                    this.handleGenerateMenu(function () {
                        alert('complete-structure')
                    })
                },
                parametersLocals: function () {

                },
                event: function () {

                },
                handleGenerateMenu: function (callback) {
                    menu.initialize(callback)
                }

            }

        }


    }


    $(document).ready(function () {
        home.initialize();
    })
})(pedidos.ajax, pedidos.menusJs);