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
    public class InventarioCrudFactory : CrudFactory
    {
        public InventarioMapper Mapper;

        public InventarioCrudFactory()
        {
            Mapper = new InventarioMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var operacion = Mapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(operacion);
        }

        public override void Delete(BaseEntity entity)
        {
            var operacion = Mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(operacion);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var nObj = (Inventario)entity;
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

        public List<T> ObtenerInventario<T>(BaseEntity entity)
        {
            var lstObjs = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(Mapper.GetRetriveAllStatement(entity));
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
            var operacion = Mapper.GetUpdateStatement(entity);
            dao.ExecuteProcedure(operacion);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}
