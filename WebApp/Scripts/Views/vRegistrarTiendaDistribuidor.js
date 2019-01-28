function vRegistrarTiendaDistribuidor() {
    this.tblTiendaId = 'tbl_distribuidores_x_tiendas';
    this.servicio = 'tienda/AsociarDistribuidor';
    this.ctrlActions = new ControlActions();
    this.columnas = "idTienda, idDistribuidor";

    this.ObtenerDistribuidores = function () {
        this.ctrlActions.FillTable('distribuidor', 'tbl_distribuidores', false);
    }

    this.AsociarDistribuidor = function () {
        let data = [];
        let idTienda = JSON.parse(sessionStorage.getItem('idTienda'));
        let idDistribuidor = document.querySelector("#txtCedula").value;

        if (idDistribuidor != "") {
            let peticion = this.servicio += "?idTienda=" + idTienda + "&idDistribuidor=" + idDistribuidor;
            this.ctrlActions.PostToAPI(peticion, data);
        }
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmRegistrarTiendaDistribuidor', data);
    }

    this.ReiniciarInputs = function () {
        let lstInputs = [];
        lstInputs.push(document.querySelector("#txtCedula"));
        lstInputs.push(document.querySelector("#txtNombre"));

        for (ind = 0; ind < lstInputs.length; ind++) {
            lstInputs[ind].value = "";
        }
    }

    this.ValidarInputs = function () {
        let lstInputs = document.querySelector("#txtCedula");

        if (lstInputs.value == "") {
            this.ctrlActions.ShowMessage('E', 'Primero seleccione un distribuidor a registrar');
        } else {
            this.AsociarDistribuidor();
            this.ReiniciarInputs();
        }
            
    }

    this.Listo = function () {
        let idTienda = JSON.parse(sessionStorage.getItem('idTienda'));
        let consulta = "tienda/ObtenerDistribuidores?idTienda=" + idTienda;
        let info = this.ctrlActions.GetToAPI(this.ctrlActions.URL_API + consulta);

        if (info.length != 0) {
            window.location.assign("http://localhost:57056/Home/vRegistrarTiendaCategorias");
        } else {
            this.ctrlActions.ShowMessage("E","Tienes que registrar mínimo un distribuidor, para seguir adelante");
        }
    }
}

$(document).ready(function () {

    var view = new vRegistrarTiendaDistribuidor();
    view.ObtenerDistribuidores();
});