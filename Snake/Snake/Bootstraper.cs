using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Snake.Data;
using Snake.Services;

namespace Snake
{
    public static class Bootstraper
    {
        public static Container Bootstrap()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.RegisterDatabase();

            container.Register<TickService>(Lifestyle.Transient);

            return container;
        }

        public static void RegisterDatabase(this Container container)
        {
            var builder = new DbContextOptionsBuilder();

            // TODO: Change to SqlDatabase
            builder.UseInMemoryDatabase(nameof(SnakeContext));
            builder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));

            container.RegisterInstance(builder.Options);
            container.Register<SnakeContext>(Lifestyle.Scoped);
        }
    }
}
