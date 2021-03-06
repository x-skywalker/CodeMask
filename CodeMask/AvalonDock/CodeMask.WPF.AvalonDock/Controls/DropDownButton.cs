﻿/************************************************************************

   AvalonDock

   




 


   

  **********************************************************************/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CodeMask.WPF.AvalonDock.Controls
{
    public class DropDownButton : ToggleButton
    {
        public DropDownButton()
        {
            Unloaded += DropDownButton_Unloaded;
        }

        protected override void OnClick()
        {
            if (DropDownContextMenu != null)
            {
                //IsChecked = true;
                DropDownContextMenu.PlacementTarget = this;
                DropDownContextMenu.Placement = PlacementMode.Bottom;
                DropDownContextMenu.DataContext = DropDownContextMenuDataContext;
                DropDownContextMenu.Closed += OnContextMenuClosed;
                DropDownContextMenu.IsOpen = true;
            }

            base.OnClick();
        }

        private void OnContextMenuClosed(object sender, RoutedEventArgs e)
        {
            //Debug.Assert(IsChecked.GetValueOrDefault());
            var ctxMenu = sender as ContextMenu;
            ctxMenu.Closed -= OnContextMenuClosed;
            IsChecked = false;
        }

        private void DropDownButton_Unloaded(object sender, RoutedEventArgs e)
        {
            DropDownContextMenu = null;
        }

        #region DropDownContextMenu

        /// <summary>
        ///     DropDownContextMenu Dependency Property
        /// </summary>
        public static readonly DependencyProperty DropDownContextMenuProperty =
            DependencyProperty.Register("DropDownContextMenu", typeof (ContextMenu), typeof (DropDownButton),
                new FrameworkPropertyMetadata(null,
                    OnDropDownContextMenuChanged));

        /// <summary>
        ///     Gets or sets the DropDownContextMenu property.  This dependency property
        ///     indicates drop down menu to show up when user click on an anchorable menu pin.
        /// </summary>
        public ContextMenu DropDownContextMenu
        {
            get { return (ContextMenu) GetValue(DropDownContextMenuProperty); }
            set { SetValue(DropDownContextMenuProperty, value); }
        }

        /// <summary>
        ///     Handles changes to the DropDownContextMenu property.
        /// </summary>
        private static void OnDropDownContextMenuChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DropDownButton) d).OnDropDownContextMenuChanged(e);
        }

        /// <summary>
        ///     Provides derived classes an opportunity to handle changes to the DropDownContextMenu property.
        /// </summary>
        protected virtual void OnDropDownContextMenuChanged(DependencyPropertyChangedEventArgs e)
        {
            var oldContextMenu = e.OldValue as ContextMenu;
            if (oldContextMenu != null && IsChecked.GetValueOrDefault())
                oldContextMenu.Closed -= OnContextMenuClosed;
        }

        #endregion

        #region DropDownContextMenuDataContext

        /// <summary>
        ///     DropDownContextMenuDataContext Dependency Property
        /// </summary>
        public static readonly DependencyProperty DropDownContextMenuDataContextProperty =
            DependencyProperty.Register("DropDownContextMenuDataContext", typeof (object), typeof (DropDownButton),
                new FrameworkPropertyMetadata((object) null));

        /// <summary>
        ///     Gets or sets the DropDownContextMenuDataContext property.  This dependency property
        ///     indicates data context to set for drop down context menu.
        /// </summary>
        public object DropDownContextMenuDataContext
        {
            get { return GetValue(DropDownContextMenuDataContextProperty); }
            set { SetValue(DropDownContextMenuDataContextProperty, value); }
        }

        #endregion
    }
}