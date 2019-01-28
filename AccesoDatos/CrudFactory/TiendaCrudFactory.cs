using AccesoDatos.Dao;
using AccesoDatos.Mapper;
using EntidadesPOJO;
using System;
using System.Collections.Generic;

namespace AccesoDatos.CrudFactory
{
    public class TiendaCrudFactory : CrudFactory
    {
        public TiendaMapper Mapper;

        public TiendaCrudFactory()
        {
            Mapper = new TiendaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var ope = Mapper.GetCreateStatement(entity);
            dao.ExecuteProcedure(ope);
        }

        public override void Delete(BaseEntity entity)
        {
            var ope = Mapper.GetDeleteStatement(entity);
            dao.ExecuteProcedure(ope);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var nObj = (Tienda)entity;
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
            var ope = Mapper.GetUpdateStatement(entity);
            dao.ExecuteProcedure(ope);
        }

        public void AsociarCategoria(string idTienda, int idCategoria)
        {
            var ope = Mapper.AsociarCategoriaSentencia(idTienda, idCategoria);
            dao.ExecuteProcedure(ope);
        }

        public void AsociarDistribuidor(string idTienda, string idDistribuidor)
        {
            var ope = Mapper.AsociarDistribuidorSentencia(idTienda, idDistribuidor);
            dao.ExecuteProcedure(ope);
        }

        public List<T> ObtenerCategorias<T>(string idTienda)
        {
            var lstObjs = new List<T>();
            var mapperCategoria = new CategoriasMapper();

            var lstResult = dao.ExecuteQueryProcedure(Mapper.ObtenerCategoriasSentencia(idTienda));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapperCategoria.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstObjs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstObjs;
        }

        public List<T> ObtenerDistribuidores<T>(string idTienda)
        {
            var lstObjs = new List<T>();
            var mapperDistribuidor = new DistribuidorMapper();

            var lstResult = dao.ExecuteQueryProcedure(Mapper.ObtenerDistribuidoresSentencia(idTienda));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapperDistribuidor.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstObjs.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstObjs;
        }

        public void EliminarDistribuidor(string idTienda, string idDistribuidor)
        {
            var ope = Mapper.EliminarDistribuidorSentencia(idTienda, idDistribuidor);
            dao.ExecuteProcedure(ope);
        }
    }
}
