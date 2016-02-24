/// <reference path="../_references.js" />



(function () {

    pedidos.slidePoint = {
        initialize: function () {
            this.references();
        },
        references: function () {
            var fc = new this.tag();
            fc.initialize();
        },
        tag: function () {
            this.initialize = function () {
                this.handles.initialize(this.control)
            },
            this.control = {
                backgroundPopup: $('.fxs-modalpresenter-shield')
            }
            this.handles = {
                initialize: function (control) {

                    this.ctrl = control;
                    this.events();
                },
                events: function () {
                    this.handleLoad();
                },
                handleLoad: function () {
                
                    this.ctrl.backgroundPopup.css({ 'background': '#171717', 'opacity': '1' })
                    this.ctrl.backgroundPopup.show();
                }

            }

        }



    }


})();