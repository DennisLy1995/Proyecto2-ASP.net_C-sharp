

function vRegistrarDistribuidor() {

    this.tblDistribuidorId = 'tbl_distribuidores';   
    this.servicio = 'distribuidor';
    this.ctrlActions = new ControlActions();
    this.columnas = "Cedula, Nombre, Administrador, TarifaBase, TarifaKm, Rango";

    this.Registrar = function () {
        let data = [];  
        data = this.ctrlActions.GetDataForm('frmRegistrarDistribuidor');
        data['Administrador'] = JSON.parse(sessionStorage.getItem('Administrador'));
        this.ctrlActions.PostToAPI(this.servicio, data);
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
            this.Registrar();
            this.ReiniciarInputs();
        } else {
            this.ctrlActions.ShowMessage('E', 'Porfavor, llene los campos requeridos.');
        }
    }

    this.ReiniciarInputs = function () {
        let lstInputs = document.querySelectorAll("input");

        for (ind = 0; ind < lstInputs.length; ind++) {
            lstInputs[ind].value = "";
        }
    }

    //Se elimina este metodo cuando se una lo de usuario actual
    this.AgregarUsuario = function () {
        sessionStorage.setItem('Administrador', JSON.stringify("117180829"));
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmRegistrarDistribuidor', data);
    }
}