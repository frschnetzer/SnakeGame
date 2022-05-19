using SimpleInjector;
using Snake.Data;
using Snake.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int _size;

        private readonly Container _container;
        private readonly Scope _scope;

        private readonly GameService _gameService;
        private readonly LogOnService _logOnService;

        public MainWindow()
        {
            _container = Bootstraper.Bootstrap();
            _scope = SimpleInjector.Lifestyles.AsyncScopedLifestyle.BeginScope(_container);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            _logOnService = LogOnService.GetInstance(_scope.Container.GetInstance<SnakeContext>());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            _size = 50;

            InitializeComponent();

            if (snakeCanvas.Height % _size != 0 || snakeCanvas.Width % _size != 0)
                throw new System.Exception("Size is not fitting!");

            var tickService = new TickService();

            _gameService = new GameService((int)snakeCanvas.Height, (int)snakeCanvas.Width, _size, EndGame, tickService);

            tickService.AddDelegate(DrawField);

            _gameService.StartGame();
            DrawField();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.W || e.Key == Key.Up)
            {
                _gameService.ChangeDircetion(Models.Dirctions.Up);
            }
            else if(e.Key == Key.S || e.Key == Key.Down)
            {
                _gameService.ChangeDircetion(Models.Dirctions.Down);
            }
            else if(e.Key == Key.A || e.Key == Key.Right)
            {
                _gameService.ChangeDircetion(Models.Dirctions.Right);
            }
            else if(e.Key == Key.A || e.Key == Key.Left)
            {
                _gameService.ChangeDircetion(Models.Dirctions.Left);
            }
        }

        private void DrawField()
        {
            Dispatcher.Invoke(() =>
            {
                snakeCanvas.Children.Clear();

                foreach (var item in _gameService.GetSnakePositions().ToList())
                {
                    var temp = new Ellipse { Width = _size, Height = _size, Stroke = Brushes.Red, StrokeThickness = 2 };

                    snakeCanvas.Children.Add(temp);

                    temp.SetValue(Canvas.LeftProperty, (double)item.X - (_size / 2));
                    temp.SetValue(Canvas.BottomProperty, (double)item.Y - (_size / 2));
                }

                var tempFood = _gameService.GetFoodPosition();
                if (!(tempFood.X == 0 && tempFood.Y == 0))
                {
                    var foodPoint = new Ellipse { Width = _size, Height = _size, Stroke = Brushes.Black, StrokeThickness = 2 };

                    snakeCanvas.Children.Add(foodPoint);

                    foodPoint.SetValue(Canvas.LeftProperty, (double)tempFood.X - (_size / 2));
                    foodPoint.SetValue(Canvas.BottomProperty, (double)tempFood.Y - (_size / 2));
                }
            });
        }

        private void EndGame(string text)
        {
            DrawField();

            MessageBox.Show(text);

            _gameService.ResetGame();
        }

        private void logOnButton_Click(object sender, RoutedEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var view = new LogOnWindow(_scope.Container.GetInstance<SnakeContext>());
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            view.ShowDialog();
        }
    }
}
