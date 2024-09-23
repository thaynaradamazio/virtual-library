using Microsoft.EntityFrameworkCore;
namespace ProjetoUm.Aplicativos;

public class ApplicationDbContext : DbContext
{
    public DbSet<Lidos> Lido { get; set; }
    public DbSet<Ler> Lerei { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "server=192.168.1.111;database=db_livros;user=suporte;password=thaynara123;";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    
}