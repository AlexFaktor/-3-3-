using Game_Life_WPF.MVVM.Models.GameObjects;

namespace Game_Life_WPF.Game
{
    class GameManager
    {
        public CellField CellField { get; set; }
        public GameStats Stats { get; set; }

        public GameManager(int fieldWidth, int fieldHeight, double density)
        {
            CellField = new CellField(fieldWidth, fieldHeight, density);
            Stats = new GameStats(CellField);
        }

        public void NextGeneration()
        {
            var stats = Stats;
            var newGenerationField = new Cell[CellField.Field.GetLength(0), CellField.Field.GetLength(1)];

            for (int x = 0; x < newGenerationField.GetLength(0); x++)
            {
                for (int y = 0; y < newGenerationField.GetLength(1); y++)
                {
                    var neighborsCount = CellField.CountNeighbors(x, y);
                    var isAlive = CellField.Field[x, y].Alive;

                    if (!isAlive && neighborsCount == 3)
                        newGenerationField[x, y] = new Cell() { Alive = true };

                    else if (isAlive && (neighborsCount < 2 || neighborsCount > 3))
                        newGenerationField[x, y] = new Cell();

                    else
                        newGenerationField[x, y] = CellField.Field[x, y];
                }
            }
            CellField.Field = newGenerationField;

            stats.CellAlive = CellField.CountCellAlive();
            stats.CountGeneration++;
            Stats = stats;
        }

        public struct GameStats
        {
            public int CountGeneration {  get; set; }
            public int CellAlive { get; set; }
            public readonly int CellCount { get; }
            public readonly int FieldWidth { get; }
            public readonly int FieldHeight { get; }

            public GameStats(CellField field)
            {
                FieldWidth = field.Field.GetLength(0);
                FieldHeight = field.Field.GetLength(1);
                CellCount = FieldWidth * FieldHeight;
                CountGeneration = 0;
            }
        }
    }
}
