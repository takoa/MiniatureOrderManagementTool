using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderCommentReaderView : ReactiveWindow<OrderCommentReaderViewModel>, IWindow
    {
        public OrderCommentReaderView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.Window = this;

                this.OneWayBind(this.ViewModel, vm => vm.ErrorMessages, v => v.errorTextBox.Text).DisposeWith(d);

                this.Bind(this.ViewModel, vm => vm.Comment, v => v.commentTextBox.Text).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddCommand, v => v.addButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, v => v.cancelButton).DisposeWith(d);

                Observable.FromEventPattern<TextChangedEventArgs>(this.commentTextBox, nameof(this.commentTextBox.TextChanged))
                    .Throttle(TimeSpan.FromSeconds(1))
                    .Subscribe(Observer.Create<EventPattern<TextChangedEventArgs>>(e => this.Dispatcher.Invoke(() => this.ViewModel.ParseComment())))
                    .DisposeWith(d);
            });
        }
    }
}
