/// <reference path="../../_references.js" />

(function () {
    ajax = new pedidos.ajax();

    var ws = {

        listInstancia: function (typeInstitution, callback) {
            ajax.ajax('/Cargo/listInstanciaForTypeInst', JSON.stringify({ typeInstitution: typeInstitution }), function (e) {
                callback(e)
            })
        },
        listarCargosMaster: function (callback) {
            ajax.ajax('/Cargo/listarCargosMaster', null, function (e) {
                callback(e)
            })
        }

    }


    var createCharge = {

        intialize: function () {
            this.references();
        },
        references: function () {
            this.handles = new this.handles();
            this.handles.intialize();
        },
        handles: function () {

            this.intialize = function () {
                this.tag.intialize(this.control);
            },
            this.control = {
                cboinstancia: $('#cboinstancia'),
                listInstancia: $('#listbox-instancia'),
                listboxArea: $('#listbox-area'),
                listboxCharge: $('#listbox-cargo'),
                gridQueryCargos: $('#gridQueryCargos')
            }
            ,
            this.tag = {

                intialize: function (ctrl) {
                    this.ctrl = ctrl;
                    this.event();
                },
                event: function () {
                    this.handleLoad();
                    this.handleSelectedInstancia();
                    
                },
                handleLoad: function () {
                    this.loadInstancia();

                    //this.showContentPersonalize(this.ctrl.listboxArea)
                },
                loadInstancia: function () {
                    ws.listInstancia(1, function (e) {
                        pedidos.listbox.initialize(this.ctrl.listInstancia, e, "I_COD_INSTANCIA", "V_DES_INSTANCIA")
                        pedidos.listbox.handleClickListboxt(this.ctrl.listInstancia, function () {
                            pedidos.listbox.handleResetAfterItem(this.ctrl.listInstancia, 2)
                            this.loadArea();
                        }.bind(this), null)
                    }.bind(this))
                },
                loadArea: function () {
                    var element = document.getElementById('tree');
                    if (element != null) {
                        element.remove()
                    }
                    var LefttreeArea = document.createElement('div');
                    LefttreeArea.id = "tree"
                    LefttreeArea.classList.add('acidjs-css3-treeview')
                    this.ctrl.listboxArea.append(LefttreeArea)
                    pedidos.treeArea.initialize(LefttreeArea, this.ctrl.listInstancia.prev().prev().attr('data-value'), function (target) {
                        this.ClickItemTree(target, this.ctrl.listboxArea)
                    }.bind(this))

                    this.showContentPersonalize(this.ctrl.listboxArea)
                },
                beforeVerifyNotSelectedListboxt: function (idDependencia) {

                    var bool = false;
                    if (idDependencia.prev().prev().attr('data-value') < 0) {
                        alert('error en el sistema')
                        bool = true;
                    };
                    return bool;
                }
                , showContentPersonalize: function (id) {
                    id.parent().unbind('click')
                    id.parent().click(function () {
                        if (this.beforeVerifyNotSelectedListboxt(this.ctrl.listInstancia) == true) {
                            return false;
                        }
                        if (!id.parent().find('div.listbox-content').is(':hidden')) {
                            id.parent().find('div.listbox-content').hide();
                            return false;
                        }

                        id.parent().find('div.listbox-content').show();
                        this.closeTree(id);
                    }.bind(this))
                }
                ,
                ClickItemTree: function (target, listboxArea) {
                    var value = $(target).parent().attr('for');
                    var text = $(target).parents('div.form-row').prev().find('div').html();

                    var input = $('<input />');
                    input.attr('type', 'hidden');
                    input.attr('name', text.trim());
                    input.val(value);

                    var html = $(target).parent().next().html();
                    
                    listboxArea.prev().prev().attr('data-value', value);
                    listboxArea.prev().prev().html(html)
                    listboxArea.prev().prev().append(input);
                    listboxArea.hide();
                    this.loadCargosMaster();
                    pedidos.listbox.handleResetAfterItem(listboxArea, 1)
                },
                closeTree: function (id) {
                    var bit = 0;
                    id.mouseover(function () {
                        bit = 0;
                    })
                    id.mouseout(function () {
                        bit = 1;
                    })
                    $('body').unbind('click');
                    $('body').click(function () {
                        if (bit === 1) {
                            $('body').unbind('click');
                            id.unbind('mouseover');
                            id.unbind('mouseout');
                            id.hide();
                        }
                    }.bind(this))
                }
                ,
                loadCargosMaster: function () {
                    ws.listarCargosMaster(function (e) {
                        pedidos.listbox.initialize(this.ctrl.listboxCharge, e, "I_COD_CARGO", "V_DES_CARGO")
                        pedidos.listbox.handleClickListboxt(this.ctrl.listboxCharge, null, function () {
                            var bool = this.beforeVerifyNotSelectedListboxt(this.ctrl.listboxArea)
                            return bool;
                        }.bind(this))
                    }.bind(this))
                },                            
                handleSelectedInstancia: function () {
                    this.ctrl.cboinstancia.change(function () {
                        var LefttreeArea = document.createElement('div');
                        LefttreeArea.id = "tree"
                        LefttreeArea.classList.add('acidjs-css3-treeview')
                        LefttreeArea.style.background = 'rgb(226, 226, 226)';
                        LefttreeArea.style.position = "fixed";
                        LefttreeArea.style.top = "50%";
                        LefttreeArea.style.margin = "-280px 0px 0px 0px";
                        LefttreeArea.style.height = "560px";
                        LefttreeArea.style.width = "340px";
                        //LefttreeArea.style.left = "25%";
                        $('body').append(LefttreeArea);
                        pedidos.treeArea.initialize(LefttreeArea)

                    })
                }

            }

        }

    }

    $(document).ready(function () {
        createCharge.intialize();
    })

})();
