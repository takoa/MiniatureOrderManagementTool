using MiniatureOrderManagementTool.Models;
using ReactiveUI;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class OrderCommentEditorViewModel : ViewModelBase
    {
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

        public void ParseComment()
        {
            var result = PartManager.ParseOrderComment(this.Comment);

            this.ErrorMessages = result.ParseErrors.Count == 0 ? "" : PartManager.GetErrorString(result.ParseErrors);
        }
    }
}
