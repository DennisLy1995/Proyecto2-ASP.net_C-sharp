function vRegistrarTiendaCategorias() {
    this.tblTiendaId = 'tbl_categorias_x_tiendas';
    this.servicio = 'tienda/AsociarCategoria';
    this.ctrlActions = new ControlActions();
    this.columnas = "idTienda, idCategoria";

    this.ObtenerCategorias = function () {
        this.ctrlActions.FillTable('categorias', 'tbl_categorias', false);
    }

    this.AsociarCategoria = function () {
        let data = [];
        let idTienda = JSON.parse(sessionStorage.getItem('idTienda'));
        let idCategoria = document.querySelector("#txtCodigo").value;

        if (idCategoria != "") {
            let peticion = this.servicio += "?idTienda=" + idTienda + "&idCategoria=" + idCategoria;
            this.ctrlActions.PostToAPI(peticion, data);
        }
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmRegistrarTiendaCategoria', data);
    }

    this.ReiniciarInputs = function () {
        let lstInputs = [];
        lstInputs.push(document.querySelector("#txtCodigo"));
        lstInputs.push(document.querySelector("#txtNombre"));

        for (ind = 0; ind < lstInputs.length; ind++) {
            lstInputs[ind].value = "";
        }
    }

    this.ValidarInputs = function () {
        let lstInputs = document.querySelector("#txtCodigo");

        if (lstInputs.value == "") {
            this.ctrlActions.ShowMessage('E', 'Primero seleccione una categoría a registrar');
        } else {
            this.AsociarCategoria();
            this.ReiniciarInputs();
        }

    }

    this.Listo = function () {
        let idTienda = JSON.parse(sessionStorage.getItem('idTienda'));
        let consulta = "tienda/ObtenerCategorias?idTienda=" + idTienda;
        let info = this.ctrlActions.GetToAPI(this.ctrlActions.URL_API + consulta);

        if (info.length != 0) {
            this.ctrlActions.ShowMessage("I", "Registro de la tienda completado");
        } else {
            this.ctrlActions.ShowMessage("E", "Tienes que registrar mínimo una categoría, para seguir adelante");
        }
    }
}

$(document).ready(function () {

    var view = new vRegistrarTiendaCategorias();
    view.ObtenerCategorias();
});