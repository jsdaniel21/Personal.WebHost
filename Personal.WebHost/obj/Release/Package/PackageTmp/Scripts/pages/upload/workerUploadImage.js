
//ACORDEMNOS DE QUE LSO TRABAJDORES NO TIENE ACCESO AL DOM este se comunica por medio de mensaje directamente 
self.onmessage = function (e) {
    var json = JSON.parse(e.data);
    var formData = new FormData();

    formData.append('imageName', json.imageName);
    formData.append('contentType', json.contentType);
    formData.append('imageData', json.imageData);

    var xml = new XMLHttpRequest();
    xml.onreadystatechange = function () {
        if (xml.readyState == 4 && xml.status == 200) {
            self.postMessage(xml.response)
        }
    }
    xml.open('POST', '/Upload/Upload', true)
    xml.send(formData)

    //this.postMessage(json._parameter)

}