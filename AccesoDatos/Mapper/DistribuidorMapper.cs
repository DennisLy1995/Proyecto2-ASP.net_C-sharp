using System.Collections.Generic;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class DistribuidorMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public const string DB_COL_CEDULA = "CEDULA";
        public const string DB_COL_CODIGO_USUARIO = "CODIGO_USUARIO";
        public const string DB_COL_NOMBRE = "NOMBRE";
        public const string DB_COL_TARIFA_BASE = "TARIFA_BASE";
        public const string DB_COL_TARIFA_KM = "TARIFA_KM";
        public const string DB_COL_RANGO = "RANGO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var distribuidor = new Distribuidor()
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Rango = GetIntValue(row, DB_COL_RANGO),
                TarifaBase = GetDoubleValue(row, DB_COL_TARIFA_BASE),
                TarifaKM = GetDoubleValue(row, DB_COL_TARIFA_KM),
                Administrador = GetStringValue(row, DB_COL_CODIGO_USUARIO)
            };
            return distribuidor;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lista = new List<BaseEntity>();

            foreach (var varFila in lstRows)
            {
                var nuevaObjeto = BuildObject(varFila);
                lista.Add(nuevaObjeto);
            }

            return lista;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "CRE_DISTRIBUIDOR_PR" };
            var obj = (Distribuidor)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, obj.Cedula);
            sqlOpe.AddVarcharParam(DB_COL_NOMBRE, obj.Nombre);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_USUARIO, obj.Administrador);
            sqlOpe.AddDoubleParam(DB_COL_TARIFA_BASE, obj.TarifaBase);
            sqlOpe.AddDoubleParam(DB_COL_TARIFA_KM, obj.TarifaKM);
            sqlOpe.AddIntParam(DB_COL_RANGO, obj.Rango);
            return sqlOpe;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "DEL_DISTRIBUIDOR_PR" };
            var objeto = (Distribuidor)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, objeto.Cedula);
            return sqlOpe;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_ALL_DISTRIBUIDOR_PR" };
            return sqlOpe;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_DISTRIBUIDOR_PR" };
            var objeto = (Distribuidor)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, objeto.Cedula);
            return sqlOpe;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "UPD_DISTRIBUIDOR_PR" };
            var obj = (Distribuidor)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, obj.Cedula);
            sqlOpe.AddVarcharParam(DB_COL_NOMBRE, obj.Nombre);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_USUARIO, obj.Administrador);
            sqlOpe.AddDoubleParam(DB_COL_TARIFA_BASE, obj.TarifaBase);
            sqlOpe.AddDoubleParam(DB_COL_TARIFA_KM, obj.TarifaKM);
            sqlOpe.AddIntParam(DB_COL_RANGO, obj.Rango);
            return sqlOpe;
        }

        public SqlOperation ObtenerDistribuidorPorAdminConsulta(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_DISTRIBUIDOR_BY_ADMIN_PR" };
            var obj = (Distribuidor)entity;

            sqlOpe.AddVarcharParam(DB_COL_CODIGO_USUARIO, obj.Administrador);
            return sqlOpe;
        }
    }
}
