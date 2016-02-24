/// <reference path="../jquery-1.8.2.min.js" />

(function () {
    'use strict'
    var menuRight = $('.menu-right');
    var viewMenuRight = $('a.fx-headerLayout-link');
    var parentMenuRight = $('.fx-headerLayout-avatar')
    var count = 0;

    var menuAvatarUser = {
        initialize: function () {
            this.event();
        },
        hiddenMenu: function () {
            menuRight.slideUp('fast');
            viewMenuRight.css('background-color', '')
        },
        showMenu: function () {
            menuRight.slideDown('fast');
        },
        viewElement: function (callback) {
            if (menuRight.is(':hidden')) {
                count = 0;
                this.showMenu();
                viewMenuRight.css('background-color', '#46515c')
            } else {

                this.hiddenMenu();

            }
        },
        countMouseOver: function () {
            parentMenuRight.mouseleave(function () {
                count = 1;
            })
        },
        bodyEvent: function () {
            $('body').click(function () {
                if (count == 1) {
                    menuAvatarUser.hiddenMenu();
                    count = 0;
                }
            })
        },
        parentMenuOver: function () {
            parentMenuRight.mouseover(function () {
                count = 0;
            })
        }
        ,


        event: function () {
            viewMenuRight.click(this.viewElement.bind(this));
            this.countMouseOver();
            this.bodyEvent();
            this.parentMenuOver();
        }
    }
    $(document).ready(function () {
        menuAvatarUser.initialize();
    })
}());