using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
        public bool Paused { get; set; }
        private CellIdentity _target;

        public MainWindow()
        {
            InitializeComponent();

            BoardWidth = 40;
            BoardHeight = 40;
            Paused = true;

            var generator = new BoardGenerator();
            _cells = generator.GenerateCells(BoardWidth, BoardHeight);
            Grid = generator.GenerateGrid(BoardWidth, BoardHeight);

            foreach (var cell in _cells)
            {
                Grid.Children.Add(cell.Label);
            }

            _snake = new Snake();
            _snake.Position = new Vector2(BoardWidth / 2, BoardHeight / 2);

            MakeFood();
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
            _snake.TargetPosition = _target.Position;
            _snake.Length = 3;

            GameBoard.Content = Grid;
        }

        private void MakeFood()
        {
            _target = GetRandomFreeCell();
            _target.IsFood = true;
            _target.Label.Background = new SolidColorBrush(Colors.DarkRed);
            _snake.TargetPosition = _target.Position;
        }

        public void SetupBoard()
        {

        }

        /// <inheritdoc />
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                if (Paused)
                {
                    Paused = false;
                    new Thread(Run).Start();
                }
                else
                    Paused = true;
            }
        }

        private void Run()
        {
            while (_snake.IsAlive && !Paused)
            {
                Dispatcher.BeginInvoke(new Action(() => Move(_snake.Direction)));

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
                    Step(_snake.Position - Vector2.UnitY);
                    break;
                case Direction.Down:
                    Step(_snake.Position + Vector2.UnitY);
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
            if (!CheckIfInBounds(vector))
            {
                Paused = true;
                MessageBox.Show("CRASH!!!");
                Application.Current.Shutdown();
                return;
            }

            _snake.Position = vector;

            var cell = GetCell(_snake.Position);
            if (cell.IsFood)
            {
                _snake.Length += 3;
                CheckSpeed();
                MakeFood();
                cell.IsFood = false;
            }

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
                var random = new Random(new Random().Next());
                var output = new Vector2(random.Next(BoardWidth), random.Next(BoardHeight));

                if (!GetCell(output).IsFood && !GetCell(output).IsSnake)
                {
                    return output;
                }
            }
        }

        private void CheckSpeed()
        {
            var threshhold = _thresholds.FirstOrDefault(x => x != null && x.Value.Item1 == _snake.Length);
            if (threshhold != null)
            {
                _snake.Speed = threshhold.Value.Item2;
            }
        }

        private List<(int, Speed)?> _thresholds = new List<(int, Speed)?>()
        {
            (9999, Speed.HolyShitFuck),
            (27, Speed.RidiculouslyFast),
            (18, Speed.SuperFast),
            ( 9, Speed.Fast),
            ( 3, Speed.Comfortable),
            ( 2, Speed.PokemonGoSlow),
            ( 0, Speed.DMV)
        };

        private CellIdentity GetCell(Vector2 position) => _cells[(int)position.X, (int)position.Y];

        private bool IsSnake(Vector2 position) => GetCell(position).IsSnake;

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up when GetCell(_snake.Position - Vector2.UnitY).IsSnake:
                    return;
                case Key.Up:
                    _snake.Direction = Direction.Up;
                    break;
                case Key.Left when GetCell(_snake.Position - Vector2.UnitX).IsSnake:
                    return;
                case Key.Left:
                    _snake.Direction = Direction.Left;
                    break;
                case Key.Right when GetCell(_snake.Position + Vector2.UnitX).IsSnake:
                    return;
                case Key.Right:
                    _snake.Direction = Direction.Right;
                    break;
                case Key.Down when GetCell(_snake.Position + Vector2.UnitY).IsSnake:
                    return;
                case Key.Down:
                    _snake.Direction = Direction.Down;
                    break;
            }
        }
    }
}
