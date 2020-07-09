using System.Windows;

namespace MiniatureOrderManagementTool.Models.Dtos
{
    public class Config
    {
        public Point MainWindowPosition { get; set; }
        public Size MainWindowSize { get; set; }
        public Point OrderEditorWindowDelta { get; set; }
        public Size OrderEditorWindowSize { get; set; }
    }
}
