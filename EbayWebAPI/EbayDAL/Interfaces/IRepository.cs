using EbayDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);

        void Update(TEntity entity);
    }
}
