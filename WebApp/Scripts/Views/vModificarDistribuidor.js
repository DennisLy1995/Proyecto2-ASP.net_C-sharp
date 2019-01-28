function vModificarDistribuidor() {
    this.tblDistribuidorId = 'tbl_distribuidores';
    this.servicio = 'distribuidor';
    this.ctrlActions = new ControlActions();
    this.columnas = "Cedula, Nombre, Administrador, TarifaBase, TarifaKm, Rango";

    this.Modificar = function () {
        let data = [];
        data = this.ctrlActions.GetDataForm('frmModificarDistribuidor');
        data['Administrador'] = JSON.parse(sessionStorage.getItem('idUsuario'));
        this.ctrlActions.PutToAPI(this.servicio, data);
    }

    this.ValidarInputs = function () {
        let lstInputs = document.querySelectorAll("input");
        let cont = 0;

        for (ind = 0; ind < lstInputs.length; ind++) {
            if (lstInputs[ind].value != "") {
                lstInputs[ind].classList.remove("is-invalid");
                cont++;
            }
            else {
                lstInputs[ind].classList.add("is-invalid");
            }
        }
        this.MostrarResultado(cont, lstInputs);
    }

    this.MostrarResultado = function (cont, lstInputs) {
        if (cont == lstInputs.length) {
            this.Modificar();
            this.ReiniciarInputs();
        } else {
            this.ctrlActions.ShowMessage('E', 'Porfavor, llene los campos requeridos.');
        }
    }

    this.LlenarFormulario = function (data) {
        let inputCedula = document.querySelector("#txtCedula");
        inputCedula.value = data['Cedula'];
        inputCedula.disabled = true;
        document.querySelector("#txtNombre").value = data['Nombre'];
        document.querySelector("#txtTarifaBase").value = data['TarifaBase'];
        document.querySelector("#txtTarifaKm").value = data['TarifaKM'];
        document.querySelector("#txtRango").value = data['Rango'];
    }

    this.ObtenerDistribuidor = function () {
        //PENDIENTE DE BORRARLO
        sessionStorage.setItem('idUsuario', JSON.stringify('117180829'));
        //PENDIENTE DE BORRARLO
        let codigoUsuario = JSON.parse(sessionStorage.getItem('idUsuario'));
        let url = this.ctrlActions.GetUrlApiService(this.servicio) + '/ObtenerPorAdmin/' + codigoUsuario;
        let data = this.ctrlActions.GetToAPI(url);
        return data;
    }
}

$(document).ready(function () {
    let view = new vModificarDistribuidor();
    let data = view.ObtenerDistribuidor();
    view.LlenarFormulario(data);
})