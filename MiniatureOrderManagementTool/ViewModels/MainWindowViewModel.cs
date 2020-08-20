using MiniatureOrderManagementTool.Helpers;
using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IWindow Window { get; set; }
        public OrderListViewModel OrderListViewModel { get; set; }

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                App.Config.MainWindowPosition = new Point(value, App.Config.MainWindowPosition.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                App.Config.MainWindowPosition = new Point(App.Config.MainWindowPosition.X, value);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                App.Config.MainWindowSize = new Size(value, App.Config.MainWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                App.Config.MainWindowSize = new Size(App.Config.MainWindowSize.Width, value);
            }
        }

        public ReactiveCommand<Unit, Unit> QuitCommand { get; }
        public ReactiveCommand<Unit, Unit> ShowAboutCommand { get; }

        public MainWindowViewModel()
        {
            this.Left = App.Config.MainWindowPosition.X;
            this.Top = App.Config.MainWindowPosition.Y;
            this.Width = App.Config.MainWindowSize.Width;
            this.Height = App.Config.MainWindowSize.Height;

            this.QuitCommand = ReactiveCommand.Create(this.Quit);
            this.ShowAboutCommand = ReactiveCommand.Create(this.ShowAbout);
        }

        private void Quit()
        {
            this.Window.Close();
        }

        private void ShowAbout()
        {
            var aboutViewModel = new AboutViewModel();

            WindowViewHelper.ShowWindow(aboutViewModel);
        }
    }
}
