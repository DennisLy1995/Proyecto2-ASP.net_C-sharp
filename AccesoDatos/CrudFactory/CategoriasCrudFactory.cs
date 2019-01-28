using AccesoDatos.Dao;
using AccesoDatos.Mapper;
using EntidadesPOJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.CrudFactory
{
    public class CategoriasCrudFactory : CrudFactory
    {
        CategoriasMapper mapper;

        public CategoriasCrudFactory() : base()
        {
            mapper = new CategoriasMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var categoria = (Categorias)entity;
            var sqlOperation = mapper.GetCreateStatement(categoria);
            dao.ExecuteProcedure(sqlOperation);
        }



        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T CountByNombre<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountByNombreStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }


        public T CountByTag<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountByTagStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T CountAll<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountAllStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }


        public override List<T> RetrieveAll<T>()
        {
            var lstClientes = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstClientes.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstClientes;
        }

        public List<T> RetrieveAllByNombre<T>(string nombreCategoria)
        {
            var lstClientes = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByNombreStatement(nombreCategoria));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstClientes.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstClientes;
        }

        public List<T> RetrieveAllByTag<T>(string tag)
        {
            var lstClientes = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByTagStatement(tag));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstClientes.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstClientes;
        }
        


        public override void Update(BaseEntity entity)
        {
            var categoria = (Categorias)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(categoria));

        }

        public override void Delete(BaseEntity entity)
        {
            var categoria = (Categorias)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(categoria));
        }

    }
}
