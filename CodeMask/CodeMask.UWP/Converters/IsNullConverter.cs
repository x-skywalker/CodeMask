﻿using System;
using Windows.UI.Xaml.Data;

namespace CodeMask.UWP.Converters
{
    /// <summary>
    ///     判断是否为空转换器。
    /// </summary>
    public sealed class IsNullConverter : CoreConverter<IsNullConverter>, IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        ///     转换值。
        /// </summary>
        /// <param name="value">绑定源生成的值。</param>
        /// <param name="targetType">绑定目标属性的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="language">要用在转换器中的区域性。</param>
        /// <returns>转换后的值。如果该方法返回 null，则使用有效的 null 值。</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value == null;
        }

        /// <summary>
        ///     转换值。
        /// </summary>
        /// <param name="value">绑定目标生成的值。</param>
        /// <param name="targetType">要转换到的类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="language">要用在转换器中的区域性。</param>
        /// <returns>转换后的值。如果该方法返回 null，则使用有效的 null 值。</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}