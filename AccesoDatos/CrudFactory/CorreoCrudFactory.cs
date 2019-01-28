﻿using System;
using System.Collections.Generic;
using AccesoDatos.Dao;
using AccesoDatos.Mapper;
using EntidadesPOJO;

namespace AccesoDatos.CrudFactory
{
    public class CorreoCrudFactory : CrudFactory
    {
        CorreoMapper mapper;

        public CorreoCrudFactory()
        {
            mapper = new CorreoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var entidad = (Correo)entity;
            var sqlOperation = mapper.GetCreateStatement(entidad);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var entidad = (Correo)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(entity));
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstEntity = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstEntity.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstEntity;
        }

        public override void Update(BaseEntity entity)
        {
            var entidad = (Correo)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(entity));
        }
    }
}