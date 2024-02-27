using Game_Life_WPF.MVVM.Models.GameObjects;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game_Life_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GameField.Source = ConvertCellsToBitmapImage(new CellField(200, 20d).Field);



        }

        private void StartGame()
        {
            GameField.Source = new BitmapImage();


        }

        public static BitmapImage ConvertCellsToBitmapImage(Cell[,] cells)
        {
            int width = cells.GetLength(0);
            int height = cells.GetLength(1);

            // Створюємо нове зображення Bitmap
            var bitmap = new Bitmap(width, height);

            // Проходимо по кожній комірці масиву і встановлюємо піксель на зображенні
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    System.Drawing.Color color = cells[x, y].Alive ? System.Drawing.Color.Green : System.Drawing.Color.Black; // Встановлюємо зелений колір для true, чорний - для false
                    bitmap.SetPixel(x, y, color); // Встановлюємо піксель
                }
            }

            // Конвертуємо зображення Bitmap в BitmapImage
            var bitmapImage = new BitmapImage();

            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }
    }
}