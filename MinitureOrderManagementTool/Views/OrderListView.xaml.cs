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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinitureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for OrderListView.xaml
    /// </summary>
    public partial class OrderListView : ReactiveUserControl<OrderListViewModel>
    {
        public OrderListView()
        {
            this.InitializeComponent();
            this.ViewModel = new OrderListViewModel("./database.db");

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Orders, view => view.ordersListView.ItemsSource).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.SelectedOrder, view => view.ordersListView.SelectedItem).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.IsFinished, view => view.isFinishedTextBlock.Text, OrderListViewModel.GetIsFinishedString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.TimeSpent, view => view.timeSpantTextBlock.Text, OrderListViewModel.GetTimeSpentString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Name, view => view.orderNameTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Customer, view => view.customerTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Price, view => view.priceTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Deadline, view => view.deadlineDateTextBlock.Text, vmToViewConverterOverride: new DateConverter()).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Description, view => view.descriptionTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Parts, view => view.partsDataGrid.ItemsSource).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, view => view.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.EditOrderCommand, view => view.editOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.DeleteOrderCommand, view => view.deleteOrderButton).DisposeWith(d);
            });
        }
    }
}
