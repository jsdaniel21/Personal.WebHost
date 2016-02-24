(function () {

    var _jsonIdentificacion = [];
    var _jsonAvatarPerfil = [];
    var ws = {
        resetContent: function (callback) {
            $.ajax({
                type: 'get',
                url: '/Employees/_DetailsPeople',
                data: { codMenu: ctrl.codMenu, codPersona: ctrl.codPersona },
                dataType: 'html',
                success: function (e) {
                    callback(e)
                }
            })
        },
        registrarCaracteristicas: function (callback) {
            $.ajax({
                type: 'post',
                url: '/Employees/registrarCaracteristicas/',
                data: $('form').serialize(),
                dataType: 'json',
                success: function (e) {
                    callback(e)
                }
            })
        },
        GetpersonaIdentificacion: function (codpersona, callback) {
            $.ajax({
                type: 'get',
                url: '/Employees/listarIdentificacionPersonal/',
                dataType: 'json',
                data: { codpersona: codpersona },
                success: function (e) {
                    callback(e)
                }
            })

        },
        listTypeIdentificacion: function (callback) {
            $.ajax({
                type: 'get',
                url: '/Employees/listTypeIdentificacion',
                dataType: 'json',
                success: function (e) {
                    callback(e)
                }
            })
        },
        PostpersonaIdentificacion: function (entity, op, callback) {
            $.ajax({
                type: 'post',
                data: JSON.stringify({ entity: entity, op: op }),
                contentType: 'application/json;charset=utf8',
                dataType: 'json',
                url: '/Employees/personaIdentificacion',
                //ASYNG--ASINCRONA quiere decir cuando es tru que lo datos sera en enviados ppor background de manera asincrona
                //async: false,
                async: false,
                success: function (e) {
                    callback(e)
                }
            })
        },
        fillDepartamentoCb: function (target, codPais, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'JSON',
                data: { codPais: codPais },
                url: '/Domicilio/fillDepartamentoCb',
                success: function (e) {
                    callback(target, e);
                }
            })
        }, fillProvinciaCb: function (target, codPais, codDepartamento, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { codPais: parseInt(codPais), codDepartamento: codDepartamento },
                contentType: 'application/json; charset=utf-8',
                url: '/Domicilio/fillProvinciaCb',
                success: function (e) {
                    callback(target, e)
                }
            })
        }, fillDistritoCb: function (target, codPais, codDepartamento, codProvincia, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { codPais: parseInt(codPais), codDepartamento: codDepartamento, codProvincia: codProvincia },
                contentType: 'application/json; charset=utf-8',
                url: '/Domicilio/fillDistritoCb',
                success: function (e) {
                    callback(target, e)
                }
            })
        }
    }

    var ctrl = {
        queryIdentificacion: $('#queryIdentificacion'),
        codMenu: $('#codMenu').val(),
        atras: $('[data-static="true"]'),
        guardar: null,
        descartar: null,
        codPersona: $('#C_COD_PERSONA').val(),
        contengHomeMenu: $('div.content-menu-employees'),
        contentPage: $('div.content-Pages'),
        back: $('div.footer-command ul > li:first-child'),
        codDepartamento: $('#C_COD_DEPARTAMENTO'),
        codPais: $('#I_COD_PAIS'),
        codProvincia: $('#C_COD_PROVINCIA'),
        codDistrito: $('#C_COD_DISTRITO')
    }

    var tags = function () {

        var that = this;

        this.showAtras = function () {
            ctrl.atras.show();
        }

        this.setBottomFooter = function () {
            ctrl.guardar = $('#015-GUAR');
            ctrl.descartar = $('#039-DESC');
        }
        this.setEventsTags = function () {
            ctrl.guardar.click(this.footer.clickFooter)
            ctrl.descartar.click(this.footer.clickFooter)
            ctrl.back.click(this.footer.clickFooter)
            ctrl.codPais.change(that.select.changeItem)
            ctrl.codDepartamento.change(that.select.changeItem);
            ctrl.codProvincia.change(that.select.changeItem);
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
                    _private.updateJson(tipo, i, val, 'srv');
                } else {
                    that.addItemJson(tipo, val, 'loc')
                    _private.deleteItemListBox(target, tipo)
                }
            })
        }

        this.sizeJsonIdentificacion = function () {
            var count = 0;
            for (var int = 0; int < _jsonIdentificacion.length; int++) {
                if (_jsonIdentificacion[int].op != 'el') {
                    count++;
                }
            }
            return count;
        }
        this.addItemJson = function (tipo, val, op) {
            _jsonIdentificacion.push({ tipo: tipo, num: val, op: op })
        }
        this.showButtonDeleteRow = function (target) {
            if (that.sizeJsonIdentificacion() > 0) {
                target.parents('tr').find('td:last-child > button').show();
            }
        }

        this.removeElementsTr = function (target) {
            var tr = target.parents('tr');
            var body = tr.parents('tbody');
            var tipo = target.parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');


            if (that.sizeJsonIdentificacion() == 1) {
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
                    if (_jsonIdentificacion[i].op == 'srv') {
                        _jsonIdentificacion[i].op = 'el'
                    } else {
                        _jsonIdentificacion.splice(i, 1);
                    }
                }
            })
            if (that.sizeJsonIdentificacion() == 2) {
                that.addRowBody();
            }
        }

        this.sendJsonIdentificacion = function () {
            var entity = {};
            var count = 0;
            for (var i = 0; i < _jsonIdentificacion.length; i++) {
                entity.C_COD_PERSONA = ctrl.codPersona;
                entity.I_COD_TIPO_IDENTIFICACION = _jsonIdentificacion[i].tipo;
                entity.V_NUM_DOCUMENTO = _jsonIdentificacion[i].num;
                ws.PostpersonaIdentificacion(entity, _jsonIdentificacion[i].op, function (e) {
                    count += e;
                });
            }
            if (count > 0) {
                ws.resetContent(that.reloadCaracteristicas)
                //alert('se registraron correctamente los datos')
            }
        }

        this.addPreloadAvatarInput = function (op) {

            var queryEdit = document.querySelectorAll('[data-edit="true"]');
            var avatarData = document.querySelectorAll('div.data-employees-content div > label')
            for (var i = 0; i < queryEdit.length; i++) {
                for (var y = 0; y < avatarData.length; y++) {
                    if (queryEdit[i].getAttribute('name') == avatarData[y].getAttribute('name')) {
                        avatarData[y].innerHTML = "";
                        if (op == "ad") {
                            avatarData[y].appendChild(_private.addContentPreoloadAvatar())
                        } else if (op == "ch") {
                            var valor = "";
                            if (queryEdit[i].tagName == "SELECT") {
                                valor = queryEdit[i].options[queryEdit[i].selectedIndex].text == "" ? "--------" : queryEdit[i].options[queryEdit[i].selectedIndex].text;
                            } else {
                                valor = queryEdit[i].value == "" ? "--------" : queryEdit[i].value;
                            }
                            avatarData[y].innerHTML = valor;
                            $(avatarData[y]).fadeIn('slow')
                        }

                    }
                }
            }
        }

        this.addAvatarBeforeInput = function () {

        }
        this.fillIdentifiacionPersonal = function () {
            ws.GetpersonaIdentificacion(ctrl.codPersona, this.createDetailsIndentificacion.bind(this))
        }

        this.createDetailsIndentificacion = function (e) {
            for (var i = 0; i < e.length; i++) {
                var json = {
                    tipo: e[i].I_COD_TIPO_IDENTIFICACION, num: e[i].V_NUM_DOCUMENTO, des: e[i].MA_TIPO_IDENTIFICACION.V_ABREV_IDENTIFICACION, op: 'srv'
                }
                that.addItemJson(json.tipo, json.num, json.op)
                _private.createRow('dt', json);
            }
            $('table').parents('div.form-content').prevAll().mouseover(function () {
                ctrl.queryIdentificacion.find('tr').each(function () {
                    var input = $(this).find('td > input')
                    if (input.is(':focus')) {
                        input.trigger('blur')
                    }
                })
            })
            $('div.form-content ~ *').mouseover(function () {
                ctrl.queryIdentificacion.find('tr').each(function () {
                    var input = $(this).find('td > input')
                    if (input.is(':focus')) {
                        input.trigger('blur')
                    }
                })

            })




            if (e.length <= 2) {
                that.addRowBody();
            }
        }

        this.setBorderLeftPurple = function () {
            var input = document.querySelectorAll("div.form-row-cell > input");
            var select = document.querySelectorAll("div.form-row-cell > select");
            for (var i = 0; i < input.length; i++) {
                input[i].addEventListener('keyup', _private.changeStyleEdit)
            }
            for (var i = 0; i < input.length; i++) {
                select[i].addEventListener('change', _private.changeStyleEdit)
            }
        }

        this.afterRegisterCaracteristicas = function (e) {
            if (e > 0) {
                that.addPreloadAvatarInput("ch");
                that.sendJsonIdentificacion();
            }
        }

        this.reloadCaracteristicas = function (result) {
            ctrl.contentPage.hide();
            ctrl.contentPage.html(result);
            $('div#aux-foreground').css({ 'background': '#fff' })
            ctrl.contentPage.fadeIn('slow');
        }

        this.back = function () {
            $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
            $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
            ctrl.contengHomeMenu.fadeIn('slow');
            ctrl.contentPage.html('');
        }

        this.fillSelect = function (target, e) {
            var option = "";
            target.find('option:not(:first-child)').remove();
            that.removeOptions(target)
            //cuando en MVC se retornar un selectlist maneja un Text y un Value
            for (var i = 0; i < e.length; i++) {
                option += "<option  value=" + e[i].Value + ">" + e[i].Text + "</option>"
            }
            target.append(option)
        }

        this.removeOptions = function (target) {
            switch (target.attr('id')) {
                case 'I_COD_PAIS':
                    ctrl.codDepartamento.find('option:not(:first-child)').remove()
                    ctrl.codProvincia.find('option:not(:first-child)').remove()
                    ctrl.codDistrito.find('option:not(:first-child)').remove()
                    break;
                case 'C_COD_DEPARTAMENTO':
                    ctrl.codProvincia.find('option:not(:first-child)').remove()
                    ctrl.codDistrito.find('option:not(:first-child)').remove()
                    break;
                case 'C_COD_PROVINCIA':
                    ctrl.codDistrito.find('option:not(:first-child)').remove()
                    break;
            }


        }
        var _private = {

            addContentPreoloadAvatar: function () {
                var div = document.createElement('div');
                div.style.backgroundImage = "url('https://az213233.vo.msecnd.net/Content/5.2.00298.7.150326-1058/Images/icon-status-status-dots-anim-16.gif')"
                div.style.width = "80px";
                div.style.margin = "auto";
                div.style.borderBottom = "0"
                return div;
            },
            changeStyleEdit: function (e) {
                var t = /^[a-zA-Z0-9 ,]+$/
                //var key = window.Event ? e.which : e.keyCode
                //if (e.ket) {
                //  return false;
                //}
                var width = e.target.offsetWidth;
                var disccount = e.target.tagName == 'SELECT' ? 0 : 15;

                if (e.target.getAttribute('data-edit') == null) {
                    e.target.style.width = (parseInt(width) - disccount).toString() + 'px';
                    e.target.style.borderLeft = "5px solid rgb(200, 79, 215)"
                    e.target.style.outline = "none";
                    e.target.setAttribute('data-edit', 'true');
                }
            },
            deleteItemListBox: function (listbox) {
                listbox.find('div').show();
                listbox.find('div').each(function (i) {
                    for (var i = 0; i < _jsonIdentificacion.length; i++) {
                        if (_jsonIdentificacion[i].tipo == $(this).attr('data-value') &&
                            _jsonIdentificacion[i].op != 'el') {
                            $(this).hide();
                            break;
                        }
                    }
                })
            },
            updateJson: function (tipo, indice, val, op) {
                _jsonIdentificacion[indice].tipo = tipo;
                _jsonIdentificacion[indice].num = val;
                if (typeof (op) != 'undefined') {
                    _jsonIdentificacion[indice].op = op
                }


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
            createRow: function (op, json) {
                //recomendable que se asigne alos elmenetos cuando apenas estos se creaeen con javascript
                //es mandarlo directamente
                var tr = $('<tr />');
                var tdText = $('<td/>')
                var input = $('<input/>');
                var tdValue = $('<td/>')
                var listBox = this.listBoxt();
                input.addClass('cellDefault')
                input.attr('placeholder', 'Numero del Documento');
                input.attr('type', 'text')
                input.css('width', '300px')
                input.keyup(that.input.keyup)//aqui creo al elementyo y lemando su evento
                input.blur(that.input.blur);
                input.hover(that.input.hover)
                tdText.append(input);
                tdValue.append(listBox)
                tdValue.css('width', '90px')
                var tdbutton = $('<td/>');
                var button = $('<button />');
                button.attr('type', 'button')
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
                var elements = { listBox: listBox, input: input }
                this.setValuesDetails(op, json, elements)
            },
            setValuesDetails: function (op, json, elements) {
                if (op == 'dt') {
                    elements.input.val(json.num)
                    elements.input.trigger('blur')
                    that.disableElements(elements.input)
                    var textList = elements.listBox.find('span > div[class] > div:first-of-type');
                    textList.attr('data-value', json.tipo);
                    textList.html(json.des)
                }
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
                            _private.updateJson(tipo, i, input.val(), 'el')
                            _private.ifExitsJson(tipo, function (i, b) {
                                if (b == true) {
                                    _private.updateJson(tipoAfter, i, input.val(), 'srv')
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
                        if (that.sizeJsonIdentificacion() == 3 && typeof (tipo) != 'undefined') {
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
                var bottomOption = new pedidos.menusJs.tag();
                bottomOption.handle.footerMenuOptions(pedidos.codTipoSistemaDOM.val(), pedidos.username.val()
                  , ctrl.codMenu, this.load)
            },
            load: function () {
                that.setBottomFooter();
                that.setEventsTags();
                //that.addRowBody();
                that.showAtras();
                that.fillIdentifiacionPersonal();
                that.setBorderLeftPurple();

            }, changeItem: function () {
                switch ($(this).attr('id')) {
                    case 'I_COD_PAIS':
                        ws.fillDepartamentoCb(ctrl.codDepartamento, ctrl.codPais.val(), that.fillSelect)
                        break;
                    case 'C_COD_DEPARTAMENTO':
                        ws.fillProvinciaCb(ctrl.codProvincia, ctrl.codPais.val(), ctrl.codDepartamento.val(), that.fillSelect)
                        break;
                    case 'C_COD_PROVINCIA':
                        ws.fillDistritoCb(ctrl.codDistrito, ctrl.codPais.val(), ctrl.codDepartamento.val(), ctrl.codProvincia.val(), that.fillSelect)
                        break;
                    default:
                }
            }
            ,
            clickFooter: function () {
                var id = $(this).attr('id');
                switch (id) {
                    case '015-GUAR':
                        that.addPreloadAvatarInput("ad");
                        setTimeout(function () {
                            ws.registrarCaracteristicas(that.afterRegisterCaracteristicas)
                        }, 500)
                        break;
                    case '039-DESC':
                        ws.resetContent(that.reloadCaracteristicas)
                        break;
                    default:
                        that.back();
                        break;

                }
            }
            ,
            keyup: function () {
                var tipo = $(this).parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');
                if (that.validateInputRow($(this).val()) == false && typeof (tipo) != 'undefined') {
                    that.colorkBorderTDFirst($(this))
                    if (typeof (tipo) != 'undefined') {
                        that.addJsonIdentificacion($(this))
                        that.showButtonDeleteRow($(this))
                    }
                }
                if (that.isExistRow(this) == false && typeof (tipo) != 'undefined') {
                    if (that.sizeJsonIdentificacion() < 3) {
                        that.addRowBody();
                        $(this).removeClass('cellDefault');
                    }
                }
            },

            blur: function (e) {
                var tipo = $(this).parents('tr').find('span div[class*="umKEB"] div:first-child').attr('data-value');
                if (typeof (tipo) != 'undefined') {
                    if (that.validateInputRow($(this).val()) == false && $(this).parents('tr').next().length >= 0
                        || that.validateInputRow($(this).val()) == false && $(this).parents('tr').index() == 2) {
                        that.disableElements($(this));
                        that.showButtonDeleteRow($(this))
                    }
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
        this.input = { keyup: _listener.keyup, blur: _listener.blur, hover: _listener.hover }
        this.listbox = { hoverListbox: _listener.hoverListbox }
        this.tr = { hover: _listener.hoverTr, clickButtonTr: _listener.clickButtonTr }
        this.footer = { clickFooter: _listener.clickFooter }
        this.select = { changeItem: _listener.changeItem }
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