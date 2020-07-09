namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModelBase : CommonOrderEditorViewModel
    {
        public IConfirmationBox ConfirmationBox { get; set; }
        public IWindow Window { get; set; }

        public void Cancel()
        {
            if (this.ConfirmationBox.Show("本当に取り消しますか？", "キャンセル"))
            {
                this.Window.Close();
            }
        }
    }
}
