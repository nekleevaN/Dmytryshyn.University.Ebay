using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("SallerId")]
        public int SallerId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        [ForeignKey("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public string ProductPhotoUrl { get; set; }
        public User Seller { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public virtual IList<OrderDetail> OrderDetails { get; set; }
        public Product() : base() { }
        public Product(int id, string name, int sallerId, decimal unitPrice, string description, int manufacturerId, int categoryId, string productPhotoUrl) : base(id)
        {
            this.Name = name;
            this.SallerId = sallerId;
            this.UnitPrice = unitPrice;
            this.Description = description;
            this.ManufacturerId = manufacturerId;
            this.CategoryId = categoryId;
            this.ProductPhotoUrl = productPhotoUrl;
        }
    }
}
