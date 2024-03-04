using EbayDAL.Entities;
using EbayDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using EbayDAL.DB;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Repository
{
    public class OrderDetailRepository : AbstractRepository, IOrderDetailRepository
    {
        private readonly DbSet<OrderDetail> dbSet;
        public OrderDetailRepository(EbayDbContext context) : base(context)
        {
            dbSet = context.Set<OrderDetail>();
        }
        public void Add(OrderDetail entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(OrderDetail entity)
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

        public IEnumerable<OrderDetail> GetAll()
        {
            return dbSet.ToList();
        }

        public OrderDetail GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(OrderDetail entity)
        {
            var orderDetail = dbSet.Find(entity.Id);

            if (orderDetail != null)
            {
                orderDetail = entity;
                dbSet.Add(orderDetail);
                context.SaveChanges();
            }
        }
    }
}
