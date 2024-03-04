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
    public class ProductRepository : AbstractRepository, IProductRepository
    {
        private readonly DbSet<Product> dbSet;
        public ProductRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<Product>();
        }
        public void Add(Product entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Product entity)
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

        public IEnumerable<Product> GetAll()
        {
            return dbSet.ToList();
        }

        public Product GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(Product entity)
        {
            var product = dbSet.Find(entity.Id);

            if (product != null)
            {
                product = entity;
                dbSet.Add(product);
                context.SaveChanges();
            }
        }
    }
}
