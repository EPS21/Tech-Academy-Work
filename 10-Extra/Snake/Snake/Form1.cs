using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
        Random random = new Random();
               
        public Form1()
        {
            InitializeComponent();

            // Set settings to default
            new Settings();

            // Set game speed and start timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            // Start the game
            StartGame();
        }        

        private void StartGame()
        {
            lblGameOver.Visible = false;

            // Set settings to default
            new Settings();

            // Create new player object
            snake.Clear();
            Circle head = new Circle();

            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;
            //Random random1 = new Random();

            head.X = random.Next(0, maxXPos);
            head.Y = random.Next(0, maxYPos / 2);
            snake.Add(head);

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();
        }        

        // Place random food 
        private void GenerateFood()
        {
            int maxXPos = pbCanvas.Size.Width / Settings.Width;
            int maxYPos = pbCanvas.Size.Height / Settings.Height;            

            //Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxXPos);
            food.Y = random.Next(0, maxYPos);
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            // Check for gameover
            if(Settings.GameOver == true)
            {
                // Check if Enter is pressed
                if(Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                {
                    //MessageBox.Show("D key pressed");
                    Settings.direction = Direction.Right;
                }
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }

            // to refresh the screen
            pbCanvas.Invalidate();
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if(Settings.GameOver == false)
            {
                // Set color of snake
                Brush snakeColor;

                // Draw snake
                for (int i = 0; i < snake.Count; i++)
                {
                    if (i == 0)
                        snakeColor = Brushes.DarkGreen; //Draw head
                    else
                        snakeColor = Brushes.Green; //Draws rest of body

                    //Draw snake
                    canvas.FillEllipse(snakeColor,
                        new Rectangle(snake[i].X * Settings.Width,
                                      snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));

                    // Draw Food
                    canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                                      food.Y * Settings.Height,
                                      Settings.Width, Settings.Height));
                }

            }
            else
            {
                string gameOver = "Game over \nYour final score is: " + Settings.Score + "\nPress enter to try again";
                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                // Move head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Right:
                            snake[i].X++;
                            break;
                        default:
                            break;
                    }

                    // Get maximum X and Y Pos
                    int maxXPos = pbCanvas.Size.Width / Settings.Width;
                    int maxYPos = pbCanvas.Size.Height / Settings.Height;

                    // Detect collision with game borders
                    if (snake[i].X < 0 || snake[i].Y < 0
                        || snake[i].X >= maxXPos || snake[i].Y >= maxYPos)
                    {
                        Die();
                    }

                    // Detect collision with body 
                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X &&
                            snake[i].Y == snake[j].Y)
                        {
                            Die();
                        }
                    }

                    // Detect collision with food piece
                    if (snake[0].X == food.X && snake[0].Y == food.Y)
                    {
                        Eat();
                    }
                }
                else
                {
                    // Move body
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        private void Die()
        {
            Settings.GameOver = true;
        }

        private void Eat()
        {
            // Add circle to body
            Circle food = new Circle();
            food.X = snake[snake.Count - 1].X;
            food.Y = snake[snake.Count - 1].Y;

            snake.Add(food);

            // Update score
            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            // make another piece of food
            GenerateFood();
        }
        
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}
