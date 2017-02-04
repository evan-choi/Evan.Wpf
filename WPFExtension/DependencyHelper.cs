using System;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WPFExtension
{
    public class DependencyHelperException : Exception
    {
        public DependencyHelperException(string message) : base(message)
        {
        }
    }

    public static class DependencyHelper
    {
        private const string NameRulePattern = @"[A-Z]\w*Property";
        private const string NameRuleKeyPattern = @"[A-Z]\w*PropertyKey";

        private const string NamePattern = @"[A-Z]\w*(?=Property)";
        private const string NameKeyPattern = @"[A-Z]\w*(?=PropertyKey)";

        #region [ 내부 메서드 ]
        private static Type GetDeclaringType(int depth)
        {
            var st = new StackTrace();
            var frame = st.GetFrame(depth);
            var method = frame.GetMethod();

            return method.DeclaringType;
        }

        private static DependencyProperty Register(
            string propName, Type ownerType,
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            PropertyInfo property = ownerType.GetProperty(propName);

            if (property == null)
                throw new DependencyHelperException($"'{propName}'속성을 찾을 수 없습니다.");

            if (typeMetadata == null && validateValueCallback == null)
                return DependencyProperty.Register(propName, property.PropertyType, ownerType);
            else if (typeMetadata != null)
                if (validateValueCallback == null)
                    return DependencyProperty.Register(propName, property.PropertyType, ownerType, typeMetadata);
                else
                    return DependencyProperty.Register(propName, property.PropertyType, ownerType, typeMetadata, validateValueCallback);

            throw new ArgumentException();
        }

        private static DependencyPropertyKey RegisterReadOnly(
            string propName, Type ownerType,
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            PropertyInfo property = ownerType.GetProperty(propName);

            if (property == null)
                throw new DependencyHelperException($"'{propName}'속성을 찾을 수 없습니다.");

            if (typeMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterReadOnly(propName, property.PropertyType, ownerType, typeMetadata);
            else
                return DependencyProperty.RegisterReadOnly(propName, property.PropertyType, ownerType, typeMetadata, validateValueCallback);

            throw new ArgumentException();
        }

        private static DependencyProperty RegisterAttached(
            string propName, Type ownerType,
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            PropertyInfo property = ownerType.GetProperty(propName);

            if (property == null)
                throw new DependencyHelperException($"'{propName}'속성을 찾을 수 없습니다.");

            if (typeMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterAttached(propName, property.PropertyType, ownerType, typeMetadata);
            else
                return DependencyProperty.RegisterAttached(propName, property.PropertyType, ownerType, typeMetadata, validateValueCallback);

            throw new ArgumentException();
        }

        private static DependencyPropertyKey RegisterAttachedReadOnly(
            string propName, Type ownerType,
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null)
        {
            PropertyInfo property = ownerType.GetProperty(propName);

            if (property == null)
                throw new DependencyHelperException($"'{propName}'속성을 찾을 수 없습니다.");

            if (typeMetadata == null && validateValueCallback == null)
                return DependencyProperty.RegisterAttachedReadOnly(propName, property.PropertyType, ownerType, typeMetadata);
            else
                return DependencyProperty.RegisterAttachedReadOnly(propName, property.PropertyType, ownerType, typeMetadata, validateValueCallback);

            throw new ArgumentException();
        }

        #endregion

        #region [ 사용자 메서드 - 등록 ]
        public static DependencyProperty Register(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return Register(propName, ownerType, typeMetadata);
        }

        public static DependencyPropertyKey RegisterReadOnly(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRuleKeyPattern))
                throw new DependencyHelperException("종속성 읽기 전용 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NameKeyPattern).Value;

            return RegisterReadOnly(propName, ownerType, typeMetadata);
        }

        public static DependencyProperty RegisterAttached(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return RegisterAttached(propName, ownerType, typeMetadata);
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return RegisterAttachedReadOnly(propName, ownerType, typeMetadata);
        }

        public static DependencyProperty Register<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return DependencyProperty.Register(propName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterReadOnly<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return DependencyProperty.RegisterReadOnly(propName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyProperty RegisterAttached<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return DependencyProperty.RegisterAttached(propName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
            [CallerMemberName]string dpPropName = "")
        {
            // 소유자 정보
            Type ownerType = GetDeclaringType(2);

            if (!Regex.IsMatch(dpPropName, NameRulePattern))
                throw new DependencyHelperException("종속성 속성 명명규칙에 어긋납니다.");

            // 대상 속성
            string propName = Regex.Match(dpPropName, NamePattern).Value;

            return DependencyProperty.RegisterAttachedReadOnly(propName, typeof(T), ownerType, metadata, validateValueCallback);
        }
        #endregion

        #region [ 사용자 메서드 - Descriptor ]
        public static void AddValueChanged(this DependencyProperty property, DependencyObject element, EventHandler handler)
        {
            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            descriptor.AddValueChanged(element, handler);
        }

        public static void RemoveValueChanged(this DependencyProperty property, DependencyObject element, EventHandler handler)
        {
            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            descriptor.RemoveValueChanged(element, handler);
        }

        public static bool IsSupportValueChangedEventg(this DependencyProperty property)
        {
            var descriptor = DependencyPropertyDescriptor.FromProperty(property, property.OwnerType);
            return descriptor.SupportsChangeEvents;
        }
        #endregion
    }
}