using System.Reflection;
using BestFootForwardApi.Application.Common.Interfaces;
using BestFootForwardApi.Domain.Entities;
using BestFootForwardApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestFootForwardApi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Manufacturer> Manufacturers  => Set<Manufacturer>();
    public DbSet<Shop> Shops  => Set<Shop>();
    public DbSet<Supplier> Suppliers  => Set<Supplier>();
    public DbSet<SupplierShoe> SupplierShoes  => Set<SupplierShoe>();
    public DbSet<ShopShoe> ShopShoes  => Set<ShopShoe>();
    public DbSet<Shoe> Shoes  => Set<Shoe>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
