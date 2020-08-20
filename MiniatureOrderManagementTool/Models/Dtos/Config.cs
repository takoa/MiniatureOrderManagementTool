using System.Windows;

namespace MiniatureOrderManagementTool.Models.Dtos
{
    public class Config
    {
        public int DatabaseVersion { get; set; } = 3;
        public Point MainWindowPosition { get; set; } = new Point(200d, 200d);
        public Size MainWindowSize { get; set; } = new Size(800, 600);
        public Point OrderEditorWindowDelta { get; set; } = new Point(100d, 100d);
        public Size OrderEditorWindowSize { get; set; } = new Size(400, 600);
        public Point OrderCommentReaderWindowDelta { get; set; } = new Point(100d, 100d);
        public Size OrderCommentReaderWindowSize { get; set; } = new Size(400, 600);
    }
}
