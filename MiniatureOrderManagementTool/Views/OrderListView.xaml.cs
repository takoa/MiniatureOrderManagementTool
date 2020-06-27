﻿using MiniatureOrderManagementTool.Models;
using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    public partial class OrderListView : ReactiveUserControl<OrderListViewModel>
    {
        public OrderListView()
        {
            this.InitializeComponent();
            this.ViewModel = new OrderListViewModel();

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.Orders, view => view.ordersListView.ItemsSource).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.SelectedOrder, view => view.ordersListView.SelectedItem).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.IsFinished, view => view.isFinishedTextBlock.Text, OrderManager.GetIsFinishedString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.TimeSpent, view => view.timeSpantTextBlock.Text, OrderManager.GetTimeSpentString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Name, view => view.orderNameTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Customer, view => view.customerTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Price, view => view.priceTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Deadline, view => view.deadlineDateTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.CreatedAt, view => view.createdAtTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.ModifiedAt, view => view.modifiedAtTextBlock.Text, OrderManager.GetDeadlineString).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Description, view => view.descriptionTextBlock.Text).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.SelectedOrder.Parts, view => view.partsDataGrid.ItemsSource).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddOrderCommand, view => view.addOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.EditOrderCommand, view => view.editOrderButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.DeleteOrderCommand, view => view.deleteOrderButton).DisposeWith(d);
            });
        }
    }
}
