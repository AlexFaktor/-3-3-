using CourseManager.ViewModels.Base;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Game_Life_WPF.MVVM.ViewModels
{
    public abstract class PageVM : ViewModel
    {
    }

    public class PageGameVM : PageVM
    {
        private BitmapImage _GameScreen;

        public BitmapImage GameScreen
        {
            get => _GameScreen;
            set => Set(ref _GameScreen, value);
        }
    }

    public class PageСonfiguration : PageVM
    {
        
    }
}
