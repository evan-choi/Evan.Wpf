using System.Windows;
using System.Windows.Data;

namespace WPFExtension
{
    public static class BindingHelper
    {
        public static Binding SetBinding(
            DependencyObject source, string sourcePropertyPath,
            DependencyObject target, DependencyProperty targetProperty,
            BindingMode mode = BindingMode.TwoWay,
            UpdateSourceTrigger sourceTrigger = UpdateSourceTrigger.Default,
            IValueConverter converter = null,
            object fallbackValue = null)
        {
            var result = new Binding(sourcePropertyPath)
            {
                Source = source,
                Mode = mode,
                Converter = converter,
                UpdateSourceTrigger = sourceTrigger
            };

            if (fallbackValue != null)
                result.FallbackValue = fallbackValue;

            BindingOperations.SetBinding(target, targetProperty, result);

            return result;
        }

        public static Binding SetBinding(
            DependencyObject source, DependencyProperty sourceProperty,
            DependencyObject target, DependencyProperty targetProperty,
            BindingMode mode = BindingMode.TwoWay,
            UpdateSourceTrigger sourceTrigger = UpdateSourceTrigger.Default,
            IValueConverter converter = null,
            object fallbackValue = null)
        {
            return BindingHelper.SetBinding(
                source, sourceProperty.Name,
                target, targetProperty,
                mode,
                sourceTrigger,
                converter,
                fallbackValue);
        }

        public static Binding TryBinding(
            DependencyObject source, string sourcePropertyPath,
            DependencyObject target, DependencyProperty targetProperty,
            BindingMode mode = BindingMode.TwoWay,
            UpdateSourceTrigger sourceTrigger = UpdateSourceTrigger.Default,
            IValueConverter converter = null,
            object fallbackValue = null)
        {
            var sourceProperty = source.FindDependencyProperty(sourcePropertyPath);

            if (sourceProperty != null)
            {
                if (source.GetValue(sourceProperty) == null &&
                    sourceProperty.PropertyType == targetProperty.PropertyType)
                {
                    source.SetValue(sourceProperty, target.GetValue(targetProperty));
                }

                return BindingHelper.SetBinding(
                    source, sourceProperty,
                    target, targetProperty,
                    mode, sourceTrigger, converter, fallbackValue);
            }

            return null;
        }

        public static Binding TryBinding(
            DependencyObject source, DependencyProperty sourceProperty,
            DependencyObject target, string targetPropertyPath,
            BindingMode mode = BindingMode.TwoWay,
            UpdateSourceTrigger sourceTrigger = UpdateSourceTrigger.Default,
            IValueConverter converter = null,
            object fallbackValue = null)
        {
            var targetProperty = target.FindDependencyProperty(targetPropertyPath);

            if (targetProperty != null)
            {
                return BindingHelper.SetBinding(
                    source, sourceProperty,
                    target, targetProperty,
                    mode, sourceTrigger, converter, fallbackValue);
            }

            return null;
        }
    }
}
