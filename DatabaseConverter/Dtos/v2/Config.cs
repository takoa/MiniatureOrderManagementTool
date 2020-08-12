using System.Windows;

namespace MiniatureOrderManagementTool.DatabaseConverter.Dtos.v2
{
    public class Config
    {
        public Point MainWindowPosition { get; set; }
        public Size MainWindowSize { get; set; }
        public Point OrderEditorWindowDelta { get; set; }
        public Size OrderEditorWindowSize { get; set; }
    }
}
