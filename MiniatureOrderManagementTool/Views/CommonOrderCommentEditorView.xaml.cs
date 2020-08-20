using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace MiniatureOrderManagementTool.Views
{
    public partial class CommonOrderCommentEditorView : ReactiveUserControl<CommonOrderCommentEditorViewModel>
    {
        public CommonOrderCommentEditorView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.ErrorMessages, v => v.errorTextBox.Text).DisposeWith(d);

                this.Bind(this.ViewModel, vm => vm.Comment, v => v.commentTextBox.Text).DisposeWith(d);

                Observable.FromEventPattern<TextChangedEventArgs>(this.commentTextBox, nameof(this.commentTextBox.TextChanged))
                    .Throttle(TimeSpan.FromSeconds(1))
                    .Subscribe(Observer.Create<EventPattern<TextChangedEventArgs>>(e => this.Dispatcher.Invoke(() => this.ViewModel.ParseComment())))
                    .DisposeWith(d);
            });
        }
    }
}
