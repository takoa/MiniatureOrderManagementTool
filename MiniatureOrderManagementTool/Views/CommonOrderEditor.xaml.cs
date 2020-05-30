﻿using MiniatureOrderManagementTool.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace MiniatureOrderManagementTool.Views
{
    /// <summary>
    /// Interaction logic for CommonOrderEditor.xaml
    /// </summary>
    public partial class CommonOrderEditorView : ReactiveUserControl<CommonOrderEditorViewModel>
    {
        public CommonOrderEditorView()
        {
            this.InitializeComponent();

            this.ViewModel = new CommonOrderEditorViewModel();

            this.WhenActivated(d =>
            {
                this.Bind(this.ViewModel, vm => vm.OrderName, v => v.orderNameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderPrice, v => v.priceNumericTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderCustomer, v => v.customerTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderDeadline, v => v.deadlineDatePicker.SelectedDate).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.OrderDescription, v => v.descriptionTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.SelectedPart, v => v.partsDataGrid.SelectedItem).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartName, v => v.partNameTextBox.Text).DisposeWith(d);
                this.Bind(this.ViewModel, vm => vm.PartAmount, v => v.partAmountNumericTextBox.Text, x => x.ToString(), CommonOrderEditorViewModel.GetPartAmountInt).DisposeWith(d);

                this.OneWayBind(this.ViewModel, vm => vm.Parts, v => v.partsDataGrid.ItemsSource).DisposeWith(d);

                this.BindCommand(this.ViewModel, vm => vm.AddPartCommand, view => view.addPartButton).DisposeWith(d);
                this.BindCommand(this.ViewModel, vm => vm.RemovePartCommand, view => view.removePartButton).DisposeWith(d);
            });
        }
    }
}