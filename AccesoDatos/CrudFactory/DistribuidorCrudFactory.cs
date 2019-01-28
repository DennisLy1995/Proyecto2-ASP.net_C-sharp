using System;
using System.Collections.Generic;
using AccesoDatos.Dao;
using AccesoDatos.Mapper;
using EntidadesPOJO;

namespace AccesoDatos.CrudFactory
{
    public class DistribuidorCrudFactory : CrudFactory
    {
        public DistribuidorMapper Mapper;

        public DistribuidorCrudFactory()
        {
            Mapper = new DistribuidorMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var sqlOpe = Mapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(sqlOpe);
        }

        public override void Delete(BaseEntity entity)
        {
            var sqlOpe = Mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(sqlOpe);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var nObj = (Distribuidor)entity;
            var sqlOperacion = Mapper.GetRetriveStatement(nObj);
            var results = dao.ExecuteQueryProcedure(sqlOperacion);
            var dic = new Dictionary<string, object>();

            if (results.Count > 0)
            {
                dic = results[0];
                var objs = Mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstObjs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(Mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = Mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstObjs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstObjs;
        }

        public override void Update(BaseEntity entity)
        {
            var sqlOpe = Mapper.GetUpdateStatement(entity);
            dao.ExecuteProcedure(sqlOpe);
        }

        public T ObtenerDistribuidorPorAdmin<T>(BaseEntity entity)
        {
            var nObj = (Distribuidor)entity;
            var sqlOperacion = Mapper.ObtenerDistribuidorPorAdminConsulta(nObj);
            var results = dao.ExecuteQueryProcedure(sqlOperacion);
            var dic = new Dictionary<string, object>();

            if (results.Count > 0)
            {
                dic = results[0];
                var objs = Mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
    }
}
