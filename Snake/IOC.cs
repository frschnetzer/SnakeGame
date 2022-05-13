using Autofac;
using Autofac.Core;
using Snake.Interfaces;

namespace SnakeGame;

internal static class IOC
{
    private static ILifetimeScope? _rootScope;

    public static void Start()
    {
        if (_rootScope is not null)
            throw new Exception("Container already started");

        _rootScope = new ContainerBuilder()
            .Setup()
            .Build();
    }

    public static T Resolve<T>(params Parameter[] parameter) where T : notnull
    {
        _ = _rootScope ?? throw new Exception("Container not started");

        return _rootScope.Resolve<T>(parameter);
    }

    public static void Stop()
    {
        _rootScope?.Dispose();
    }

    private static ContainerBuilder Setup(this ContainerBuilder builder)
    {
        builder.RegisterType<Circle>().As<IInput>();
        builder.RegisterType<Settings>().As<IInput>();
        builder.RegisterType<Input>().As<IInput>();

        return builder;
    }
}