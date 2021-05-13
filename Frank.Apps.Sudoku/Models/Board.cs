namespace Frank.Apps.Sudoku.Models
{
    public class Board
    {
        public Board()
        {
            Cells = GenerateCells();
        }

        private Cell[,] GenerateCells()
        {
            var output = new Cell[9, 9];

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    output[i, j] = new Cell(Position.Initialize(i, j));
                }
            }

            return output;
        }

        public Cell[,] Cells { get; }
    }
}
