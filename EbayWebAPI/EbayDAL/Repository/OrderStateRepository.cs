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
    public class OrderStateRepository : AbstractRepository, IOrderStateRepository
    {
        private readonly DbSet<OrderState> dbSet;
        public OrderStateRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<OrderState>();
        }
        public void Add(OrderState entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(OrderState entity)
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

        public IEnumerable<OrderState> GetAll()
        {
            return dbSet.ToList();
        }

        public OrderState GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(OrderState entity)
        {
            var orderState = dbSet.Find(entity.Id);

            if (orderState != null)
            {
                orderState = entity;
                dbSet.Add(orderState);
                context.SaveChanges();
            }
        }
    }
}
