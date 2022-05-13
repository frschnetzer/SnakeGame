using Microsoft.EntityFrameworkCore;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models;

public partial class SnakeGameContext : DbContext
{
    public DbSet<SnakeGameDb> GameDb { get; set; }

    public SnakeGameContext()
    {
    }

    public SnakeGameContext(DbContextOptions<SnakeGameContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SnakeGameDb; Integrated Security = True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SnakeGameDb>(entity =>
        {
            entity.ToTable("SnakeGameDb");

            entity.Property(e => e.LoginName)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.RegisterDate)
                .IsRequired()
                .HasColumnType("datetime");

            entity.Property(e => e.Highscore)
               .IsRequired()
               .HasMaxLength(150);
        });

        //OnModelCreatingPartial(modelBuilder);
    }

    //private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}