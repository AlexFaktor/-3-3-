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
                        newGenerationField[x, y] = CellField.Field[x,y];
                }
            }
            CellField.Field = newGenerationField;
            CountGeneration++;
        }
    }
}
