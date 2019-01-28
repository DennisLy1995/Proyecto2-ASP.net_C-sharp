using System;
using System.Collections.Generic;
using System.Linq;
 using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class UsuarioMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_IDENTIFICACION = "IDENTIFICACION";
        private const string DB_COL_PRIMER_NOMBRE = "PRIMER_NOMBRE";
        private const string DB_COL_SEGUNDO_NOMBRE = "SEGUNDO_NOMBRE";
        private const string DB_COL_PRIMER_APELLIDO = "PRIMER_APELLIDO";
        private const string DB_COL_SEGUNDO_APELLIDO = "SEGUNDO_APELLIDO";
        private const string DB_COL_URL_FOTO_PERFIL = "URL_FOTO_PERFIL";
        private const string DB_COL_URL_FOTO_ID = "URL_FOTO_ID";
        private const string DB_COL_TIPO_CUENTA = "TIPO_CUENTA";
        private const string DB_COL_NUM_CUENTA = "NUM_CUENTA";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA_VALOR";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ent = new Usuario
            {
                IDENTIFICACION = GetStringValue(row, DB_COL_IDENTIFICACION),
                PRIMER_NOMBRE = GetStringValue(row, DB_COL_PRIMER_NOMBRE),
                SEGUNDO_NOMBRE = GetStringValue(row, DB_COL_SEGUNDO_NOMBRE),
                PRIMER_APELLIDO = GetStringValue(row, DB_COL_PRIMER_APELLIDO),
                SEGUNDO_APELLIDO = GetStringValue(row, DB_COL_SEGUNDO_APELLIDO),
                URL_FOTO_PERFIL = GetStringValue(row, DB_COL_URL_FOTO_PERFIL),
                URL_FOTO_ID = GetStringValue(row, DB_COL_URL_FOTO_ID),
                TIPO_CUENTA = GetStringValue(row, DB_COL_TIPO_CUENTA),
                NUM_CUENTA = GetIntValue(row, DB_COL_NUM_CUENTA)

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
         
            var e = (Usuario)entity;
 
            SqlOperation op = new SqlOperation { ProcedureName = "CRE_USUARIOS_PR" };
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION.Replace("-", ""));
            op.AddVarcharParam(DB_COL_PRIMER_NOMBRE, e.PRIMER_NOMBRE);
            op.AddVarcharParam(DB_COL_SEGUNDO_NOMBRE, e.SEGUNDO_NOMBRE);
            op.AddVarcharParam(DB_COL_PRIMER_APELLIDO, e.PRIMER_APELLIDO);
            op.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, e.SEGUNDO_APELLIDO);
            op.AddVarcharParam(DB_COL_URL_FOTO_PERFIL, e.URL_FOTO_PERFIL);
            op.AddVarcharParam(DB_COL_URL_FOTO_ID, e.URL_FOTO_ID);
            op.AddVarcharParam(DB_COL_TIPO_CUENTA, e.TIPO_CUENTA);
            op.AddVarcharParam(DB_COL_CONTRASENNA, e.CONTRASENNA);
            op.AddVarcharParam("EMAIL", e.EMAIL);
            return op;
        }

        public SqlOperation GetLogInStatement(BaseEntity entity)
        {
            var e = (Usuario)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "INICIAR_SESION_PR" };
            op.AddVarcharParam("EMAIL", e.EMAIL);
            op.AddVarcharParam("PASSWORD", e.CONTRASENNA);
            return op;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var e = (Usuario)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "DESACT_USUARIOS_PR" };
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            return op;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            return new SqlOperation { ProcedureName = "RET_USUARIOS_PR" };
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation op = new SqlOperation { ProcedureName = "RET_USUARIO_PR" };
            var e = (Usuario)entity;
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            return op;

        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var e = (Usuario)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "UPD_USUARIO_PR" };
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            op.AddVarcharParam(DB_COL_PRIMER_NOMBRE, e.PRIMER_NOMBRE);
            op.AddVarcharParam(DB_COL_SEGUNDO_NOMBRE, e.SEGUNDO_NOMBRE);
            op.AddVarcharParam(DB_COL_PRIMER_APELLIDO, e.PRIMER_APELLIDO);
            op.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, e.SEGUNDO_APELLIDO);
            op.AddVarcharParam(DB_COL_URL_FOTO_PERFIL, e.URL_FOTO_PERFIL);
            op.AddVarcharParam(DB_COL_URL_FOTO_ID, e.URL_FOTO_ID);
            op.AddVarcharParam(DB_COL_TIPO_CUENTA, e.TIPO_CUENTA);
            op.AddIntParam(DB_COL_NUM_CUENTA, e.NUM_CUENTA);
            return op;
        }
    }
}
