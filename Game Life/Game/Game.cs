namespace Game_Life.Game
{
    public class GameField
    {
        public List<List<Cell>>? Field { get; set; }

        public GameField()
        {

        }

        public void NextGeneration()
        {
            var NewGeneration = new List<List<Cell>>();

            // Логіка яка буде створювати нове покоління


            Field = NewGeneration;
        }

        // Правило 1
        private void RuleOne()
        { 
        
        }
        // Правило 2
        private void RuleTwo()
        {

        }

        // Правило 3
        private void RuleThree()
        {

        }

        // Створення ігрового поля
        private void NewGame()
        {

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
