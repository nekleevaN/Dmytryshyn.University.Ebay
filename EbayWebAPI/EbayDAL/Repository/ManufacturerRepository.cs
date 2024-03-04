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
    public class ManufacturerRepository : AbstractRepository, IManufacturerRepository
    {
        private readonly DbSet<Manufacturer> dbSet;
        public ManufacturerRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<Manufacturer>();
        }
        public void Add(Manufacturer entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(Manufacturer entity)
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

        public IEnumerable<Manufacturer> GetAll()
        {
            return dbSet.ToList();
        }

        public Manufacturer GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(Manufacturer entity)
        {
            var manufacturer = dbSet.Find(entity.Id);

            if (manufacturer != null)
            {
                manufacturer = entity;
                dbSet.Add(manufacturer);
                context.SaveChanges();
            }
        }
    }
}
