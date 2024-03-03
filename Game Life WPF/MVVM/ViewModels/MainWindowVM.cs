using CourseManager.ViewModels.Base;

namespace Game_Life_WPF.MVVM.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        private PageVM? _Page;

        public PageVM? Page
        {
            get => _Page;
            set => Set(ref _Page, value);
        }
    }
}   