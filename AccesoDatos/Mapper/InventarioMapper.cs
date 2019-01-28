using System;
using System.Collections.Generic;
using AccesoDatos.Dao;
using EntidadesPOJO;

namespace AccesoDatos.Mapper
{
    public class InventarioMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public const string DB_COL_CODIGO_PRODUCTO = "CODIGO_PRODUCTO";
        public const string DB_COL_CODIGO_TIENDA = "CODIGO_TIENDA";
        public const string DB_COL_CODIGO_PROVEEDOR = "CODIGO_PROVEEDOR";
        public const string DB_COL_CANTIDAD = "CANTIDAD";
        public const string DB_COL_FECHA_ENTRADA = "FECHA_ENTRADA";
        public const string DB_COL_PRECIO_UNIDAD = "PRECIO_UNIDAD";
        public const string DB_COL_IMPUESTO = "IMPUESTO";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var inventario = new Inventario()
            {
                IdProducto = GetStringValue(row, DB_COL_CODIGO_PRODUCTO),
                IdProveedor = GetStringValue(row, DB_COL_CODIGO_PROVEEDOR),
                Cantidad = GetIntValue(row, DB_COL_CANTIDAD),
                FechaEntrada = GetStringValue(row, DB_COL_FECHA_ENTRADA),
                PrecioUnidad = GetDoubleValue(row, DB_COL_PRECIO_UNIDAD),
                Impuesto = GetDoubleValue(row, DB_COL_IMPUESTO)
            };

            return inventario;
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
            var sqlOpe = new SqlOperation { ProcedureName = "CRE_INVENTARIOS_PR" };
            var inventario = (Inventario)entity;

            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PRODUCTO, inventario.IdProducto);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_TIENDA, inventario.IdTienda);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PROVEEDOR, inventario.IdProveedor);
            sqlOpe.AddIntParam(DB_COL_CANTIDAD, inventario.Cantidad);
            sqlOpe.AddDoubleParam(DB_COL_PRECIO_UNIDAD, inventario.PrecioUnidad);
            sqlOpe.AddVarcharParam(DB_COL_FECHA_ENTRADA, inventario.FechaEntrada);
            sqlOpe.AddDoubleParam(DB_COL_IMPUESTO, inventario.Impuesto);
            return sqlOpe; ;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "DEL_INVENTARIOS_PR" };
            var inventario = (Inventario)entity;
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_TIENDA, inventario.IdTienda);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PRODUCTO, inventario.IdProducto);
            return sqlOpe; ;
        }

        public SqlOperation GetRetriveAllStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_ALL_INVENTARIOS_PR" };
            var inventario = (Inventario)entity;

            sqlOpe.AddVarcharParam(DB_COL_CODIGO_TIENDA, inventario.IdTienda);
            return sqlOpe; ;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "RET_INVENTARIOS_PR" };
            var inventario = (Inventario)entity;
            
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_TIENDA, inventario.IdTienda);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PRODUCTO, inventario.IdProducto);  
            return sqlOpe; ;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var sqlOpe = new SqlOperation { ProcedureName = "UPD_INVENTARIOS_PR" };
            var inventario = (Inventario)entity;

            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PRODUCTO, inventario.IdProducto);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_TIENDA, inventario.IdTienda);
            sqlOpe.AddVarcharParam(DB_COL_CODIGO_PROVEEDOR, inventario.IdProveedor);
            sqlOpe.AddIntParam(DB_COL_CANTIDAD, inventario.Cantidad);
            sqlOpe.AddDoubleParam(DB_COL_PRECIO_UNIDAD, inventario.PrecioUnidad);
            sqlOpe.AddVarcharParam(DB_COL_FECHA_ENTRADA, inventario.FechaEntrada);
            sqlOpe.AddDoubleParam(DB_COL_IMPUESTO, inventario.Impuesto);
            return sqlOpe; ;
        }
    }
}
