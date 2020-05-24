using MinitureOrderManagementTool.Helpers;
using MinitureOrderManagementTool.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
    /// Interaction logic for NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : ReactiveWindow<NewOrderViewModel>, IClosable
    {
        public NewOrderView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.ViewModel.CommonOrderEditorViewModel = this.commonOrderEditorView.ViewModel;

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, view => view.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.CancelCommand, view => view.cancelButton).DisposeWith(d);
            });
        }
    }
}
