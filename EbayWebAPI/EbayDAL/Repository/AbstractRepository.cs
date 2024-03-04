using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbayDAL.DB;

namespace EbayDAL.Repository
{
    public abstract class AbstractRepository
    {
        protected readonly EbayDbContext context;
        protected AbstractRepository(EbayDbContext context)
        {
            this.context = context;
        }
    }
}
