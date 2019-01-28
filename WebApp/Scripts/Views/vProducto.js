function vProducto() {

    this.tblProductoId = 'tblProductos';
    this.servicio = 'Productos';
    this.ctrlActions = new ControlActions();
    this.columnas = "CODIGO,NOMBRE,TIPO";
    this.popup = document.querySelector("#show_message");
    this.txt = document.querySelector("#show_message_description");

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.servicio, this.tblProductoId, false); 
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


    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmRegistrarProducto', data);
    }


    this.MostrarFormulario = function() {
        try {
            $("#form_registrar_block").toggle(400);
        }
        catch (err) {
            console.log(err);
        }
    }


    this.IngresarProductos = function (productos) {

        $("#listaProductos").append(productos);

    }




    this.GenerarHTML = function (listaProductos){

    }

    this.RetrieveAllProductos = function () {

        var obj;
        try {
            $.ajax({
                type: "GET",
                url: "http://localhost:58520/api/Productos",
                cache: false,
                async: false,
                success: function (data) {
                    obj = data['Data'];
                }
            });
            console.log(obj);
        } catch (err) {
            console.log("Error en el metodo 'RetrieveAll' con Ajax | Error:" + err);
        }
    }
}

//ON DOCUMENT READY
    $(document).ready(function () {

        try {
            $("#form_registrar_block").hide();
        }
        catch (err) {
            console.log(err);
        }
        try {
            var vproducto = new vProducto();
            vproducto.RetrieveAll();
            vproducto.RetrieveAllProductos();
        } catch (err) {
            console.log(err);
        }
    });