using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderCommentReaderViewModel : ViewModelBase
    {
        private PartManager partManager;

        public IWindow Window { get; set; }

        public string comment;
        public string Comment
        {
            get => this.comment;
            set => this.RaiseAndSetIfChanged(ref this.comment, value);
        }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public OrderCommentReaderViewModel(PartManager partManager)
        {
            this.partManager = partManager;

            this.AddCommand = ReactiveCommand.Create(this.Add);
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
        }

        private void Add()
        {
            this.Window?.Close();
        }

        private void Cancel()
        {
            this.Window?.Close();
        }
    }
}
