﻿using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Reactive;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderCommentReaderViewModel : OrderCommentEditorViewModel
    {
        public IWindow Window { get; set; }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public OrderCommentReaderViewModel(PartManager partManager)
            : base(partManager)
        {
            this.AddCommand = ReactiveCommand.Create(this.Add);
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
        }

        private void Add()
        {
            this.PartManager.AddFromOrderComment(this.Comment);
            this.Window?.Close();
        }

        private void Cancel()
        {
            this.Window?.Close();
        }
    }
}
