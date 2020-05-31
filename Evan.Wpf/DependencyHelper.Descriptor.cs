using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows;

namespace Evan.Wpf
{
    public static partial class DependencyHelper
    {
#if NETCOREAPP
        public static void AddValueChanged([NotNull] this DependencyProperty property, [NotNull] DependencyObject element, [NotNull] EventHandler handler)
#else
        public static void AddValueChanged(this DependencyProperty property, DependencyObject element, EventHandler handler)
#endif
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            descriptor.AddValueChanged(element, handler);
        }

#if NETCOREAPP
        public static void RemoveValueChanged([NotNull] this DependencyProperty property, [NotNull] DependencyObject element, [NotNull] EventHandler handler)
#else
        public static void RemoveValueChanged(this DependencyProperty property, DependencyObject element, EventHandler handler)
#endif
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            descriptor.RemoveValueChanged(element, handler);
        }

#if NETCOREAPP
        public static bool IsSupportValueChangedEvent([NotNull] this DependencyProperty property)
#else
        public static bool IsSupportValueChangedEvent(this DependencyProperty property)
#endif
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            return descriptor.SupportsChangeEvents;
        }

#if NETCOREAPP
        [return: NotNull]
        public static DependencyProperty GetDependencyProperty([NotNull] this PropertyInfo propertyInfo)
#else
        public static DependencyProperty GetDependencyProperty(this PropertyInfo propertyInfo)
#endif
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }

            string name = $"{propertyInfo.Name}Property";

            // DependencyProperty
            var dpField = propertyInfo.DeclaringType!.GetField(name);

            if (dpField != null)
                return (DependencyProperty)dpField.GetValue(null);

            // DependencyPropertyKey (ReadOnly)
            var dpKeyField = propertyInfo.DeclaringType.GetField($"{propertyInfo.Name}PropertyKey", BindingFlags.NonPublic | BindingFlags.Static);

            var dpKey = (DependencyPropertyKey)dpKeyField?.GetValue(null);

            return dpKey?.DependencyProperty;
        }

#if NETCOREAPP
        [return: NotNull]
        public static DependencyProperty FindDependencyProperty([NotNull] this DependencyObject obj, [NotNull] string propertyName)
#else
        public static DependencyProperty FindDependencyProperty(this DependencyObject obj, string propertyName)
#endif
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            var propertyInfo = GetPropertyInfo(obj.GetType(), propertyName);
            return GetDependencyProperty(propertyInfo);
        }
    }
}
