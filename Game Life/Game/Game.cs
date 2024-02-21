namespace Game_Life.Game
{
    public class GameField
    {
        public int FieldSize { get; set; }
        public Cell[,] Field { get; set; }

        public GameField(int fieldSize)
        {
            FieldSize = fieldSize;
            Field = new Cell[fieldSize, fieldSize];
        }

        public void NextGeneration()
        {
            var NewGeneration = new Cell[FieldSize, FieldSize];

            // Логіка яка буде створювати нове покоління


            Field = NewGeneration;
        }

        // Створення ігрового поля
        private void NewGame()
        {

        }

        private void CellRules(int aliveNeighborhood)
        {

        }

        private int CellAliveAround(int cellX, int cellY)
        {
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };


            return 1;
        }
    }

    public class Cell
    {
        public bool Alive { get; set; }

        Cell()
        {
            Alive = true;
        }
    }
}
