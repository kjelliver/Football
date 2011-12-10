using System.Collections.Generic;
using Football.Storage.Interfaces;
using Hulen.Storage;
using NHibernate;
using NHibernate.Criterion;
using Storage.DTO;

namespace Football.Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SaveOneUser(UserDTO user)
        {
            if (GetOneUserByUsername(user.Username) == null)
            {
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }
                //return StorageResult.Success;
            }
            //return StorageResult.AllreadyExsists;
        }

        public UserDTO GetOneUserByUsername(string username)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria(typeof(UserDTO))
                    .Add(Restrictions.Eq("Username", username))
                    .UniqueResult<UserDTO>();
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(UserDTO)).AddOrder(Order.Asc("Name")).List<UserDTO>();
            }
        }

        public void UpdateOneUser(UserDTO user, bool usernameChanged)
        {
            try
            {
                if(usernameChanged){
                    if(GetOneUserByUsername(user.Username) == null)
                    {
                        Update(user);
                        //return StorageResult.Success;
                    }
                    //return StorageResult.AllreadyExsists;
                }
                Update(user);
                //return StorageResult.Success;
            }
            catch
            {
                //return StorageResult.Failed;
            }
            
        }

        public void DeleteOneUser(string username)
        {
            try
            {
                var user = GetOneUserByUsername(username);
                using (ISession session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
                //return StorageResult.Success;
            }
            catch
            {
                //return StorageResult.Failed;
            }
        }

        private static void Update(UserDTO user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(user);
                transaction.Commit();
            }
        }
    }
}
