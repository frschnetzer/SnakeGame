using Snake.Interfaces;
using System.Collections;

namespace SnakeGame;

internal class Input : IInput
{
    private static Hashtable keyTable = new Hashtable();

    public Input()
    {
    }

    public bool KeyPress(Keys key)
    {
        if (keyTable[key] == null)
        {
            return false;
        }

        return (bool)keyTable[key];
    }

    public void ChangeState(Keys key, bool state)
    {
        keyTable[key] = state;
    }
}