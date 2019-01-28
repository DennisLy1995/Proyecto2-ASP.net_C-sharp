using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class CategoriaFavoritaMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID_CATEGORIA = "ID_CATEGORIA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ent = new CategoriaFavorita
            {
                IdCategoria = GetIntValue(row, DB_COL_ID_CATEGORIA),
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO)
            };
            return ent;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var entity = BuildObject(row);
                lstResults.Add(entity);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var e = (CategoriaFavorita)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "CRE_CATEGORIA_FAVORITA_PR" };
            op.AddIntParam(DB_COL_ID_CATEGORIA, e.IdCategoria);
            op.AddVarcharParam(DB_COL_ID_USUARIO, e.IdUsuario);
            
            return op;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation op = new SqlOperation { ProcedureName = "DEL_CATEGORIA_FAVORITA_PR" };
            var e = (CategoriaFavorita)entity;            
            op.AddIntParam(DB_COL_ID_CATEGORIA, e.IdCategoria);
            op.AddVarcharParam(DB_COL_ID_USUARIO, e.IdUsuario);
            return op;
        }

        public SqlOperation GetRetriveAllCategoriasUsuario(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORIAS_USUARIO" };
            var e = (CategoriaFavorita)entity;
            operation.AddVarcharParam(DB_COL_ID_USUARIO, e.IdUsuario);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
