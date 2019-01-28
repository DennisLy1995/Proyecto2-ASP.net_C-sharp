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
    public class CategoriasManager : BaseManager
    {
        private CategoriasCrudFactory crudCategorias;

        public CategoriasManager()
        {
            crudCategorias = new CategoriasCrudFactory();
        }

        public void Create(Categorias categoria)
        {
            try
            {
                var c = crudCategorias.Retrieve<Categorias>(categoria);

                if (c != null)
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }
                else
                {
                    crudCategorias.Create(categoria);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Categorias> RetrieveAll()
        {
            return crudCategorias.RetrieveAll<Categorias>();
        }

        public List<Categorias> RetrieveAllByNombre(string nombreCategoria)
        {
            return crudCategorias.RetrieveAllByNombre<Categorias>(nombreCategoria);
        }

        public List<Categorias> RetrieveAllByTag(string tag)
        {
            return crudCategorias.RetrieveAllByTag<Categorias>(tag);
        }
        

        public Categorias RetrieveById(Categorias categoria)
        {
            Categorias c = null;
            try
            {
                c = crudCategorias.Retrieve<Categorias>(categoria);
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

        public Categorias CountByNombre(string nombreCategoria)
        {
            Categorias categoria = new Categorias();
            categoria.NOMBRE = nombreCategoria;
            Categorias c = null;
            try
            {
                c = crudCategorias.CountByNombre<Categorias>(categoria);
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

        public Categorias CountByTag(string tag)
        {
            Categorias categoria = new Categorias();
            categoria.TAG = tag;
            Categorias c = null;
            try
            {
                c = crudCategorias.CountByTag<Categorias>(categoria);
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

        public Categorias CountAll()
        {
            Categorias categoria = new Categorias();
            Categorias c = null;
            try
            {
                c = crudCategorias.CountAll<Categorias>(categoria);
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



        public void Update(Categorias categoria)
        {
            crudCategorias.Update(categoria);
        }

        public void Delete(Categorias categoria)
        {
            crudCategorias.Delete(categoria);
        }
    }
}
