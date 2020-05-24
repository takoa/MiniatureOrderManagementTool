using MinitureOrderManagementTool.Helpers;
using MinitureOrderManagementTool.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MinitureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for OrderEditorView.xaml
    /// </summary>
    public partial class OrderEditorView : ReactiveWindow<OrderEditorViewModel>, IClosable
    {
        public OrderEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.CommonOrderEditorViewModel = this.commonOrderEditorView.ViewModel;

                this.Bind(this.ViewModel, vm => vm.IsOrderFinished, v => v.isFinishedCheckBox.IsChecked).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.UpdateOrderCommand, view => view.updateOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
