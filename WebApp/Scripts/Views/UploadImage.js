let imagenUrl = '';
$(function () {
    $.cloudinary.config({ cloud_name: 'dofeo1jm7', api_key: '346236359485865' });
    let uploadButton = $('#btnSeleccionarImagen');
    uploadButton.on('click', function (e) {
        // Initiate upload
        cloudinary.openUploadWidget({ cloud_name: 'dofeo1jm7', upload_preset: 'sc5rspmt', tags: ['cgal'] },
            function (error, result) {
                if (error) console.log(error);
                if (result == null) {
                    /*var popup = document.querySelector("#show_message");
                    popup.classList.remove("alert-success");
                    popup.classList.add("alert-danger");
                    var txt = document.querySelector("#show_message_description");
                    txt.innerHTML = "Oops. Se canceló el proceso. Intenta nuevamente.";
                    popup.classList.remove("div_hidden");*/

                } else {
                    let id = result[0].public_id;
                    localStorage.setItem('idImageLS', JSON.stringify(id));
                    imagenUrl = 'https://res.cloudinary.com/dofeo1jm7/image/upload/v1541378178/' + id + '.png';
                    document.querySelector("#txtUrlImagen").value = imagenUrl;
                    console.log(imagenUrl);
              /*      var txt = document.querySelector("#show_message_description");
                    txt.innerHTML = "La <a href='"+imagenUrl+"'>imagen</a> se subió correctamente.";
                    var popup = document.querySelector("#show_message");
                    popup.classList.add("alert-success");
                    popup.classList.remove("alert-danger");
                    popup.classList.remove("div_hidden");*/
                   /* var link = document.querySelector("#url_link_upload");
                    link.setAttribute("href", imagenUrl);*/
                

                }
            });
    });
})

function processImage(id) {
    let options = {
        client_hints: true,
    };
    return $.cloudinary.url(id, options);
}
