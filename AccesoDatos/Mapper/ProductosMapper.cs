using AccesoDatos.Dao;
using EntidadesPOJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    class ProductosMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_CODIGO = "CODIGO";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_CODIGO_CATEGORIA = "CODIGO_CATEGORIA";
        private const string DB_COL_CODIGO_TIENDA = "CODIGO_TIENDA";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";


        //Otros
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_TAG = "TAG";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PRODUCTO_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);
            operation.AddVarcharParam(DB_COL_TIPO, c.TIPO);
            operation.AddIntParam(DB_COL_CODIGO_CATEGORIA, c.CODIGO_CATEGORIA);
            operation.AddIntParam(DB_COL_CODIGO_TIENDA, c.CODIGO_TIENDA);
            operation.AddVarcharParam(DB_COL_CODIGO_TIENDA, c.DESCRIPCION);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PRODUCTO_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);

            return operation;
        }

        public SqlOperation GetCountByNombreTiendaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CON_ALL_PRODUCTOS_BY_NOMBRE_TIENDA_PR" };

            var c = (Productos)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);

            return operation;
        }

        public SqlOperation GetCountByCodigoCategoriaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_ALL_PRODUCTOS_BY_CATEGORIA_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO_CATEGORIA, c.CODIGO_CATEGORIA);

            return operation;
        }

        public SqlOperation GetCountByTiendaStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_ALL_PRODUCTOS_BY_TIENDA_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO_TIENDA, c.CODIGO_TIENDA);
            operation.AddIntParam(DB_COL_CODIGO_CATEGORIA, c.CODIGO_CATEGORIA);

            return operation;
        }

        public SqlOperation GetCountAllProductsStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CONT_ALL_PRODUCTOS_PR" };
            return operation;
        }
        


        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllByCedulaTiendaStatement(string cedula)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_BY_CEDULA_TIENDA_PR" };
            operation.AddVarcharParam(DB_COL_CEDULA, cedula);
            return operation;
        }


        public SqlOperation RetrieveAllByNombreCategoria(string nombreCategoria)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_BY_NOMBRE_CATEGORIA_PR" };
            operation.AddVarcharParam(DB_COL_NOMBRE, nombreCategoria);
            return operation;
        }


        public SqlOperation RetrieveAllByNombreProducto(string nombreProducto)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_BY_NOMBRE_PR" };
            operation.AddVarcharParam(DB_COL_NOMBRE, nombreProducto);
            return operation;
        }

        public SqlOperation RetrieveAllByNombreTienda(string nombreTienda)
        {
            var operacion = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_BY_NOMBRE_TIENDA_PR" };
            operacion.AddVarcharParam(DB_COL_NOMBRE, nombreTienda);
            return operacion;
        }

        public SqlOperation RetrieveAllByTag(string tag)
        {
            var operacion = new SqlOperation { ProcedureName = "RET_ALL_PRODUCTOS_BY_TAG_CATEGORIA_PR" };
            operacion.AddVarcharParam(DB_COL_TAG, tag);
            return operacion;
        }

        public SqlOperation RetrieveAllCodigoCategoria(int codigoCategoria)
        {
            var operacion = new SqlOperation {  ProcedureName = "RET_PRODUCTOS_BY_CATEGORY_CODIGO_PR" };
            operacion.AddIntParam(DB_COL_CODIGO, codigoCategoria);
            return operacion;
        }

        public SqlOperation RetrieveAllByTipoProducto(string tipoProducto)
        {
            var operacion = new SqlOperation { ProcedureName = "RET_PRODUCTOS_BY_PRODUCT_TYPE_PR" };
            operacion.AddVarcharParam(DB_COL_TIPO, tipoProducto);
            return operacion;
        }





        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PRODUCTO_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.NOMBRE);
            operation.AddVarcharParam(DB_COL_TIPO, c.TIPO);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PRODUCTO_PR" };

            var c = (Productos)entity;
            operation.AddIntParam(DB_COL_CODIGO, c.CODIGO);

            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var producto = BuildObject(row);
                lstResults.Add(producto);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var producto = new Productos
            {

                CODIGO = GetIntValue(row, DB_COL_CODIGO),
                NOMBRE = GetStringValue(row, DB_COL_NOMBRE),
                TIPO = GetStringValue(row, DB_COL_TIPO),
                CODIGO_CATEGORIA = GetIntValue(row, DB_COL_CODIGO_CATEGORIA),
                CODIGO_TIENDA = GetIntValue(row, DB_COL_CODIGO_TIENDA),
                DESCRIPCION = GetStringValue(row, DB_COL_DESCRIPCION)

        };
            return producto;
        }
    }
}
