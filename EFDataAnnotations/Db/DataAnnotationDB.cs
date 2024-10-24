using EFDataAnnotations.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFDataAnnotations.Db;

public class DataAnnotationDB : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public DataAnnotationDB(DbContextOptions<DataAnnotationDB> options) : base(options) { }
    
}