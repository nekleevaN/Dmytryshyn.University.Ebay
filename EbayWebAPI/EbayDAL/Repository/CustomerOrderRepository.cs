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
    public class CustomerOrderRepository : AbstractRepository, ICustomerOrderRepository
    {
        private readonly DbSet<CustomerOrder> dbSet;
        public CustomerOrderRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<CustomerOrder>();
        }
        public void Add(CustomerOrder entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(CustomerOrder entity)
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

        public IEnumerable<CustomerOrder> GetAll()
        {
            return dbSet.ToList();
        }

        public CustomerOrder GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(CustomerOrder entity)
        {
            var customerOrder = dbSet.Find(entity.Id);

            if (customerOrder != null)
            {
                customerOrder = entity;
                dbSet.Update(customerOrder);
                context.SaveChanges();
            }
        }
    }
}
