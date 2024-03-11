namespace Game_Life_WPF.MVVM.Models.GameObjects
{
    public class Cell
    {
        public bool Alive { get; set; }

        public Cell()
        {
            Alive = false;
        }

        public Cell(bool alive)
        {
            Alive = alive;
        }
    }
}
