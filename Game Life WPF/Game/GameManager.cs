using Game_Life_WPF.MVVM.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Life_WPF.Game
{
    class GameManager
    {
        public CellField CellField { get; set; }
        public int CountGeneration { get; set; }

        public GameManager(int fieldWidth, int fieldHeight, double density)
        {
            CellField = new CellField(fieldWidth, fieldHeight, density);
            CountGeneration = 0;
        }

        public void NextGeneration()
        {
            var newGenerationField = new Cell[CellField.Field.GetLength(0), CellField.Field.GetLength(1)];
        }
    }
}
