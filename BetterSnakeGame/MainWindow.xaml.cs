using BetterSnakeGame.Services;
using SimpleInjector;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BetterSnakeGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly int _size;

    private readonly Container _container;

    private readonly GameService _gameService;

    public MainWindow()
    {
        _container = Bootstrapper.Bootstrap();

        _size = 25;

        InitializeComponent();

        var tickServie = new TickService();

        _gameService = new GameService((int)snakeCanvas.Height, (int)snakeCanvas.Width, _size, EndGame, tickServie);
        tickServie.AddDelegate(DrawField);
        _gameService.StartGame();
        DrawField();
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.ToString() == "W" || e.Key.ToString() == "Up")
        {
            _gameService.ChangeDiretion(Models.Directions.Up);
        }
        else if (e.Key.ToString() == "S" || e.Key.ToString() == "Down")
        {
            _gameService.ChangeDiretion(Models.Directions.Down);
        }
        else if (e.Key.ToString() == "D" || e.Key.ToString() == "Right")
        {
            _gameService.ChangeDiretion(Models.Directions.Right);
        }
        else if (e.Key.ToString() == "A" || e.Key.ToString() == "Left")
        {
            _gameService.ChangeDiretion(Models.Directions.Left);
        }
    }

    // TODO: Draw snake

    private void DrawField()
    {
        Dispatcher.Invoke(() =>
        {
            snakeCanvas.Children.Clear();
            foreach (var item in _gameService.GetSnakePositions().ToList())
            {
                var temp = new Ellipse
                {
                    Width = _size,
                    Height = _size,
                    Stroke = Brushes.Red,
                    StrokeThickness = 2
                };

                snakeCanvas.Children.Add(temp);

                temp.SetValue(Canvas.LeftProperty, (double)item.X - (_size / 2));
                temp.SetValue(Canvas.BottomProperty, (double)item.Y - (_size / 2));
            }

            var foodPoint = new Ellipse { Width = _size, Height = _size, Stroke = Brushes.Black, StrokeThickness = 2 };

            snakeCanvas.Children.Add(foodPoint);

            var tempFood = _gameService.GetFoodPosition();

            foodPoint.SetValue(Canvas.LeftProperty, (double)tempFood.X - (_size / 2));
            foodPoint.SetValue(Canvas.BottomProperty, (double)tempFood.Y - (_size / 2));
        });
    }

    private void EndGame(string text)
    {
        MessageBox.Show(text);
    }
}