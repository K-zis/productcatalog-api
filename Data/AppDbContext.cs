using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Models;

namespace ProductCatalogApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}
