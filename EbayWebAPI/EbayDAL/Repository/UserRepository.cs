using EbayDAL.Entities;
using EbayDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using EbayDAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Repository
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        private readonly DbSet<User> dbSet;
        public UserRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<User>();
        }
        public void Add(User entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return dbSet.ToList();
        }


        public User GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(User entity)
        {
            var user = dbSet.Find(entity.Id);

            if (user != null)
            {  
                user = entity;
                dbSet.Add(user);
                context.SaveChanges();
            }
        }
    }
}
