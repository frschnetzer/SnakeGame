using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Snake.Services
{
    public delegate void GameDelegate(string text);

    public class GameService
    {
        private event GameDelegate _gameEvent;

        private readonly int _heigth = 0;
        private readonly int _width = 0;

        private readonly int _size = 0;

        private readonly TickService _tickService;
        private CancellationTokenSource _tickServiceCancelationTokenSource;

        private Dirctions _currentDirection;

        private readonly List<Point> _snakePositions = new List<Point>();

        private Point _foodPos = new Point();

        public GameService(int heigth, int width, int size, GameDelegate gameDelegate, TickService tickService)
        {
            _tickServiceCancelationTokenSource = new CancellationTokenSource();

            _heigth = heigth;
            _width = width;
            _size = size;

            _gameEvent = gameDelegate;

            _tickService = tickService;
            _tickService.AddDelegate(Move);
        }

        public void StartGame()
        {
            _currentDirection = Dirctions.Down;

            _snakePositions.Clear();
            _snakePositions.Add(new Point { X = (_width / 2), Y = (_heigth / 2) });
            AddFoot();

            _tickService.StartTickTask(_tickServiceCancelationTokenSource.Token);
        }

        public List<Point> GetSnakePositions()
        {
            return _snakePositions;
        }

        public Point GetFoodPosition()
        {
            return _foodPos;
        }

        public void AddFoot()
        {
            var rand = new Random();

            int randX = 0;
            int randY = 0;

            do
            {
                randX = rand.Next((_size / 2), (_width - (_size / 2)));
                randY = rand.Next((_size / 2), (_heigth - (_size / 2)));
            } while (_snakePositions.Any(x => x.X + _size >= randX && x.X - _size <= randX
                && x.Y + _size >= randY && x.Y - _size <= randY) 
                && randX % _size == 0 && randY % _size == 0);

            _foodPos = new Point { X = randX, Y = randY };
        }

        public void ChangeDircetion(Dirctions dirction)
        {
            _currentDirection = dirction;
        }

        public void Move()
        {
            var head = _snakePositions.First();

            int oldX = head.X;
            int oldY = head.Y;

            switch (_currentDirection)
            {
                case Dirctions.Up:
                    head.Y += (_size / 2);
                    break;
                case Dirctions.Down:
                    head.Y -= (_size / 2);
                    break;
                case Dirctions.Right:
                    head.X += (_size / 2);
                    break;
                case Dirctions.Left:
                    head.X -= (_size / 2);
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
                _gameEvent("Game over!");
                return true;
            }
            else if (head.X - (_size / 2) < 0 || head.X + (_size / 2) > _width || head.Y - (_size / 2) < 0 || head.Y + (_size / 2) > _heigth)
            {
                _gameEvent("Game over!");
                return true;
            }

            return false;
        }

        public void ResetGame()
        {
            _snakePositions.Clear();
            _foodPos = new Point();

            _tickServiceCancelationTokenSource.Cancel();
        }

        private void CheckFoodConsumtion()
        {
            var head = _snakePositions.First();

            if ((head.X + (_size / 2) >= _foodPos.X && (head.X - (_size / 2)) <= _foodPos.X
                && (head.Y + (_size / 2)) >= _foodPos.Y && (head.Y - (_size / 2)) <= _foodPos.Y))
            {
                AddTail();
                AddFoot();

                _tickService.ReduceTickTime();
            }
        }

        private void AddTail()
        {
            var end = _snakePositions.Last();

            switch (_currentDirection)
            {
                case Dirctions.Up:
                    _snakePositions.Add(new Point { X = end.X, Y = end.Y + (_size / 2) });
                    break;
                case Dirctions.Down:
                    _snakePositions.Add(new Point { X = end.X, Y = end.Y - (_size / 2) });
                    break;
                case Dirctions.Right:
                    _snakePositions.Add(new Point { X = end.X + (_size / 2), Y = end.Y });
                    break;
                case Dirctions.Left:
                    _snakePositions.Add(new Point { X = end.X - (_size / 2), Y = end.Y });
                    break;
                default:
                    break;
            }
        }
    }
}
