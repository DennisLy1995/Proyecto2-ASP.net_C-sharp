function validarDatos(data, valCon) {
    var error = "";
    if (valCon == true) {
        if (data["CONTRASENNA"] == data["CONFIRMACION_CONTRASENNA"]) {
        } else {
            error = "Las contraseñas ingresadas no coinciden.";
        }
        if (data["CONTRASENNA"].length <= 5 && error == "") {
            error = "La contraseña debe tener mínimo un tamaño de 5 carácteres.";
        }
        if (data["IDENTIFICACION"].length == 0 || data["EMAIL"].length == 0 && error == "") {
            error = "Por favor, llene todos los campos necesarios.";
        }
    }
    if (data["PRIMER_NOMBRE"].length == 0 || data["PRIMER_APELLIDO"].length == 0 && error == "") {
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

function vEmpleados() {
    this.service = 'empleado';
    this.ctrlActions = new ControlActions();
    this.ctrlAlert = new ControlAlert();
    this.tblEmpleadosId = 'tblEmpleados';
    this.columns = "IDENTIFICACION,PRIMER_NOMBRE,SEGUNDO_NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,TIPO_CUENTA";

    this.Create = function () {
        var empleadosData = {};
        empleadosData = this.ctrlActions.GetDataForm('frmEmpleados');

        if (validarDatos(empleadosData, true) == "") {
            this.ctrlAlert.SetMessage("Estamos realizando el registro de tu empleado, por favor, espera.");
            this.ctrlAlert.SetProgress(0);
            this.ctrlAlert.Open();
            setTimeout(function () {
                this.ctrlAlert = new ControlAlert();
                this.ctrlActions = new ControlActions();
                this.service = 'empleado';
                if (validarEmail(empleadosData["EMAIL"])) {
                    this.ctrlAlert.SetProgress(0);
                    this.ctrlAlert.SetMessage("El correo del empleado que intentas registrar ya existe. Por favor, utiliza otro.");
                    window.setTimeout(function () {
                        window.location.href = "#";
                    }, 3000);
                } else {
                    this.ctrlAlert.SetProgress(50);
                    this.ctrlActions.PostToAPI(this.service, empleadosData);
                    this.ctrlAlert.SetProgress(100);
                    window.setTimeout(function () {
                        window.location.href = "#";
                    }, 3000);
                    var popup = document.querySelector("#show_message");//mensaje de la imagen
                    popup.classList.add("div_hidden");//desaparece mensaje de la imagen
                    this.ctrlActions.ClearDataForm('frmEmpleados');
                }
            }, 1000);
        } else {
            console.log(validarDatos(empleadosData, true));
        }
        this.ReloadTable();
    }

    this.Update = function () {
        var empleadosData = {};
        empleadosData = this.ctrlActions.GetDataForm('frmModEmpleados');
        if (validarDatos(empleadosData, false) == "") {
            this.ctrlAlert.SetMessage("Estamos modificando los datos de tu empleado, por favor, espera.");
            this.ctrlAlert.SetProgress(0);
            this.ctrlAlert.Open();
            setTimeout(function () {
                this.ctrlAlert = new ControlAlert();
                this.ctrlActions = new ControlActions();
                this.service = 'empleado';
                this.ctrlAlert.SetProgress(50);
                this.ctrlActions.PutToAPI(this.service, empleadosData);
                this.ctrlAlert.SetProgress(100);
                window.setTimeout(function () {
                    window.location.href = "#";
                }, 3000);
                var popup = document.querySelector("#show_message");//mensaje de la imagen
                popup.classList.add("div_hidden");//desaparece mensaje de la imagen
                this.ctrlActions.ClearDataForm('frmModEmpleados');
            }, 1000);
        } else {
            console.log(validarDatos(empleadosData, false));
        }
        this.ReloadTable();
        this.MostrarMostrarLista();
    }

    this.Delete = function () {
        var empleadosData = {};
        empleadosData = this.ctrlActions.GetDataForm('frmModEmpleados');
        this.ctrlActions.DeleteToAPI(this.service, empleadosData);
        this.ReloadTable();
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + '?idTienda=1'/*+ id de la tienda*/, this.tblEmpleadosId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service + '?idTienda=1'/*+ id de la tienda*/, this.tblEmpleadosId, true);
    }

    this.BindFields = function (data) {
        var urlImg = data["URL_FOTO_ID"];

        $("#imagenId").html('<img src="' + urlImg + '" alt="imagen">');

        this.ctrlActions.BindFields('frmModEmpleados', data);
        document.querySelector("#tabla_block").classList.add("oculto");
        document.querySelector("#form_modificar_block").classList.remove("oculto");
        document.querySelector("#Registro").classList.remove("oculto");
        document.querySelector("#Listar").classList.remove("oculto");
    }

    this.MostrarRegistro = function () {
        document.querySelector("#tabla_block").classList.add("oculto");
        document.querySelector("#Registro").classList.add("oculto");
        document.querySelector("#form_modificar_block").classList.add("oculto");
        document.querySelector("#form_editar_block").classList.remove("oculto");
        document.querySelector("#Listar").classList.remove("oculto");
    }

    this.MostrarMostrarLista = function () {
        document.querySelector("#form_editar_block").classList.add("oculto");
        document.querySelector("#Listar").classList.add("oculto");
        document.querySelector("#form_modificar_block").classList.add("oculto");
        document.querySelector("#tabla_block").classList.remove("oculto");
        document.querySelector("#Registro").classList.remove("oculto");
    }

    this.ObtenerEmpleado = function () {

        var id = $('#txtBuscar').val();

        var element = document.getElementById(data);
        console.log(element.value);

        localStorage.setItem("idBuscar", id + "");

        //this.ctrlActions.BindFields('frmBuscar', data);

        //localStorage.removeItem("idBuscar") //-- > Se elimina el dato deseado
    }
}

//ON DOCUMENT READY
$(document).ready(function () {
    var vemp = new vEmpleados();
    vemp.RetrieveAll();
    document.querySelector("#tabla_block").classList.remove("oculto");
    document.querySelector("#Registro").classList.remove("oculto");
});

//$(document).ready(function () {
//    var vista = new vEmpleados();

//    vista.ObtenerEmpleado();
//});