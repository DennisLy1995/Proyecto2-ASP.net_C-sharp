function vCategoria() {

    this.service = 'Categorias';
    this.ctrlActions = new ControlActions();
    this.columns = "CODIGO,NOMBRE,TAG";
    this.tblProductoId = 'tblCategorias';
    this.popup = document.querySelector("#show_message");
    this.txt = document.querySelector("#show_message_description");

    this.MostrarFormulario = function () {
        try {
            $("#frmRegistrarCategoria").toggle(1000);
        }
        catch (err) {
            console.log(err);
        }
    }


    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblProductoId, false);
    }

    this.RegistrarCategoria = function () {

        var obj;
        try {
            $.ajax({
                type: "GET",
                url: "http://localhost:58520/api/Categorias/CountTotal",
                cache: false,
                async: false,
                success: function (data) {
                    obj = data['Data'];
                }
            });
        } catch (err) {
            console.log("Error en el metodo 'CountTotal' | Error:" + err);
        }



        console.log("En la base de datos ahi una cantidad de " + obj.CODIGO + " categorias registradas, se procedera a registrar la nueva categoria.");
        try {
            //Request POST a la API para poder registrar la categoria.
            var test = $(".txtNombre").text();
            $.post("http://localhost:58520/api/Categorias",
                {
                    CODIGO: obj.CODIGO + 1,
                    NOMBRE: $("#txtNombre").val(),
                    TAG: $("#txtTag").val()
                },
                function (data, status) {
                    console.log("Categoria " + $("#txtNombre").val() + " registrada satisfactoriamente.");
                    $("#frmRegistrarCategoria").toggle(1000);
                    this.ctrlActions.FillTable(this.service, this.tblProductoId, true);
                });
        }
        catch (err) {
            console.log("Error en el metodo POST de categorias | Error:" + err);
        }
    }




    
}

//ON DOCUMENT READY
$(document).ready(function () {

    try {
        $("#frmRegistrarCategoria").hide();
    }
    catch (err) {
        console.log(err);
    }
    try {
        var vcategoria = new vCategoria();
        vcategoria.RetrieveAll();
    } catch (err) {
        console.log(err);
    }


});