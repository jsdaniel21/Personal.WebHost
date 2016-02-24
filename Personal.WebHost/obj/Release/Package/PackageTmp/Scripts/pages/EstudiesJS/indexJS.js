/// <reference path="../../_references.js" />

(function () {

    var _pageCurrent = 1;
    var _opcion = "";

    var array = new Array(3);
    array["yes"] = "ico-popup-yes.png";
    array["next"] = "icon-next-popup.png";
    array["prev"] = "icon-prev-popup.png";

    var ws = {
        details: function (id) {
            $.ajax({
                type: 'GET',
                url: '/Estudios/_details',
                contentType: 'application/json;charset=utf-8',
                data: { id: id },
                dataType: 'json',
                success: function () {

                }

            })
        },
        delete: function (id, target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: JSON.stringify({ id: id }),
                url: '/Estudios/_delete',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        actualizar: function (target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: $('form').serialize(),
                url: '/Estudios/_actualizar',
                success: function (e) {
                    callback(target, e)
                }
            })
        },
        fillEspecialidades: function (buscar, datalist, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { buscar: buscar },
                url: '/Estudios/listarEspecialidad',
                success: function (e) {
                    callback(datalist, e)
                }

            })
        }
        ,
        fillCarrerasProfesionales: function (buscar, dataList, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { buscar: buscar },
                url: '/Estudios/listarCarrerasProfesionales',
                success: function (e) {
                    callback(dataList, e);
                }
            })
        }
        ,
        register: function (target, callback) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: $('form').serialize(),
                url: '/Estudios/_register',
                success: function (e) {
                    callback(target, e)
                }
            })
        }, fillTipoEntidadCb: function (target, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'JSON',
                url: '/Estudios/listarTipoEntidad',
                success: function (e) {
                    callback(target, e);
                }
            })
        }, fillInstitucionesCb: function (target, codTipoInstitucion, codTipoEntidad, callback) {
            $.ajax({
                type: 'GET',
                dataType: 'json',
                data: { codTipoInstitucion: parseInt(codTipoInstitucion), codTipoEntidad: codTipoEntidad },
                contentType: 'application/json; charset=utf-8',
                url: '/Estudios/listarInstituciones',
                success: function (e) {
                    callback(target, e)
                }
            })
        }
    }


    var ctrl = {
        codMenu: $('#codMenu').val(),
        atras: $('[data-static="true"]'),
        contentPageAjax: $('#content-page-ajax'),
        gridQueryDOM: $('#gridQueryDOM'),
        d_containerIcoPopup: null,
        create: null,
        update: null,
        delete: null,
        h2_TitlePopup: null,
        page: null,
        ifraMaps: null,
        codTipoEntidad: null,
        codTipoInstitucion: null,
        codInstitucion: null,
        back: $('div.footer-command ul > li:first-child'),
        contengHomeMenu: $('div.content-menu-employees'),
        contentPage: $('div.content-Pages'),
        d_carreraProfesional: null,
        especialidadAutocomplete: null
    }

    var tags = function () {
        var that = this;
        this.showAtras = function () {
            ctrl.atras.show();
        }


        this.setBottomFooter = function () {
            ctrl.create = $('#037-CREA');
            ctrl.update = $('#023-MODI');
            ctrl.delete = $('#014-ELIM')
            ctrl.details = $('#016-LIDT')
        }

        this.setEventsTags = function () {
            ctrl.create.click(this.eventMant.Mantclick)
            ctrl.update.click(this.eventMant.Mantclick);
            ctrl.delete.click(this.eventMant.Mantclick);
            ctrl.details.click(this.eventMant.Mantclick)
            ctrl.back.click(this.eventMant.back)
        }
        this.setEventGrid = function () {
            ctrl.gridQueryDOM.find('tbody tr > td:first-child').click(this.grid.handleSelected)
        }
        this.showPopup = function (e) {
            switch ($(e).attr('id')) {
                case "037-CREA":
                    _private.showCreateAJAX();
                    _opcion = "in";
                    break;
                case '016-LIDT':
                    _private.showDetailsAJAX();
                    break;
                case "023-MODI":
                    _private.showUpdateAJAX();
                    _opcion = "up";
                    break;
                case "014-ELIM":
                    _opcion = "del";
                    this.pagination.save();
                    break;
                default:

            }
        }

        this.getOperation = function (e) {

            var id = $(e).attr('id');
            if (id == 'next' && _pageCurrent <= 2) {
                _pageCurrent++;
            } else if (id == 'prev' && _pageCurrent > 1) {
                _pageCurrent--;
            }
            _private.removeIcoPage(id);
        }
        this.showPageContainer = function () {
            ctrl.page.hide();
            ctrl.page.each(function (i) {
                if ($(this).attr('data-page') == _pageCurrent) {

                    $(this).fadeIn('slow');
                }
            })
        };

        this.setPageCount = function () {
            $('#pageCount').html(_pageCurrent)
        }

        this.fillSelect = function (target, e) {
            var option = "";
            target.find('option:not(:first-child)').remove();
            //cuando en MVC se retornar un selectlist maneja un Text y un Value
            for (var i = 0; i < e.length; i++) {
                option += "<option  value=" + e[i].Value + ">" + e[i].Text + "</option>"
            }
            target.append(option)
        }
        this.callbackRegister = function (target, e) {
            target.removeAttr('disabled');
            if (e > 0) {
                that.hidePopup();
                that.showListDomicilio();
            }
        }
        this.showListDomicilio = function () {
            //cada vez que se cre un  elemento po JS es recomendable conforme se esta creando enlazandolo al evento
            ctrl.contentPageAjax.load('/Estudios/_listStudies?codPersona=' + (typeof ($('input[data-name').val()) == 'undefined' ? $('#C_COD_PERSONA').val() : $('input[data-name').val()), function () {
                _private.resetVarGlobals();
                this.setAfterList();
                this.setEventGrid();
            }.bind(this))
        }
        this.hidePopup = function () {
            pedidos.popup.hidePopUpExecute();
        }

        this.setAfterList = function () {
            ctrl.gridQueryDOM = $('#gridQueryDOM')
        }
        this.rowSelectID = function () {
            var id = ctrl.gridQueryDOM.find('tr.active-row-select > td:first-child > span:first-child').html();
            return id;
        }
        this.showDataList = function (target) {
            var DataList = $(target).nextAll('div');
            DataList.show();
        }
        this.fillDataList = function (target, callback) {
            var values = $(target).val();
            var DataList = $(target).nextAll('div');
            if (values.trim() == '') {
                DataList.hide();
                return false;
            }
            if (DataList.length > 0) {
                DataList.show();
                callback(values, DataList);
            }
            else {
                alert('No cuenta con un dataList')
            }

        }
        this.ItemsDataListCarrera = function (dataList, e) {

            dataList.html('')
            for (var i = 0; i < e.length; i++) {
                var div = _private.createItemDataList(e[i].I_COD_CARRERA_PROFESIONAL, e[i].V_DES_CARRERA_PROFESIONAL, e[i].I_COD_CARRERA_PROFESIONAL);
                div.click(function () {
                    that.keys.clickItemDataList(dataList, this)
                })
                dataList.append(div);
            }

        }
        this.ItemsDataListEspecialidad = function (dataList, e) {
            dataList.html('')
            for (var i = 0; i < e.length; i++) {
                var div = _private.createItemDataList(e[i].I_COD_ESPECIALIDAD, e[i].V_DES_ESPECIALIDAD, e[i].I_COD_ESPECIALIDAD, e);
                div.click(function () {
                    that.keys.clickItemDataList(dataList, this)
                })
                dataList.append(div);
            }
        }

        this.DisabledNotSuperiores = function (val) {
            if (val == 4) {
                ctrl.d_carreraProfesional.attr('disabled', 'disabled')
                ctrl.especialidadAutocomplete.attr('disabled', 'disabled')
            } else {
                ctrl.d_carreraProfesional.removeAttr('disabled')
                ctrl.especialidadAutocomplete.removeAttr('disabled')
            }
        }
        this.DisabledNotSuperioresDT = function (val) {
            if (val == 4) {                
                $('#I_COD_ESPECIALIDAD').parents('div.form-content').hide();
                $('#I_COD_CARRERA_PROFESIONAL').parents('div.form-content').hide();
            }
        }
        var _private = {

            createItemDataList: function (Value, Text, Aux) {
                var div = $('<div />')
                div.attr('data-parent', "true")
                div.css({ position: 'relative', 'line-height': '23px', 'padding-right': '5px', 'padding-left': '5px', 'cursor': 'pointer' })
                var html = '';
                html += '<div style="display:inline" data-values="' + Value + '">'
                          + Text + '</div>'
                          + '<div style="float:right;font: 9px/20px ' + "'Sg-SemiBold'" + '; opacity: 0.8;">' + Aux + '</div>'
                div.append(html);
                return div;
            }
            ,
            removeIcoPage: function (id) {
                if (this.PageSize() == _pageCurrent && id == 'next') {
                    this.createIcoPopup("yes");
                    this.createIcoPopup("prev");
                    $('#' + id).hide();
                } else if (_pageCurrent == 1 && id == 'prev') {
                    $('#' + id).remove();
                    $('#' + 'next').show();
                }
                else if (_pageCurrent === 2 && id == 'next') {
                    this.createIcoPopup("prev");
                }
                else if (_pageCurrent == this.PageSize() - 1 && id == 'prev') {
                    $('#' + 'next').show();
                }
                if (_pageCurrent < this.PageSize()) {
                    $('#' + 'yes').remove();
                }
            },
            setEventsAfterPOPUP: function () {
                ctrl.codTipoInstitucion.change(that.select.changeItem)
                ctrl.codTipoEntidad.change(that.select.changeItem);
                ctrl.codInstitucion.change(that.select.changeItem);
                ctrl.d_carreraProfesional.keyup(that.keys.KeyUp);
                ctrl.d_carreraProfesional.focusin(that.keys.focusin);
                ctrl.especialidadAutocomplete.keyup(that.keys.KeyUp);
                ctrl.especialidadAutocomplete.focusin(that.keys.focusin);
            },
            afterShowAjax: function () {
                this.resetVarGlobals();
                this.setCtrlPopup();
                this.clearIcoPopup();
                this.createIcoPopup('next', '')
                this.changeHeaderTitle();
                this.changeSizeifraMaps();
                this.setEventsAfterPOPUP();
                this.setCodPersona();
                that.DisabledNotSuperiores(ctrl.codTipoInstitucion.val())
            },
            showDetailsAJAX: function () {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Vista previa de Estudios", 'Detalles de Estudios'
                   , '/Estudios/_details?id=' + that.rowSelectID(), '680', '577', function () {
                       this.resetVarGlobals();
                       this.setCtrlPopup();
                       this.clearIcoPopup();
                       this.changeSizeifraMaps();
                       that.DisabledNotSuperioresDT(ctrl.codTipoInstitucion.val())
                   }.bind(this))
            },
            showUpdateAJAX: function () {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Modificar Estudios Seleccionado", 'Actualizar Estudios'
                   , '/Estudios/_edit?id=' + that.rowSelectID(), '680', '577', function () {
                       thatPrivate.afterShowAjax();
                   })
            }
            ,
            showCreateAJAX: function (callback) {
                var thatPrivate = this;
                pedidos.popup.executePopupNoBor("Crear nuevo Estudio", 'Agregar Estudios'
                      , '/Estudios/_crear/', '680', '577', function () {
                          thatPrivate.afterShowAjax();
                          if (callback != null) {
                              callback();
                          }

                      })
            },
            resetVarGlobals: function () {
                _pageCurrent = 1;
            }
            ,
            setCtrlPopup: function () {
                ctrl.d_containerIcoPopup = $('#PopUp div.popup-footer-ico');
                ctrl.h2_TitlePopup = $('#PopUp h2.PopUp-title-form');
                ctrl.page = $('[data-page]');
                ctrl.ifraMaps = $('#ifraMaps');
                ctrl.codTipoEntidad = $('#I_COD_TIPO_ENTIDAD'),
                ctrl.codTipoInstitucion = $('#I_COD_TIPO_INSTITUCION'),
                ctrl.codInstitucion = $('#I_COD_INSTITUCION')
                ctrl.d_carreraProfesional = $('#V_DES_CARRERA_PROFESIONAL');
                ctrl.especialidadAutocomplete = $('#V_DES_ESPECIALIDAD')

            },
            setCodPersona: function () {
                $('[data-name="codPersona"]').val($('#C_COD_PERSONA').val())
            }
            ,
            changeSizeifraMaps: function () {
                ctrl.ifraMaps.css({ 'width': '100%', 'height': '400px' })
            }
            ,
            changeHeaderTitle: function () {
                ctrl.h2_TitlePopup.before(this.createParagrah())
            },
            createParagrah: function () {
                var p = document.createElement('p');
                p.innerHTML = "<span style='font-weight:bold'>Page <span id='pageCount'>1</span> of <span>" + this.PageSize() + "</span></span>"
                return p;
            },
            PageSize: function () {
                return ctrl.page.length
            }
            ,
            clearIcoPopup: function () {
                ctrl.d_containerIcoPopup.html('')
            },
            createIcoPopup: function (name, text) {
                var divContentIco = $('<div />');
                divContentIco.css('float', 'right');
                var contentButton = $('<div />');
                contentButton.addClass('ico-popup-yes')
                contentButton.css({
                    'background': "url('../../Images/" + array[name] + "')",
                    width: '37px',
                    height: '37px',
                    opacity: '0.7'
                })
                contentButton.html(text)
                divContentIco.append(contentButton);
                divContentIco.attr('id', name)
                divContentIco.click(name == 'yes' ? that.pagination.save : that.pagination.clickPopUpIco);

                ctrl.d_containerIcoPopup.append(divContentIco);
            }
        }
    }

    var handles = function () {
        tags.call(this)
        that = this;

        var _listener = {
            initialize: function () {
                var bottomOption = new pedidos.menusJs.tag();
                bottomOption.handle.footerMenuOptions(pedidos.codTipoSistemaDOM.val(), pedidos.username.val()
                  , ctrl.codMenu, this.load)
            },
            load: function () {
                that.showAtras();
                that.setBottomFooter();
                that.setEventsTags();
                that.setEventGrid();
            },
            handleSelected: function () {
                var gridTables = ctrl.gridQueryDOM;
                gridTables.find('tbody tr').attr('class', 'not-active-row-td')
                $(this).parents('tr').attr('class', 'active-row-select')
            }
            ,
            Mantclick: function (e) {
                that.showPopup(this);
            },
            clickPopUpIco: function () {
                that.getOperation(this)
                that.showPageContainer(this);
                that.setPageCount();
            },
            changeItem: function () {
                switch ($(this).attr('id')) {
                    case 'I_COD_TIPO_INSTITUCION':
                        that.DisabledNotSuperiores($(this).val());
                        ws.fillTipoEntidadCb(ctrl.codTipoEntidad, that.fillSelect)
                        break;
                    case 'I_COD_TIPO_ENTIDAD':
                        ws.fillInstitucionesCb(ctrl.codInstitucion, ctrl.codTipoInstitucion.val(), ctrl.codTipoEntidad.val(), that.fillSelect)
                        break;
                    default:
                }
            }, back: function () {
                $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
                $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
                ctrl.contengHomeMenu.fadeIn('slow');
                ctrl.contentPage.html('');
            }
            ,
            save: function () {
                $(this).attr('disabled', 'disabled');
                switch (_opcion) {
                    case "in":
                        ws.register($(this), that.callbackRegister);
                        break;
                    case 'up':
                        ws.actualizar($(this), that.callbackRegister);
                        break;
                    case 'del':
                        ws.delete(that.rowSelectID(), $(this), that.callbackRegister);
                        break;
                    default:
                        break;
                }
                _opcion = "";
                _pageCurrent = 1;
            },
            KeyUp: function () {

                switch ($(this).attr('id')) {
                    case "V_DES_CARRERA_PROFESIONAL":
                        that.fillDataList(this, function (values, DataList) {
                            ws.fillCarrerasProfesionales(values, DataList, that.ItemsDataListCarrera)
                        });
                        break;
                    case "V_DES_ESPECIALIDAD":
                        that.fillDataList(this, function (values, DataList) { ws.fillEspecialidades(values, DataList, that.ItemsDataListEspecialidad) });
                        break;
                    default:
                        break;
                }
            },
            focusin: function () {

                switch ($(this).attr('id')) {
                    case "V_DES_CARRERA_PROFESIONAL":
                        that.fillDataList(this, function (values, DataList) {
                            ws.fillCarrerasProfesionales(values, DataList, that.ItemsDataListCarrera)
                        });
                        break;
                    case "V_DES_ESPECIALIDAD":
                        that.fillDataList(this, function (values, DataList) { ws.fillEspecialidades(values, DataList, that.ItemsDataListEspecialidad) });
                        break;
                    default:
                        break;
                }
            }
            ,
            clickItemDataList: function (datalist, event) {
                var values = $(event).find('div:first-child').attr('data-values');
                var Text = $(event).find('div:first-child').html();
                var input = $(event).parent().prev();
                input.val(values)
                input = $(event).parent().prevAll(':first-child');
                input.val(Text)
                datalist.hide();

            }
        }

        this.eventMant = { Mantclick: _listener.Mantclick, back: _listener.back }
        this.pagination = { clickPopUpIco: _listener.clickPopUpIco, save: _listener.save }
        this.select = { changeItem: _listener.changeItem }
        this.keys = { KeyUp: _listener.KeyUp, clickItemDataList: _listener.clickItemDataList, focusin: _listener.focusin }
        this.grid = { handleSelected: _listener.handleSelected }

        this.initialize = function () {
            _listener.initialize();
        }
    }

    handles.prototype = new tags();
    handles.prototype.constructor = handles;

    $(document).ready(function () {
        var x = new handles();
        x.initialize();
    })

})();