using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class CustomerOrder : BaseEntity
    {
        [ForeignKey("CustomerId")]
        public int UserId { get; set; }
        public string OperationTime { get; set; }

        [ForeignKey("OrderStateId")]
        public int OrderStateId { get; set; }
        public User User { get; set; }
        public OrderState State { get; set; }
        public virtual IList<OrderDetail> Details { get; set; }

        public CustomerOrder() : base() { }
        public CustomerOrder(int id, string operationTime, int userId, int orderStateId) : base(id)
        {
            this.OperationTime = operationTime;
            this.UserId = userId;
            this.OrderStateId = orderStateId;
        }
    }
}
