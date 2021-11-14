using System.Windows;
using System.Windows.Controls;

namespace Frank.Apps.Snake;

public class BoardGenerator
{

    public Grid GenerateGrid(int x, int y)
    {
        var grid = new Grid();

        for (int i = 0; i < x; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
        }
        for (int i = 0; i < y; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
        }

        return grid;
    }

    public CellIdentity[,] GenerateCells(int x = 10, int y = 10)
    {
        CellIdentity[,] output = new CellIdentity[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                output[i, j] = new CellIdentity(i, j);
            }
        }

        return output;
    }
}