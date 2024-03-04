using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class OrderState : BaseEntity
    {
        public string StateName { get; set; }
        public virtual IList<CustomerOrder> Order { get; set; }
        public OrderState() : base() { }
        public OrderState(int id, string stateName) : base(id)
        {
            this.StateName = stateName;
        }
    }
}
