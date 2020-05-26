using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;

namespace MiniatureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.ViewModel = new MainWindowViewModel();
        }
    }
}
