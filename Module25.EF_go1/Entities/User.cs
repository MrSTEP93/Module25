using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.EF_go1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Внешний ключ
        public int CompanyId { get; set; }

        // Навигационное свойство
        public Company Company { get; set; }

        public UserCredential UserCredential { get; set; }
    }
}
