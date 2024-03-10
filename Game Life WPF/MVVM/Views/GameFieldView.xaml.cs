using Game_Life_WPF.MVVM.ViewModels;
using System.Windows.Controls;

namespace Game_Life_WPF.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для GameField.xaml
    /// </summary>
    public partial class GameFieldView : UserControl
    {
        public GameFieldView()
        {
            InitializeComponent();
        }

        private void GameField_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            var img = sender as Image;

            if (DataContext is PageGameVM vm)
            {
                vm.ImageHeight = img!.ActualHeight;
                vm.ImageWidth = img!.ActualWidth;
            }
        }
    }
}
