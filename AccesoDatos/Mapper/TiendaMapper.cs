using System.Collections.Generic;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class TiendaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public const string DB_COL_CEDULA = "CEDULA";
        public const string DB_COL_CODIGO_ADMIN = "CODIGO_ADMIN";
        public const string DB_COL_NOMBRE = "NOMBRE";
        public const string DB_COL_URL_LOGO = "URL_LOGO";
        public const string DB_COL_COMISION = "COMISION";
        public const string DB_COL_TIPO_CEDULA = "TIPO_CEDULA";
        public const string DB_COL_CODIGO_GPS_BODEGA = "CODIGO_GPS_BODEGA";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var tienda = new Tienda()
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                UrlLogo = GetStringValue(row, DB_COL_URL_LOGO),
                TipoCedula = GetStringValue(row, DB_COL_TIPO_CEDULA),
                CodigoVendedor = GetStringValue(row, DB_COL_CODIGO_ADMIN),
                Comision = GetDoubleValue(row, DB_COL_COMISION)
            };
            return tienda;
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
            var sqlOpe = new SqlOperation { ProcedureName = "CRE_TIENDAS_PR" };
            var tienda = (Tienda)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, tienda.Cedula);
            sqlOpe.AddVarcharParam(DB_COL_NOMBRE, tienda.Nombre);
            sqlOpe.AddVarcharParam(DB_COL_URL_LOGO, tienda.UrlLogo);
            sqlOpe.AddVarcharParam(DB_COL_TIPO_CEDULA, tienda.TipoCedula);
            sqlOpe.AddIntParam(DB_COL_CODIGO_GPS_BODEGA, tienda.GpsBodega);
            sqlOpe.AddDoubleParam(DB_COL_COMISION, tienda.Comision);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_ADMIN, tienda.CodigoVendedor);
            return sqlOpe;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "DEL_TIENDAS_PR" };
            var tienda = (Tienda)entity;
            sqlOpe.AddVarcharParam(DB_COL_CEDULA, tienda.Cedula);
            return sqlOpe;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_ALL_TIENDAS_PR" };
            return sqlOpe;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_TIENDAS_PR" };
            var tienda = (Tienda)entity;
            sqlOpe.AddVarcharParam(DB_COL_CEDULA, tienda.Cedula);
            return sqlOpe;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "UPD_TIENDAS_PR" };
            var tienda = (Tienda)entity;

            sqlOpe.AddVarcharParam(DB_COL_CEDULA, tienda.Cedula);
            sqlOpe.AddVarcharParam(DB_COL_NOMBRE, tienda.Nombre);
            sqlOpe.AddVarcharParam(DB_COL_URL_LOGO, tienda.UrlLogo);
            sqlOpe.AddVarcharParam(DB_COL_TIPO_CEDULA, tienda.TipoCedula);
            sqlOpe.AddIntParam(DB_COL_CODIGO_GPS_BODEGA, tienda.GpsBodega);
            sqlOpe.AddDoubleParam(DB_COL_COMISION, tienda.Comision);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_ADMIN, tienda.CodigoVendedor);
            return sqlOpe;
        }

        public SqlOperation AsociarCategoriaSentencia(string idTienda, int idCategoria)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "CRE_CATEGORIAS_TIENDAS_PR" };
            sqlOpe.AddVarcharParam("CODIGO_TIENDA", idTienda);
            sqlOpe.AddIntParam("CODIGO_CATEGORIA", idCategoria);
            return sqlOpe;
        }

        public SqlOperation AsociarDistribuidorSentencia(string idTienda, string idDistribuidor)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "CRE_DISTRIBUIDORES_TIENDAS_PR" };
            sqlOpe.AddVarcharParam("CODIGO_TIENDA", idTienda);
            sqlOpe.AddVarcharParam("CODIGO_DISTRIBUIDOR", idDistribuidor);
            return sqlOpe;
        }

        public SqlOperation ObtenerCategoriasSentencia(string idTienda)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_CATEGORIAS_TIENDAS_PR" };
            sqlOpe.AddVarcharParam(DB_COL_CEDULA, idTienda);
            return sqlOpe;
        }

        public SqlOperation ObtenerDistribuidoresSentencia(string idTienda)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_DISTRIBUIDORES_TIENDAS_PR" };
            sqlOpe.AddVarcharParam(DB_COL_CEDULA, idTienda);
            return sqlOpe;
        }

        public SqlOperation EliminarDistribuidorSentencia(string idTienda, string idDistribuidor)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "DEL_DISTRIBUIDORES_TIENDAS_PR" };
            sqlOpe.AddVarcharParam(DB_COL_CEDULA, idTienda);
            sqlOpe.AddVarcharParam("CODIGO_DISTRIBUIDOR", idDistribuidor);
            return sqlOpe;
        }
    }
}
