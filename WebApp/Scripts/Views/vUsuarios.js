function validarDatos(data) {
    var error = "";
    if (data["CONTRASENNA"] == data["CONFIRMACION_CONTRASENNA"]) {
    } else {
        error = "Las contraseñas ingresadas no coinciden.";
    }
    if (data["CONTRASENNA"].length <= 5 && error == "") {
        error = "La contraseña debe tener mínimo un tamaño de 5 carácteres.";
    }
    if (data["PRIMER_NOMBRE"].length == 0 || data["PRIMER_APELLIDO"].length == 0 || data["IDENTIFICACION"].length == 0 || data["EMAIL"].length == 0 && error == "") {
        error = "Por favor, llene todos los campos necesarios.";
    }
    if (data["URL_FOTO_ID"].length == 0 && error == "") {
        error = "Por favor, suba la imagen de su identificación.";
    }
    return error;

}

function validarEmail(email) {
    var email_response;
    try {
        $.ajax({
            type: "GET",
            url: "http://localhost:58520/api/Correo",
            cache: false,
            async: false,
            success: function (data) {
                email_response = data['Data'];
            }
        });
    } catch (err) {
        console.log(err);
    }
    var found = false;
    for (var i = 0; i < email_response.length; i++) {
        if (email_response[i]["VALOR"].toLowerCase() == email.toLowerCase()) {
            found = true;
        }
    }
    return found;
}

function vUsuarios() {

    this.tblCustomersId = 'tblUsuarios';
    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.columns = "IDENTIFICACION,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TIPO_CUENTA";
    this.ctrlAlert = new ControlAlert();

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblCustomersId, false);
        this.ctrlActions.UpdateNavPanel();
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblCustomersId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }

    this.DesactivarUsuario = function () {
        var dataUsuario = {};
        dataUsuario = this.ctrlActions.GetDataForm('frmDesactivarUsuario');
        if (dataUsuario['IDENTIFICACION'].length >= 11) {
            var id = dataUsuario['IDENTIFICACION'].split("-");
            var link = "http://localhost:58520/api/usuario?id=" + id[0] + id[1] + id[2] + "&status=0";
            this.ctrlActions.GetToAPI(link);
            console.log(link);
            document.querySelector("#txtId").value = "";
        } else {
            console.log("La identificación no está bien.");
        }
    }

    this.RegistrarUsuario = function () {
        var customerData = {};
        customerData = this.ctrlActions.GetDataForm('frmRegistrarUsuarios');
        if (validarDatos(customerData) == "") {
            this.ctrlAlert.SetMessage("Estamos realizando tu registro, por favor, espera.");
            this.ctrlAlert.SetProgress(0);
            this.ctrlAlert.Open();
            setTimeout(function () {
                this.ctrlAlert = new ControlAlert();
                this.ctrlActions = new ControlActions();
                if (validarEmail(customerData["EMAIL"])) {
                    this.ctrlAlert.SetProgress(0);
                    this.ctrlAlert.SetMessage("Oops! El correo que intentas usar ya existe. Por favor, utiliza otro.");
                    window.setTimeout(function () {
                        window.location.href = "#";
                    }, 3000);
                } else {
                    this.ctrlAlert.SetProgress(50);
                    customerData["CONTRASENNA"] = MD5(customerData["CONTRASENNA"]);
                    this.ctrlActions.PostToAPI('usuario', customerData);
                    this.ctrlAlert.SetProgress(100);
                    this.ctrlAlert.SetMessage("¡Listo! Serás redireccionado en 3 segundos.");
                    window.setTimeout(function () {
                        window.location.href = "/Home";
                    }, 3000);
                }
            }, 1000);



        } else {
            console.log(validarDatos(customerData));
        }



    }
}

 $(document).ready(function () {
     if (window.location.href == "http://localhost:52014/Home/vListarUsuarios") {
         var vuser = new vUsuarios();
         vuser.RetrieveAll();
     }
    

});

