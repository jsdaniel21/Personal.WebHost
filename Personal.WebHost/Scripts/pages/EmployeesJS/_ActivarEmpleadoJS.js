(function () {

    var ws = {}

    var ctrl = {
        addModalidadCargo: $('#addModalidadCargo')
    }

    var handles = {
        setEvents: function () {
            ctrl.addModalidadCargo.click(listener.click_addModalidadCargo);
        }
    }

    var listener = {
        initialize: function () {
            handles.setEvents();
        },
        click_addModalidadCargo: function () {
            pedidos.popup.executePopupNoBor("agrege un nuevo cargo", 'asignar un cargo'
                       , '/Employees/_ModalidadCargo', '500', '525', function () {
                          alert('gfgf')
                       }.bind(this));
        }
    }


    $(document).ready(function () {
        listener.initialize();

    })

})();