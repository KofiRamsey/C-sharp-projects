using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeGame
{
    public partial class MainWindow : Window
    {
        private const int CellSize = 20;
        private const int GridWidth = 40;
        private const int GridHeight = 30;

        private readonly DispatcherTimer gameTimer = new DispatcherTimer();

        private Snake snake;
        private Direction currentDirection;
        private bool isGameInProgress;

        private Food food;

        public MainWindow()
        {
            InitializeComponent();
            gameTimer.Tick += GameTimer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGameArea();
            StartNewGame();
        }

        private void DrawGameArea()
        {
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    var cell = new Rectangle
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Fill = Brushes.Black
                    };

                    Canvas.SetLeft(cell, x * CellSize);
                    Canvas.SetTop(cell, y * CellSize);

                    gameCanvas.Children.Add(cell);
                }
            }
        }

        private void StartNewGame()
        {
            snake = new Snake(new Point(GridWidth / 2, GridHeight / 2));
            currentDirection = Direction.Right;
            isGameInProgress = true;

            GenerateNewFood();

            gameTimer.Interval = TimeSpan.FromMilliseconds(100);
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            snake.Move(currentDirection);

            if (snake.IsOutOfBounds(GridWidth, GridHeight) || snake.IsCollidingWithItself())
            {
                EndGame();
                return;
            }

            if (snake.HeadPosition == food.Position)
            {
                snake.Grow();
                GenerateNewFood();
            }

            DrawSnake();
        }

        private void EndGame()
        {
            isGameInProgress = false;
            gameTimer.Stop();
            MessageBox.Show("Game Over! Your score: " + snake.Length);
        }

        private void DrawSnake()
        {
            gameCanvas.Children.Clear();

            foreach (var segment in snake.Segments)
            {
                var cell = new Rectangle
                {
                    Width = CellSize,
                    Height = CellSize,
                    Fill = Brushes.Green
                };

                Canvas.SetLeft(cell, segment.X * CellSize);
                Canvas.SetTop(cell, segment.Y * CellSize);

                gameCanvas.Children.Add(cell);
            }

            DrawFood();
        }

        private void DrawFood()
        {
            var foodCell = new Rectangle
            {
                Width = CellSize,
                Height = CellSize,
                Fill = Brushes.Red
            };

            Canvas.SetLeft(foodCell, food.Position.X * CellSize);
            Canvas.SetTop(foodCell, food.Position.Y * CellSize);

            gameCanvas.Children.Add(foodCell);
        }

        private void GenerateNewFood()
        {
            var random = new Random();
            Point position;

            do
            {
                int x = random.Next(0, GridWidth);
                int y = random.Next(0, GridHeight);
                position = new Point(x, y);
            } while (snake.Segments.Contains(position));

            food = new Food(position);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameInProgress)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        if (currentDirection != Direction.Right)
                            currentDirection = Direction.Left;
                        break;
                    case Key.Right:
                        if (currentDirection != Direction.Left)
                            currentDirection = Direction.Right;
                        break;
                    case Key.Up:
                        if (currentDirection != Direction.Down)
                            currentDirection = Direction.Up;
                        break;
                    case Key.Down:
                        if (currentDirection != Direction.Up)
                            currentDirection = Direction.Down;
                        break;
                }
            }
            else
            {
                if (e.Key == Key.Space)
                    StartNewGame();
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class Snake
    {
        private List<Point> segments;

        public Snake(Point startPosition)
        {
            segments = new List<Point> { startPosition };
        }

        public IReadOnlyList<Point> Segments => segments;

        public Point HeadPosition => segments.First();

        public int Length => segments.Count;

        public void Move(Direction direction)
        {
            Point newHeadPosition = HeadPosition;

            switch (direction)
            {
                case Direction.Up:
                    newHeadPosition.Y--;
                    break;
                case Direction.Down:
                    newHeadPosition.Y++;
                    break;
                case Direction.Left:
                    newHeadPosition.X--;
                    break;
                case Direction.Right:
                    newHeadPosition.X++;
                    break;
            }

            segments.Insert(0, newHeadPosition);
            segments.RemoveAt(segments.Count - 1);
        }

        public bool IsOutOfBounds(int width, int height)
        {
            Point head = HeadPosition;
            return head.X < 0 || head.X >= width || head.Y < 0 || head.Y >= height;
        }

        public bool IsCollidingWithItself()
        {
            Point head = HeadPosition;
            return segments.Count(s => s == head) > 1;
        }

        public void Grow()
        {
            segments.Add(segments.Last());
        }
    }

    public class Food
    {
        public Food(Point position)
        {
            Position = position;
        }

        public Point Position { get; }
    }
}