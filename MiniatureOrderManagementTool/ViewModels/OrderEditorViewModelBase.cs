using System;
using System.Collections.Generic;
using System.Text;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderEditorViewModelBase : CommonOrderEditorViewModel
    {
        public IConfirmationBox ConfirmationBox { get; set; }

        public void Cancel(IClosable closable)
        {
            if (this.ConfirmationBox.Show("本当に取り消しますか？", "キャンセル"))
            {
                closable.Close();
            }
        }
    }
}
