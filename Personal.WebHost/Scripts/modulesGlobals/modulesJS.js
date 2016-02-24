/// <reference path="../_namespace.js" />
/// <reference path="ajax.js" />
/// <reference path="../animation/menu-left.js" />

/// <reference path="../jquery-1.8.2.min.js" />
/// <reference path="menu-left.js" />

(function () {
    'use strict';
    var element = $('#ly-navigation-container li > a');
    var menuleft = $('#ly-navpane-2');
    var back = $('#ly-navpane-back');
    pedidos.menuleft = {
        initilize: function () {
            this.event();
            this.optionSelect();
        },
        cadenaUrl: function () {
            var array = new Array();
            // split convierte un array de acuerdo un filtro en este caso convierte un array si mi cadena tiene un signo '/'
            //array = document.URL.replace('http://','').split("/").reverse();
            var cadena = ""
            cadena = document.URL.replace('http://', '')
            cadena = cadena.substr(cadena.indexOf('/'), cadena.length - 1).toLowerCase();

            var url = document.URL.replace("https", "http");
            url = url.substring(7, url.length)
            url = url.substring(url.indexOf('/') + 1, url.length)
            var t = /(index|edit)/
            if (t.test(url.toLowerCase())) {
                url = url.substr(0, url.indexOf('/'));
            }
            url = "/" + url + '/index';
             
            return url.toUpperCase();
        },
        elementUrl: function () {
            return $('#ly-navpane li[data-url="' + this.cadenaUrl() + '"]').find('a');
        }
        ,

        optionSelect: function (filter) {

            var element = null

            if (filter == null) {
                element = this.elementUrl()// que contengan un li con el atributo
            } else {
                element = $('#ly-navpane li[data-url="' + filter + '"]').find('a')

            }

            if (typeof (element.find('div:first-child').html()) != 'undefined' && element.hasClass('navpane-2') == false) {
                element.find('div:first-child').css({
                    'background-position': '80px 0'

                })
                element.css({
                    'background': '#fff',
                    'color': '#39444c'
                })

            } else if (element.hasClass('navpane-2') == true) {
                element.css('background', 'rgb(81, 155, 189)')
            } else {

                element.css({
                    'background': '#fff',
                    'color': '#39444c'
                }).attr('class', 'active')
                element.parents('#ly-navpane-2').css({ 'left': "55px", 'position': 'absolute', 'display': 'block' })
                var parent = element.parents('#ly-navpane-2').find('ul').attr('data-child');
                $('#ly-navpane a[data-parent="' + parent + '"]').css({ 'background-color': '#519bbd' })
            }

            element.parent().attr('data-parent-select', 'true');

        },
        styleBack: function () {
            menuleft.css({ 'left': "180px" })
        }
        ,
        hiddenMenu: function (callback) {
            this.clear();
            menuleft.animate({ 'left': "150px", 'opacity': 'hide' }, 200, 'linear', function () {
                if (callback != null) {
                    callback()
                }

            });

        },
        showMenu: function () {
            menuleft.animate({ 'left': "55px", 'opacity': 'show' }, 200, "linear");
        },
        displayMenu: function () {
            menuleft.hide();
        }
        ,
        back: function (callback) {
            back.unbind('click');
            back.click(function () {
                this.hiddenMenu(callback);
            }.bind(this));
        },
        viewElement: function (e) {

            if (menuleft.is(':hidden')) {
                pedidos.menuleft.showMenu();
                $(e).css('background-color', '#519bbd')

            } else {

                pedidos.menuleft.clear();
                pedidos.menuleft.hiddenMenu();
                $(e).css('background-color', '')
            }

        },
        clear: function () {
            element.css('background-color', '')
        },
        menuleftElement: $('#ly-navigation-container li > a')
        ,
        event: function click() {
            element.click(function () {
                var child = $('#ly-navpane-scroll-items ul').data('child')
                var id = $(this).attr('id');
                if (child == id) {

                    pedidos.menuleft.viewElement(this)
                }

            }
               )

        }
    }
    // seejeucta una ves que se a cargado todos los elemenetos del DOM
    $(document).ready(function () {
        //pedidos.menuleft.initilize();
    })

})();


/*-----------------------------------------------------------------------*/

(function (ajax) {
    ajax = new ajax();
    'use strict';
    var ws = {
        permisos_UsuarioXsitema: function (codtipoSistema, nomUsuario, tipoMenu, callback) {
            ajax.ajax('/Login/permisosUsuarioXSistema',
             JSON.stringify({
                 codTipoSistema: codtipoSistema,
                 nomUsuario: nomUsuario,
                 tipoMenu: tipoMenu
             }), function (e) {
                 if (callback != null) {
                     callback(e);
                 }
             })
        },
        datosAvatarUser: function (username, callback) {
            ajax.ajax('/Login/datosAvatarUser', JSON.stringify({
                username: username
            }), function (e) {
                callback(e);
            })
        }

    }

    var JsonSubmenus = [];
    pedidos.menusJs = {

        initialize: function (callback) {
            this.references(callback);
        },
        references: function (callback) {
            this.tag = new this.tag(callback);
            this.tag.initialize();
        },
        tag: function (callback) {
            this.initialize = function () {
                this.controls();
                this.handle.initiliaze(this)
            }

            this.controls = function () {
                this.navPanelLeft = $('#ly-navpane');
                this.codTipoSistemaDOM = $('#hidden-codTipoSistema').val();
                this.codUserDOM = $('#hidden-username').val();
                this.footerMenuBottoms = $('div.footer-menu-buttons');
                this.menuRightInstancia = $('#menu-right-Instancia');
                this.menuRightArea = $('#menu-right-Area');
                this.menuRightCargo = $('#menu-right-Cargo')

            }

            this.handle = {
                initiliaze: function (t) {
                    this.ctrl = t;

                    this.event();
                },

                event: function () {
                    this.handleLoad();

                },
                handleLoad: function () {
                    //this.ctrl.navPanelLeft.html('')
                    //this.fillAvatarUser();
                    var that = this.ctrl;
                    ws.permisos_UsuarioXsitema(this.ctrl.codTipoSistemaDOM, this.ctrl.codUserDOM, 'me', function (e) {                         
                        this.createNavPanelLeft(e);                        
                        this.handleOtionsClick();
                        var currentElement = pedidos.menuleft.elementUrl();                        
                        this.footerMenuOptionsNuevo(this.ctrl.codTipoSistemaDOM, this.ctrl.codUserDOM
                            , currentElement.parents('li').attr('data-parent'), callback);

                    }.bind(this))
                },
                fillAvatarUser: function () {

                    ws.datosAvatarUser(this.ctrl.codUserDOM, function (e) {
                        this.ctrl.menuRightInstancia.html(e.clsMaInstancia.V_DES_INSTANCIA)
                        this.ctrl.menuRightArea.html(e.clsMaArea.V_DES_FUNCIONES)
                        this.ctrl.menuRightCargo.html(e.clsMaCargo.V_DES_CARGO)

                        this.ctrl.menuRightInstancia.attr('data-codigo', e.clsMaInstancia.I_COD_INSTANCIA);
                        this.ctrl.menuRightArea.attr('data-codigo', e.clsMaInstanciaAreas.C_COD_AREA);
                        this.ctrl.menuRightCargo.attr('data-codigo', e.clsMaCargo.I_COD_CARGO)

                    }.bind(this))
                }
                ,
                createNavPanelLeft: function (data) {                    
                    var ul = $('<ul />')
                    ul.attr('id', 'ly-navigation-container');
                    var i = data.length;
                    while (data.length > 0) {
                        i--;
                        //if (data[i].clsMenuSistema.C_COD_MENU == '013-NUEV') {
                        //    $('#newData').show();
                        //    data.splice(i, 1);
                        //}

                        //else
                        if (data[i].clsMenuSistema.C_COD_MENU_SUPERIOR == data[i].clsMenuSistema.C_COD_MENU
                        && data[i].clsMenuSistema.C_COD_MENU != '013-NUEV') {

                            var li = $('<li />')
                            li.addClass('ly-navigation-item');
                            if (data[i].clsMenuSistema.C_NAME_FORM.toUpperCase() != '') {
                                li.attr('data-url', data[i].clsMenuSistema.C_NAME_FORM.toUpperCase());
                            }
                            li.attr('data-parent', data[i].clsMenuSistema.C_COD_MENU_SUPERIOR)

                            var a = $('<a />');
                            a.addClass('ly-div-navigation-link');
                            var url = '';
                            if (data[i].clsMenuSistema.C_COD_MENU == '010-EXTR') {
                                url = '?op=extraordinario'

                            }

                            a.attr('href', data[i].clsMenuSistema.C_NAME_FORM + url);
                            var divImg = $('<div />');
                            divImg.css({
                                'background-image': 'url(../../' + data[i].clsMenuSistema.C_DES_DIRECTORIO_IMG + ')',
                                'background-repeat-y': 'no-repeat',
                                'background-position': '40px 0',
                                'width': '40px',
                                'height': '45px',
                                'float': 'left'
                            })

                            var divText = $('<div />');
                            divText.addClass('ly-div-navigation-label')
                            divText.html(data[i].ClsMenu.V_DES_MENU)
                            a.append(divImg);
                            a.append(divText);
                            li.append(a);
                            ul.append(li);
                            data.splice(i, 1);

                        } else {
                            var bit = false;
                            var createElementBack = this.createElementBack;
                            var navPanelLeft = this.ctrl.navPanelLeft
                            ul.find('li').each(function () {
                                var find = false;

                                for (var item = data.length - 1; item >= 0; item--) {
                                    if (data[item].clsMenuSistema.C_COD_MENU_SUPERIOR == $(this).attr('data-parent')) {
                                        find = true;
                                        var json = {
                                            parent: $(this).attr('data-parent'),
                                            des: data[item].ClsMenu.V_DES_MENU,
                                            cod: data[item].clsMenuSistema.C_COD_MENU,
                                            nameForm: data[item].clsMenuSistema.C_NAME_FORM
                                        }
                                        JsonSubmenus.push(json);
                                        data.splice(item, 1)
                                        i = data.length
                                    }
                                }
                                if (find === true) {
                                    $(this).find('div:first-child').addClass('ly-div-navigation-ico');
                                    $(this).find('a').attr('href', '#')
                                }

                            })

                        }

                        if (i == 0) {
                            i = data.length
                        }
                    }
                    this.ctrl.navPanelLeft.append(ul);
                    this.currentParent = null;
                    if (this.getParentItem(pedidos.menuleft.cadenaUrl()) == null) {
                        pedidos.menuleft.optionSelect();
                        this.currentParent = this.getParentItem(pedidos.menuleft.cadenaUrl())
                    } else {
                        this.currentParent = this.getParentItem(pedidos.menuleft.cadenaUrl())
                        this.optionSelect(this.ctrl.navPanelLeft
                                              , this.getParentItem(pedidos.menuleft.cadenaUrl())
                                              , this.currentParent);
                    }


                },
                handleOtionsClick: function () {
                    var createElementBack = this.createElementBack
                    var navPanelLeft = this.ctrl.navPanelLeft;
                    var optionSelect = this.optionSelect;
                    var currentParent = this.currentParent;
                    this.ctrl.navPanelLeft.find('ul#ly-navigation-container li > a').click(function () {                  
                        if ($(this).find('div:first-child').hasClass('ly-div-navigation-ico') == true) {
                            navPanelLeft.find('li > a').removeAttr('style');
                            navPanelLeft.find('li > a > div:first-child').css({ 'background-position': '40px 0px' })
                            pedidos.menuleft.styleBack();
                            optionSelect(navPanelLeft, $(this).parent().attr('data-parent'), currentParent);
                        } else {                           
                            pedidos.menuleft.displayMenu();
                        }

                    })
                },
                getParentItem: function (value) {
                    var ReturnValue = null;
                    for (var i = 0; i < JsonSubmenus.length; i++) {
                        if (JsonSubmenus[i].nameForm.toUpperCase() == value.toUpperCase()) {
                            ReturnValue = JsonSubmenus[i].parent.toUpperCase()
                        }
                    }
                    return ReturnValue;
                }
                ,
                optionSelect: function (navPanelLeft, value, currentUrl) {

                    var ulSubmenu = $('<ul />');
                    ulSubmenu.attr('data-child', value);
                    var find = false;
                    for (var i = 0; i < JsonSubmenus.length; i++) {
                        if (JsonSubmenus[i].parent.toUpperCase() == value) {
                            find = true;
                            var li = $('<li />');
                            li.attr('data-url', JsonSubmenus[i].nameForm.toUpperCase());
                            li.attr('data-parent', JsonSubmenus[i].cod)

                            var a = $('<a />');
                            a.attr('href', '' + JsonSubmenus[i].nameForm + '');
                            var span = $('<span />');
                            span.html(JsonSubmenus[i].des);
                            a.append(span);
                            li.append(a);
                            ulSubmenu.append(li);

                        }
                    }
                    if (find == true) {

                        navPanelLeft.find('div#ly-navpane-scroll-items > nav').html('')
                        navPanelLeft.find('div#ly-navpane-scroll-items > nav').append(ulSubmenu)
                        navPanelLeft.find('li[data-parent="' + value + '"] > a').css('background', 'rgb(81, 155, 189)')

                        pedidos.menuleft.showMenu();

                        pedidos.menuleft.back(function () {
                            navPanelLeft.find('li > a').removeAttr('style');
                            if (currentUrl == null) {
                                pedidos.menuleft.optionSelect();
                            }

                        });
                        if (currentUrl != null) {
                            pedidos.menuleft.optionSelect();
                        }


                    }



                }
                ,
                footerMenuOptions: function (tipoSistema, username, parent, callback) {            
                    ws.permisos_UsuarioXsitema(tipoSistema, username, 'op', function (e) {           
                        this.loadOptionsBottom(e, parent);
                        if (callback != null)
                            callback(e);
                    }.bind(this))
                },

                footerMenuOptionsNuevo: function (tipoSistema, username, parent, callback) {
                    ws.permisos_UsuarioXsitema(tipoSistema, username, 'op', function (e) {
                        this.showOptionsNuevo(e, parent);
                        if (callback != null)
                            callback(e);
                    }.bind(this))
                },
                showOptionsNuevo: function (data, parent) {
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].clsMenuSistema.C_COD_MENU == '015-GUAR' && parent == data[i].clsMenuSistema.C_COD_MENU_SUPERIOR
                       && pedidos.codTipoSistemaDOM.val() != '2014-SISPER-0002'
                         || data[i].clsMenuSistema.C_COD_MENU == '013-NUEV' && parent == data[i].clsMenuSistema.C_COD_MENU_SUPERIOR) {
                            $('#newData').show();
                        }
                    }
                }
                ,
                /*footer options*/
                loadOptionsBottom: function (data, parent) {
                 
                    var ul = $('<ul />');
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].clsMenuSistema.C_COD_MENU == '015-GUAR' && parent == data[i].clsMenuSistema.C_COD_MENU_SUPERIOR
                          && pedidos.codTipoSistemaDOM.val() != '2014-SISPER-0002'
                            || data[i].clsMenuSistema.C_COD_MENU == '013-NUEV' && parent == data[i].clsMenuSistema.C_COD_MENU_SUPERIOR) {
                            $('#newData').show();
                        }
                        else if (parent == data[i].clsMenuSistema.C_COD_MENU_SUPERIOR && data[i].C_COD_MENU != '013-NUEV'
                           ) {

                            var li = $('<li />')
                            li.attr('id', data[i].clsMenuSistema.C_COD_MENU);
                            var divContainer = $('<div />');
                            divContainer.addClass('footer-command-img');
                            var directory = data[i].clsMenuSistema.C_DES_DIRECTORIO_IMG
                            var pos = directory.substr(directory.indexOf('top=') + 4, directory.length)
                            var style = "style='top: " + pos + ";position: absolute;'"
                            if (data[i].clsMenuSistema.C_COD_MENU == '018-IMPR') {
                                style = "style='top: " + pos + ";position: absolute;height:24px;width:24px'";
                            }

                            var divleftImg = '<div class="footer-comand-wraper"><div class="footer-comnand-ico">'
                                                + ' <img src="..' + directory + '" ' + style + ' /></div></div>';
                            var divRightText = ' <div class="footer-comand-text">' + data[i].ClsMenu.V_DES_MENU + '</div>';
                            divContainer.append(divleftImg);
                            divContainer.append(divRightText);
                            li.append(divContainer)
                            ul.append(li)
                        }
                    }
                    //alert($('div.footer-menu-buttons').find('div.footer-command ul li:not([data-static])').html())
                    //$('div.footer-menu-buttons').find('div.footer-command ul li:not([data-static])').remove();
                    /*2  forma*/
                    $('div.footer-menu-buttons').find('div.footer-command ul li:not(:first-child)').remove();
                    $('div.footer-menu-buttons').find('div.footer-command ul').append(ul.html());
                }




            }


        }
    }
})(pedidos.ajax);


(function () {

    var ws = {
        listarPermisoXmenuParent: function (parameter, callback) {
            $.ajax({
                //CUANDO SE MANDA POR POST TIENES QUE SERIALIZAR
                //type: 'POST',
                type: 'GET',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                url: '/Login/listarPermisoXmenuParent',
                //data: JSON.stringify(parameter),
                data: parameter,
                success: function (e) {
                    callback(e)
                }
            })
        }

    }

    var _detailsMsg = "";

    var menuandbutton = {

        initialize: function () {
            this.references();
        },
        references: function () {
            this.tag = new this.tag();
            this.tag.initialize();
            pedidos.hideItemsOptionsFooter = this.tag.handles.hideItemsOptions;

        },
        tag: function () {

            this.initialize = function () {
                this.handles.initialize(this.control);
                //this.handles.hideItemsOptions();
            }

            this.control = {
                newData: $('div[data-parent="013-NUEV"]'),
                menuandbutton: $('#footer-menuandbutton'),
                drawmenuContent: $('div.footer-drawermenu-content'),
                divDetails: $('div.fxs-drawermenu-details'),
                containerOptions: $('#footer-menuandbutton').find('div.fxs-drawermenu-menuarea')
            }
            var thatCtrlGlobals = this.control;

            this.handles = {
                initialize: function (jsonCtrl) {
                    this.ctrl = jsonCtrl;
                    this.events();
                },
                events: function () {
                    this.handleLoad();
                    //this.showSubOptions();
                    this.clickCloseBottom();
                },
                clickCloseBottom: function () {
                    $('#closedBottomMenu').click(function () {
                        this.hideItemsOptions(null);
                    }.bind(this))
                }
                ,
                handleLoad: function () {
                    this.ctrl.newData.click(function () {
                        ws.listarPermisoXmenuParent({
                            codMenu: this.ctrl.newData.attr('data-parent'),
                            codTipoSistema: pedidos.codTipoSistemaDOM.val(),
                            tipoOpcion: 'so',
                            nomUsuario:pedidos.username.val()
                        }, function (e) {
                            this.CreateItemsOptions(e, function () {
                                _detailsMsg = $('div.fxs-drawermenu-left li:first-child a').attr('data-desopcion');
                                $('div.fxs-drawermenu-left li:first-child').css({
                                    'border-color': 'transparent',
                                    'borderLeft': '3px solid #fff',
                                    'background-color': '#6d747b'
                                })
                                ws.listarPermisoXmenuParent({
                                    codMenu: e[0].ClsMenu.C_COD_MENU,
                                    codTipoSistema: pedidos.codTipoSistemaDOM.val(),
                                    tipoOpcion: 'so',
                                    nomUsuario: pedidos.username.val()
                                }, function (e) {
                                    this.CreateItemsOptions(e);
                                    var nextElement = $('div.fxs-drawermenu-left').next();
                                    nextElement.find('div.fxs-menu-menu').css('width', '0');
                                    nextElement.show();
                                    nextElement.find('div.fxs-menu-menu').animate({ 'width': '241px' }, 250, 'linear', function () {
                                        this.widthSize(this.ctrl.containerOptions)
                                    }.bind(this))
                                }.bind(this))
                            }.bind(this));
                        }.bind(this))
                    }.bind(this))
                },
                hideItemsOptions: function (callback) {
                    thatCtrlGlobals.menuandbutton.animate({ 'height': '0px', 'bottom': '0', }, 300, 'linear', function () {
                        thatCtrlGlobals.drawmenuContent.hide(200, function () {
                            thatCtrlGlobals.newData.css({ top: '0px' })
                            thatCtrlGlobals.newData.fadeIn(200);
                            //thatCtrlGlobals.newData.animate({ top: '0px' }, 200, "linear")
                            $('#footer-menuandbutton').removeAttr('style')
                            thatCtrlGlobals.drawmenuContent.find('div.fxs-drawermenu-left').removeAttr('style');
                            thatCtrlGlobals.drawmenuContent.find('div.fxs-drawermenu-left').remove();
                            $('div.fxs-drawermenu-details').html('<div class="fxs-drawerdetails-details-box"></div>')
                            if (callback != null) {
                                callback();
                            }


                        });

                    })
                },
                clickItems: function (e) {
                  
                    var thatEvent = $(e.target).parents('li');
                    var len = thatEvent.parents('div.fxs-drawermenu-left').next('div.fxs-drawermenu-left').find('a[data-parent="' + thatEvent.find('a').attr('data-codmenu') + '"]').length;
                    if (len > 0) {
                        return false;
                    } else {
                        var href = thatEvent.find('a').attr('href');
                        if ($('div.fxs-drawermenu-details > div.fxs-drawerdetails-details-box').length == 0) {
                            $('div.fxs-drawermenu-details').html('<div class="fxs-drawerdetails-details-box"></div>')
                        }
                        if (href != '#') {
                            var ini = href.indexOf('w=');
                            var width = 580;
                            var height = 517;
                            if (ini >= 0) {
                                width = href.substring(ini + 2, href.indexOf('&', ini + 1));
                                var iniH = href.indexOf('h=');
                                height = href.substring(iniH + 2, href.length);
                            }
                            var p = href.indexOf('p=');
                            var controller = href.substring(1, href.indexOf('/', 1))
                            pedidos.controller = controller;
                            thatEvent.parents('ul').find('li').removeAttr('style');
                            if (p >= 0) {
                                thatEvent.css({
                                    'border-color': 'transparent',
                                    'borderLeft': '3px solid #fff',
                                    'background-color': '#6d747b'
                                })
                                $('div.fxs-drawermenu-details').load(href)
                            } else {
                           
                                pedidos.popup.executePopupNoBor("", ''
                                , thatEvent.find('a').attr('href'), width, height, function () {
                                }.bind(this))
                            }
                            return false;
                            e.preventDefault();
                        }
                        len = thatEvent.parents('div.fxs-drawermenu-left').index();
                        if (len == 0) {
                            thatEvent.parents('div.fxs-drawermenu-menuarea').find('div.fxs-drawermenu-left:first-child li').removeAttr('style');
                            thatEvent.parents('div.fxs-drawermenu-menuarea').find('div.fxs-drawermenu-left:not(:first-child)').remove();
                        } else {
                            //alert(thatEvent.parents('div.fxs-drawermenu-left').html())
                            // thatEvent.parents('div.fxs-drawermenu-left').next().remove() 
                            var nextLet = thatEvent.parents('div.fxs-drawermenu-left').next();
                            //alert(thatEvent[0].tagName)                                                         
                            if (nextLet.attr('class') != 'fxs-drawermenu-details') {
                                thatEvent.parents('ul').find('li').removeAttr('style');
                                nextLet.remove();
                            }
                            //alert(thatEvent.index())
                        }
                        thatEvent.css({
                            'border-color': 'transparent',
                            'borderLeft': '3px solid #fff',
                            'background-color': '#6d747b'
                        })
                        thatEvent.find('a').css('border-color', 'transparent')
                        ws.listarPermisoXmenuParent({
                            codMenu: thatEvent.find('a').attr('data-codMenu'),
                            codTipoSistema: pedidos.codTipoSistemaDOM.val(),
                            tipoOpcion: 'so',
                            nomUsuario: pedidos.username.val()
                        }, function (e) {
                            _detailsMsg = thatEvent.find('a').attr('data-desopcion');
                            if (e.length == 0) {
                                return false;
                            }
                            this.CreateItemsOptions(e);
                            var nextElement = thatEvent.parents('div.fxs-drawermenu-left').next();
                            nextElement.find('div.fxs-menu-menu').css('width', '0');
                            nextElement.show();
                            nextElement.find('div.fxs-menu-menu').animate({ 'width': '241px' }, 200, 'linear', function () {
                                this.widthSize(this.ctrl.containerOptions)
                            }.bind(this))
                        }.bind(this))
                    }
                },

                CreateItemsOptions: function (e, callback) {
                    this.CreateItemsSubOptions(e)
                    this.ctrl.newData.css('background-color', 'transparent')
                    this.ctrl.menuandbutton.css('position', 'absolute')
                    this.ctrl.menuandbutton.animate({
                        'height': '530px',
                        'bottom': '0',
                    }, 200, 'linear', function () {
                        this.ctrl.drawmenuContent.show(function () {
                        }.bind(this));
                        this.ctrl.newData.animate({ top: '-30px' }, 160, 'linear', function () {
                            $(this).hide();
                        })
                        if (callback != null) {
                            callback();
                        }
                    }.bind(this))
                },
                widthSize: function (div) {
                    var acumulado = 0;
                    var size = $('div.fxs-drawermenu-menuandbutton').outerWidth();
                    div.find('div.fxs-drawermenu-left').each(function () {
                        acumulado += parseInt($(this).css('width').substr(0, $(this).css('width').length - 2))
                    })
                    this.ctrl.divDetails.css('width', '200px')
                    this.ctrl.divDetails.animate({ 'width': ((size - acumulado) - 30) + 'px' }, 250, 'linear')
                }
            ,
                CreateItemsSubOptions: function (e) {
                    var data = e;
     
                    var i = 0;
                    var divDetails = this.ctrl.divDetails;
                    var divLeft = $('<div />');
                    divLeft.attr('class', 'fxs-drawermenu-left')
                    var divMenu = $('<div />');
                    divMenu.attr('class', 'fxs-menu-menu')
                    var divScrollbar = $('<div />');
                    divScrollbar.attr('class', 'fx-scrollbar')
                    var divScrollable = $('<div />');
                    divScrollable.attr('class', 'fx-scrollbar-scrollable')
                    var ul = $("<ul />")
                    for (var i = 0; i < data.length; i++) {
                        var li = $('<li />');
                        var divTable = $('<div />');
                        var a = "";
                        var directory = data[i].clsMenuSistema.C_DES_DIRECTORIO_IMG
                        var pos = directory.substr(directory.indexOf('top=') + 4, directory.length)

                        li.append(divTable);
                        divTable.attr('class', 'fxs-div-table');

                        var href = data[i].clsMenuSistema.C_NAME_FORM == "" ? "#" : data[i].clsMenuSistema.C_NAME_FORM;
                        a += '<a ' + 'data-parent="' + data[i].clsMenuSistema.C_COD_MENU_SUPERIOR + '"'
                        a += 'data-desopcion="' + data[i].clsMenuSistema.V_DES_OPCION + '"'
                        a += 'data-codMenu="' + data[i].ClsMenu.C_COD_MENU + '"'
                        a += 'href="' + href + '"'
                        a += '>'
                        a += '<div class="icon">'
                        a += '<img data-bind="attr: { src: image, alt: text }" src="' + directory + '" alt="Proceso" style="left: 1px;  top: ' + pos + ';position: absolute;">'
                        a += '</div>'
                        a += '<div class="fxs-menu-text">';
                        a += ' <div class="fxs-menu-itemtext" data-bind="text: text" style=" font-family: Sg-SemiBold;">' + data[i].ClsMenu.V_DES_MENU + '</div>'
                        a += '</div>'
                        a += '</a>'
                        divTable.append(a);
                        li.append(divTable)
                        li.click(this.clickItems.bind(this))
                        li.hover(this.itemHover);
                        li.mouseleave(this.itemLeave);
                        ul.append(li)
                        /*
                          if (i === 0) {
                            $(li).attr('data-selected', 'true')
                            $(li).css({ border: '1px solid rgb(70, 112, 187)', 'borderLeft': '3px solid #fff' })
                            divDetails.html('<div class="fxs-drawerdetails-details-box ">' + data[i].clsMenuSistema.V_DES_OPCION + '</div>')
                            divDetails.show();
                        }
                        */

                    }
                    divScrollable.append(ul)
                    divScrollbar.append(divScrollable);
                    divMenu.append(divScrollbar);
                    divLeft.append(divMenu);
                    this.ctrl.containerOptions.find(divDetails).before(divLeft)

                }
            ,
                itemHover: function (e) {
                    $('div.fxs-drawermenu-details > div').html($(this).find('a').attr('data-desopcion'))
                },
                itemLeave: function (e) {
                    $('div.fxs-drawermenu-details > div').html(_detailsMsg);
                }
            }
        }
    }

    $(document).ready(function () {
        var t = new menuandbutton.tag();
        menuandbutton.initialize();

    })

}());

