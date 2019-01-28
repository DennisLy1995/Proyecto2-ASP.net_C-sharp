function vListarTienda() {
    this.tblTiendasId = 'TBL_TIENDAS';
    this.servicio = 'tienda';
    this.ctrlActions = new ControlActions();
    this.columns = "Cedula,Nombre,UrlLogo,TipoCedula,GpsBodega,Comision,CodigoVendedor";

    this.ObtenerTiendas = function () {
        let url = this.ctrlActions.GetUrlApiService(this.servicio);
        let data = this.ctrlActions.GetToAPI(url);
        return data;
    }
}

$(document).ready(function () {
    let view = new vListarTienda();
    let data = view.ObtenerTiendas();

    if (data.length == 0) {
        ConstruirPaginaVacia();
    } else {
        ConstruirPagina(data);
    }
    
});

function ConstruirPagina(data) {
    let cuerpoPrincipal = document.querySelector("#whole_content");

    for (obj = 0; obj < data.length; obj++) {
        let contenedor = ConstruirContenedor(obj);

        let encabezado = ConstruirEncabezado(data[obj]);
        contenedor.appendChild(encabezado);

        let cuerpo = ConstruirCuerpo(data[obj]);
        contenedor.appendChild(cuerpo);

        let pie = ConstruirPieContenedor(data[obj]);
        contenedor.appendChild(pie);
        
        cuerpoPrincipal.appendChild(contenedor);
    }
}

function ConstruirPaginaVacia() {
    let cuerpoPrincipal = document.querySelector("#whole_content");

    let texto = document.createElement('p');
    texto.classList.add('lead');
    texto.textContent = 'Disculpen las molestias, no se encuentran tiendas disponibles.';
    cuerpoPrincipal.appendChild(texto);
}

function VerProductos() {
    let cedula = this.dataset.codigo;
    sessionStorage.setItem('idTienda', JSON.stringify(cedula));
}

function ConstruirContenedor(info) {
    let divPrincipal = document.createElement('div');
    divPrincipal.id = 'card-tienda-' + info;
    divPrincipal.classList.add('card');
    divPrincipal.classList.add('border-secondary');
    divPrincipal.classList.add('ordenado');
    divPrincipal.style.width = '25%';
    return divPrincipal;
}

function ConstruirEncabezado(info) {
    let cabeza = document.createElement('div');
    cabeza.classList.add('card-header');
    cabeza.classList.add('font-weight-bold');
    cabeza.style.width = '100%';
    cabeza.textContent = info['Nombre'];
    return cabeza;
}

function ConstruirCuerpo(info) {
    let cuerpo = document.createElement('div');
    cuerpo.classList.add('card-body');
    cuerpo.style.width = '100%';
    cuerpo.style.textAlign = 'center';

    let imagen = document.createElement('img');
    imagen.style.width = '150px';
    imagen.style.height = '150px';
    imagen.src = info['UrlLogo'];

    cuerpo.appendChild(imagen);
    return cuerpo;
}

function ConstruirPieContenedor(info) {
    let pie = document.createElement('div');
    pie.classList.add('card-footer');
    pie.style.width = '100%';
    pie.style.textAlign = 'center';

    let output = document.createElement('output');
    output.id = 'cedula';
    output.classList.add('oculto');
    output.textContent = info['Cedula'];
    pie.appendChild(output);

    let boton = document.createElement('button');
    boton.id = 'btnMostrar';
    boton.classList.add('btn');
    boton.classList.add('btn-info');
    boton.textContent = 'Ver productos';
    boton.dataset.codigo = info['Cedula'];
    boton.addEventListener('click', VerProductos)
    pie.appendChild(boton);

    return pie;
}