using SnakeGame.Models;

namespace SnakeGame
{
    public partial class FormSnakeGame : Form
    {
        private List<Circle> Snake = new();

        private Circle _food = new();

        public FormSnakeGame()
        {
            InitializeComponent();

            this.Hide();
            RegistrationForm registrationForm = new();
            registrationForm.ShowDialog();
        }

        private void FormSnakeGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void FormSnakeGame_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (Settings.GameOver == false)
            {
                Brush snakeColour;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = Brushes.Black;
                    }
                    else
                    {
                        snakeColour = Brushes.Green;
                    }

                    canvas.FillEllipse(snakeColour,
                                        new Rectangle(
                                            Snake[i].X * Settings.Width,
                                            Snake[i].Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                            ));

                    canvas.FillEllipse(Brushes.Red,
                                        new Rectangle(
                                            _food.X * Settings.Width,
                                            _food.Y * Settings.Height,
                                            Settings.Width, Settings.Height
                                            ));
                }
            }
            else
            {
                string gameOver = "Game Over \n" + "Final Score is " + Settings.Score + "\nPress enter to Restart \n";
                labelEndText.Text = gameOver;
                labelEndText.Visible = true;
            }
        }

        private void StartGame()
        {
            labelEndText.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            labelPoints.Text = Settings.Score.ToString();

            GenerateFood();
        }

        private void MovePlayer()
        {
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Right:
                            Snake[i].X++;
                            break;

                        case Directions.Left:
                            Snake[i].X--;
                            break;

                        case Directions.Up:
                            Snake[i].Y--;
                            break;

                        case Directions.Down:
                            Snake[i].Y++;
                            break;
                    }

                    int maxXpos = pictureBoxBoard.Size.Width / Settings.Width;
                    int maxYpos = pictureBoxBoard.Size.Height / Settings.Height;

                    if (
                        Snake[i].X < 0 || Snake[i].Y < 0 ||
                        Snake[i].X > maxXpos || Snake[i].Y > maxYpos
                        )
                    {
                        Die();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            Die();
                        }
                    }

                    if (Snake[0].X == _food.X && Snake[0].Y == _food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void GenerateFood()
        {
            int maxXpos = pictureBoxBoard.Size.Width / Settings.Width;

            int maxYpos = pictureBoxBoard.Size.Height / Settings.Height;

            Random rnd = new Random();
            _food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };
        }

        private void Eat()
        {
            Circle body = new()
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);
            Settings.Score += Settings.Points;
            labelPoints.Text = Settings.Score.ToString();
            GenerateFood();
        }

        private void Die()
        {
            Settings.GameOver = true;

            // TODO: Save Highscore to db
            // Implement class CurrentUser
        }

        private void UpdateSreen(object sender, EventArgs e)
        {
            if (Settings.GameOver == true)
            {
                if (Input.KeyPress(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPress(Keys.Right) && Settings.direction != Directions.Left)
                {
                    Settings.direction = Directions.Right;
                }
                else if (Input.KeyPress(Keys.Left) && Settings.direction != Directions.Right)
                {
                    Settings.direction = Directions.Left;
                }
                else if (Input.KeyPress(Keys.Up) && Settings.direction != Directions.Down)
                {
                    Settings.direction = Directions.Up;
                }
                else if (Input.KeyPress(Keys.Down) && Settings.direction != Directions.Up)
                {
                    Settings.direction = Directions.Down;
                }

                MovePlayer();
            }

            pictureBoxBoard.Invalidate();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Focus();
            new Settings();

            timerSnakeGame.Interval = 1000 / Settings.Speed;
            timerSnakeGame.Tick += UpdateSreen;
            timerSnakeGame.Start();

            StartGame();
        }
    }
}