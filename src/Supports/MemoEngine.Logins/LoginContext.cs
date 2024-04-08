using Microsoft.EntityFrameworkCore;

namespace MemoEngine.Logins
{
    /// <summary>
    /// LoginContext 클래스: 데이터베이스와 일대일로 매핑되는 컨텍스트 클래스 
    /// </summary>
    public class LoginContext : DbContext
    {
        /// <summary>
        /// Logins 속성: Logins 테이블과 일대일 
        /// </summary>
        public DbSet<Login> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
