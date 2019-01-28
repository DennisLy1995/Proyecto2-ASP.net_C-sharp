function vTienda() {
    this.tblTiendaId = 'tbl_tiendas';
    this.servicio = 'tienda';
    this.ctrlActions = new ControlActions();
    this.columnas = "Cedula, TipoCedula, Nombre, UrlLogo, CodigoVendedor";
    this.popup = document.querySelector("#show_message");
    this.txt = document.querySelector("#show_message_description");

    this.Registrar = function () {
        let data = [];
        data = this.ctrlActions.GetDataForm('frmRegistrarTienda');
        data['CodigoVendedor'] = JSON.parse(sessionStorage.getItem('Administrador'));
        data['TipoCedula'] = document.querySelector('#sltTipoCedula').value;
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
            this.ValidarSelects();
        } else {
            this.popup.classList.remove("alert-success");
            this.popup.classList.add("alert-danger");
            this.txt.innerHTML = "Por favor, llene los campos requeridos";
            this.popup.classList.remove("div_hidden");
        }
    }

    this.ReiniciarInputs = function () {
        let lstInputs = document.querySelectorAll("input");

        for (ind = 0; ind < lstInputs.length; ind++) {
            lstInputs[ind].value = "";
        }
    }

    this.ValidarSelects = function () {
        let lstSelects = document.querySelectorAll("select");
        let cont = 0;

        for (ind = 0; ind < lstSelects.length; ind++) {
            if (lstSelects[ind].value != "") {
                lstSelects[ind].classList.remove("is-invalid");
                cont++;
            } else {
                lstSelects[ind].classList.add("is-invalid");
            }
        }

        if (cont == lstSelects.length) {
            try {
                this.Registrar();
                let cedula = document.querySelector('#txtCedula').value;
                sessionStorage.setItem('idTienda', JSON.stringify(cedula));
                this.ReiniciarInputs();
                this.txt.innerHTML = "La tienda se registró correctamente.";
                this.popup.classList.add("alert-success");
                this.popup.classList.remove("alert-danger");
                this.popup.classList.remove("div_hidden");
                setTimeout('window.location.assign("http://localhost:57056/Home/vRegistrarTiendaDistribuidor")', 3000);
            } catch{
                this.popup.classList.remove("alert-success");
                this.popup.classList.add("alert-danger");
                this.txt.innerHTML = "Ocurrio un error, vuelve a intentarlo";
                this.popup.classList.remove("div_hidden");
            }
           
        } else {
            this.popup.classList.remove("alert-success");
            this.popup.classList.add("alert-danger");
            this.txt.innerHTML = "Por favor, llene los campos requeridos";
            this.popup.classList.remove("div_hidden");
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