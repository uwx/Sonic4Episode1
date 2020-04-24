#nullable enable
using System;
using System.Collections.Generic;

namespace Sonic4Episode1.Core.FUCK
{
    public struct XNullable<T> where T : struct
    {
        private readonly bool _hasValue; // Do not rename (binary serialization)
        internal T UnsafeValue; // Do not rename (binary serialization) or make readonly (can be mutated in ToString, etc.)

        public XNullable(T value)
        {
            UnsafeValue = value;
            _hasValue = true;
        }

        public bool HasValue => _hasValue;

        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    throw new InvalidOperationException($"{nameof(XNullable)} has no value");
                }
                return UnsafeValue;
            }
        }

        public T GetValueOrDefault()
        {
            return UnsafeValue;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            return _hasValue ? UnsafeValue : defaultValue;
        }

        public override bool Equals(object? other)
        {
            if (!_hasValue) return other == null;
            return other != null && UnsafeValue.Equals(other);
        }

        public override int GetHashCode()
        {
            return _hasValue ? UnsafeValue.GetHashCode() : 0;
        }

        public override string? ToString()
        {
            return _hasValue ? UnsafeValue.ToString() : "";
        }

        public static implicit operator XNullable<T>(T value)
        {
            return new XNullable<T>(value);
        }

        public static explicit operator T(XNullable<T> value)
        {
            return value!.UnsafeValue;
        }
    }

    public static class XNullable
    {
        public static int Compare<T>(XNullable<T> n1, XNullable<T> n2) where T : struct
        {
            if (n1.HasValue)
            {
                return n2.HasValue ? Comparer<T>.Default.Compare(n1.UnsafeValue, n2.UnsafeValue) : 1;
            }

            return n2.HasValue ? -1 : 0;
        }

        public static bool Equals<T>(XNullable<T> n1, XNullable<T> n2) where T : struct
        {
            if (n1.HasValue)
            {
                return n2.HasValue && EqualityComparer<T>.Default.Equals(n1.UnsafeValue, n2.UnsafeValue);
            }
            return !n2.HasValue;
        }
    }
}