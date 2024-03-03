using Game_Life_WPF.Game;
using Game_Life_WPF.MVVM.Models.GameObjects;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


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

            StartGameLoop(130, 130, 30, 150, Color.Green);

            async void StartGameLoop(int sizeWidth, int sizeHeight, double cellDensity, int generationInterval, Color cellColor)
            {
                var game = new GameManager(sizeWidth, sizeHeight, cellDensity); // Height, width, density

                while (true)
                {
                    Title = $"game life | generation - {game.CountGeneration} | alive - {game.Stats.CellAlive}/{game.Stats.CellCount} | field size - {game.Stats.FieldHeight}x{game.Stats.FieldWidth} | window size {GameField.ActualHeight}x{GameField.ActualWidth}";
                    GameField.Source = ConvertCellsToBitmapImage(game.CellField.Field, cellColor); // cell color
                    game.NextGeneration();

                    await Task.Delay(generationInterval); // Generation interval
                }
            }
        }

        public static BitmapImage ConvertCellsToBitmapImage(Cell[,] cells, System.Drawing.Color cellColor)
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
                    System.Drawing.Color color = cells[x, y].Alive ? cellColor : System.Drawing.Color.Black; // Встановлюємо зелений колір для true, чорний - для false
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