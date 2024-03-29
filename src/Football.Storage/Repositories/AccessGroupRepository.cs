﻿using System;
using System.Collections.Generic;
using System.Linq;
using Football.Storage.Interfaces;
using Hulen.Storage;
using NHibernate;
using NHibernate.Criterion;
using Storage.DTO;

namespace Football.Storage.Repositories
{
    public class AccessGroupRepository : IAccessGroupRepository
    {
        public IEnumerable<AccessGroupDTO> GetAll()
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return session
                        .CreateCriteria(typeof(AccessGroupDTO))
                        .AddOrder(Order.Asc("Name"))
                        .List<AccessGroupDTO>();
                }
            }
            catch (Exception)
            {
                return new List<AccessGroupDTO>();
            }
        }

        public void SaveOne(AccessGroupDTO acc)
        {
            try
            {
                //if(NameAllreadyInUse(acc.Name))
                //{
                //    return StorageResult.AllreadyExsists;
                //}
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(acc);
                    transaction.Commit();
                }
                //return StorageResult.Success;
            }
            catch (Exception)
            {
                //return StorageResult.Failed;
            }   
        }

        public AccessGroupDTO GetOne(Guid id)
        { 
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return session.Get<AccessGroupDTO>(id);
                }
            }
            catch (Exception)
            {
                return new AccessGroupDTO();
            }
        }

        public void UpdateOne(AccessGroupDTO acc)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(acc);
                    transaction.Commit();
                }
                //return StorageResult.Success;
            }
            catch (Exception)
            {
                //return StorageResult.Failed;
            }  
        }

        public void DeleteOne(AccessGroupDTO acc)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(acc);
                    transaction.Commit();
                }
                //return StorageResult.Success;
            }
            catch (Exception)
            {
                //return StorageResult.Failed;
            }
        }

        public IEnumerable<AccessGroupDTO> GetAllByType(string type)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    return session
                        .CreateCriteria(typeof(AccessGroupDTO))
                        .Add(Restrictions.Eq("Type", type))
                        .List<AccessGroupDTO>();
                }
            }
            catch (Exception)
            {
                return new List<AccessGroupDTO>();
            }
        }

        public AccessGroupDTO GetOneByName(string name)
        {
            try
            {
                return GetAll().Where(x => x.Name == name).FirstOrDefault();

            }
            catch (Exception)
            {
                return new AccessGroupDTO();
            }
        }

        private static bool NameAllreadyInUse(string name)
        {
            AccessGroupDTO ac;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                ac = session
                    .CreateCriteria(typeof(AccessGroupDTO))
                    .Add(Restrictions.Eq("Name", name))
                    .UniqueResult<AccessGroupDTO>();
            }
            return ac != null;
        }
    }
}
