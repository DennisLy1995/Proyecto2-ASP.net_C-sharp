using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class EmpleadoMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_CODIGO_TIENDA = "CODIGO_TIENDA";
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
        private const string DB_COL_CORREO = "CORREO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var ent = new Empleado
            {
                //ID_TIENDA = GetStringValue(row, DB_COL_CODIGO_TIENDA),
                IDENTIFICACION = GetStringValue(row, DB_COL_IDENTIFICACION),
                PRIMER_NOMBRE = GetStringValue(row, DB_COL_PRIMER_NOMBRE),
                SEGUNDO_NOMBRE = GetStringValue(row, DB_COL_SEGUNDO_NOMBRE),
                PRIMER_APELLIDO = GetStringValue(row, DB_COL_PRIMER_APELLIDO),
                SEGUNDO_APELLIDO = GetStringValue(row, DB_COL_SEGUNDO_APELLIDO),
                URL_FOTO_PERFIL = GetStringValue(row, DB_COL_URL_FOTO_PERFIL),
                URL_FOTO_ID = GetStringValue(row, DB_COL_URL_FOTO_ID),
                TIPO_CUENTA = GetStringValue(row, DB_COL_TIPO_CUENTA),
                NUM_CUENTA = GetIntValue(row, DB_COL_NUM_CUENTA),
                EMAIL = GetStringValue(row, DB_COL_CORREO)
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
            var e = (Empleado)entity;

            var md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(e.CONTRASENNA);
            var encodedBytes = md5.ComputeHash(originalBytes);

            SqlOperation op = new SqlOperation { ProcedureName = "CRE_EMPLEADOS_PR" };
            op.AddVarcharParam(DB_COL_CODIGO_TIENDA, e.ID_TIENDA);
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            op.AddVarcharParam(DB_COL_PRIMER_NOMBRE, e.PRIMER_NOMBRE);
            op.AddVarcharParam(DB_COL_SEGUNDO_NOMBRE, e.SEGUNDO_NOMBRE);
            op.AddVarcharParam(DB_COL_PRIMER_APELLIDO, e.PRIMER_APELLIDO);
            op.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, e.SEGUNDO_APELLIDO);
            op.AddVarcharParam(DB_COL_URL_FOTO_PERFIL, e.URL_FOTO_PERFIL);
            op.AddVarcharParam(DB_COL_URL_FOTO_ID, e.URL_FOTO_ID);
            op.AddVarcharParam(DB_COL_TIPO_CUENTA, e.TIPO_CUENTA);
            op.AddVarcharParam(DB_COL_CONTRASENNA, BitConverter.ToString(encodedBytes));
            op.AddVarcharParam("EMAIL", e.EMAIL);
            return op;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var e = (Empleado)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "DEL_EMPLEADO_PR" };
            op.AddVarcharParam(DB_COL_CODIGO_TIENDA, e.ID_TIENDA);
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            return op;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllEmpleadosTiendaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EMPLEADOS_TIENDAS_PR" };
            var e = (Empleado)entity;
            operation.AddVarcharParam(DB_COL_CODIGO_TIENDA, e.ID_TIENDA);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation op = new SqlOperation { ProcedureName = "RET_EMPLEADO_PR" };
            var e = (Empleado)entity;
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            op.AddVarcharParam(DB_COL_CODIGO_TIENDA, e.ID_TIENDA);
            return op;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var e = (Empleado)entity;
            SqlOperation op = new SqlOperation { ProcedureName = "UPD_EMPLEADO_PR" };
            op.AddVarcharParam(DB_COL_CODIGO_TIENDA, e.ID_TIENDA);
            op.AddVarcharParam(DB_COL_IDENTIFICACION, e.IDENTIFICACION);
            op.AddVarcharParam(DB_COL_PRIMER_NOMBRE, e.PRIMER_NOMBRE);
            op.AddVarcharParam(DB_COL_SEGUNDO_NOMBRE, e.SEGUNDO_NOMBRE);
            op.AddVarcharParam(DB_COL_PRIMER_APELLIDO, e.PRIMER_APELLIDO);
            op.AddVarcharParam(DB_COL_SEGUNDO_APELLIDO, e.SEGUNDO_APELLIDO);
            op.AddVarcharParam(DB_COL_URL_FOTO_ID, e.URL_FOTO_ID);
            return op;
        }
    }
}
