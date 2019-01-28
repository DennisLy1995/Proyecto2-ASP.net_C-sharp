window.location.href = "#alert";
function vPerfil() {

    this.service = 'usuario';
    this.ctrlActions = new ControlActions();
    this.userLogged = false;
    this.informacionUsuario = {};

    this.CargarInformacionUsuario = function () {
        if (sessionStorage.getItem('SESSION_USER') != null) {
            var user_data = JSON.parse(sessionStorage.getItem("SESSION_USER"))
            var link = "http://localhost:58520/api/usuario?id=" + user_data['IDENTIFICACION'];
            this.informacionUsuario = this.ctrlActions.GetToAPI(link);
            this.userLogged = true;

        }
        else {
            console.log("¡NO DEBERÍA ESTAR AQUÍ!");

        }
    }

    this.CargarInformacionPerfil = function () {
        document.querySelector("#perfil_nombre_completo").innerHTML = this.informacionUsuario["PRIMER_NOMBRE"] + " " + this.informacionUsuario["PRIMER_APELLIDO"];
        document.querySelector("#perfil_identificacion").innerHTML = this.informacionUsuario["IDENTIFICACION"];
        document.querySelector("#perfil_tipo_cuenta").innerHTML = this.informacionUsuario["TIPO_CUENTA"];
        document.querySelector("#perfil_email").innerHTML = this.informacionUsuario["CODIGO_CORREO"];
    }
  
    this.CargarInformacionForm = function () {
        if (this.userLogged) {
            document.querySelector("#txtId").disabled = true;
            document.querySelector("#txtId").value = this.informacionUsuario["IDENTIFICACION"];
            document.querySelector("#txtPrimerApellido").value = this.informacionUsuario["PRIMER_APELLIDO"];
            document.querySelector("#txtSegundoApellido").value = this.informacionUsuario["SEGUNDO_APELLIDO"];
            document.querySelector("#txtPrimerNombre").value = this.informacionUsuario["PRIMER_NOMBRE"];
            document.querySelector("#txtSegundoNombre").value = this.informacionUsuario["SEGUNDO_NOMBRE"];
            if (this.informacionUsuario["URL_FOTO_ID"].length >= 10) {
                document.querySelector("#perfil_foto_pp").src = this.informacionUsuario["URL_FOTO_ID"];
            }
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



    }
}

$(document).ready(function () {
    var vp = new vPerfil();
    vp.CargarInformacionUsuario();
    vp.CargarInformacionPerfil();
    if (window.location.href == "http://localhost:52014/Home/vPerfilConfiguracion#alert") {
        vp.CargarInformacionForm();
        window.location.href = "#";
    }
    

});

