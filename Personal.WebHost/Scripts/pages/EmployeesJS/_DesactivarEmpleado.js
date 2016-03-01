/// <reference path="../../_references.js" />
(function () {

    var ws = {
        desactivarEmpleado: function (data, callback) {
            $.ajax({
                type: 'POST',
                url: '/Employees/desactivarEmpleado',
                dataType: 'json',
                contentType: 'application/json;charset=utf-8',
                data: data,
                success: function (d) {
                    callback(d);
                }
            })
        }
    }

    var ctrl = {
        vCodigoMenu: $('#C_COD_MENU').val(),
        btnAtras: $('[data-static="true"]'),
        btnGuardar: null,
        divContengHomeMenu: $('div.content-menu-employees'),
        divContentPage: $('div.content-Pages'),
        rdbDestacado: $('#rdbDestacado'),
        rdbRetiro: $('#rdbRetiro'),
        cboSituacionMilitar: $('#I_COD_SITUACION_MILITAR'),
        txtdFechaCese: $('#D_FECHA_SECE'),
        cboTipoDocumento: $('#I_COD_TIPO_DOCUMENTO_CESE'),
        txtvNumeroDocumentoCese: $('#V_NRO_DOCUMENTO_CESE'),
        txtvMotivoCese: $('#V_MOTIVO_CESE_CONTRATO'),
        txtiCodigoTipoEmpleado: $('#I_COD_TIPO_EMPLEADO'),
        txtvDescripcionTipoEmpleado: $('#V_DES_TIPO_EMPLEADO')
    }

    var handles = {

        showBack: function () {
            ctrl.btnAtras.show();
        },
        setElementsAfterMenuBottoms: function () {
            ctrl.btnGuardar = $('#015-GUAR');

        }
        ,
        setEvens: function () {
            ctrl.btnAtras.click(listener.click_back);
            ctrl.btnGuardar.click(listener.click_btnGuardar);
            ctrl.rdbDestacado.click(listener.click_rdbDestacado);
            ctrl.rdbRetiro.click(listener.click_rdbRetiro);
        },
        validaEnvioDatos: function () {
            var bit = true;
            if (ctrl.rdbRetiro.is(':checked') == false && ctrl.rdbDestacado.is(':checked') == false) {
                alert('es necesario seleccionar una opcion de tipo de baja')
                bit = false;
            }
            else if (ctrl.txtvMotivoCese.val().trim() == '') {
                alert('no ha ingresado nigun motivo de cese')
                bit = false;
            }
            else if (ctrl.txtvNumeroDocumentoCese.val().trim() == '') {
                alert('no ha ingresado un numero documento de cese');
                bit = false;
            } else if (ctrl.txtdFechaCese.val().trim() == '') {
                alert('no se ha ingresado una fecha de cese')
                bit = false;
            }
            return bit;
        }
        ,
        desactivarEmpleadoData: function (callback) {
            if (handles.validaEnvioDatos() == false) {
                return true;
            }

            ws.desactivarEmpleado(JSON.stringify({
                vCodigoPersona: pedidos.codPersona.val(),
                vTipoBaja: ctrl.rdbRetiro.is(':checked') == true ? 'rt' : ctrl.rdbDestacado.is(':checked') == true ? 'di' : '',
                vFechaCese: ctrl.txtdFechaCese.val(),
                vTexto: ctrl.txtvMotivoCese.val(),
                iCodigoTipoEmpleado: parseInt(ctrl.txtiCodigoTipoEmpleado.val()),
                vDescricionTipoEmpleado: ctrl.txtvDescripcionTipoEmpleado.val(),
                vDescripcionTipoDocumentoCese: ctrl.cboTipoDocumento.find('option:selected').text(),
                vNumeroDocumenCese: ctrl.txtvNumeroDocumentoCese.val(),
                iCodigoTipoDocumentoCese: ctrl.cboTipoDocumento.val()
            }), callback)
        },
        afterDesactivarEmpleado: function (d) {
            alert('se desactivo correctamente');
        }
    }

    var listener = {
        initialize: function () {
            var bottomOption = new pedidos.menusJs.tag();
            bottomOption.handle.footerMenuOptions(pedidos.codTipoSistemaDOM.val(), pedidos.username.val()
                  , ctrl.vCodigoMenu, this.load)
        },
        load: function () {
            handles.setElementsAfterMenuBottoms();
            handles.showBack();
            handles.setEvens();
        },
        click_back: function () {
            $('div.footer-menu-buttons').find('div.footer-command ul li:first-child').hide();
            $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
            ctrl.divContengHomeMenu.fadeIn('slow');
            ctrl.divContentPage.html('');
        },
        click_btnGuardar: function () {
            handles.desactivarEmpleadoData(handles.afterDesactivarEmpleado);
        }
        ,
        click_rdbDestacado: function () {
            var that = $(this);
            if (that.is(':checked')) {
                ctrl.cboSituacionMilitar.val(1);
            }
        },
        click_rdbRetiro: function () {
            var that = $(this);
            if (that.is(':checked')) {
                ctrl.cboSituacionMilitar.val(2);
            }
        }
    }


    $(document).ready(function () {
        listener.initialize();
    })

})();