using BetterSnakeGame.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BetterSnakeGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Container _container;

    private readonly GameService _gameService;

    public MainWindow()
    {
        _container = Bootstrapper.Bootstrap();

        InitializeComponent();
        _gameService = new GameService((int)snakeCanvas.Height, (int)snakeCanvas.Width, EndGame);

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

        _gameService.Move();
        DrawField();
    }

    // TODO: Draw snake

    private void DrawField()
    {
        snakeCanvas.Children.Clear();
        foreach (var item in _gameService.GetSnakePositions())
        {
            var temp = new Ellipse
            {
                Width = 5,
                Height = 5,
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            snakeCanvas.Children.Add(temp);

            temp.SetValue(Canvas.LeftProperty, (double)item.X);
            temp.SetValue(Canvas.BottomProperty, (double)item.Y);
        }

        var foodPoint = new Ellipse { Width = 5, Height = 5, Stroke = Brushes.Black, StrokeThickness = 2 };

        snakeCanvas.Children.Add(foodPoint);

        var tempFood = _gameService.GetFoodPosition();

        foodPoint.SetValue(Canvas.LeftProperty, (double)tempFood.X);
        foodPoint.SetValue(Canvas.BottomProperty, (double)tempFood.Y);
    }

    private void EndGame(string text)
    {
        MessageBox.Show(text);
    }
}