using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniatureOrderManagementTool.Controls
{
    public class ProgrammaticallySelectableListView : ListView
    {
        private bool isArrowKeysDisabled = false;

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            if (e.AddedItems.Count == 0)
            {
                return;
            }

            this.ItemContainerGenerator.StatusChanged += this.StatusChangedHandler;
            this.isArrowKeysDisabled = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!this.isArrowKeysDisabled)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                case Key.Right:
                case Key.Up:
                case Key.Down:
                    e.Handled = true;

                    break;
            }
        }

        private void StatusChangedHandler(object sender, EventArgs e)
        {
            if (this.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                this.ItemContainerGenerator.StatusChanged -= this.StatusChangedHandler;
                this.isArrowKeysDisabled = false;

                if (this.SelectedItem != null)
                {
                    this.ScrollIntoView(this.SelectedItem);
                    ((UIElement)this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem)).Focus();
                }
            }
        }
    }
}
