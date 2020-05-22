using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
