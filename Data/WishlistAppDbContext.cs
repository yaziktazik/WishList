// Data/WishlistAppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class WishlistAppDbContext : DbContext
{
    public WishlistAppDbContext(DbContextOptions<WishlistAppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<WishListItem> WishListItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ItemTag> ItemTags { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<Role>()
            .HasOne(r => r.Permission)
            .WithMany(p => p.Roles)
            .HasForeignKey(r => r.PermissionId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.WishLists)
            .WithOne(w => w.User)
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<WishList>()
            .HasMany(w => w.WishListItems)
            .WithOne(wi => wi.WishList)
            .HasForeignKey(wi => wi.WishListId);

        modelBuilder.Entity<Item>()
            .HasMany(i => i.WishListItems)
            .WithOne(wi => wi.Item)
            .HasForeignKey(wi => wi.ItemId);

        modelBuilder.Entity<Item>()
            .HasMany(i => i.ItemTags)
            .WithOne(it => it.Item)
            .HasForeignKey(it => it.ItemId);

        modelBuilder.Entity<WishListItem>()
            .HasMany(wi => wi.Comments)
            .WithOne(c => c.WishListItem)
            .HasForeignKey(c => c.WishListItemId);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Items)
            .WithOne(i => i.Category)
            .HasForeignKey(i => i.CategoryId);

        modelBuilder.Entity<ItemTag>()
            .HasOne(it => it.Tag)
            .WithMany(t => t.ItemTags)
            .HasForeignKey(it => it.TagId);
    }
}