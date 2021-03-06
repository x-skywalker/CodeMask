﻿/************************************************************************

   AvalonDock

   




 


   

  **********************************************************************/

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CodeMask.WPF.AvalonDock.Converters
{
    [ValueConversion(typeof (bool), typeof (Visibility))]
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members 

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && targetType == typeof (Visibility))
            {
                var val = !(bool) value;
                if (val)
                    return Visibility.Visible;
                if (parameter != null && parameter is Visibility)
                    return parameter;
                return Visibility.Collapsed;
            }
            throw new ArgumentException(
                "Invalid argument/return type. Expected argument: bool and return type: Visibility");
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility && targetType == typeof (bool))
            {
                var val = (Visibility) value;
                if (val == Visibility.Visible)
                    return false;
                return true;
            }
            throw new ArgumentException(
                "Invalid argument/return type. Expected argument: Visibility and return type: bool");
        }

        #endregion
    }
}