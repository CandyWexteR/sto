using Core.Models.Bugs;
using Core.Models.Chat;
using Core.Models.Inventory;
using Core.Models.Orders;
using Core.Models.Tickets;
using Core.Models.UserRoles;
using Core.Models.Users;
using Core.Models.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> ops) : base(ops)
    {
        
    }
    
    public DbSet<Jsonb> Jsonbs { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<InventoryItemAcceptability> InventoryItemAcceptabilities { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ChatMessage> Messages { get; set; }
    public DbSet<Bug> Bugs { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<UsedInventoryItem> UsedInventoryItems { get; set; }
}   