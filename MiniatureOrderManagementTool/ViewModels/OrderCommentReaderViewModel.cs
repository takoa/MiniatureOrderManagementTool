﻿using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Reactive;

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

        public string errorMessages;
        public string ErrorMessages
        {
            get => this.errorMessages;
            set => this.RaiseAndSetIfChanged(ref this.errorMessages, value);
        }

        public ReactiveCommand<Unit, Unit> AddCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public OrderCommentReaderViewModel(PartManager partManager)
        {
            this.partManager = partManager;

            this.AddCommand = ReactiveCommand.Create(this.Add);
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
        }

        public void ParseComment()
        {
            var errors = this.partManager.ReadOrderComment(this.Comment);

            this.ErrorMessages = errors.Count == 0 ? "" : PartManager.GetErrorString(errors);
        }

        private void Add()
        {
            var errors = this.partManager.ReadOrderComment(this.Comment);

            if (errors.Count != 0)
            {
                this.ErrorMessages = PartManager.GetErrorString(errors);
            }
            else
            {
                this.Window?.Close();
            }
        }

        private void Cancel()
        {
            this.Window?.Close();
        }
    }
}
