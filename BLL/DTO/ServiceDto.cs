using System.Collections.Generic;
using DAL.Models;

namespace BLL.DTO
{
    public class ServiceDto
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Price { get; set; }

        public virtual ICollection<User> UsersWhoBought { get; set; }
    }
}
