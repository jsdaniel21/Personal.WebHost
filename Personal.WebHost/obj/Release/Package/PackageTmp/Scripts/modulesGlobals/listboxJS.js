/// <reference path="../_references.js" />
(function (ajax) {
    ajax = new ajax();

    pedidos.listbox = {

        initialize: function (id, e, value, text) {
            this.id = id;
            this.value = value;
            this.text = text;
            this.loadData(e);
        },

        loadData: function (e) {
            this.id.html('');
            for (var i = 0; i < e.length; i++) {
                this.id.append('<div class="umnt" style="-webkit-user-select: none;" data-estado="' +
                    e[i].C_ESTADO_APERTURA + '" data-value="' + eval("e[i]" + '.' + this.value) + '">'
                    + eval("e[i]" + '.' + this.text)
                    + '</div>');
            }
        },
        handleClickListboxt: function (id, callback, callbackContent) {
            this.showContentListbox(id, callbackContent)
            var clearId = this.clearId;
            id.find('div').click(function (event) {
          
                var text = $(this).parent().prevAll('span').attr('data-name');
                var value = $(this).data('value');                               
                var input = $('<input />');
                input.attr('type', 'hidden');
                input.attr('name', typeof text === 'undefined' ? "" : text.trim());
                input.val(value);

                var html = $(this).html();
                $(this).parent().prev().prev().attr('data-value', value);
                $(this).parent().prev().prev().html(html)
                $(this).parent().prev().prev().append(input);
                $(this).parent().next().val(value)
                if (callback != null) {
                    callback($(this));
                }
                clearId(id);
                return false;
            })
        },
        showContentListbox: function (id, callback) {
            id.parent().click(function () {
          
                if (callback != null) {
                    if (callback() == true) {
                        return false;
                    }
                }
                id.parent().find('div.listbox-content').show(0.7, function () {
                    $('body').click(function () {
                        this.clearId(id);
                    }.bind(this))
                }.bind(this));
            }.bind(this))
        },
        clearId: function (id) {
            id.hide();
            $('body').unbind('click');
        },
        handleResetAfterItem: function (id, cantItem) {
            var index = id.index('div.listbox-content');
            var cant = 0;
            $('div.listbox-content').each(function (i) {
                if (i > index) {
                    $(this).prev().prev().html('seleccione');
                    $(this).prev().prev().attr('data-value', '-1')
                    cant++;
                    if (cant == cantItem) {
                        return false;
                    }
                }
            })
        }
                ,

    }



}(pedidos.ajax));