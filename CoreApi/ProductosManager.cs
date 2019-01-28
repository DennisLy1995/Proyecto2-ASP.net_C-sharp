using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi
{
    public class ProductosManager : BaseManager
    {
        private ProductosCrudFactory crudProductos;

        public ProductosManager()
        {
            crudProductos = new ProductosCrudFactory();
        }

        public void Create(Productos producto)
        {
            try
            {
                var c = crudProductos.Retrieve<Productos>(producto);

                if (c != null)
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }
                else
                {
                    crudProductos.Create(producto);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Productos> RetrieveAll()
        {
            return crudProductos.RetrieveAll<Productos>();
        }

        public List<Productos> RetrieveAllByCedulaTienda(string cedula)
        {
            return crudProductos.RetrieveAllByCedulaTienda<Productos>(cedula);
        }

        public List<Productos> RetrieveAllByNombreCategoria(string nombreCategoria)
        {
            return crudProductos.RetrieveAllByNombreCategoria<Productos>(nombreCategoria);
        }

        public List<Productos> RetrieveAllByNombreProducto(string nombreProducto)
        {
            return crudProductos.RetrieveAllByNombreProducto<Productos>(nombreProducto);
        }

        public List<Productos> RetrieveAllByNombreTienda(string nombreTienda)
        {
            return crudProductos.RetrieveAllByNombreTienda<Productos>(nombreTienda);
        }

        public List<Productos> RetrieveAllByTag(string tag)
        {
            return crudProductos.RetrieveAllByTag<Productos>(tag);
        }

        public List<Productos> RetrieveAllByCodigoCategoria(int codigoCategoria)
        {
            return crudProductos.RetrieveAllByCodigoCategoria<Productos>(codigoCategoria);
        }

        public List<Productos> RetrieveAllByTipoProducto(string tipoProducto)
        {
            return crudProductos.RetrieveAllByTipoProducto<Productos>(tipoProducto);
        }



        public Productos CountByNombreTienda(string nombreTienda)
        {
            Productos producto = new Productos();
            producto.NOMBRE = nombreTienda;
            return crudProductos.CountByNombreTienda<Productos>(producto);
        }

        public Productos CountByCodigoTienda(int codigoCategoria)
        {
            Productos producto = new Productos();
            producto.CODIGO_CATEGORIA = codigoCategoria;
            return crudProductos.CountByCodigoTienda<Productos>(producto);
        }

        public Productos CountByTienda(int codigoTienda,int codigoCategoria)
        {
            Productos producto = new Productos();
            producto.CODIGO_CATEGORIA = codigoCategoria;
            producto.CODIGO_TIENDA = codigoTienda;
            return crudProductos.CountByTienda<Productos>(producto);
        }

        public Productos CountAllProducts()
        {
            Productos producto = new Productos();
            return crudProductos.CountAllProducts<Productos>(producto);
        }

        public Productos RetrieveById(Productos producto)
        {
            Productos c = null;
            try
            {
                c = crudProductos.Retrieve<Productos>(producto);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Productos producto)
        {
            crudProductos.Update(producto);
        }

        public void Delete(Productos producto)
        {
            crudProductos.Delete(producto);
        }
    }
}
