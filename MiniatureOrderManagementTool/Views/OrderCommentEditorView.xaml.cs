using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderCommentEditorView : ReactiveUserControl<OrderCommentEditorViewModel>
    {
        public OrderCommentEditorView()
        {
            this.InitializeComponent();
            this.ViewModel = new OrderCommentEditorViewModel();
            this.orderCommentEditor.ViewModel = this.ViewModel;
        }
    }
}
