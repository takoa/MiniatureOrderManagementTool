using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Windows;

namespace MiniatureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>, IClosable
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.ViewModel = new MainWindowViewModel(((App)Application.Current).Config);

            this.WhenActivated(d =>
            {
                this.ViewModel.OrderListViewModel = this.orderListView.ViewModel;

                this.Bind(this.ViewModel, vm => vm.Left, v => v.Left).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Top, v => v.Top).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Width, v => v.Width).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.Height, v => v.Height).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.QuitCommand, v => v.quitMenuItem).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.OrderListViewModel.AddOrderCommand, v => v.newOrderMenuItem).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.OrderListViewModel.EditOrderCommand, v => v.editOrderMenuItem).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.OrderListViewModel.DeleteOrderCommand, v => v.removeOrderMenuItem).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.ShowAboutCommand, v => v.showAboutMenuItem).DisposeWith(d);
            });
        }
    }
}
