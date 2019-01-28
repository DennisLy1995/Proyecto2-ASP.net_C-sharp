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
    public class CategoriaFavoritaCrudFactory : CrudFactory
    {
        CategoriaFavoritaMapper mapper;

        public CategoriaFavoritaCrudFactory()
        {
            mapper = new CategoriaFavoritaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var entidad = (CategoriaFavorita)entity;
            var sqlOperation = mapper.GetCreateStatement(entidad);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var entidad = (CategoriaFavorita)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveAllCategoriasUsuario<T>(BaseEntity entity)
        {
            var lstCategoriasFav = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllCategoriasUsuario(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var a in objs)
                {
                    lstCategoriasFav.Add((T)Convert.ChangeType(a, typeof(T)));
                }
            }

            return lstCategoriasFav;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
