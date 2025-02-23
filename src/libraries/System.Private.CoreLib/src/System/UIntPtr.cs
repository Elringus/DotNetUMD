// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;

#pragma warning disable SA1121 // explicitly using type aliases instead of built-in types

#if TARGET_64BIT
using nuint_t = System.UInt64;
#else
using nuint_t = System.UInt32;
#endif

namespace System
{
    [Serializable]
    [CLSCompliant(false)]
    [StructLayout(LayoutKind.Sequential)]
    [TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public readonly struct UIntPtr
        : IEquatable<nuint>,
          IComparable,
          IComparable<nuint>,
          ISpanFormattable,
          ISerializable,
          IBinaryInteger<nuint>,
          IMinMaxValue<nuint>,
          IUnsignedNumber<nuint>
    {
        private readonly nuint _value;

        [Intrinsic]
        public static readonly nuint Zero;

        [NonVersionable]
        public UIntPtr(uint value)
        {
            _value = value;
        }

        [NonVersionable]
        public UIntPtr(ulong value)
        {
#if TARGET_64BIT
            _value = (nuint)value;
#else
            _value = checked((nuint)value);
#endif
        }

        [NonVersionable]
        public unsafe UIntPtr(void* value)
        {
            _value = (nuint)value;
        }

        private UIntPtr(SerializationInfo info, StreamingContext context)
        {
            ulong value = info.GetUInt64("value");

#if TARGET_32BIT
            if (value > uint.MaxValue)
            {
                throw new ArgumentException(SR.Serialization_InvalidPtrValue);
            }
#endif

            _value = (nuint)value;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ArgumentNullException.ThrowIfNull(info);

            ulong value = _value;
            info.AddValue("value", value);
        }

        public override bool Equals([NotNullWhen(true)] object? obj) => (obj is nuint other) && Equals(other);

        public override int GetHashCode()
        {
#if TARGET_64BIT
            ulong value = _value;
            return value.GetHashCode();
#else
            return (int)_value;
#endif
        }

        [NonVersionable]
        public uint ToUInt32()
        {
#if TARGET_64BIT
            return checked((uint)_value);
#else
            return (uint)_value;
#endif
        }

        [NonVersionable]
        public ulong ToUInt64() => _value;

        [NonVersionable]
        public static explicit operator nuint(uint value) => value;

        [NonVersionable]
        public static explicit operator nuint(ulong value) => checked((nuint)value);

        [NonVersionable]
        public static unsafe explicit operator nuint(void* value) => (nuint)value;

        [NonVersionable]
        public static unsafe explicit operator void*(nuint value) => (void*)value;

        [NonVersionable]
        public static explicit operator uint(nuint value)
        {
#if TARGET_64BIT
            return checked((uint)value);
#else
            return (uint)value;
#endif
        }

        [NonVersionable]
        public static explicit operator ulong(nuint value) => value;

        [NonVersionable]
        public static bool operator ==(nuint value1, nuint value2) => value1 == value2;

        [NonVersionable]
        public static bool operator !=(nuint value1, nuint value2) => value1 != value2;

        [NonVersionable]
        public static nuint Add(nuint pointer, int offset) => pointer + (nuint)offset;

        [NonVersionable]
        public static nuint operator +(nuint pointer, int offset) => pointer + (nuint)offset;

        [NonVersionable]
        public static nuint Subtract(nuint pointer, int offset) => pointer - (nuint)offset;

        [NonVersionable]
        public static nuint operator -(nuint pointer, int offset) => pointer - (nuint)offset;

        public static int Size
        {
            [NonVersionable]
            get => sizeof(nuint_t);
        }

        [NonVersionable]
        public unsafe void* ToPointer() => (void*)_value;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        public static nuint MaxValue
        {
            [NonVersionable]
            get => unchecked((nuint)nuint_t.MaxValue);
        }

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        public static nuint MinValue
        {
            [NonVersionable]
            get => unchecked((nuint)nuint_t.MinValue);
        }

        public int CompareTo(object? value)
        {
            if (value is nuint other)
            {
                return CompareTo(other);
            }
            else if (value is null)
            {
                return 1;
            }

            throw new ArgumentException(SR.Arg_MustBeUIntPtr);
        }

        public int CompareTo(nuint value)
        {
            if (_value < value) return -1;
            if (_value > value) return 1;
            return 0;
        }

        [NonVersionable]
        public bool Equals(nuint other) => _value == other;

        public override string ToString() => ((nuint_t)_value).ToString();
        public string ToString([StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format) => ((nuint_t)_value).ToString(format);
        public string ToString(IFormatProvider? provider) => ((nuint_t)_value).ToString(provider);
        public string ToString([StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format, IFormatProvider? provider) => ((nuint_t)_value).ToString(format, provider);

        public bool TryFormat(Span<char> destination, out int charsWritten, [StringSyntax(StringSyntaxAttribute.NumericFormat)] ReadOnlySpan<char> format = default, IFormatProvider? provider = null) =>
            ((nuint_t)_value).TryFormat(destination, out charsWritten, format, provider);

        public static nuint Parse(string s) => (nuint)nuint_t.Parse(s);
        public static nuint Parse(string s, NumberStyles style) => (nuint)nuint_t.Parse(s, style);
        public static nuint Parse(string s, IFormatProvider? provider) => (nuint)nuint_t.Parse(s, provider);
        public static nuint Parse(string s, NumberStyles style, IFormatProvider? provider) => (nuint)nuint_t.Parse(s, style, provider);
        public static nuint Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => (nuint)nuint_t.Parse(s, provider);
        public static nuint Parse(ReadOnlySpan<char> s, NumberStyles style = NumberStyles.Integer, IFormatProvider? provider = null) => (nuint)nuint_t.Parse(s, style, provider);

        public static bool TryParse([NotNullWhen(true)] string? s, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, provider, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, style, provider, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        public static bool TryParse(ReadOnlySpan<char> s, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, provider, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out nuint result)
        {
            Unsafe.SkipInit(out result);
            return nuint_t.TryParse(s, style, provider, out Unsafe.As<nuint, nuint_t>(ref result));
        }

        //
        // IAdditionOperators
        //

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        static nuint IAdditionOperators<nuint, nuint, nuint>.operator +(nuint left, nuint right) => left + right;

        /// <inheritdoc cref="IAdditionOperators{TSelf, TOther, TResult}.op_Addition(TSelf, TOther)" />
        static nuint IAdditionOperators<nuint, nuint, nuint>.operator checked +(nuint left, nuint right) => checked(left + right);

        //
        // IAdditiveIdentity
        //

        /// <inheritdoc cref="IAdditiveIdentity{TSelf, TResult}.AdditiveIdentity" />
        static nuint IAdditiveIdentity<nuint, nuint>.AdditiveIdentity => 0;

        //
        // IBinaryInteger
        //

        /// <inheritdoc cref="IBinaryInteger{TSelf}.DivRem(TSelf, TSelf)" />
        public static (nuint Quotient, nuint Remainder) DivRem(nuint left, nuint right) => Math.DivRem(left, right);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.LeadingZeroCount(TSelf)" />
        public static nuint LeadingZeroCount(nuint value) => (nuint)BitOperations.LeadingZeroCount(value);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.PopCount(TSelf)" />
        public static nuint PopCount(nuint value) => (nuint)BitOperations.PopCount(value);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.RotateLeft(TSelf, int)" />
        public static nuint RotateLeft(nuint value, int rotateAmount) => BitOperations.RotateLeft(value, rotateAmount);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.RotateRight(TSelf, int)" />
        public static nuint RotateRight(nuint value, int rotateAmount) => BitOperations.RotateRight(value, rotateAmount);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.TrailingZeroCount(TSelf)" />
        public static nuint TrailingZeroCount(nuint value) => (nuint)BitOperations.TrailingZeroCount(value);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.GetShortestBitLength()" />
        int IBinaryInteger<nuint>.GetShortestBitLength() => (sizeof(nuint_t) * 8) - BitOperations.LeadingZeroCount(_value);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.GetByteCount()" />
        int IBinaryInteger<nuint>.GetByteCount() => sizeof(nuint_t);

        /// <inheritdoc cref="IBinaryInteger{TSelf}.TryWriteBigEndian(Span{byte}, out int)" />
        bool IBinaryInteger<nuint>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten)
        {
            if (destination.Length >= sizeof(nuint_t))
            {
                nuint_t value = (nuint_t)_value;

                if (BitConverter.IsLittleEndian)
                {
                    value = BinaryPrimitives.ReverseEndianness(value);
                }
                Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);

                bytesWritten = sizeof(nuint_t);
                return true;
            }
            else
            {
                bytesWritten = 0;
                return false;
            }
        }

        /// <inheritdoc cref="IBinaryInteger{TSelf}.TryWriteLittleEndian(Span{byte}, out int)" />
        bool IBinaryInteger<nuint>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten)
        {
            if (destination.Length >= sizeof(nuint_t))
            {
                nuint_t value = (nuint_t)_value;

                if (!BitConverter.IsLittleEndian)
                {
                    value = BinaryPrimitives.ReverseEndianness(value);
                }
                Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(destination), value);

                bytesWritten = sizeof(nuint_t);
                return true;
            }
            else
            {
                bytesWritten = 0;
                return false;
            }
        }

        //
        // IBinaryNumber
        //

        /// <inheritdoc cref="IBinaryNumber{TSelf}.IsPow2(TSelf)" />
        public static bool IsPow2(nuint value) => BitOperations.IsPow2(value);

        /// <inheritdoc cref="IBinaryNumber{TSelf}.Log2(TSelf)" />
        public static nuint Log2(nuint value) => (nuint)BitOperations.Log2(value);

        //
        // IBitwiseOperators
        //

        /// <inheritdoc cref="IBitwiseOperators{TSelf, TOther, TResult}.op_BitwiseAnd(TSelf, TOther)" />
        static nuint IBitwiseOperators<nuint, nuint, nuint>.operator &(nuint left, nuint right) => left & right;

        /// <inheritdoc cref="IBitwiseOperators{TSelf, TOther, TResult}.op_BitwiseOr(TSelf, TOther)" />
        static nuint IBitwiseOperators<nuint, nuint, nuint>.operator |(nuint left, nuint right) => left | right;

        /// <inheritdoc cref="IBitwiseOperators{TSelf, TOther, TResult}.op_ExclusiveOr(TSelf, TOther)" />
        static nuint IBitwiseOperators<nuint, nuint, nuint>.operator ^(nuint left, nuint right) => left ^ right;

        /// <inheritdoc cref="IBitwiseOperators{TSelf, TOther, TResult}.op_OnesComplement(TSelf)" />
        static nuint IBitwiseOperators<nuint, nuint, nuint>.operator ~(nuint value) => ~value;

        //
        // IComparisonOperators
        //

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther}.op_LessThan(TSelf, TOther)" />
        static bool IComparisonOperators<nuint, nuint>.operator <(nuint left, nuint right) => left < right;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther}.op_LessThanOrEqual(TSelf, TOther)" />
        static bool IComparisonOperators<nuint, nuint>.operator <=(nuint left, nuint right) => left <= right;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther}.op_GreaterThan(TSelf, TOther)" />
        static bool IComparisonOperators<nuint, nuint>.operator >(nuint left, nuint right) => left > right;

        /// <inheritdoc cref="IComparisonOperators{TSelf, TOther}.op_GreaterThanOrEqual(TSelf, TOther)" />
        static bool IComparisonOperators<nuint, nuint>.operator >=(nuint left, nuint right) => left >= right;

        //
        // IDecrementOperators
        //

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        static nuint IDecrementOperators<nuint>.operator --(nuint value) => --value;

        /// <inheritdoc cref="IDecrementOperators{TSelf}.op_Decrement(TSelf)" />
        static nuint IDecrementOperators<nuint>.operator checked --(nuint value) => checked(--value);

        //
        // IDivisionOperators
        //

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_Division(TSelf, TOther)" />
        static nuint IDivisionOperators<nuint, nuint, nuint>.operator /(nuint left, nuint right) => left / right;

        /// <inheritdoc cref="IDivisionOperators{TSelf, TOther, TResult}.op_CheckedDivision(TSelf, TOther)" />
        static nuint IDivisionOperators<nuint, nuint, nuint>.operator checked /(nuint left, nuint right) => left / right;

        //
        // IIncrementOperators
        //

        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_Increment(TSelf)" />
        static nuint IIncrementOperators<nuint>.operator ++(nuint value) => ++value;

        /// <inheritdoc cref="IIncrementOperators{TSelf}.op_CheckedIncrement(TSelf)" />
        static nuint IIncrementOperators<nuint>.operator checked ++(nuint value) => checked(++value);

        //
        // IMinMaxValue
        //

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MinValue" />
        static nuint IMinMaxValue<nuint>.MinValue => MinValue;

        /// <inheritdoc cref="IMinMaxValue{TSelf}.MaxValue" />
        static nuint IMinMaxValue<nuint>.MaxValue => MaxValue;

        //
        // IModulusOperators
        //

        /// <inheritdoc cref="IModulusOperators{TSelf, TOther, TResult}.op_Modulus(TSelf, TOther)" />
        static nuint IModulusOperators<nuint, nuint, nuint>.operator %(nuint left, nuint right) => left % right;

        //
        // IMultiplicativeIdentity
        //

        /// <inheritdoc cref="IMultiplicativeIdentity{TSelf, TResult}.MultiplicativeIdentity" />
        static nuint IMultiplicativeIdentity<nuint, nuint>.MultiplicativeIdentity => 1;

        //
        // IMultiplyOperators
        //

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_Multiply(TSelf, TOther)" />
        static nuint IMultiplyOperators<nuint, nuint, nuint>.operator *(nuint left, nuint right) => left * right;

        /// <inheritdoc cref="IMultiplyOperators{TSelf, TOther, TResult}.op_CheckedMultiply(TSelf, TOther)" />
        static nuint IMultiplyOperators<nuint, nuint, nuint>.operator checked *(nuint left, nuint right) => checked(left * right);

        //
        // INumber
        //

        /// <inheritdoc cref="INumber{TSelf}.Clamp(TSelf, TSelf, TSelf)" />
        public static nuint Clamp(nuint value, nuint min, nuint max) => Math.Clamp(value, min, max);

        /// <inheritdoc cref="INumber{TSelf}.CopySign(TSelf, TSelf)" />
        static nuint INumber<nuint>.CopySign(nuint value, nuint sign) => value;

        /// <inheritdoc cref="INumber{TSelf}.Max(TSelf, TSelf)" />
        public static nuint Max(nuint x, nuint y) => Math.Max(x, y);

        /// <inheritdoc cref="INumber{TSelf}.MaxNumber(TSelf, TSelf)" />
        static nuint INumber<nuint>.MaxNumber(nuint x, nuint y) => Max(x, y);

        /// <inheritdoc cref="INumber{TSelf}.Min(TSelf, TSelf)" />
        public static nuint Min(nuint x, nuint y) => Math.Min(x, y);

        /// <inheritdoc cref="INumber{TSelf}.MinNumber(TSelf, TSelf)" />
        static nuint INumber<nuint>.MinNumber(nuint x, nuint y) => Min(x, y);

        /// <inheritdoc cref="INumber{TSelf}.Sign(TSelf)" />
        public static int Sign(nuint value) => (value == 0) ? 0 : 1;

        //
        // INumberBase
        //

        /// <inheritdoc cref="INumberBase{TSelf}.One" />
        static nuint INumberBase<nuint>.One => 1;

        /// <inheritdoc cref="INumberBase{TSelf}.Zero" />
        static nuint INumberBase<nuint>.Zero => 0;

        /// <inheritdoc cref="INumberBase{TSelf}.Abs(TSelf)" />
        static nuint INumberBase<nuint>.Abs(nuint value) => value;

        /// <inheritdoc cref="INumberBase{TSelf}.CreateChecked{TOther}(TOther)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint CreateChecked<TOther>(TOther value)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(byte))
            {
                return (byte)(object)value;
            }
            else if (typeof(TOther) == typeof(char))
            {
                return (char)(object)value;
            }
            else if (typeof(TOther) == typeof(decimal))
            {
                return checked((nuint)(decimal)(object)value);
            }
            else if (typeof(TOther) == typeof(double))
            {
                return checked((nuint)(double)(object)value);
            }
            else if (typeof(TOther) == typeof(short))
            {
                return checked((nuint)(short)(object)value);
            }
            else if (typeof(TOther) == typeof(int))
            {
                return checked((nuint)(int)(object)value);
            }
            else if (typeof(TOther) == typeof(long))
            {
                return checked((nuint)(long)(object)value);
            }
            else if (typeof(TOther) == typeof(nint))
            {
                return checked((nuint)(nint)(object)value);
            }
            else if (typeof(TOther) == typeof(sbyte))
            {
                return checked((nuint)(sbyte)(object)value);
            }
            else if (typeof(TOther) == typeof(float))
            {
                return checked((nuint)(float)(object)value);
            }
            else if (typeof(TOther) == typeof(ushort))
            {
                return (ushort)(object)value;
            }
            else if (typeof(TOther) == typeof(uint))
            {
                return (uint)(object)value;
            }
            else if (typeof(TOther) == typeof(ulong))
            {
                return checked((nuint)(ulong)(object)value);
            }
            else if (typeof(TOther) == typeof(nuint))
            {
                return (nuint)(object)value;
            }
            else
            {
                ThrowHelper.ThrowNotSupportedException();
                return default;
            }
        }

        /// <inheritdoc cref="INumberBase{TSelf}.CreateSaturating{TOther}(TOther)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint CreateSaturating<TOther>(TOther value)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(byte))
            {
                return (byte)(object)value;
            }
            else if (typeof(TOther) == typeof(char))
            {
                return (char)(object)value;
            }
            else if (typeof(TOther) == typeof(decimal))
            {
                var actualValue = (decimal)(object)value;
                return (actualValue > nuint.MaxValue) ? MaxValue :
                       (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(double))
            {
                var actualValue = (double)(object)value;
                return (actualValue > nuint.MaxValue) ? MaxValue :
                       (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(short))
            {
                var actualValue = (short)(object)value;
                return (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(int))
            {
                var actualValue = (int)(object)value;
                return (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(long))
            {
                var actualValue = (long)(object)value;

                return ((Size == 4) && (actualValue > uint.MaxValue)) ? MaxValue :
                       (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(nint))
            {
                var actualValue = (nint)(object)value;
                return (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(sbyte))
            {
                var actualValue = (sbyte)(object)value;
                return (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(float))
            {
                var actualValue = (float)(object)value;
                return (actualValue > nuint.MaxValue) ? MaxValue :
                       (actualValue < 0) ? MinValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(ushort))
            {
                return (ushort)(object)value;
            }
            else if (typeof(TOther) == typeof(uint))
            {
                return (uint)(object)value;
            }
            else if (typeof(TOther) == typeof(ulong))
            {
                var actualValue = (ulong)(object)value;
                return (actualValue > nuint.MaxValue) ? MaxValue : (nuint)actualValue;
            }
            else if (typeof(TOther) == typeof(nuint))
            {
                return (nuint)(object)value;
            }
            else
            {
                ThrowHelper.ThrowNotSupportedException();
                return default;
            }
        }

        /// <inheritdoc cref="INumberBase{TSelf}.CreateTruncating{TOther}(TOther)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static nuint CreateTruncating<TOther>(TOther value)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(byte))
            {
                return (byte)(object)value;
            }
            else if (typeof(TOther) == typeof(char))
            {
                return (char)(object)value;
            }
            else if (typeof(TOther) == typeof(decimal))
            {
                return (nuint)(decimal)(object)value;
            }
            else if (typeof(TOther) == typeof(double))
            {
                return (nuint)(double)(object)value;
            }
            else if (typeof(TOther) == typeof(short))
            {
                return (nuint)(short)(object)value;
            }
            else if (typeof(TOther) == typeof(int))
            {
                return (nuint)(int)(object)value;
            }
            else if (typeof(TOther) == typeof(long))
            {
                return (nuint)(long)(object)value;
            }
            else if (typeof(TOther) == typeof(nint))
            {
                return (nuint)(nint)(object)value;
            }
            else if (typeof(TOther) == typeof(sbyte))
            {
                return (nuint)(sbyte)(object)value;
            }
            else if (typeof(TOther) == typeof(float))
            {
                return (nuint)(float)(object)value;
            }
            else if (typeof(TOther) == typeof(ushort))
            {
                return (ushort)(object)value;
            }
            else if (typeof(TOther) == typeof(uint))
            {
                return (uint)(object)value;
            }
            else if (typeof(TOther) == typeof(ulong))
            {
                return (nuint)(ulong)(object)value;
            }
            else if (typeof(TOther) == typeof(nuint))
            {
                return (nuint)(object)value;
            }
            else
            {
                ThrowHelper.ThrowNotSupportedException();
                return default;
            }
        }

        /// <inheritdoc cref="INumberBase{TSelf}.IsFinite(TSelf)" />
        static bool INumberBase<nuint>.IsFinite(nuint value) => true;

        /// <inheritdoc cref="INumberBase{TSelf}.IsInfinity(TSelf)" />
        static bool INumberBase<nuint>.IsInfinity(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNaN(TSelf)" />
        static bool INumberBase<nuint>.IsNaN(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegative(TSelf)" />
        static bool INumberBase<nuint>.IsNegative(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNegativeInfinity(TSelf)" />
        static bool INumberBase<nuint>.IsNegativeInfinity(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsNormal(TSelf)" />
        static bool INumberBase<nuint>.IsNormal(nuint value) => value != 0;

        /// <inheritdoc cref="INumberBase{TSelf}.IsPositiveInfinity(TSelf)" />
        static bool INumberBase<nuint>.IsPositiveInfinity(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.IsSubnormal(TSelf)" />
        static bool INumberBase<nuint>.IsSubnormal(nuint value) => false;

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitude(TSelf, TSelf)" />
        static nuint INumberBase<nuint>.MaxMagnitude(nuint x, nuint y) => Max(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MaxMagnitudeNumber(TSelf, TSelf)" />
        static nuint INumberBase<nuint>.MaxMagnitudeNumber(nuint x, nuint y) => Max(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitude(TSelf, TSelf)" />
        static nuint INumberBase<nuint>.MinMagnitude(nuint x, nuint y) => Min(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.MinMagnitudeNumber(TSelf, TSelf)" />
        static nuint INumberBase<nuint>.MinMagnitudeNumber(nuint x, nuint y) => Min(x, y);

        /// <inheritdoc cref="INumberBase{TSelf}.TryCreate{TOther}(TOther, out TSelf)" />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryCreate<TOther>(TOther value, out nuint result)
            where TOther : INumberBase<TOther>
        {
            if (typeof(TOther) == typeof(byte))
            {
                result = (byte)(object)value;
                return true;
            }
            else if (typeof(TOther) == typeof(char))
            {
                result = (char)(object)value;
                return true;
            }
            else if (typeof(TOther) == typeof(decimal))
            {
                var actualValue = (decimal)(object)value;

                if ((actualValue < 0) || (actualValue > nuint.MaxValue))
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(double))
            {
                var actualValue = (double)(object)value;

                if ((actualValue < 0) || (actualValue > nuint.MaxValue))
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(short))
            {
                var actualValue = (short)(object)value;

                if (actualValue < 0)
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(int))
            {
                var actualValue = (int)(object)value;

                if (actualValue < 0)
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(long))
            {
                var actualValue = (long)(object)value;

                if ((actualValue < 0) || ((Size == 4) && (actualValue > uint.MaxValue)))
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(nint))
            {
                var actualValue = (nint)(object)value;

                if (actualValue < 0)
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(sbyte))
            {
                var actualValue = (sbyte)(object)value;

                if (actualValue < 0)
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(float))
            {
                var actualValue = (float)(object)value;

                if ((actualValue < 0) || (actualValue > nuint.MaxValue))
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(ushort))
            {
                result = (ushort)(object)value;
                return true;
            }
            else if (typeof(TOther) == typeof(uint))
            {
                result = (uint)(object)value;
                return true;
            }
            else if (typeof(TOther) == typeof(ulong))
            {
                var actualValue = (ulong)(object)value;

                if (actualValue > nuint.MaxValue)
                {
                    result = default;
                    return false;
                }

                result = (nuint)actualValue;
                return true;
            }
            else if (typeof(TOther) == typeof(nuint))
            {
                result = (nuint)(object)value;
                return true;
            }
            else
            {
                ThrowHelper.ThrowNotSupportedException();
                result = default;
                return false;
            }
        }

        //
        // IShiftOperators
        //

        /// <inheritdoc cref="IShiftOperators{TSelf, TResult}.op_LeftShift(TSelf, int)" />
        static nuint IShiftOperators<nuint, nuint>.operator <<(nuint value, int shiftAmount) => value << shiftAmount;

        /// <inheritdoc cref="IShiftOperators{TSelf, TResult}.op_RightShift(TSelf, int)" />
        static nuint IShiftOperators<nuint, nuint>.operator >>(nuint value, int shiftAmount) => value >> shiftAmount;

        /// <inheritdoc cref="IShiftOperators{TSelf, TResult}.op_UnsignedRightShift(TSelf, int)" />
        static nuint IShiftOperators<nuint, nuint>.operator >>>(nuint value, int shiftAmount) => value >>> shiftAmount;

        //
        // ISubtractionOperators
        //

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_Subtraction(TSelf, TOther)" />
        static nuint ISubtractionOperators<nuint, nuint, nuint>.operator -(nuint left, nuint right) => left - right;

        /// <inheritdoc cref="ISubtractionOperators{TSelf, TOther, TResult}.op_CheckedSubtraction(TSelf, TOther)" />
        static nuint ISubtractionOperators<nuint, nuint, nuint>.operator checked -(nuint left, nuint right) => checked(left - right);

        //
        // IUnaryNegationOperators
        //

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_UnaryNegation(TSelf)" />
        static nuint IUnaryNegationOperators<nuint, nuint>.operator -(nuint value) => (nuint)0 - value;

        /// <inheritdoc cref="IUnaryNegationOperators{TSelf, TResult}.op_CheckedUnaryNegation(TSelf)" />
        static nuint IUnaryNegationOperators<nuint, nuint>.operator checked -(nuint value) => checked((nuint)0 - value);

        //
        // IUnaryPlusOperators
        //

        /// <inheritdoc cref="IUnaryPlusOperators{TSelf, TResult}.op_UnaryPlus(TSelf)" />
        static nuint IUnaryPlusOperators<nuint, nuint>.operator +(nuint value) => +value;
    }
}
