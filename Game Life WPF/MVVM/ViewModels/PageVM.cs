using CourseManager.ViewModels.Base;
using Game_Life_WPF.Game;
using Game_Life_WPF.MVVM.Models.GameObjects;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Game_Life_WPF.MVVM.ViewModels
{
    public abstract class PageVM : ViewModel
    {
        private string? _Title = "Game life";
        public string Title
        {
            get => _Title!;
            set => Set(ref _Title, value);
        }
    }

    public class PageGameVM : PageVM
    {
        private double? _ImageHeight;
        private double? _ImageWidth;
        private BitmapImage? _GameScreen;

        public double? ImageHeight
        {
            get => _ImageHeight;
            set => Set(ref _ImageHeight, value);
        }
        public double? ImageWidth
        {
            get => _ImageWidth;
            set => Set(ref _ImageWidth, value);
        }

        public BitmapImage? GameScreen
        {
            get => _GameScreen;
            set => Set(ref _GameScreen, value);
        }

        public PageGameVM()
        {
            StartGameLoop(130, 130, 30, 150, Color.Green);
        }

        private async void StartGameLoop(int sizeWidth, int sizeHeight, double cellDensity, int generationInterval, Color cellColor)
        {
            var game = new GameManager(sizeWidth, sizeHeight, cellDensity); // Height, width, density

            while (true)
            {
                Title = $"game life | generation - {game.CountGeneration} | alive - {game.Stats.CellAlive}/{game.Stats.CellCount} | field size - {game.Stats.FieldHeight}x{game.Stats.FieldWidth} | window size {ImageHeight}x{ImageWidth}";
                GameScreen = ConvertCellsToBitmapImage(game.CellField.Field, cellColor); // cell color
                game.NextGeneration();

                await Task.Delay(generationInterval); // Generation interval
            }
        }

        private static BitmapImage ConvertCellsToBitmapImage(Cell[,] cells, System.Drawing.Color cellColor)
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

    public class PageСonfigurationVM : PageVM
    {
        private int _SizeWidth = 130;
        private int _SizeHeight = 130;
        private double _CellDensity = 30;
        private int _Interval = 150;
        private Color _Color = Color.Green;

        public int SizeWidth
        {
            get => _SizeWidth;
            set => Set(ref _SizeWidth, value);
        }

        public int SizeHeight
        {
            get => _SizeHeight;
            set => Set(ref _SizeHeight, value);
        }

        public double CellDensity
        {
            get => _CellDensity;
            set => Set(ref _CellDensity, value);
        }

        public int Interval
        {
            get => _Interval;
            set => Set(ref _Interval, value);
        }

        public Color Color
        {
            get => _Color;
            set => Set(ref _Color, value);
        }
    }
}
