
/// <reference path="../EmployeesJS/avatarJS.js" />
/// <reference path="../../_references.js" />
(function () {

    var ws = {
        uploadImage: function (_formData, callback) {
            $.ajax({
                type: 'POST',
                url: '/Upload/Upload',
                data: _formData,
                async: true,
                processData: false,
                contentType: false,
                success: function (e) {
                    callback(e)
                }
            })

        }
    }


    var ctrl = {
        d_bodyPoupContent: $('div.body-poup-content'),
        d_popupContentForm: null,
        d_popupContentFormJS: null,
        d_PopUp: $('#PopUp'),
        d_popupUploadDrag: $('div.popup-upload-drag'),
        c_preview: document.getElementById('preview'),
        d_imageName: document.getElementById('imageName'),
        d_contentType: document.getElementById('contentType'),
        d_imageData: document.getElementById('imageData'),
        d_detailsUpload: $('div#details-upload'),
        d_popupfooterico: $('div.popup-footer-ico'),
        d_fotoPerfilContainer: $('section.foto-perfil-content'),
        d_codPersona: $('#C_COD_PERSONA').val(),
        d_perfilIco: $('div.foto-perfil-ico')
    }
    var _context = null;
    var _file = null;
    var _dataURL = null;

    var tags = function () {
        this.createButtonPopup = function () {
            var div = $('<div />');
            div.addClass('button-blue-upload')
            div.attr('id', "btnperfil")
            div.html('Establecer Como Foto de Perfil')
            div.click(this.UploadImage.clickbtnPerfil)
            ctrl.d_popupfooterico.append(div)
        }

        this.setIdPopupContent = function () {
            ctrl.d_PopUp.find('div.PopUp-content-form').attr('id', 'popup-upload');
            ctrl.d_popupContentForm = $('#popup-upload');
            ctrl.d_popupContentFormJS = document.querySelector('#popup-upload')
        }
        this.changeSizePopup = function () {
            var width = ctrl.d_popupContentForm.css('width');
            width = (parseInt(width.substr(0, width.indexOf('p'))) + 20) + 'px';
            ctrl.d_popupContentForm.css('width', width);
            ctrl.d_popupfooterico.css('height', '0px')
            ctrl.d_popupfooterico.html('')
        }

        /*Eventos asociado entre la etiqueta y DOM*/
        this.eventsTags = function () {
            ctrl.d_bodyPoupContent.bind('dragover', this.dragAndDrop.dragoverProfile)
            ctrl.d_bodyPoupContent.bind('dragleave', this.dragAndDrop.dragleaveProfile)
            ctrl.d_popupContentFormJS.addEventListener('drop', this.dragAndDrop.dropProfile)
        }

        this.previewCanvas = function (file) {
            _context = ctrl.c_preview.getContext('2d');
            _file = file;
            var url = URL.createObjectURL(_file);
            var img = new Image();
            img.onload = this.CanvasUpload.loadImageCanvas
            img.src = url;
        }

        this.constSizeUpload = function (img) {
            var MAX_WIDHT = 300,
              MAX_HEIGHT = 300;
            var width = img.width,
              height = img.height;

            if (width > MAX_WIDHT) {
                height *= MAX_WIDHT / width;
                width = MAX_WIDHT;
            }
            else {
                if (height > MAX_HEIGHT) {
                    width *= MAX_HEIGHT / height;
                    height = MAX_HEIGHT;
                }
            }

            return {
                width: width,
                height: height
            }
        }

        this.changeSizePreviewCanvas = function (size) {
            ctrl.c_preview.setAttribute('width', size.width);
            ctrl.c_preview.setAttribute('height', size.height);
            ctrl.c_preview.style.position = "absolute";
            ctrl.c_preview.style.left = "50%";
            ctrl.c_preview.style.top = "50%";
            ctrl.c_preview.style.marginTop = "-" + (parseInt(size.height) / 2) + 'px';
            ctrl.c_preview.style.marginLeft = "-" + (parseInt(size.width) / 2) + 'px';


        }
        this.PostUploadDetails = function () {
            ctrl.d_imageName.value = _file.name;
            ctrl.d_contentType = _file.type;
            ctrl.d_detailsUpload.find('div:last-of-type').html(_file.name);
            _dataURL = ctrl.c_preview.toDataURL('image/png').replace('data:image/png;base64,', '')
            ctrl.d_imageData.value = _dataURL;
            ctrl.d_detailsUpload.fadeIn('slow')
        }

        this.hideContentDRAG = function () {
            ctrl.d_popupUploadDrag.find('canvas ~ *').hide();
        }

        this.showCanvasPreview = function () {
            $(ctrl.c_preview).fadeIn('slow')
        }


        this.formData = function () {
            var formData = new FormData();
            formData.append('imageName', _file.name);
            formData.append('contentType', _file.type);
            formData.append('imageData', _dataURL);
            formData.append("codPersona", ctrl.d_codPersona)
            return formData;
        }

        this.showPreloadPerfil = function () {
            //ctrl.d_fotoPerfilContainer.find('div.foto-perfil-preload~*').hide();
            ctrl.d_fotoPerfilContainer.find('section.foto-perfil-show').hide();
            ctrl.d_fotoPerfilContainer.find('div:first-child').fadeIn('slow');
        }
        this.hidePreloadPerfil = function (callback) {
            ctrl.d_fotoPerfilContainer.find('div:first-child').fadeOut('slow', function () {
                callback();
            }.bind(this));
        }
        this.webWorkerImage = function (data) {
            var worker = new Worker("/Scripts/pages/upload/workerUploadImage.js");
            var parameter = {
                imageName: _file.name,
                contentType: _file.type,
                imageData: _dataURL
            }
            worker.onmessage = function (e) {
                console.log(e.data)
            }
            //Cuando se serializa un variable semana propiedades no metodos
            worker.postMessage(JSON.stringify(parameter));
        }

        this.changePerfil = function (e) {
            var img = ctrl.d_fotoPerfilContainer.find('img');
            img.attr('src', e)
            this.hidePreloadPerfil(function () {
                img.fadeIn('slow')
                ctrl.d_perfilIco.removeAttr('style');
                ctrl.d_fotoPerfilContainer.find('section.foto-perfil-show').show();
            })
        }

        this.changeClassFooterIco = function () {
            ctrl.d_popupfooterico.addClass('popup-upload-ico ')
        }
    }

    var events = function () {
        tags.call(this);
        var that = this;

        var _listener = {
            load: function () {
                that.setIdPopupContent();
                that.eventsTags();
                that.changeSizePopup();
                that.createButtonPopup();
                that.changeClassFooterIco();
            },
            dragoverProfile: function (e) {

                e.preventDefault();
                e.stopPropagation();
                ctrl.d_bodyPoupContent.css('border', '2px solid #4d90fe')
            },
            dragleaveProfile: function (e) {

                ctrl.d_bodyPoupContent.removeAttr('style')
            },
            dropProfile: function (e) {
                e.preventDefault();
                if (e.stopPropagation) {
                    e.stopPropagation(); // stops the browser from redirecting.
                }
                var file = e.dataTransfer.files[0];
                that.previewCanvas(file);
                that.hideContentDRAG();
                that.showCanvasPreview();
                // See the section on the DataTransfer object.

                return false;


            },
            loadImageCanvas: function (e) {
                img = e.target;
                var sizeStandar = that.constSizeUpload(img);
                that.changeSizePreviewCanvas(sizeStandar);
                _context.drawImage(img, 0, 0, sizeStandar.width, sizeStandar.height);
                that.PostUploadDetails();

            },
            clickbtnPerfil: function (e) {

                pedidos.popup.hidePopUpExecute(function () {
                    //  that.webWorkerImage(that.formData());
                    ws.uploadImage(that.formData(), that.changePerfil.bind(that))
                });
                that.showPreloadPerfil();

            }
        }


        this.dragAndDrop = {
            dragoverProfile: _listener.dragoverProfile,
            dragleaveProfile: _listener.dragleaveProfile,
            dropProfile: _listener.dropProfile
        }

        this.CanvasUpload = {
            loadImageCanvas: _listener.loadImageCanvas
        }

        this.UploadImage = {
            clickbtnPerfil: _listener.clickbtnPerfil
        }

        this.Initialize = function () {
            _listener.load();
        }
    }

    events.prototype = tags.prototype;
    events.prototype.constructor = events;

    $(document).ready(function () {
        var x = new events();
        x.Initialize();
    })

})();

/***/
