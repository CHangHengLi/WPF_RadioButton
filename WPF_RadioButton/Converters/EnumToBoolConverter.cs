using System;
using System.Globalization;
using System.Windows.Data;

namespace RadioButtonDemo.Converters
{
    /// <summary>
    /// 将枚举值转换为布尔值，用于RadioButton的IsChecked绑定
    /// </summary>
    public class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 检查值和参数
            if (value == null || parameter == null) return false;
            
            // 获取枚举值字符串表示
            string enumValue = value.ToString();
            string targetValue = parameter.ToString();
            
            // 比较并返回结果
            return enumValue.Equals(targetValue);
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 如果选中，则返回对应的枚举值
            if (value is bool && (bool)value)
            {
                if (parameter != null)
                {
                    return Enum.Parse(targetType, parameter.ToString());
                }
            }
            
            // 默认返回
            return Binding.DoNothing;
        }
    }
} 