function vRegistrarInventario () {
    this.tblInventarioId = 'tbl_inventarios';
    this.servicio = 'inventario';
    this.ctrlActions = new ControlActions();
    this.columnas = "IdProducto, IdTienda, FechaEntrada, Cantidad, PrecioUnidad, Impuesto, IdProveedor";

    this.OpcionRegistrar = function () {
        if (this.ValidarInputs()) {
            this.ctrlActions.PostToAPI(this.servicio, this.ObtenerInformacion());
            this.LimpiarForm();
            this.RecargarTabla();
        }
    }

    this.OpcionModificar = function () {
        if (this.ValidarInputs()) {
            this.ctrlActions.PutToAPI(this.servicio, this.ObtenerInformacion());
            this.LimpiarForm();
            this.RecargarTabla();
        }
    }

    this.ValidarInputs = function () {
        let cont = 0
        $('#frmInventario *').filter(':input').each(function (input) {
            if ($(this).val() == '') {
                $(this).addClass("is-invalid");
            } else {
                $(this).removeClass("is-invalid");
                cont++;
            }   
        });

        let elementos = $('input', '#frmInventario *').length + $('select', '#frmInventario *').length;

        if (cont >= elementos) {
            return true;
        } else {
            this.ctrlActions.ShowMessage('E', 'Por favor, ingrese los campos requeridos.');
            return false;
        }

    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmInventario', data);
    }

    this.ObtenerInformacion = function () {
        let data = [];
        data = this.ctrlActions.GetDataForm("frmInventario");
        data['IdTienda'] = JSON.parse(sessionStorage.getItem('IdTienda'));
        data['IdProveedor'] = document.querySelector("#sltProveedor").value;
        data['IdProducto'] = document.querySelector("#sltProducto").value;
        return data;
    }

    this.ObtenerInventario = function () {
        let parametro = "/ObtenerInventario?tienda=" + JSON.parse(sessionStorage.getItem('IdTienda'));
        this.ctrlActions.FillTable(this.servicio + parametro, this.tblInventarioId, false);
    }

    this.RecargarTabla = function () {
        let parametro = "/ObtenerInventario?tienda=" + JSON.parse(sessionStorage.getItem('IdTienda'));
        this.ctrlActions.FillTable(this.service + parametro, this.tblInventarioId, true);
    }

    this.ObtenerProductos = function () {
        let idTienda = JSON.parse(sessionStorage.getItem('IdTienda'));
        let url = this.ctrlActions.GetUrlApiService('productos');
        url += '/GetByCedulaTienda/' + idTienda;
        return this.ctrlActions.GetToAPI(url);
    }

    this.MostrarFormRegistro = function () {
        $("#sltProducto").prop('disabled', false);
        $("#sltProveedor").prop('disabled', false);
        $("#boton-registrar").removeClass("oculto");
        $("#boton-modificar").addClass("oculto");
        $("#frmInventario").removeClass("oculto");
    }

    this.MostrarFormModificar = function () {
        $("#sltProducto").prop('disabled', 'disabled');
        $("#sltProveedor").prop('disabled', 'disabled');
        $("#boton-registrar").addClass("oculto");
        $("#boton-modificar").removeClass("oculto");
        $("#frmInventario").removeClass("oculto");
    }

    this.OcultarForms = function () {
        $("#boton-registrar").addClass("oculto");
        $("#boton-modificar").addClass("oculto");
        $("#frmInventario").addClass("oculto");
    }

    this.LimpiarForm = function () {
        $('#frmInventario *').filter(':input').each(function (input) {
            $(this).val('');
        });
    }
}

$(document).ready(function () {
    //PENDIENTE DE BORRARLO
    sessionStorage.setItem('IdTienda', JSON.stringify('1-2222-3333'));
    //PENDIENTE DE BORRARLO
    var view = new vRegistrarInventario();
    view.ObtenerInventario();
    ConstruirSelectProductos(view.ObtenerProductos());
});

function ConstruirSelectProductos(lstProductos) {
    let elementoPrincipal = document.querySelector("#sltProducto");

    for (ind = 0; ind < lstProductos.length; ind++) {
        let nuevaOpcion = document.createElement('option');
        nuevaOpcion.value = lstProductos[ind]['CODIGO'];
        nuevaOpcion.textContent = lstProductos[ind]['NOMBRE'];
        elementoPrincipal.appendChild(nuevaOpcion);
    }
}