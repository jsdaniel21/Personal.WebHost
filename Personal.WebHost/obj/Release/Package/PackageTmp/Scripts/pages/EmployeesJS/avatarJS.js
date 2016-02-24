/// <reference path="../../_references.js" />
var $avatar = null;
(function () {
    var ws = {

    }
    var bottomOption = new pedidos.menusJs.tag();

    $avatar = {

        initialize: function () {
            this.references();

        },
        references: function () {
            this.tag = new this.tag();
            this.tag.initialize();
        },
        tag: function () {
            this.initialize = function () {
                this.handle.initialize(this.control)
            },
            this.control = {
                contentPage: $('div.content-Pages'),
                menu: $('div.content-menu-employees a:not(:first-child)'),
                codTipoSistemaDOM: pedidos.codTipoSistemaDOM.val(),
                username: pedidos.username.val(),
                newData: $('#newData'),
                s_fotoPerfilParent: $('section.foto-perfil-show')
            },
            this.handle = {
                initialize: function (ctrl) {
                    this.ctrl = ctrl;
                    this.ctrl.newData.hide();
                    this.event();
                },
                event: function () {
                    this.handleClickMenu();
                    this.OptionsXSubOptions();
                    this.GetCallUploadPerfil();
                },
                GetCallUploadPerfil: function () {
                    this.ctrl.s_fotoPerfilParent.click(function () {
                        pedidos.popup.executePopupNoBor("Foto de Perfil", 'Subir Imagen'
               , "/Upload/UploadPerfil", '580', '517', function () {
               }.bind(this))
                    })
                }
                ,
                OptionsXSubOptions: function () {
                    bottomOption.handle.footerMenuOptions(this.ctrl.codTipoSistemaDOM,
                        this.ctrl.username, this.ctrl.newData.attr('data-parent'), null)
                }
                ,
                handleClickMenu: function () {
                    var contentPage = this.ctrl.contentPage;
                    this.ctrl.menu.click(function () {

                        /*tambien se puedo aver echo con $().load*/
                        var url = $(this).data('url');
                        var parent = $(this).data('parent');

                        $.ajax({
                            url: url,
                            contentType: 'application/json;charset=utf-8',
                            type: 'get',
                            dataType: 'html',
                            data: {
                                codMenu: parent,
                                codPersona: $('#C_COD_PERSONA').val()
                            },
                            success: function (result) {
                                contentPage.hide();
                                contentPage.html(result);
                                $('div#aux-foreground').css({ 'background': '#fff' })
                                $(this).parents('div.content-menu-employees').fadeOut(400, function () {
                                    contentPage.fadeIn('slow');
                                });
                            }.bind(this)
                        })

                        return false;
                    })
                }

            }
        }

    }

    $avatar.Global = {
        UploadImage: function () {
            alert('fg')
        }
    }
    $(document).ready(function () {
        $avatar.initialize();
    })

})();