using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Services")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }

        public virtual ICollection<User> UsersWhoBought { get; set; }
    }
}
