using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class CorreoMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_CORREO = "CORREO";
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ent = new Correo
            {
                VALOR = GetStringValue(row, DB_COL_CORREO)

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
            SqlOperation op = new SqlOperation { ProcedureName = "CRE_CORREOS_PR" };
            return op;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation op = new SqlOperation { ProcedureName = "RET_CORREOS_PR" };
            return op;
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
