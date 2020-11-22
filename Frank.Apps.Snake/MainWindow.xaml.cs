using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Frank.Apps.Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CellIdentity[,] _cells;
        public Grid Grid { get; set; }
        private readonly Snake _snake;

        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            BoardWidth = 40;
            BoardHeight = 40;

            var generator = new BoardGenerator();
            _cells = generator.GenerateCells(BoardWidth, BoardHeight);
            Grid = generator.GenerateGrid(BoardWidth, BoardHeight);

            foreach (var cell in _cells)
            {
                Grid.Children.Add(cell.Label);
            }

            _cells[1, 1].IsFood = true;
            _cells[1, 1].Label.Background = new SolidColorBrush(Colors.DarkRed);

            _snake = new Snake();
            _snake.Position = new Vector2(BoardWidth / 2, BoardHeight / 2);


            var initialTail = new Vector2(_snake.Position.X - 2, _snake.Position.Y);
            var initialMidriff = new Vector2(_snake.Position.X - 1, _snake.Position.Y);
            var initialHead = new Vector2(_snake.Position.X, _snake.Position.Y);

            MakeSnake(initialTail);
            MakeSnake(initialMidriff);
            MakeSnake(initialHead);

            _snake.Body.Enqueue(initialTail);
            _snake.Body.Enqueue(initialMidriff);
            _snake.Body.Enqueue(initialHead);

            _snake.Speed = Speed.Comfortable;
            _snake.TargetPosition = new Vector2(1, 1);

            GameBoard.Content = Grid;
        }

        public void SetupBoard()
        {

        }

        /// <inheritdoc />
        protected override void OnKeyDown(KeyEventArgs e) => new Thread(Run).Start();

        private void Run()
        {
            while (_snake.IsAlive)
            {
                Dispatcher.BeginInvoke(new Action(() => Move(Direction.Right)));
                Thread.Sleep((int)_snake.Speed);
            }
        }

        bool CheckIfInBounds(Vector2 cell)
        {
            try
            {
                GetCell(cell);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void MakeSnake(Vector2 position)
        {
            GetCell(position).Label.Background = new SolidColorBrush(Colors.ForestGreen);
            GetCell(position).IsSnake = true;
            GetCell(position).IsFood = false;
        }

        private void ClearSnake(Vector2 position)
        {
            GetCell(position).Label.Background = new SolidColorBrush(Colors.Black);
            GetCell(position).IsSnake = false;
            GetCell(position).IsFood = false;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Step(_snake.Position + Vector2.UnitY);
                    break;
                case Direction.Down:
                    Step(_snake.Position - Vector2.UnitY);
                    break;
                case Direction.Left:
                    Step(_snake.Position - Vector2.UnitX);
                    break;
                case Direction.Right:
                    Step(_snake.Position + Vector2.UnitX);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        private void Step(Vector2 vector)
        {
            if (_snake.Body.Contains(vector) || !CheckIfInBounds(vector))
            {
                throw new Exception("You are eating yourself!");
            }

            _snake.Position = vector;
            _snake.Body.Enqueue(_snake.Position);
            MakeSnake(_snake.Position);
            if (_snake.Body.Count > _snake.Length)
            {
                var dequeued = _snake.Body.Dequeue();
                ClearSnake(dequeued);
            }
        }

        public CellIdentity GetRandomFreeCell() => GetCell(GetRandomFreePosition());

        public Vector2 GetRandomFreePosition()
        {
            while (true)
            {
                var random = new Random(new Random(947593274).Next());
                var output = new Vector2(random.Next(BoardWidth), random.Next(BoardHeight));

                if (!GetCell(output).IsFood && !GetCell(output).IsSnake)
                {
                    return output;
                }
            }
        }

        private void CheckSpeed()
        {
            switch (_snake.Speed)
            {
                case Speed.HolyShitFuck:
                    break;
                case Speed.RidiculouslyFast:
                    break;
                case Speed.SuperFast:
                    break;
                case Speed.Fast:
                    break;
                case Speed.Comfortable:
                    break;
                case Speed.Slow:
                    break;
                case Speed.VerySlow:
                    break;
                case Speed.PokemonGoSlow:
                    break;
                case Speed.DMV:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Dictionary<int, Speed> _thresholds = new Dictionary<int, Speed>()
        {
            {9999, Speed.HolyShitFuck},
            {27, Speed.RidiculouslyFast},
            {18, Speed.SuperFast},
            {9, Speed.Fast},
            {3, Speed.Comfortable},
            {2, Speed.PokemonGoSlow},
            {0, Speed.DMV}
        };

        private CellIdentity GetCell(Vector2 position) => _cells[(int)position.X, (int)position.Y];

        private Point SetPoints(ref Point point, double x, double y)
        {
            var outputBuilder = new StringBuilder();

            outputBuilder.AppendLine($"GetHashCode: {point.GetHashCode()}");

            SetPoints(ref point, 0.0, 0.0);
            outputBuilder.AppendLine($"GetHashCode: {point.GetHashCode()}");

            SetPoints(ref point, 1.0, 2.0);
            outputBuilder.AppendLine($"GetHashCode: {point.GetHashCode()}");

            SetPoints(ref point, 2.0, 1.0);
            outputBuilder.AppendLine($"GetHashCode: {point.GetHashCode()}");


            point.X = x;
            point.Y = y;

            return point;
        }
    }
}
