using CourseManager.ViewModels.Base;
using Game_Life_WPF.Game;
using Game_Life_WPF.MVVM.Models.GameObjects;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Documents;
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

        public PageGameVM(PageСonfigurationVM confg)
        {
            StartGameLoop(confg.SizeHeight, confg.SizeWidth, confg.CellDensity, confg.Interval, confg.SelectedColor.Color);
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

        private ObservableCollection<ColorItem>? _ColorList;
        private ColorItem? _SelectedColor = new("Green", Color.Green) ;

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
        public ColorItem SelectedColor
        {
            get => _SelectedColor!;
            set => Set(ref _SelectedColor, value);
        }
        public ObservableCollection<ColorItem> ColorList
        {
            get => _ColorList!;
            set => Set(ref _ColorList, value);
        }
        public PageСonfigurationVM()
        {
            #region Color list
            ColorList = new ObservableCollection<ColorItem>
            {
                new ("AliceBlue", Color.AliceBlue),
                new ("AntiqueWhite", Color.AntiqueWhite),
                new ("Aqua", Color.Aqua),
                new ("Aquamarine", Color.Aquamarine),
                new ("Azure", Color.Azure),
                new ("Beige", Color.Beige),
                new ("Bisque", Color.Bisque),
                new ("Black", Color.Black),
                new ("BlanchedAlmond", Color.BlanchedAlmond),
                new ("Blue", Color.Blue),
                new ("BlueViolet", Color.BlueViolet),
                new ("Brown", Color.Brown),
                new ("BurlyWood", Color.BurlyWood),
                new ("CadetBlue", Color.CadetBlue),
                new ("Chartreuse", Color.Chartreuse),
                new ("Chocolate", Color.Chocolate),
                new ("Coral", Color.Coral),
                new ("CornflowerBlue", Color.CornflowerBlue),
                new ("Cornsilk", Color.Cornsilk),
                new ("Crimson", Color.Crimson),
                new ("Cyan", Color.Cyan),
                new ("DarkBlue", Color.DarkBlue),
                new ("DarkCyan", Color.DarkCyan),
                new ("DarkGoldenrod", Color.DarkGoldenrod),
                new ("DarkGray", Color.DarkGray),
                new ("DarkGreen", Color.DarkGreen),
                new ("DarkKhaki", Color.DarkKhaki),
                new ("DarkMagenta", Color.DarkMagenta),
                new ("DarkOliveGreen", Color.DarkOliveGreen),
                new ("DarkOrange", Color.DarkOrange),
                new ("DarkOrchid", Color.DarkOrchid),
                new ("DarkRed", Color.DarkRed),
                new ("DarkSalmon", Color.DarkSalmon),
                new ("DarkSeaGreen", Color.DarkSeaGreen),
                new ("DarkSlateBlue", Color.DarkSlateBlue),
                new ("DarkSlateGray", Color.DarkSlateGray),
                new ("DarkTurquoise", Color.DarkTurquoise),
                new ("DarkViolet", Color.DarkViolet),
                new ("DeepPink", Color.DeepPink),
                new ("DeepSkyBlue", Color.DeepSkyBlue),
                new ("DimGray", Color.DimGray),
                new ("DodgerBlue", Color.DodgerBlue),
                new ("Firebrick", Color.Firebrick),
                new ("FloralWhite", Color.FloralWhite),
                new ("ForestGreen", Color.ForestGreen),
                new ("Fuchsia", Color.Fuchsia),
                new ("Gainsboro", Color.Gainsboro),
                new ("GhostWhite", Color.GhostWhite),
                new ("Gold", Color.Gold),
                new ("Goldenrod", Color.Goldenrod),
                new ("Gray", Color.Gray),
                new ("Green", Color.Green),
                new ("GreenYellow", Color.GreenYellow),
                new ("Honeydew", Color.Honeydew),
                new ("HotPink", Color.HotPink),
                new ("IndianRed", Color.IndianRed),
                new ("Indigo", Color.Indigo),
                new ("Ivory", Color.Ivory),
                new ("Khaki", Color.Khaki),
                new ("Lavender", Color.Lavender),
                new ("LavenderBlush", Color.LavenderBlush),
                new ("LawnGreen", Color.LawnGreen),
                new ("LemonChiffon", Color.LemonChiffon),
                new ("LightBlue", Color.LightBlue),
                new ("LightCoral", Color.LightCoral),
                new ("LightCyan", Color.LightCyan),
                new ("LightGoldenrodYellow", Color.LightGoldenrodYellow),
                new ("LightGray", Color.LightGray),
                new ("LightGreen", Color.LightGreen),
                new ("LightPink", Color.LightPink),
                new ("LightSalmon", Color.LightSalmon),
                new ("LightSeaGreen", Color.LightSeaGreen),
                new ("LightSkyBlue", Color.LightSkyBlue),
                new ("LightSlateGray", Color.LightSlateGray),
                new ("LightSteelBlue", Color.LightSteelBlue),
                new ("LightYellow", Color.LightYellow),
                new ("Lime", Color.Lime),
                new ("LimeGreen", Color.LimeGreen),
                new ("Linen", Color.Linen),
                new ("Magenta", Color.Magenta),
                new ("Maroon", Color.Maroon),
                new ("MediumAquamarine", Color.MediumAquamarine),
                new ("MediumBlue", Color.MediumBlue),
                new ("MediumOrchid", Color.MediumOrchid),
                new ("MediumPurple", Color.MediumPurple),
                new ("MediumSeaGreen", Color.MediumSeaGreen),
                new ("MediumSlateBlue", Color.MediumSlateBlue),
                new ("MediumSpringGreen", Color.MediumSpringGreen),
                new ("MediumTurquoise", Color.MediumTurquoise),
                new ("MediumVioletRed", Color.MediumVioletRed),
                new ("MidnightBlue", Color.MidnightBlue),
                new ("MintCream", Color.MintCream),
                new ("MistyRose", Color.MistyRose),
                new ("Moccasin", Color.Moccasin),
                new ("NavajoWhite", Color.NavajoWhite),
                new ("Navy", Color.Navy),
                new ("OldLace", Color.OldLace),
                new ("Olive", Color.Olive),
                new ("OliveDrab", Color.OliveDrab),
                new ("Orange", Color.Orange),
                new ("OrangeRed", Color.OrangeRed),
                new ("Orchid", Color.Orchid),
                new ("PaleGoldenrod", Color.PaleGoldenrod),
                new ("PaleGreen", Color.PaleGreen),
                new ("PaleTurquoise", Color.PaleTurquoise),
                new ("PaleVioletRed", Color.PaleVioletRed),
                new ("PapayaWhip", Color.PapayaWhip),
                new ("PeachPuff", Color.PeachPuff),
                new ("Peru", Color.Peru),
                new ("Pink", Color.Pink),
                new ("Plum", Color.Plum),
                new ("PowderBlue", Color.PowderBlue),
                new ("Purple", Color.Purple),
                new ("Red", Color.Red),
                new ("RosyBrown", Color.RosyBrown),
                new ("RoyalBlue", Color.RoyalBlue),
                new ("SaddleBrown", Color.SaddleBrown),
                new ("Salmon", Color.Salmon),
                new ("SandyBrown", Color.SandyBrown),
                new ("SeaGreen", Color.SeaGreen),
                new ("SeaShell", Color.SeaShell),
                new ("Sienna", Color.Sienna),
                new ("Silver", Color.Silver),
                new ("SkyBlue", Color.SkyBlue),
                new ("SlateBlue", Color.SlateBlue),
                new ("SlateGray", Color.SlateGray),
                new ("Snow", Color.Snow),
                new ("SpringGreen", Color.SpringGreen),
                new ("SteelBlue", Color.SteelBlue),
                new ("Tan", Color.Tan),
                new ("Teal", Color.Teal),
                new ("Thistle", Color.Thistle),
                new ("Tomato", Color.Tomato),
                new ("Transparent", Color.Transparent),
                new ("Turquoise", Color.Turquoise),
                new ("Violet", Color.Violet),
                new ("Wheat", Color.Wheat),
                new ("White", Color.White),
                new ("WhiteSmoke", Color.WhiteSmoke),
                new ("Yellow", Color.Yellow),
                new ("YellowGreen", Color.YellowGreen)
            };
            #endregion
        }
    }
    public class ColorItem
    {
        public string Name { get; set; }
        public Color Color { get; set; }

        public ColorItem(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
