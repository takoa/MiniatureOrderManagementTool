using ReactiveUI;
using System.ComponentModel;
using System.Reactive;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModelBase : CommonOrderEditorViewModel
    {
        public IConfirmationBox ConfirmationBox { get; set; }
        public IWindow Window { get; set; }
        public bool ShowsConfirmation { get; set; } = true;

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }
        public ReactiveCommand<CancelEventArgs, Unit> ClosingEventCommand { get; }

        public OrderEditorViewModelBase()
        {
            this.CancelCommand = ReactiveCommand.Create(this.Cancel);
            this.ClosingEventCommand = ReactiveCommand.Create<CancelEventArgs>(this.Cancel);
        }

        public void Cancel()
        {
            this.Window?.Close();
        }

        public void Cancel(CancelEventArgs e)
        {
            if (this.ShowsConfirmation && !this.ConfirmationBox.Show("本当に取り消しますか？", "キャンセル"))
            {
                e.Cancel = true;
            }
        }
    }
}
