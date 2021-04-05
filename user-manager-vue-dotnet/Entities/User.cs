using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace user_manager_vue_dotnet.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        [StringLength(maximumLength: 8, MinimumLength = 3, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
