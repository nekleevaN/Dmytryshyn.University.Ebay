using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayBLL.Models
{
    public abstract class AbstractModel
    {
        public int Id { get; set; }
        public AbstractModel(int Id)
        {
            this.Id = Id;
        }
    }
}
