using BetterSnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterSnakeGame.Services;

public delegate void GameDelegate(string text);

public class GameService
{
    private event GameDelegate _gameEvent;

    private readonly int _height = 0;

    private readonly int _width = 0;

    private Directions _currentDirection;

    private readonly List<Point> _snakePositions = new();

    private Point _foodPos = new Point();

    public GameService(int height, int width, GameDelegate gameDelegate)
    {
        _height = height;
        _width = width;

        _gameEvent = gameDelegate;
    }

    public void StartGame()
    {
        _snakePositions.Clear();

        _snakePositions.Add(new Point { X = (_width / 2), Y = (_height / 2) });
    }

    public List<Point> GetSnakePositions()
    {
        return _snakePositions;
    }

    public Point GetFoodPosition()
    {
        return _foodPos;
    }

    public void AddFood()
    {
        var rand = new Random();
        int randX = 0;
        int randY = 0;
        do
        {
            randX = rand.Next(1, _width - 1);
            randY = rand.Next(1, _height - 1);
        } while (_snakePositions.Any(x => x.X == randX && x.Y == randY));

        _foodPos = new Point { X = randX, Y = randY };
    }

    public void ChangeDiretion(Directions direction)
    {
        _currentDirection = direction;
    }

    public void Move()
    {
        var head = _snakePositions.First();

        int oldX = head.X;
        int oldY = head.Y;

        switch (_currentDirection)
        {
            case Directions.Up:
                head.Y++;
                break;

            case Directions.Down:
                head.Y--;
                break;

            case Directions.Right:
                head.X++;
                break;

            case Directions.Left:
                head.X--;
                break;

            default:
                break;
        }

        _snakePositions[0] = head;

        for (int i = 1; i < _snakePositions.Count; i++)
        {
            int tempX = _snakePositions[i].X;
            int tempY = _snakePositions[i].Y;

            _snakePositions[i].X = oldX;
            _snakePositions[i].Y = oldY;

            oldX = tempX;
            oldY = tempY;
        }

        if (!IsGameOver())
        {
            CheckFoodConsumtion();
        }
    }

    public bool IsGameOver()
    {
        var groups = _snakePositions.GroupBy(x => new { x.X, x.Y });

        var head = _snakePositions.First();

        if (groups.Any(x => x.Count() > 1))
        {
            _gameEvent.Invoke("Game over!");
            return true;
        }
        else if (head.X < 0 || head.X > _width || head.Y < 0 || head.Y > _height)
        {
            _gameEvent.Invoke("Game over!");
            return true;
        }
        return false;
    }

    private void CheckFoodConsumtion()
    {
        var head = _snakePositions.First();

        if (head.X == _foodPos.X && head.Y == _foodPos.Y)
        {
            AddTail();
            AddFood();
        }
    }

    private void AddTail()
    {
        var end = _snakePositions.Last();

        switch (_currentDirection)
        {
            case Directions.Up:
                _snakePositions.Add(new Point { X = end.X, Y = end.Y + 1 });
                break;

            case Directions.Down:
                _snakePositions.Add(new Point { X = end.X, Y = end.Y - 1 });
                break;

            case Directions.Right:
                _snakePositions.Add(new Point { X = end.X + 1, Y = end.Y });
                break;

            case Directions.Left:
                _snakePositions.Add(new Point { X = end.X - 1, Y = end.Y });
                break;

            default:
                break;
        }
    }
}