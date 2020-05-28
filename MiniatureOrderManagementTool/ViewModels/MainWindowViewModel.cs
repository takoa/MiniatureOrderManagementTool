﻿using MiniatureOrderManagementTool.Models;
using ReactiveUI;
using System.Windows;

namespace MiniatureOrderManagementTool.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly Config config;

        private double left;
        public double Left
        {
            get => this.left;
            set
            {
                this.RaiseAndSetIfChanged(ref this.left, value);
                this.config.MainWindowPosition = new Point(value, this.config.MainWindowPosition.Y);
            }
        }

        private double top;
        public double Top
        {
            get => this.top;
            set
            {
                this.RaiseAndSetIfChanged(ref this.top, value);
                this.config.MainWindowPosition = new Point(this.config.MainWindowPosition.X, value);
            }
        }

        private double width;
        public double Width
        {
            get => this.width;
            set
            {
                this.RaiseAndSetIfChanged(ref this.width, value);
                this.config.MainWindowSize = new Size(value, this.config.MainWindowSize.Height);
            }
        }

        private double height;
        public double Height
        {
            get => this.height;
            set
            {
                this.RaiseAndSetIfChanged(ref this.height, value);
                this.config.MainWindowSize = new Size(this.config.MainWindowSize.Width, value);
            }
        }

        public MainWindowViewModel(Config config)
        {
            this.config = config;

            this.Left = this.config.MainWindowPosition.X;
            this.Top = this.config.MainWindowPosition.Y;
            this.Width = this.config.MainWindowSize.Width;
            this.Height = this.config.MainWindowSize.Height;
        }
    }
}
