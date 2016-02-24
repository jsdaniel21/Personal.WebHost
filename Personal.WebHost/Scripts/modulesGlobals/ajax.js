
pedidos.ajax = function () {
    this.ajax = function (url, parameters, callback, escalar) {
        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            cache: false,//por defecto es false
            data: parameters,

            contentType: "application/json; charset=utf-8",
            success: function (data) {
         
                if (callback != null) {
                    //JSON.parse deseariliza
                    if (escalar == null) {
                        callback(data)
                    } else {

                        callback(data)
                    }

                }
 
            },
            error: function (jqXHR, exception) {
                if (jqXHR.status === 0) {
                    alert('Not connect.\n Verify Network.');
                } else if (jqXHR.status == 404) {
                    alert('Requested page not found. [404]');
                } else if (jqXHR.status == 500) {
                    alert('Internal Server Error [500].');
                } else if (exception === 'parsererror') {
                    alert('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    alert('Time out error.');
                } else if (exception === 'abort') {
                    alert('Ajax request aborted.');
                } else {
                    alert('Uncaught Error.\n' + jqXHR.responseText);
                }
            }
        })
    },

    this.version = function () {
        alert('correcto')
    }

};
