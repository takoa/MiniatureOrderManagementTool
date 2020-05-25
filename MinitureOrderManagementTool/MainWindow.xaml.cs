using MinitureOrderManagementTool.ViewModels;
using ReactiveUI;

namespace MinitureOrderManagementTool.Views
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
