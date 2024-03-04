using Game_Life_WPF.MVVM.ViewModels;
using System.Windows.Controls;

namespace Game_Life_WPF.MVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для GameField.xaml
    /// </summary>
    public partial class GameConfigurationView : UserControl
    {
        public GameConfigurationView()
        {
            InitializeComponent();
            DataContext = App.Current.MainWindow.DataContext;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is MainWindowVM vm)
            {
                PageСonfigurationVM? confg = vm.Page as PageСonfigurationVM;
                vm.Page = new PageGameVM(confg!);
            }
        }
    }
}
