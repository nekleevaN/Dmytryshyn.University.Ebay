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
    public class CategoryRepository : AbstractRepository, ICategoryRepository
    {
        private readonly DbSet<Category> dbSet;
        public CategoryRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<Category>();
        }
        public void Add(Category entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Category entity)
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

        public IEnumerable<Category> GetAll()
        {
            return dbSet.ToList();
        }

        public Category GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(Category entity)
        {
            var category = dbSet.Find(entity.Id);

            if (category != null)
            {
                category = entity;
                dbSet.Add(category);
                context.SaveChanges();
            }
        }
    }
}
