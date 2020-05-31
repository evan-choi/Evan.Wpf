#if CALLER_MEMBER_NAME
using System.Runtime.CompilerServices;
#endif
using System.Windows;

namespace Evan.Wpf
{
    public static partial class DependencyHelper
    {
        public static DependencyProperty Register(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return Register(propertyName, ownerType, typeMetadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterReadOnly(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyKeyName = GetTargetPropertyKeyName(dpPropertyName);

            return RegisterReadOnly(propertyKeyName, ownerType, typeMetadata, validateValueCallback);
        }

        public static DependencyProperty RegisterAttached(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return RegisterAttached(propertyName, ownerType, typeMetadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly(
            PropertyMetadata typeMetadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return RegisterAttachedReadOnly(propertyName, ownerType, typeMetadata, validateValueCallback);
        }

        public static DependencyProperty Register<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return DependencyProperty.Register(propertyName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterReadOnly<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return DependencyProperty.RegisterReadOnly(propertyName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyProperty RegisterAttached<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return DependencyProperty.RegisterAttached(propertyName, typeof(T), ownerType, metadata, validateValueCallback);
        }

        public static DependencyPropertyKey RegisterAttachedReadOnly<T>(
            PropertyMetadata metadata = null,
            ValidateValueCallback validateValueCallback = null,
#if CALLER_MEMBER_NAME
            [CallerMemberName] string dpPropertyName = default
#else
            string dpPropertyName = default
#endif
        )
        {
            var ownerType = GetOwnerType();
            var propertyName = GetTargetPropertyName(dpPropertyName);

            return DependencyProperty.RegisterAttachedReadOnly(propertyName, typeof(T), ownerType, metadata, validateValueCallback);
        }
    }
}
