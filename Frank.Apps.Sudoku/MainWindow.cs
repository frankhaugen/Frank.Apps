using System.Windows;
using System.Windows.Controls;
using Frank.Apps.Sudoku.Models;

namespace Frank.Apps.Sudoku;

public class MainWindow : Window
{
    public MainWindow()
    {
        var grid = GenerateGrid(9, 9);
        var board = new Board();
        foreach (var boardCell in board.Cells)
        {
            grid.Children.Add(boardCell.TextBox);
        }

        Content = grid;
    }

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
}