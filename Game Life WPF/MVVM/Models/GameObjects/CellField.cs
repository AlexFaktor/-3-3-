using System.Windows.Controls;

namespace Game_Life_WPF.MVVM.Models.GameObjects
{
    public class CellField
    {
        public Cell[,] Field { get; set; }

        public CellField(int size)
        {
            var field = new Cell[size, size];

            FillField(field);

            Field = field;
        }

        public CellField(int sizeHeights, int sizeWidth)
        {
            var field = new Cell[sizeHeights, sizeWidth];

            FillField(field);

            Field = field;
        }

        public CellField(int size, double percentageLiveCells)
        {
            var field = new Cell[size, size];

            FillField(field);

            Field = field.FieldAliveCells(percentageLiveCells);
        }

        public CellField(int sizeHeights, int sizeWidth, double percentageLiveCells)
        {
            var field = new Cell[sizeHeights, sizeWidth];

            FillField(field);

            Field = field.FieldAliveCells(percentageLiveCells);
        }

        private static void FillField(Cell[,] field)
        {
            var rows = field.GetLength(0);
            var cols = field.GetLength(1);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    field[i, j] = new Cell();
                }
            }
        }
    }

    public static class GameFieldExtension
    {
        public static Cell[,] FieldAliveCells(this Cell[,] cells, double percentageLiveCells)
        {
            var randon = new Random();

            var rows = cells.GetLength(0);
            var cols = cells.GetLength(1);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var randomNum = randon.NextDouble();
                    if (randomNum * 100 < percentageLiveCells)
                        cells[i, j].Alive = true;
                    else
                        cells[i, j].Alive = false;
                }
            }

            return cells;
        }
    }
}
