//DataService.cs
using Microsoft.EntityFrameworkCore;
namespace jarmu;
public class DataService: DbContext {
    public DataService(DbContextOptions<DataService> options)
        :base(options) {}
 
    public DbSet<Jarmu> Jarmuvek {get; set;} = null!;
}