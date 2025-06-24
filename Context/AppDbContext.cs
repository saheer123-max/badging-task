using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using LastProject.Model;


namespace LastProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public List<Product> ExecuteProductSp(string action, int? id = null)
        {
            return Products.FromSqlRaw("EXEC Sp_Product_CRUD @Action = {0}, @Id = {1}", action, id).ToList();
        }

    
        public void ExecuteNonQuerySp(string action, int? id = null, string name = null, decimal? price = null)
        {
            var parameters = new[]
            {
                new SqlParameter("@Action", action),
                new SqlParameter("@Id", (object?)id ?? DBNull.Value),
                new SqlParameter("@Name", (object?)name ?? DBNull.Value),
                new SqlParameter("@Price", (object?)price ?? DBNull.Value)
            };

            Database.ExecuteSqlRaw("EXEC Sp_Product_CRUD @Action, @Id, @Name, @Price", parameters);
        }
    }
}
