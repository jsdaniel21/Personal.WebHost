/// <reference path="../../_references.js" />


/*ESTANDAR CORRECTO DE CREACION DE UNA APPI EN JAVASCRIPT */

(function () {


    var ws = {

        lisTipoModalidad: function (target, codTipoEmpleado, callback) {
            $.ajax({
                type: 'GET',
                url: '/Employees/listTypeModality',
                data: { codTipoEmpleado: codTipoEmpleado },
                dataType: 'json',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        listarGradoMilitarXinstitucion: function (target, codInstitucion, callback) {

            $.ajax({
                type: "GET",
                url: '/MaGradoMilitar/listarGradoMilitarXinstitucion',
                // contentType: "application/json; charset=utf-8",
                data: { iCodigoInstitucion: codInstitucion },
                dataType: 'json',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        saveEmployees: function (IICdentificacion) {

            $('form').find('select[disabled]').addClass('disabled');
            $('form').find('select[disabled]').removeAttr('disabled')

            var serialize = $('form').serialize() + '&IICdentificacion=' + JSON.stringify(IICdentificacion);
            $.ajax({
                type: "POST",
                url: "/Employees/saveEmployees",
                data: serialize,
                success: function (e) {
                    $('form').find('select[class*="disabled"]').removeClass('disabled');

                    if (e > 0) {
                        location.href = "Index"
                    }
                }
            })
        }
    }
    var ctrl = {
        rdbCivil: $('#rdbCivil'),
        rdbMilitar: $('#rdbMilitar'),
        p_headerPopup: $('p.aux-popup-header'),
        h2_TitlePopup: $('h2.PopUp-title-form'),
        d_containerIcoPopup: $('div.popup-footer-ico'),
        d_tabContentForm: $('div.tabcontent-form[data-page]'),
        s_cboInstitucion: $('#cboInstitucion'),
        s_cboGrado: $('#cboGrado'),
        s_cboSituacionMilitar: $('#cboSituacionMilitar'),
        d_PopUp: $('div#PopUp'),
        d_PopUpContentform: $('div.PopUp-content-form'),
        a_dataAddItem: $('a[data-add-item]'),
        d_containerIdentificacion: $('#container-identificacion'),
        r_boolGrade: $('input[name="boolGrade"]'),
        d_tipoEmpleado: $('#I_COD_TIPO_EMPLEADO'),
        s_tipoModalidad: $('#I_COD_TIPO_MODALIDAD')
    }

    var _pageCurrent = 1;

    var tags = {
        popUp: function () {

            //cuando se hace una funcion constructora se usa this ya pertenece a esa funcion constructora el this
            this.ChangeHeaderPopup = function () {
                ctrl.p_headerPopup.html('Nuevo Empleado')
                ctrl.h2_TitlePopup.html('Registrar Nuevo Empleado')
                ctrl.h2_TitlePopup.before(this.createPagination())
            }
            this.createIcoPopup = function (name) {
                var array = new Array(3);
                array["yes"] = "ico-popup-yes.png";
                array["next"] = "icon-next-popup.png";
                array["prev"] = "icon-prev-popup.png";

                var divContentIco = $('<div />');
                var divIcoImage = $('<div />');

                divIcoImage.css({
                    'background': "url('../../Images/" + array[name] + "')",
                    width: '37px',
                    height: '37px',
                    opacity: '0.7'
                })
                divIcoImage.addClass('ico-popup-yes')
                divContentIco.addClass('content-ico');
                divContentIco.append(divIcoImage);
                divContentIco.attr('id', name);
                divContentIco.css('padding-right', name == 'prev' ? '8px' : '0px')
                //Conforme se crea un elemento por javascrip se llama su evento a realizar
                divContentIco.click(name == 'yes' ? this.saveEmployees : this.clickPopUpIco);
                return divContentIco;
            }

            this.addIcoPoup = function (name) {
                ctrl.d_containerIcoPopup.append(this.createIcoPopup(name));
            }
            this.createPagination = function () {
                var p = document.createElement('p');
                p.innerHTML = "<span style='font-weight:bold'>Page <span id='pageCount'>1</span> of <span>3</span></span>"
                return p;
            },
           this.clearIcoPoup = function () {
               ctrl.d_containerIcoPopup.html('')
           },
            this.getOperation = function (e) {
                var id = $(e).attr('id');
                if (id == 'next' && _pageCurrent <= 2) {
                    _pageCurrent++;
                } else if (id == 'prev' && _pageCurrent > 1) {
                    _pageCurrent--;
                }
                this.changeStylePopUpPage();
                this.removeIcoPage(id);
            },
            this.removeIcoPage = function (id) {

                if (_pageCurrent === 2 && id == 'next') {
                    this.addIcoPoup("prev");
                }
                else if (_pageCurrent == 1 && id == 'prev') {
                    $('#' + id).remove();
                } else if (_pageCurrent == 3) {

                    this.addIcoPoup("yes");
                    this.addIcoPoup("prev");

                    $('#' + id).hide();
                    $('#prev').remove();

                } else if (_pageCurrent == 3 - 1 && id == 'prev') {
                    $('#' + 'next').show();
                    $('#' + 'yes').remove();
                }
            },
            this.showPageContainer = function () {
                ctrl.d_tabContentForm.each(function (i) {
                    if ($(this).attr('data-page') == _pageCurrent) {
                        $(this).show();
                    }
                })
            };
            this.changeStylePopUpPage = function () {
                ctrl.h2_TitlePopup.hide();
                if (_pageCurrent == 1) {
                    ctrl.d_PopUpContentform.css('height', '405px');
                    ctrl.h2_TitlePopup.show();
                }
                else if (_pageCurrent == 2) {
                    ctrl.d_PopUpContentform.css({ 'height': 'auto', 'min-height': '405px' });
                    ctrl.d_PopUp.css({ 'overflow-y': 'auto' })
                } else {
                    ctrl.d_PopUpContentform.css('height', '405px');
                    ctrl.d_PopUp.css({ 'overflow-y': 'hidden' })
                }
            }

            this.setPageCount = function () {
                $('#pageCount').html(_pageCurrent);
            };
            this.setEventsTags = function () {
                ctrl.s_cboInstitucion.change(this.changeOptionsInstitucion)
                ctrl.a_dataAddItem.click(this.clickAddInputItem)
                ctrl.r_boolGrade.click(this.checkedRadio)
                ctrl.d_tipoEmpleado.change(this.changeOptions);
                ctrl.rdbCivil.click(this.click_rdbCivil)
                ctrl.rdbMilitar.click(this.click_rdbMilitar)
            };
            this.fillSelect = function (target, e) {
                var option = "";
                target.find('option:not(:first-child)').remove();
                //cuando en MVC se retornar un selectlist maneja un Text y un Value
                for (var i = 0; i < e.length; i++) {
                    option += "<option  value=" + e[i].Value + ">" + e[i].Text + "</option>"
                }
                target.append(option)
            }
            this.clearItemsSelect = function (target, val) {
                if (val == "") {
                    target.find('option:not(:first-child)').remove();
                    return false;
                }
                return true;
            }

            this.findSelect = function (target) {
                var name = target.attr('data-add-item');
                var tag = $('select[data-add-item="' + name + '"]');
                var key = tag.val();
                var text = tag.find('option:selected').text()
                var parent = target.parents('div.form-inline-content');

                if (this.validateItemsInput(key) == true) {
                    var elements = this.createItemInput(key, text)
                    parent.append(elements);
                    elements.fadeIn('slow');
                }

            }
            this.createItemInput = function (key, text) {
                var divInlineContent = $('<div/>');
                divInlineContent.addClass('form-inline-content');
                divInlineContent.attr('id', key);
                divInlineContent.hide();
                var label = $('<label/>');
                label.addClass('form-inline-text-input');
                label.addClass('inline-label');
                label.css({ 'text-align': 'right', paddingRight: '5px' })
                label.html(text)

                var input = $('<input />');
                input.attr('type', 'text')
                input.addClass('inline-content');

                var a = $('<a />');
                a.addClass('form-ico-content');
                a.attr('href', '#');
                a.attr('title', 'remover');

                var img = $('<img/>');
                img.css({ 'margin-left': '4px', 'width': '20px' })
                img.attr('src', '/Images/ico-popup-eliminar-pedido.png')
                a.append(img);
                a.click(this.removeItemInput)

                divInlineContent.append(label);
                divInlineContent.append(input);
                divInlineContent.append(a);

                return divInlineContent;
            }

            this.validateItemsInput = function (key) {
                if ($('[id="' + key + '"]').length > 0) {
                    return false;
                } else if (key == "") {
                    return false;
                }
                return true;
            }

            this.setIICdentificacion = function () {
                var json = [];
                ctrl.d_containerIdentificacion.find('div.form-inline-content[id]').each(function (i) {
                    json.push({
                        I_COD_TIPO_IDENTIFICACION: $(this).attr('id'),
                        V_NUM_DOCUMENTO: $(this).find('input').val()
                    })
                });
                //alert(json.length)
                return json
            }

            this.disabledInstitucion = function (e) {
                if ($(e.target).val() == "false") {
                    $('#clsTypeModality_I_COD_TIPO_MODALIDAD').attr('disabled', 'disabled');
                    this.removeItemInput($('#clsTypeModality_I_COD_TIPO_MODALIDAD'));
                } else {
                    $('#militar select').removeAttr('disabled')
                    $('#clsTypeModality_I_COD_TIPO_MODALIDAD').removeAttr('disabled', 'disabled');
                }
            }
            this.removeItems = function (target) {
                target.find('option:not(:first-child)').remove();
            }
            this.selectAvalibity = function (select) {
                select.removeAttr('disabled');
                select.removeAttr('style');
            }
            this.selectDisabled = function (select) {
                select.css('background', '#E6E6E6')
                select.attr('disabled', 'disabled');
            }
            this.clearSelect = function (select) {
                select.find('option:not(:first-child)').remove();
            }
            this.disabledPorTipoEmpleado = function (iCodigoTipoEmpleado) {

                that.selectAvalibity(ctrl.s_cboGrado);
                that.clearSelect(ctrl.s_cboGrado);

                ctrl.s_cboSituacionMilitar.find('option:nth-child(0n+2)').show();
                ctrl.s_cboSituacionMilitar.val('');
                ctrl.s_cboInstitucion.val('');
                ctrl.rdbCivil.removeClass('rdbChecked')
                ctrl.rdbCivil.attr('disabled', 'disabled');
                ctrl.rdbMilitar.removeAttr('disabled', 'disabled');

                switch (iCodigoTipoEmpleado) {
                    case 100:
                        ctrl.rdbMilitar.addClass('rdbChecked');

                        that.selectDisabled(ctrl.s_cboInstitucion);
                        that.selectDisabled(ctrl.s_cboSituacionMilitar);
                        ctrl.s_cboSituacionMilitar.val(1);
                        ctrl.s_cboInstitucion.val(40);
                        ctrl.s_cboInstitucion.trigger('change');
                        break;
                    case 200:
                        ctrl.rdbMilitar.addClass('rdbChecked');

                        that.selectDisabled(ctrl.s_cboSituacionMilitar);
                        that.selectAvalibity(ctrl.s_cboInstitucion);
                        ctrl.s_cboInstitucion.find('option[value=40]').hide();
                        ctrl.s_cboSituacionMilitar.val(1);
                        break;
                    case 300:
                        $('#rdbCivil').removeAttr('disabled');
                        $('#rdbMilitar').removeAttr('checked');
                        $('#rdbCivil').attr('checked', 'checked')
                        ctrl.rdbCivil.addClass('rdbChecked')

                        that.selectAvalibity(ctrl.s_cboInstitucion);
                        //that.selectDisabled(ctrl.s_cboSituacionMilitar);                         
                        ctrl.s_cboSituacionMilitar.val('');
                        ctrl.s_cboSituacionMilitar.find('option:nth-child(0n+2)').hide();
                        ctrl.rdbCivil.trigger('click');
                        break;
                    case 400:

                        $('#rdbCivil').removeAttr('disabled');
                        $('#rdbMilitar').removeAttr('checked');
                        ctrl.rdbCivil.addClass('rdbChecked')
                        ctrl.rdbCivil.attr('checked', 'checked');
                        ctrl.rdbMilitar.attr('disabled', 'disabled');

                        that.selectAvalibity(ctrl.s_cboInstitucion);
                        that.selectDisabled(ctrl.s_cboSituacionMilitar);
                        that.selectDisabled(ctrl.s_cboGrado);
                        ctrl.s_cboSituacionMilitar.val('');
                        break;
                    default:                                                  
                        ctrl.rdbMilitar.addClass('rdbChecked')
                        ctrl.rdbMilitar.attr('checked', 'checked');
                        ctrl.rdbCivil.attr('disabled', 'disabled');

                        that.selectAvalibity(ctrl.s_cboInstitucion);
                        that.selectAvalibity(ctrl.s_cboSituacionMilitar);
                        break;
                }

            }
        }
    }


    var handles = function () {
        tags.popUp.call(this)
        that = this;

        var listener = {
            initialize: function () {
                this.load();
            },
            load: function () {
                that.ChangeHeaderPopup();
                that.clearIcoPoup();
                that.addIcoPoup("next");
                that.setPageCount();
                that.setEventsTags();

            },
            clickPopUpIco: function () {
                that.getOperation(this);
                ctrl.d_tabContentForm.hide();
                that.showPageContainer(this);
                that.setPageCount();
            },
            changeOptionsInstitucion: function () {
                if (that.clearItemsSelect(ctrl.s_cboGrado, $(this).val()) === true) {
                    ws.listarGradoMilitarXinstitucion(ctrl.s_cboGrado, $(this).val(), function (target, e) {
                        that.fillSelect(target, e);
                        if (ctrl.d_tipoEmpleado.val() == '400') {
                            ctrl.s_cboGrado.find('option').each(function () {
                                if ($(this).text().toLowerCase() == 'empleado civil') {
                                    ctrl.s_cboGrado.val($(this).val())
                                }
                            })
                        }
                    });
                }

            },
            changeOptions: function () {
                that.disabledPorTipoEmpleado(parseInt($(this).val()));
                ws.lisTipoModalidad(ctrl.s_tipoModalidad, $(this).val(), that.fillSelect);
            },

            clickAddInputItem: function () {
                that.findSelect($(this));
            },
            removeItemInput: function () {
                $(this).parent().remove();
            },
            saveEmployees: function () {
                var json = that.setIICdentificacion();
                if (json.length > 0)
                    ws.saveEmployees(json);
                else
                    alert('No ha cargado niguna Identificacion')
            }
            ,
            checkedRadio: function (e) {
                that.disabledInstitucion(e);
            },
            click_rdbCivil: function () {
                ctrl.rdbMilitar.removeClass('rdbChecked');

                if (ctrl.rdbCivil.is(':checked') && ctrl.rdbMilitar.is(':disabled') == false) {
                    ctrl.s_cboInstitucion.val('');
                    ctrl.s_cboGrado.val('');
                    ctrl.s_cboSituacionMilitar.val('');
                    ctrl.rdbCivil.addClass('rdbChecked');

                    that.selectDisabled(ctrl.s_cboInstitucion);
                    that.selectDisabled(ctrl.s_cboGrado);
                    that.selectDisabled(ctrl.s_cboSituacionMilitar);
                }
            },
            click_rdbMilitar: function () {
                ctrl.rdbCivil.removeClass('rdbChecked');

                if (ctrl.rdbMilitar.is(':checked') && ctrl.rdbCivil.attr('disabled') != 'disabled') {
                    ctrl.rdbMilitar.addClass('rdbChecked');
                    ctrl.s_cboInstitucion.val('');
                    ctrl.s_cboGrado.val('');
                    ctrl.s_cboSituacionMilitar.val('');

                    that.selectAvalibity(ctrl.s_cboInstitucion);
                    that.selectAvalibity(ctrl.s_cboGrado);
                    that.selectDisabled(ctrl.s_cboSituacionMilitar);
                    ctrl.s_cboSituacionMilitar.val(2)
                }
            }

        }

        this.clickPopUpIco = listener.clickPopUpIco;
        this.changeOptions = listener.changeOptions;
        this.changeOptionsInstitucion = listener.changeOptionsInstitucion;
        this.clickAddInputItem = listener.clickAddInputItem;
        this.removeItemInput = listener.removeItemInput;
        this.saveEmployees = listener.saveEmployees;
        this.checkedRadio = listener.checkedRadio;
        this.click_rdbCivil = listener.click_rdbCivil;
        this.click_rdbMilitar = listener.click_rdbMilitar;

        this.initialize = function () {
            listener.initialize();
        }
    }

    handles.prototype = new tags.popUp();
    handles.prototype.constructor = handles;

    $(document).ready(function () {
        var exec = new handles();
        exec.initialize();
    })
})();
