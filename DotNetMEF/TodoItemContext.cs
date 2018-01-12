namespace DotNetMEF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class TodoItemsContext : DbContext
    {
        public TodoItemsContext()
            : base("name=TodoItemModel")
        {
        }

        public virtual DbSet<T_Category> T_Category { get; set; }
        public virtual DbSet<T_TodoItems> T_TodoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Category>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<T_Category>()
                .HasMany(e => e.T_TodoItems)
                .WithOptional(e => e.T_Category)
                .HasForeignKey(e => e.Category);

            modelBuilder.Entity<T_TodoItems>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
