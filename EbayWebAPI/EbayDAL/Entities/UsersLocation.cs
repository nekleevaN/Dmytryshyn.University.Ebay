using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class UserLocation : BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }


        public UserLocation() : base() { }

        public UserLocation(int id, string county, string city) : base(id)
        {
            this.Country = county;
            this.City = city;
        }
    }
}
