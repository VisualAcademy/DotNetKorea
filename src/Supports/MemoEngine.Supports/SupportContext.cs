using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MemoEngine.Supports
{
    public class SupportContext : DbContext
    {
        /// <summary>
        /// Supports 테이블과 일대일
        /// </summary>
        public DbSet<Support> Supports { get; set; }

        /// <summary>
        /// SupportsComments 테이블과 일대일 
        /// </summary>
        public DbSet<SupportComment> SupportsComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = 
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
