namespace CarCRUD.Data;

public class AppDbContext: DbContext
{
	public AppDbContext(DbContextOptions options): base(options) { }


	public DbSet<Car> Cars { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Car>();
	}
}
