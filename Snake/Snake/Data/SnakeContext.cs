using Microsoft.EntityFrameworkCore;
using Snake.Data.Models.Base;
using System.Linq;

namespace Snake.Data
{
    public class SnakeContext : DbContext
    {
        public SnakeContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Loading the types which implement IEntity and add them to the context
            foreach (var type in typeof(IEntity).Assembly.GetExportedTypes()
                                            .Where(p => typeof(IEntity).IsAssignableFrom(p)))
                if (!type.IsAbstract && !type.IsInterface && type.IsClass)
                    modelBuilder.Entity(type);

            var relations = modelBuilder.Model.GetEntityTypes().SelectMany(c => c.GetForeignKeys());
            foreach (var rel in relations)
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
