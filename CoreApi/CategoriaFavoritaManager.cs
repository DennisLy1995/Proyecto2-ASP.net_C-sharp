using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApi
{
    public class CategoriaFavoritaManager : BaseManager
    {
        private CategoriaFavoritaCrudFactory crud;

        public CategoriaFavoritaManager()
        {
            crud = new CategoriaFavoritaCrudFactory();
        }

        public void Create(CategoriaFavorita entidad)
        {
            try
            {
                crud.Create(entidad);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<CategoriaFavorita> RetrieveAllCategoriasUsuario(CategoriaFavorita entidad)
        {
            List<CategoriaFavorita> e = null;

            try
            {
                e = crud.RetrieveAllCategoriasUsuario<CategoriaFavorita>(entidad);
                if (e == null)
                {
                    throw new BusinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return crud.RetrieveAllCategoriasUsuario<CategoriaFavorita>(entidad);
        }

        public void Delete(CategoriaFavorita entidad)
        {
            crud.Delete(entidad);
        }
    }
}
