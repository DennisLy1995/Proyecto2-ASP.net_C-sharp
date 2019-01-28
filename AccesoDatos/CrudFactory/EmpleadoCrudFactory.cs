using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Dao;
using AccesoDatos.Mapper;
using EntidadesPOJO;

namespace AccesoDatos.CrudFactory
{
    public class EmpleadoCrudFactory : CrudFactory
    {
        EmpleadoMapper mapper;

        public EmpleadoCrudFactory()
        {
            mapper = new EmpleadoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var entidad = (Empleado)entity;
            var sqlOperation = mapper.GetCreateStatement(entidad);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var entidad = (Empleado)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
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

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveAllEmpleadosTienda<T>(BaseEntity entity)
        {
            var lstProyectos = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllEmpleadosTiendaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var a in objs)
                {
                    lstProyectos.Add((T)Convert.ChangeType(a, typeof(T)));
                }
            }

            return lstProyectos;
        }

        public override void Update(BaseEntity entity)
        {
            var entidad = (Empleado)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(entity));
        }
    }
}
