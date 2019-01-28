using AccesoDatos.Dao;
using EntidadesPOJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    class CategoriasMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CODIGO = "CODIGO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_TAG = "TAG";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CATEGORIA_PR" };

            var c = (Categorias)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);
            operation.AddVarcharParam(DB_COL_TAG, c.TAG);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORIA_PR" };

            var c = (Categorias)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);

            return operation;
        }

        public SqlOperation GetCountByNombreStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_CATEGORIAS_BY_NOMBRE_PR" };

            var c = (Categorias)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);

            return operation;
        }

        public SqlOperation GetCountByTagStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_CATEGORIAS_BY_TAG_PR" };

            var c = (Categorias)entity;
            operation.AddVarcharParam(DB_COL_TAG, c.TAG);

            return operation;
        }

        public SqlOperation GetCountAllStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_CATEGORIAS_PR" };
            var c = (Categorias)entity;

            return operation;
        }
        


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORIAS_PR" };
            return operation;
        }


        public SqlOperation GetRetriveAllByNombreStatement(string nombreCategoria)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORIAS_BY_NOMBRE_PR" };
            operation.AddVarcharParam(DB_COL_NOMBRE, nombreCategoria);
            return operation;
        }

        public SqlOperation GetRetriveAllByTagStatement(string tag)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORIAS_BY_TAG_PR" };
            operation.AddVarcharParam(DB_COL_TAG, tag);
            return operation;
        }
        


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORIA_PR" };

            var c = (Categorias)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);
            operation.AddVarcharParam(DB_COL_TAG, c.TAG);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORIA_PR" };

            var c = (Categorias)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var categoria = BuildObject(row);
                lstResults.Add(categoria);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var categoria = new Categorias
            {

                CODIGO = GetIntValue(row, DB_COL_CODIGO),
                NOMBRE = GetStringValue(row, DB_COL_NOMBRE),
                TAG = GetStringValue(row, DB_COL_TAG),

        };
            return categoria;
        }
    }
}
