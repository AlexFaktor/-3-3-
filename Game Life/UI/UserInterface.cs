using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Life.UI
{
    internal class UserInterface
    {

        public static void Show()
        {
            for (int i = 0; i < 100; i++)
            { 
                for (int j = 0; j < 100 ; j++)
                {
                    Console.Write("■");
                }
                Console.WriteLine();
            }

        }
    }
}