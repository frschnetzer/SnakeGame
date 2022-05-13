using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class StartSnakeGame
    {
        //private readonly Label _labelEndText;

        //private readonly Label _labelPoints;

        //private readonly PictureBox _pictureBoxBoard;

        //public StartSnakeGame()
        //{
        //}

        //public StartSnakeGame(Label labelEndText, Label labelPoints, PictureBox pictureBox)
        //{
        //    _labelEndText = labelEndText;
        //    _labelPoints = labelPoints;
        //    _pictureBoxBoard = pictureBox;

        //    // TODO:
        //    new Settings();

        //    StartGame();
        //}

        //public void StartGame()
        //{
        //    _labelEndText.Visible = false; // set label 3 to invisible
        //    new Settings(); // create a new instance of settings
        //    Snake.Clear(); // clear all snake parts
        //    Circle head = new Circle { X = 10, Y = 5 }; // create a new head for the snake
        //    Snake.Add(head); // add the gead to the snake array

        //    _labelPoints.Text = Settings.Score.ToString(); // show the score to the label 2

        //    GenerateFood(); // run the generate food function
        //}

        //public void MovePlayer()
        //{
        //    // the main loop for the snake head and parts
        //    for (int i = Snake.Count - 1; i >= 0; i--)
        //    {
        //        // if the snake head is active
        //        if (i == 0)
        //        {
        //            // move rest of the body according to which way the head is moving
        //            switch (Settings.direction)
        //            {
        //                case Directions.Right:
        //                    Snake[i].X++;
        //                    break;

        //                case Directions.Left:
        //                    Snake[i].X--;
        //                    break;

        //                case Directions.Up:
        //                    Snake[i].Y--;
        //                    break;

        //                case Directions.Down:
        //                    Snake[i].Y++;
        //                    break;
        //            }

        //            // restrict the snake from leaving the canvas
        //            int maxXpos = _pictureBoxBoard.Size.Width / Settings.Width;
        //            int maxYpos = _pictureBoxBoard.Size.Height / Settings.Height;

        //            if (
        //                Snake[i].X < 0 || Snake[i].Y < 0 ||
        //                Snake[i].X > maxXpos || Snake[i].Y > maxYpos
        //                )
        //            {
        //                // end the game is snake either reaches edge of the canvas
        //                Die();
        //            }

        //            // detect collision with the body
        //            // this loop will check if the snake had an collision with other body parts
        //            for (int j = 1; j < Snake.Count; j++)
        //            {
        //                if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
        //                {
        //                    // if so we run the die function
        //                    Die();
        //                }
        //            }

        //            // detect collision between snake head and food
        //            if (Snake[0].X == food.X && Snake[0].Y == food.Y)
        //            {
        //                //if so we run the eat function
        //                Eat();
        //            }
        //        }
        //        else
        //        {
        //            // if there are no collisions then we continue moving the snake and its parts
        //            Snake[i].X = Snake[i - 1].X;
        //            Snake[i].Y = Snake[i - 1].Y;
        //        }
        //    }
        //}

        //private void GenerateFood()
        //{
        //    int maxXpos = _pictureBoxBoard.Size.Width / Settings.Width;

        //    // create a maximum X position int with half the size of the play area
        //    int maxYpos = _pictureBoxBoard.Size.Height / Settings.Height;

        //    // create a maximum Y position int with half the size of the play area
        //    Random rnd = new Random(); // create a new random class
        //    food = new Circle { X = rnd.Next(0, maxXpos), Y = rnd.Next(0, maxYpos) };

        //    // create a new food with a random x and y
        //}

        //private void Eat()
        //{
        //    // add a part to body
        //    Circle body = new Circle
        //    {
        //        X = Snake[Snake.Count - 1].X,
        //        Y = Snake[Snake.Count - 1].Y
        //    };

        //    Snake.Add(body); // add the part to the snakes array
        //    Settings.Score += Settings.Points; // increase the score for the game
        //    _labelPoints.Text = Settings.Score.ToString(); // show the score on the label 2
        //    GenerateFood(); // run the generate food function
        //}

        //private void Die()
        //{
        //    // change the game over Boolean to true
        //    Settings.GameOver = true;
        //}
    }
}