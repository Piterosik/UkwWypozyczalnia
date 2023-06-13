using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UkwWypozyczalnia.Models;

namespace UkwWypozyczalnia.DAL
{
    public class IdentityAppContext : IdentityDbContext<User, Role, int>
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> options) : base(options) { }
    }
}
