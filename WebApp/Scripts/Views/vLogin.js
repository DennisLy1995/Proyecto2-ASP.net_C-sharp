function validarCorreo(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
function verificarInicio() {
    var email = document.querySelector("#txtEmail").value.replace(" ", "");
    var password = document.querySelector("#txtPassword").value.replace(" ", "");
    var success = false;
    if (email != "" && password != "") {
        if (validarCorreo(email)) {
            success = true;
        } else {
            console.log("Este NO es un correo electrónico!");
        }
    } else {
        console.log("Hay espacios vacíos aún!");
    }

    return success;
}
function iniciarInicio() {
    if (sessionStorage.getItem("SESSION_USER") == null) {
        if (verificarInicio()) {
            var email = document.querySelector("#txtEmail").value.replace(" ", "");
            var password = MD5(document.querySelector("#txtPassword").value.replace(" ", ""));
            console.log(email + " -> " + password);
            this.ctrlActions = new ControlActions();
            var link = "http://localhost:58520/api/Usuario?email=" + email + " &password=" + password;
            console.log(link);
            var response = this.ctrlActions.GetToAPI(link);
            if (response != null) {
                console.log("El usuario " + response["IDENTIFICACION"] + " inició sesión correctamente.");
                sessionStorage.setItem("SESSION_USER", JSON.stringify(response));
                window.location.href = "vPerfilConfiguracion";
            } else {
                console.log("Los datos ingresados son incorrectos.");
            }
        }
    } else {
        console.log("Ya alguien inició sesión anteriormente!");
    }
}


$(document).ready(function () {
    document.querySelector("#btnIniciarSesion").addEventListener('click', iniciarInicio);
});