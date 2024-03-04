using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class OrderDetail : BaseEntity
    {
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int ProductAmount { get; set; }
        public CustomerOrder Order { get; set; }
        public Product Product { get; set; }

        public OrderDetail() : base() { }
        public OrderDetail(int id, int orderId, int productId, decimal price, int amount) : base(id)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Price = price;
            this.ProductAmount = amount;
        }
    }
}
