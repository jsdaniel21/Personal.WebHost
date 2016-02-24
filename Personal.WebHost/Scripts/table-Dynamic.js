(function () {

    var _jsonIdentificacion = [];

    var ws = {
        listTypeIdentificacion: function (callback) {
            $.ajax({
                type: 'get',
                url: '/Employees/listTypeIdentificacion',
                dataType: 'json',
                success: function (e) {
                    callback(e)
                }
            })
        }
    }

    var ctrl = {
        queryIdentificacion: $('#queryIdentificacion')
    }

    var tags = function () {

        var that = this;

        this.setEventsTags = function () {

        }
        this.addRowBody = function () {
            _private.createRow();
        }

        this.isExistRow = function (target) {
            if ($(target).parents('tr').next().length > 0) {
                return true;
            } else {
                return false;
            }
        }

        this.colorkBorderTDFirst = function (target) {
            $(target).parents('td').prevAll('td:first-child').css('background', 'rgb(200, 79, 215)')
        }

        this.validateInputRow = function (val) {
            if (val == "") {
                // alert('no has ingresado nigun valor')
                return true;
            }
            return false;
        }

        this.disableElements = function (target) {
            target.removeAttr('style')
            target.addClass('input-convert-cell')
            target.css({ 'width': '300px', 'padding': '1px 1px 1px 6px' })
            var tr = target.parents('tr');
            tr.find('span div[class*="umKEB"]').css({ 'background': '#f3f3f3', border: '1px solid transparent' })
            tr.find('span div[class*="umKEB"] div:nth-child(0n+2)').hide();
            //  tr.find('td:last-child > button').hide();
        }
        this.changeBackgroundHoverElements = function (target) {
            target.removeAttr('class');
            target.addClass('cellDefault');
            target.css({
                'font-style': 'normal',
                color: '#0C0A0A',
                'text-transform': 'lowercase',
                'background': 'white',
                'border': '1px solid #a6a6a6',
                'height': '20px',
                'padding': '1px 1px 1px 6px'
            })
            target.parents('tr').find('span div[class*="umKEB"]').removeAttr('style')
            target.parents('tr').find('span div[class*="umKEB"]').css({ 'background': 'white', border: '1px solid gray' })
            target.parents('tr').find('span div[class*="umKEB"] > div:nth-child(0n+2)').show();
        }

        this.addJsonIdentificacion = function (target) {
            var val = target.val();
            var tipo = target.parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');

            if (typeof (tipo) == 'undefined') {
                return false;
            }
            _private.ifExitsJson(tipo, function (i, b) {
                if (b == true) {
                    _private.updateJson(tipo, i, val);
                } else {
                    _jsonIdentificacion.push({ tipo: tipo, num: val })
                    _private.deleteItemListBox(target, tipo)
                }
            })
        }
        this.showButtonDeleteRow = function (target) {
            if (_jsonIdentificacion.length > 0) {
                target.parents('tr').find('td:last-child > button').show();
            }
        }

        this.removeElementsTr = function (target) {
            var tr = target.parents('tr');
            var body = tr.parents('tbody');
            var tipo = target.parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');
            if (body.find('tr').length == 1) {
                alert('es necesario agregar al menos un documento')
                return false;
            }
            tr.fadeOut('slow', function () {
                $(this).remove();
                //if (body.find('tr').length == 0) {
                //  that.addRowBody();
                //}
            })
            _private.ifExitsJson(tipo, function (i, b) {
                if (b == true) {
                    _jsonIdentificacion.splice(i, 1);
                }
            })
        }


        var _private = {
            deleteItemListBox: function (listbox) {
                listbox.find('div').show();
                listbox.find('div').each(function (i) {
                    _private.ifExitsJson($(this).attr('data-value'), function (i, b) {
                        if (b == true) {
                            $(this).hide();
                        }
                    }.bind(this))
                })
            },
            updateJson: function (tipo, indice, val) {
                _jsonIdentificacion[indice].tipo = tipo;
                _jsonIdentificacion[indice].num = val;
            },
            ifExitsJson: function (tipo, callback) {
                var bool = false;
                var indice = 0;
                for (var i = 0; i < _jsonIdentificacion.length; i++) {

                    if (_jsonIdentificacion[i].tipo == tipo) {
                        bool = true;
                        indice = i;
                        break;
                    }
                }
                callback(indice, bool)
            }
            ,
            createRow: function () {
                //recomendable que se asigne alos elmenetos cuando apenas estos se creaeen con javascript
                //es mandarlo directamente
                var tr = $('<tr />');
                var tdText = $('<td/>')
                var input = $('<input/>');
                var tdValue = $('<td/>')
                input.addClass('cellDefault')
                input.attr('placeholder', 'Numero del Documento');
                input.attr('type', 'text')
                input.css('width', '300px')
                input.keyup(that.input.keyup)//aqui creo al elementyo y lemando su evento
                input.blur(that.input.blur);
                input.hover(that.input.hover)
                tdText.append(input);
                tdValue.append(this.listBoxt())
                tdValue.css('width', '90px')
                var tdbutton = $('<td/>');
                var button = $('<button />');
                button.css({ 'background': 'transparent', 'border': '0px', 'opacity': '1', 'cursor': 'pointer' })
                var img = $('<img/>');
                img.attr({ 'src': '../Images/ico-table-cancel.png' })
                button.append(img);
                button.addClass('opacity');
                button.click(that.tr.clickButtonTr)
                button.hide();
                tdbutton.append(button)
                tr.append($('<td/>'));
                tr.append(tdValue);
                tr.append(tdText);
                tr.append(tdbutton)
                tr.hover(that.tr.hover)
                ctrl.queryIdentificacion.find('tbody').append(tr);
            }
            ,
            listBoxt: function () {
                var detailsCell = $('<div/>');
                detailsCell.addClass('combo-details-cell-content');
                var inlineInput = $('<div/>');
                inlineInput.addClass('umIEB form-inline-input');
                var span = $('<span />');
                span.addClass('umLEB');
                var displayText = $('<div />');
                displayText.addClass('umAX umLT umKEB combo-display-text');
                var divTextView = $('<div/>');
                divTextView.addClass('umAX umMT');
                divTextView.html('--select--')
                var divIco = $('<div/>');
                divIco.addClass('umAX umJT');
                var listboxContent = $('<div/>');
                listboxContent.addClass('listbox-content');
                var tipo = 0;
                ws.listTypeIdentificacion(function (e) {
                    pedidos.listbox.initialize(listboxContent, e, "I_COD_TIPO_IDENTIFICACION", "V_ABREV_IDENTIFICACION")
                    pedidos.listbox.handleClickListboxt(listboxContent, function (target) {
                        var tipoAfter = target.attr('data-value');
                        var input = listboxContent.parents('tr').find('td > input');
                        if (typeof (tipo) != 'undefined') {
                            _private.ifExitsJson(tipo, function (i, b) {
                                if (b == true) {
                                    _private.updateJson(tipoAfter, i, input.val())
                                }
                            })
                        } else {
                            if (input.val() != '') {
                                input.trigger('keyup')
                            }
                        }

                        //after
                    }.bind(this), function () {
                        //before
                        tipo = listboxContent.prevAll(':first-child').attr('data-value');
                        var input = listboxContent.parents('tr').find('td > input');
                        _private.deleteItemListBox(listboxContent)
                        that.changeBackgroundHoverElements(input)
                        if (_jsonIdentificacion.length == 3 && typeof (tipo) != 'undefined') {
                            return true;
                        } else {
                            return false;
                        }

                    })
                })

                displayText.append(divTextView);
                displayText.append(divIco);
                displayText.append(listboxContent);
                span.append(displayText);
                span.css('margin-left', '0px')
                inlineInput.append(span);
                detailsCell.append(inlineInput);
                detailsCell.css({ width: '200px', 'margin-top': '1px' })
                detailsCell.find('span > div[class]').hover(that.listbox.hoverListbox)
                return detailsCell; ''
            }

        }

    }



    var handles = function () {
        tags.call(this);
        var that = this;
        var _listener = {
            initialize: function () {
                this.load();
            },
            load: function () {
                that.setEventsTags();
                that.addRowBody();
            },
            keyup: function () {
                var tipo = $(this).parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');
                if (that.validateInputRow($(this).val() == false && typeof (tipo) != 'undefined')) {
                    that.addJsonIdentificacion($(this))
                    that.showButtonDeleteRow($(this))
                }
                if (that.isExistRow(this) == false && typeof (tipo) != 'undefined') {
                    that.colorkBorderTDFirst(this);
                    if (_jsonIdentificacion.length < 3) {
                        that.addRowBody();
                        $(this).removeClass('cellDefault');
                    }
                }
            },

            blur: function (e) {
                if (that.validateInputRow($(this).val()) == false && $(this).parents('tr').next().length >= 0
                    || that.validateInputRow($(this).val()) == false && $(this).parents('tr').index() == 2) {
                    that.disableElements($(this))
                }
            }
            , hover: function (e) {
                if (that.validateInputRow($(this).val()) == false) {
                    that.changeBackgroundHoverElements($(this))
                    $(this).focus();
                    e.stopPropagation();
                }
            },
            hoverListbox: function () {
                var input = $(this).parents('tr').find('td > input');
                var val = input.val();
                if (that.validateInputRow(val) == false && $(this).parents('tr').next().length >= 0
                    || $(this).parents('tr').index() == 2) {
                    that.changeBackgroundHoverElements(input)
                    input.focus();
                }
            },
            hoverTr: function (e) {
                var input = $(this).find('td > input');
                if ($(this).next().length > 0 && !input.is(':focus')) {
                    that.disableElements(input)
                }
            },
            clickButtonTr: function (e) {
                that.removeElementsTr($(this));
                e.stopPropagation();
            }

        }
        this.input = {
            keyup: _listener.keyup, blur: _listener.blur, hover: _listener.hover
        }
        this.listbox = { hoverListbox: _listener.hoverListbox }
        this.tr = { hover: _listener.hoverTr, clickButtonTr: _listener.clickButtonTr }
        //Execute Class
        this.listener = function () {
            _listener.initialize();
        }
    }

    handles.prototype = new tags();
    handles.prototype.constructor = handles;

    $(document).ready(function () {
        var x = new handles();
        x.listener();
    })
})();