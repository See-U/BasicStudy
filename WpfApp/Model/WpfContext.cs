using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    /// <summary>
    /// Wpf上下文
    /// </summary>
    public class WpfContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=wpfs.db");

            optionsBuilder.UseLazyLoadingProxies();
            
        }
    }
}
