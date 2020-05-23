using System.Collections.Generic;
using DAL.Models;

namespace BLL.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<ServiceDto> Services { get; set; }
    }
}
