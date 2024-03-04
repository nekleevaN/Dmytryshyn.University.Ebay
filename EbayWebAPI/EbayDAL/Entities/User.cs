using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbayDAL.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [ForeignKey("UserLocationId")]
        public int UserLocationId { get; set; }
        public UserLocation Location { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<CustomerOrder> Order { get; set; }

        public User() : base() { }

        public User(int id, string name, string lastName, string nickname, string password, string email, string phoneNumber, int userLocationId) : base(id)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Nickname = nickname;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.UserLocationId = userLocationId;
        }
    }
}
