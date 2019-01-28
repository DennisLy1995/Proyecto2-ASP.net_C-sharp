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
    public class ProductosCrudFactory : CrudFactory
    {
        ProductosMapper mapper;

        public ProductosCrudFactory() : base()
        {
            mapper = new ProductosMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var producto = (Productos)entity;
            var sqlOperation = mapper.GetCreateStatement(producto);
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


        public override List<T> RetrieveAll<T>()
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }

        public List<T> RetrieveAllByCedulaTienda<T>(string cedula)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllByCedulaTiendaStatement(cedula));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }



        public List<T> RetrieveAllByNombreCategoria<T>(string nombreCategoria)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllByNombreCategoria(nombreCategoria));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }


        public List<T> RetrieveAllByNombreProducto<T>(string nombreProducto)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllByNombreProducto(nombreProducto));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }

        public List<T> RetrieveAllByNombreTienda<T>(string nombreTienda)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllByNombreTienda(nombreTienda));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }

        public List<T> RetrieveAllByTag<T>(string tag)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllByTag(tag));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }

        public List<T> RetrieveAllByCodigoCategoria<T>(int codigoCategoria)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllCodigoCategoria(codigoCategoria));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }

        public List<T> RetrieveAllByTipoProducto<T>(string tipoProducto)
        {
            var lstProductos = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAllByTipoProducto(tipoProducto));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProductos.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProductos;
        }
        




        public T CountByNombreTienda<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountByNombreTiendaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T CountByCodigoTienda<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountByCodigoCategoriaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T CountAllProducts<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountAllProductsStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        

        public T CountByTienda<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCountByTiendaStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        




        public override void Update(BaseEntity entity)
        {
            var producto = (Productos)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(producto));

        }

        public override void Delete(BaseEntity entity)
        {
            var categoria = (Productos)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(categoria));
        }

    }
}
