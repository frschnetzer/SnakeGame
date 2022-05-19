using System.Threading;
using System.Threading.Tasks;

namespace BetterSnakeGame.Services;

public delegate void TickDelegate();

public class TickService
{
    private event TickDelegate _tickEvent = () => { };

    private int _tickTime = 300;

    public void AddDelegate(TickDelegate funct)
    {
        _tickEvent += funct;
    }

    public void ReduceTickTime()
    {
        if (_tickTime > 250)
        {
            _tickTime -= 100;
        }
    }

    public void StartTickTask(CancellationToken cancellationToken)
    {
        Task.Run(async () =>
        {
            while (true)
            {
                _tickEvent();
                await Task.Delay(_tickTime);
            }
        }, cancellationToken);
    }
}