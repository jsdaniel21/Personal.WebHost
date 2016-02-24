/// <reference path="../_references.js" />


(function (ajax) {
    ajax = new ajax();

    var ws = {

    }

    pedidos.treeArea = {
        initialize: function (idContainer, instancia, callback) {
            this.references(idContainer, instancia, callback);
        },
        references: function (idContainer, instancia, callback) {
            var x = new this.tag(idContainer, instancia, callback);
            x.initialize();
        },
        tag: function (idContainer, instancia, callback) {
            this.initialize = function () {
                this.handle.initialize();
            }

            this.handle = {
                initialize: function () {

                    this.events();
                },
                events: function () {
                    this.handleLoad();
                },
                handleLoad: function () {
                    $(idContainer).html('')
                    ajax.ajax('/area/listarAreaForIsntancia', JSON.stringify({ codInstancia: instancia }), function (e) {
                        var parent = $("<ul/>")
                        parent.attr('id', 'treeview');
                        var child;
                        var data = e;
                        var nivel, desArea, codAreaSuperior, codarea
                        //primero cargamos todos los padrs que son Nivel 1
                        //for (var i in data)
                        if (data.length == 0) {
                            return false;
                        }

                        for (var i = data.length - 1; i >= 0; i--) {

                            nivel = data[i].clsInstanciaArea.I_NIVEL_INSTANCIA_AREA;

                            desArea = data[i].clsArea.V_DES_FUNCIONES
                            codarea = data[i].clsInstanciaArea.C_COD_AREA
                            codAreaSuperior = data[i].clsInstanciaArea.C_COD_AREA_SUPERIOR
                            if (nivel == 1) {
                                child = $("<li/>");
                                child.html('' +
                              "<input type='checkbox' checked='checked' id=" + codarea + " /><label for=" + codarea +
                              "><span class='spanNotChk'></span></label><label class='des'>" + desArea + "</label>");
                                child.attr('class', 'expandIcon');
                                child.attr("data-value", codarea);
                                child.attr("data-value-superior", codAreaSuperior)
                                parent.append(child);
                                data.splice(i, 1)

                            }
                        }
                        if (data.length > 0) {
                            var total = data.length - 1;
                            var buscar = data[total].clsInstanciaArea.C_COD_AREA_SUPERIOR;
                        }

                        while (data.length > 0) {
                            parent.find("li").each(function (e) {
                                var parent = buscar
                                if (parent == $(this).data("value")) {
                                    var parentSub = $('<ul/>');
                                    for (var y = data.length - 1; y >= 0; y--) {
                                        codAreaSuperior = data[y].clsInstanciaArea.C_COD_AREA_SUPERIOR
                                        desArea = data[y].clsArea.V_DES_FUNCIONES
                                        codarea = data[y].clsInstanciaArea.C_COD_AREA
                                        if (parent == codAreaSuperior) {
                                            child = $("<li/>");
                                            child.html('' + "<input type='checkbox' checked='checked' id=" + codarea + " /><label for=" + codarea
                                                + "><span class='spanNotChk'></span></label><label class='des'>" + desArea + "</label>");
                                            child.attr('class', 'expandIcon');
                                            child.attr("data-value", codarea);
                                            child.attr("data-value-superior", codAreaSuperior)
                                            parentSub.append(child);
                                            data.splice(y, 1)
                                            total = data.length;
                                        }
                                    }
                                    $(this).append(parentSub)
                                }
                                total--;
                                if (total >= 0) {
                                    buscar = data[total].clsInstanciaArea.C_COD_AREA_SUPERIOR;
                                }
                            })
                        }
                        $(idContainer).append(parent);
                        this.treSelected();
                    }.bind(this))
                },
                treSelected: function () {
                    var element = $('#treeview').find('li:has(ul)');
                    //element.children('ul').hide();
                    $('#treeview').find('.expandIcon').unbind('click')
                    $('#treeview').find('.expandIcon').click(function (evt) {
                        if (this == evt.target) {
                            //$(this).find('span').toggleClass('spanChk');
                            $(this).toggleClass('el_expanded');
                            $(this).children('ul').toggle('medium');
                        }
                        if (!evt) var evt = window.event;
                        evt.cancelBubble = true; // in IE
                        if (evt.stopPropagation) evt.stopPropagation();
                    })
                    this.treeCheked();
                },
                treeCheked: function () {
                    $('.spanNotChk').unbind('click')
                    $('.spanNotChk').click(function (evt) {
                        $('#treeview').find('span').removeClass('spanChk')
                        $('li').find('label').removeAttr('style')
                        $(this).toggleClass('spanChk');
                        $(this).parent().next().css({
                            'text-decoration': 'underline',
                            'color': '#1583c8',
                            'font-weight': '600',
                            'width': '169px',
                            'display': 'inline-block'
                        })

                        callback(this);
                        if (!evt) var evt = window.event;
                        evt.cancelBubble = true; // in IE
                        if (evt.stopPropagation) evt.stopPropagation();
                    })
                }
            }

        }

    }



})(pedidos.ajax);