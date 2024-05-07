using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProniaEmil.Models;

namespace ProniaEmil.DataAccesLayer
{
    public class ProniaEContext : DbContext
    {
        public ProniaEContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-742DB1G;Database=EMILPRONIA;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(options);
        }
    }
}
