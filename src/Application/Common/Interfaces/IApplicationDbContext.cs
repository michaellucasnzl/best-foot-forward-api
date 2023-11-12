using BestFootForwardApi.Domain.Entities;

namespace BestFootForwardApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Manufacturer> Manufacturers { get; }
    DbSet<Shop> Shops { get; }
    DbSet<Supplier> Suppliers { get; }
    DbSet<SupplierShoe> SupplierShoes { get; }
    DbSet<ShopShoe> ShopShoes { get; }
    DbSet<Shoe> Shoes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
