using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinitureOrderManagementTool.Helpers
{
    public static class WindowViewHelper
    {
        public static void ShowWindow<T>(T viewModel) where T : ReactiveObject
        {
            var view = Locator.Current.GetService<IViewFor<T>>();

            view.ViewModel = viewModel;

            if (view is ReactiveWindow<T> window)
            {
                window.Show();
            }
        }
    }
}
