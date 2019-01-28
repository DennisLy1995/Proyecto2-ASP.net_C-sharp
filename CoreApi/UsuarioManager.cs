
using AccesoDatos.CrudFactory;
using EntidadesPOJO;
using Excepciones;
using Exceptions;
using System;
using System.Collections.Generic;


namespace CoreApi
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crud;

        public UsuarioManager()
        {
            crud = new UsuarioCrudFactory();
        }



        public void Create(Usuario entidad)
        {
            try
            {
                var c = crud.Retrieve<Usuario>(entidad);

                if (c != null)
                {
                    
                }
                else
                {
                    crud.Create(entidad);
                 }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
             }
        }

        public List<Usuario> RetrieveAll()
        {
            return crud.RetrieveAll<Usuario>();
        }

    

        public Usuario RetrieveById(Usuario entidad)
        {
            Usuario e= null;
            try
            {
                e = crud.Retrieve<Usuario>(entidad);
                if (e == null)
                {
                    throw new BusinessException(0);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return e;
        }
        public Usuario IniciarSesion(Usuario entidad)
        {
            Usuario e = null;
            try
            {
                e = crud.IniciarSesion<Usuario>(entidad);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return e;
        }

        public void Update(Usuario entidad)
        {
            Usuario e = null;
            e = crud.Retrieve<Usuario>(entidad);
            if (e == null)
            {
             }
            else
            {
                crud.Update(entidad);
             }

        }

        public void Delete(Usuario entidad)
        {
            crud.Delete(entidad);
        }
    }
}
