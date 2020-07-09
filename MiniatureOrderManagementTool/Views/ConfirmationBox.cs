using MiniatureOrderManagementTool.ViewModels;
using System.Windows;

namespace MiniatureOrderManagementTool.Views
{
    public class ConfirmationBox : IConfirmationBox
    {
        private Window owner;

        public ConfirmationBox()
        {
        }

        public ConfirmationBox(Window owner)
        {
            this.owner = owner;
        }

        public bool Show(string message, string caption)
        {
            var result = MessageBox.Show(this.owner, message, caption, MessageBoxButton.YesNo);

            return result == MessageBoxResult.Yes ? true : false;
        }
    }
}
