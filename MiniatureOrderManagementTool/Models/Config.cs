﻿using System.Windows;

namespace MiniatureOrderManagementTool.Models
{
    public class Config
    {
        public int DatabaseVersion { get; set; }
        public Point MainWindowPosition { get; set; }
        public Size MainWindowSize { get; set; }
        public Point OrderEditorWindowDelta { get; set; }
        public Size OrderEditorWindowSize { get; set; }

        public Config()
        {
        }

        public Config(Dtos.Config config)
        {
            this.DatabaseVersion = config.DatabaseVersion;
            this.MainWindowPosition = config.MainWindowPosition;
            this.MainWindowSize = config.MainWindowSize;
            this.OrderEditorWindowDelta = config.OrderEditorWindowDelta;
            this.OrderEditorWindowSize = config.OrderEditorWindowSize;
        }
    }
}