using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace Evan.Wpf
{
    public static partial class DependencyHelper
    {
        private static readonly Regex NamePattern = new Regex(@"[A-Z]\w*(?=Property)");
        private static readonly Regex NameKeyPattern = new Regex(@"[A-Z]\w*(?=PropertyKey)");

        private static PropertyInfo GetPropertyInfo(Type ownerType, string propertyName)
        {
            return
                ownerType.GetProperty(propertyName) ??
                throw new DependencyHelperException($"{ownerType.Name}.{propertyName} property not found.");
        }

        private static Type GetOwnerType()
        {
            var frame = new StackFrame(2);
            var method = frame.GetMethod();

            if (method?.DeclaringType == null || !typeof(DependencyObject).IsAssignableFrom(method?.DeclaringType))
            {
                throw new DependencyHelperException("Owner not found.");
            }

            return method.DeclaringType;
        }

        private static string GetTargetPropertyName(string propertyName)
        {
            var match = NamePattern.Match(propertyName);

            if (!match.Success)
            {
                throw new DependencyHelperException($"'{propertyName}' is violates the {nameof(DependencyProperty)} naming convention.");
            }

            return match.Value;
        }

        private static string GetTargetPropertyKeyName(string propertyKeyName)
        {
            var match = NameKeyPattern.Match(propertyKeyName);

            if (!match.Success)
            {
                throw new DependencyHelperException($"'{propertyKeyName}' is violates the {nameof(DependencyPropertyKey)} naming convention.");
            }

            return match.Value;
        }

        private static DependencyProperty Register(
            string propertyName, Type ownerType,
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var propertyInfo = GetPropertyInfo(ownerType, propertyName);

            switch (typeMetadata)
            {
                case null when validateValueCallback == null:
                    return DependencyProperty.Register(propertyName, propertyInfo.PropertyType, ownerType);

                case null:
                    throw new ArgumentException();
            }

            switch (validateValueCallback)
            {
                case null:
                    return DependencyProperty.Register(propertyName, propertyInfo.PropertyType, ownerType, typeMetadata);

                default:
                    return DependencyProperty.Register(propertyName, propertyInfo.PropertyType, ownerType, typeMetadata, validateValueCallback);
            }
        }

        private static DependencyPropertyKey RegisterReadOnly(
            string propertyName, Type ownerType,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var propertyInfo = GetPropertyInfo(ownerType, propertyName);

            if (propertyMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterReadOnly(propertyName, propertyInfo.PropertyType, ownerType, null);

            return DependencyProperty.RegisterReadOnly(propertyName, propertyInfo.PropertyType, ownerType, propertyMetadata, validateValueCallback);
        }

        private static DependencyProperty RegisterAttached(
            string propertyName, Type ownerType,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var propertyInfo = GetPropertyInfo(ownerType, propertyName);

            if (propertyMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterAttached(propertyName, propertyInfo.PropertyType, ownerType, null);

            return DependencyProperty.RegisterAttached(propertyName, propertyInfo.PropertyType, ownerType, propertyMetadata, validateValueCallback);
        }

        private static DependencyPropertyKey RegisterAttachedReadOnly(
            string propertyName, Type ownerType,
            PropertyMetadata propertyMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            var propertyInfo = GetPropertyInfo(ownerType, propertyName);

            if (propertyMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterAttachedReadOnly(propertyName, propertyInfo.PropertyType, ownerType, null);

            return DependencyProperty.RegisterAttachedReadOnly(propertyName, propertyInfo.PropertyType, ownerType, propertyMetadata, validateValueCallback);
        }
    }
}
