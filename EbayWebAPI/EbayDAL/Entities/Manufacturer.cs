using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public Manufacturer() : base() { }
        public Manufacturer(int id, string name) : base(id)
        {
            this.Name = name;
        }
    }
}
