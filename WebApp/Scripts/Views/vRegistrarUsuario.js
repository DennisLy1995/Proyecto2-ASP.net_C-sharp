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
function vRegistrarUsuario () {

     this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.ctrlAlert = new ControlAlert();
 
 
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
                    this.ctrlActions.PostToAPI(this.service, customerData);
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
        //Hace el post al create
        //Refresca la tabla
     }

 
 
}

 