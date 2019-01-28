using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using System;
using System.Collections.Generic;

namespace CoreApi
{
    public class OpcionListaManager
    {
        
        public OpcionListaManager()
        {

        }

        public List<OpcionLista> ListaSolicitada(string idLista)
        {
            var lstOpciones = new List<OpcionLista>();

            switch (idLista)
            {
                case "tienda":
                    lstOpciones = ObtenerListaTienda();
                    break;
                case "distribuidor":
                    lstOpciones = ObtenerListaDistribuidores();
                    break;
                case "usuario":
                    lstOpciones = ObtenerListaUsuarios();
                    break;
                case "productos":
                    lstOpciones = ObtenerListaProductos();
                    break;
                case "categorias":
                    lstOpciones = ObtenerListaCategorias();
                    break;
                case "tipoproductos":
                    lstOpciones = ObtenerListaTipoProductos();
                    break;
                default:
                    lstOpciones = null;
                    break;
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaTienda()
        {
            var crudFactory = new TiendaCrudFactory();
            var lstObjs = crudFactory.RetrieveAll<Tienda>();
            var lstOpciones = new List<OpcionLista>();

            foreach(var obj in lstObjs)
            {
                var nuevaOpcion = new OpcionLista
                {
                    Valor = obj.Cedula,
                    Texto = obj.Nombre
                };
                lstOpciones.Add(nuevaOpcion);
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaDistribuidores()
        {
            var crudFactory = new DistribuidorCrudFactory();
            var lstObjs = crudFactory.RetrieveAll<Distribuidor>();
            var lstOpciones = new List<OpcionLista>();

            foreach (var obj in lstObjs)
            {
                var nuevaOpcion = new OpcionLista
                {
                    Valor = obj.Cedula,
                    Texto = obj.Nombre
                };
                lstOpciones.Add(nuevaOpcion);
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaUsuarios()
        {
            var crudFactory = new UsuarioCrudFactory();
            var lstObjs = crudFactory.RetrieveAll<Usuario>();
            var lstOpciones = new List<OpcionLista>();

            foreach (var obj in lstObjs)
            {
                var nuevaOpcion = new OpcionLista
                {
                    Valor = obj.IDENTIFICACION,
                    Texto = obj.PRIMER_NOMBRE + " " + obj.PRIMER_APELLIDO 
                };
                lstOpciones.Add(nuevaOpcion);
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaProductos()
        {
            var crudFactory = new ProductosCrudFactory();
            var lstObjs = crudFactory.RetrieveAll<Productos>();
            var lstOpciones = new List<OpcionLista>();

            foreach (var obj in lstObjs)
            {
                var nuevaOpcion = new OpcionLista
                {
                    Valor = Convert.ToString(obj.CODIGO),
                    Texto = obj.NOMBRE
                };
                lstOpciones.Add(nuevaOpcion);
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaCategorias()
        {
            var crudFactory = new CategoriasCrudFactory();
            var lstObjs = crudFactory.RetrieveAll<Categorias>();
            var lstOpciones = new List<OpcionLista>();

            foreach (var obj in lstObjs)
            {
                var nuevaOpcion = new OpcionLista
                {
                    Valor = Convert.ToString(obj.CODIGO),
                    Texto = obj.NOMBRE
                };
                lstOpciones.Add(nuevaOpcion);
            }

            return lstOpciones;
        }

        public List<OpcionLista> ObtenerListaTipoProductos()
        {
            
            var lstOpciones = new List<OpcionLista>();
            var opcion1 = new OpcionLista
            {
                Valor = "Provisto",
                Texto = "Provisto"
            };
            var opcion2 = new OpcionLista
            {
                Valor = "Propio",
                Texto = "Propio"
            };

            lstOpciones.Add(opcion1);
            lstOpciones.Add(opcion2);

            return lstOpciones;
        }

        
    }
}
