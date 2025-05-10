using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeClone
{
    public partial class MainForm : Form
    {
        private List<Point> snake = new List<Point>();
        private Point food;
        private int gridSize = 20;
        private int cellSize = 20;
        private string direction = "Right";
        private bool gameOver = false;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(gridSize * cellSize + 16, gridSize * cellSize + 39);
            this.Text = "Snake Game";

            StartGame();
            timer1.Tick += GameLoop;
            timer1.Start();
        }

        private void StartGame()
        {
            snake.Clear();
            snake.Add(new Point(5, 5));
            direction = "Right";
            gameOver = false;
            GenerateFood();
        }

        private void GenerateFood()
        {
            Random rand = new Random();
            do
            {
                food = new Point(rand.Next(0, gridSize), rand.Next(0, gridSize));
            } while (snake.Contains(food));
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (gameOver)
            {
                timer1.Stop();
                MessageBox.Show("Game Over! Press Enter to Restart.");
                if (MessageBox.Show("Restart?", "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StartGame();
                    timer1.Start();
                }
                else
                {
                    Application.Exit();
                }
                return;
            }

            MoveSnake();
            CheckCollision();
            Invalidate(); // Redraw the game board
        }

        private void MoveSnake()
        {
            Point head = snake[0];
            Point newHead = head;

            switch (direction)
            {
                case "Right":
                    newHead = new Point(head.X + 1, head.Y);
                    break;
                case "Left":
                    newHead = new Point(head.X - 1, head.Y);
                    break;
                case "Up":
                    newHead = new Point(head.X, head.Y - 1);
                    break;
                case "Down":
                    newHead = new Point(head.X, head.Y + 1);
                    break;
            }

            if (newHead == food)
            {
                snake.Insert(0, newHead); // Eat food and grow
                GenerateFood();
            }
            else
            {
                snake.Insert(0, newHead);
                snake.RemoveAt(snake.Count - 1); // Move without growing
            }
        }

        private void CheckCollision()
        {
            Point head = snake[0];

            // Check collision with walls
            if (head.X < 0 || head.X >= gridSize || head.Y < 0 || head.Y >= gridSize)
            {
                gameOver = true;
            }

            // Check collision with itself
            if (snake.GetRange(1, snake.Count - 1).Contains(head))
            {
                gameOver = true;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Up && direction != "Down") direction = "Up";
            if (e.KeyCode == Keys.Down && direction != "Up") direction = "Down";
            if (e.KeyCode == Keys.Left && direction != "Right") direction = "Left";
            if (e.KeyCode == Keys.Right && direction != "Left") direction = "Right";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw snake
            foreach (Point part in snake)
            {
                g.FillRectangle(Brushes.Green, part.X * cellSize, part.Y * cellSize, cellSize, cellSize);
            }

            // Draw food
            g.FillRectangle(Brushes.Red, food.X * cellSize, food.Y * cellSize, cellSize, cellSize);

            // Draw grid
            for (int i = 0; i <= gridSize; i++)
            {
                g.DrawLine(Pens.Gray, i * cellSize, 0, i * cellSize, gridSize * cellSize);
                g.DrawLine(Pens.Gray, 0, i * cellSize, gridSize * cellSize, i * cellSize);
            }
        }
    }
}
