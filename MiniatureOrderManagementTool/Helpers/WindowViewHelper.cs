using ReactiveUI;
using Splat;

namespace MiniatureOrderManagementTool.Helpers
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
