// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Globalization;
using Xunit;

namespace System.Tests
{
    public class UInt64Tests_GenericMath
    {
        //
        // IAdditionOperators
        //

        [Fact]
        public static void op_AdditionTest()
        {
            Assert.Equal((ulong)0x0000000000000001, AdditionOperatorsHelper<ulong, ulong, ulong>.op_Addition((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000002, AdditionOperatorsHelper<ulong, ulong, ulong>.op_Addition((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x8000000000000000, AdditionOperatorsHelper<ulong, ulong, ulong>.op_Addition((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000001, AdditionOperatorsHelper<ulong, ulong, ulong>.op_Addition((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000000, AdditionOperatorsHelper<ulong, ulong, ulong>.op_Addition((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_CheckedAdditionTest()
        {
            Assert.Equal((ulong)0x0000000000000001, AdditionOperatorsHelper<ulong, ulong, ulong>.op_CheckedAddition((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000002, AdditionOperatorsHelper<ulong, ulong, ulong>.op_CheckedAddition((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x8000000000000000, AdditionOperatorsHelper<ulong, ulong, ulong>.op_CheckedAddition((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000001, AdditionOperatorsHelper<ulong, ulong, ulong>.op_CheckedAddition((ulong)0x8000000000000000, 1));

            Assert.Throws<OverflowException>(() => AdditionOperatorsHelper<ulong, ulong, ulong>.op_CheckedAddition((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        //
        // IAdditiveIdentity
        //

        [Fact]
        public static void AdditiveIdentityTest()
        {
            Assert.Equal((ulong)0x0000000000000000, AdditiveIdentityHelper<ulong, ulong>.AdditiveIdentity);
        }

        //
        // IBinaryInteger
        //

        [Fact]
        public static void DivRemTest()
        {
            Assert.Equal(((ulong)0x0000000000000000, (ulong)0x0000000000000000), BinaryIntegerHelper<ulong>.DivRem((ulong)0x0000000000000000, 2));
            Assert.Equal(((ulong)0x0000000000000000, (ulong)0x0000000000000001), BinaryIntegerHelper<ulong>.DivRem((ulong)0x0000000000000001, 2));
            Assert.Equal(((ulong)0x3FFFFFFFFFFFFFFF, (ulong)0x0000000000000001), BinaryIntegerHelper<ulong>.DivRem((ulong)0x7FFFFFFFFFFFFFFF, 2));
            Assert.Equal(((ulong)0x4000000000000000, (ulong)0x0000000000000000), BinaryIntegerHelper<ulong>.DivRem((ulong)0x8000000000000000, 2));
            Assert.Equal(((ulong)0x7FFFFFFFFFFFFFFF, (ulong)0x0000000000000001), BinaryIntegerHelper<ulong>.DivRem((ulong)0xFFFFFFFFFFFFFFFF, 2));
        }

        [Fact]
        public static void LeadingZeroCountTest()
        {
            Assert.Equal((ulong)0x0000000000000040, BinaryIntegerHelper<ulong>.LeadingZeroCount((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x000000000000003F, BinaryIntegerHelper<ulong>.LeadingZeroCount((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x0000000000000001, BinaryIntegerHelper<ulong>.LeadingZeroCount((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.LeadingZeroCount((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.LeadingZeroCount((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void PopCountTest()
        {
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.PopCount((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, BinaryIntegerHelper<ulong>.PopCount((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x000000000000003F, BinaryIntegerHelper<ulong>.PopCount((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x0000000000000001, BinaryIntegerHelper<ulong>.PopCount((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000040, BinaryIntegerHelper<ulong>.PopCount((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void RotateLeftTest()
        {
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.RotateLeft((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000002, BinaryIntegerHelper<ulong>.RotateLeft((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, BinaryIntegerHelper<ulong>.RotateLeft((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000001, BinaryIntegerHelper<ulong>.RotateLeft((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, BinaryIntegerHelper<ulong>.RotateLeft((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void RotateRightTest()
        {
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.RotateRight((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x8000000000000000, BinaryIntegerHelper<ulong>.RotateRight((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0xBFFFFFFFFFFFFFFF, BinaryIntegerHelper<ulong>.RotateRight((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x4000000000000000, BinaryIntegerHelper<ulong>.RotateRight((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, BinaryIntegerHelper<ulong>.RotateRight((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void TrailingZeroCountTest()
        {
            Assert.Equal((ulong)0x0000000000000040, BinaryIntegerHelper<ulong>.TrailingZeroCount((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.TrailingZeroCount((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.TrailingZeroCount((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x000000000000003F, BinaryIntegerHelper<ulong>.TrailingZeroCount((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000000, BinaryIntegerHelper<ulong>.TrailingZeroCount((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void GetByteCountTest()
        {
            Assert.Equal(8, BinaryIntegerHelper<ulong>.GetByteCount((ulong)0x0000000000000000));
            Assert.Equal(8, BinaryIntegerHelper<ulong>.GetByteCount((ulong)0x0000000000000001));
            Assert.Equal(8, BinaryIntegerHelper<ulong>.GetByteCount((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal(8, BinaryIntegerHelper<ulong>.GetByteCount((ulong)0x8000000000000000));
            Assert.Equal(8, BinaryIntegerHelper<ulong>.GetByteCount((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void GetShortestBitLengthTest()
        {
            Assert.Equal(0x00, BinaryIntegerHelper<ulong>.GetShortestBitLength((ulong)0x0000000000000000));
            Assert.Equal(0x01, BinaryIntegerHelper<ulong>.GetShortestBitLength((ulong)0x0000000000000001));
            Assert.Equal(0x3F, BinaryIntegerHelper<ulong>.GetShortestBitLength((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal(0x40, BinaryIntegerHelper<ulong>.GetShortestBitLength((ulong)0x8000000000000000));
            Assert.Equal(0x40, BinaryIntegerHelper<ulong>.GetShortestBitLength((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void TryWriteBigEndianTest()
        {
            Span<byte> destination = stackalloc byte[8];
            int bytesWritten = 0;

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteBigEndian((ulong)0x0000000000000000, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteBigEndian((ulong)0x0000000000000001, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteBigEndian((ulong)0x7FFFFFFFFFFFFFFF, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteBigEndian((ulong)0x8000000000000000, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteBigEndian((ulong)0xFFFFFFFFFFFFFFFF, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, destination.ToArray());

            Assert.False(BinaryIntegerHelper<ulong>.TryWriteBigEndian(default, Span<byte>.Empty, out bytesWritten));
            Assert.Equal(0, bytesWritten);
            Assert.Equal(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, destination.ToArray());
        }

        [Fact]
        public static void TryWriteLittleEndianTest()
        {
            Span<byte> destination = stackalloc byte[8];
            int bytesWritten = 0;

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteLittleEndian((ulong)0x0000000000000000, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteLittleEndian((ulong)0x0000000000000001, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteLittleEndian((ulong)0x7FFFFFFFFFFFFFFF, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteLittleEndian((ulong)0x8000000000000000, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, destination.ToArray());

            Assert.True(BinaryIntegerHelper<ulong>.TryWriteLittleEndian((ulong)0xFFFFFFFFFFFFFFFF, destination, out bytesWritten));
            Assert.Equal(8, bytesWritten);
            Assert.Equal(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, destination.ToArray());

            Assert.False(BinaryIntegerHelper<ulong>.TryWriteLittleEndian(default, Span<byte>.Empty, out bytesWritten));
            Assert.Equal(0, bytesWritten);
            Assert.Equal(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, destination.ToArray());
        }

        //
        // IBinaryNumber
        //

        [Fact]
        public static void IsPow2Test()
        {
            Assert.False(BinaryNumberHelper<ulong>.IsPow2((ulong)0x0000000000000000));
            Assert.True(BinaryNumberHelper<ulong>.IsPow2((ulong)0x0000000000000001));
            Assert.False(BinaryNumberHelper<ulong>.IsPow2((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.True(BinaryNumberHelper<ulong>.IsPow2((ulong)0x8000000000000000));
            Assert.False(BinaryNumberHelper<ulong>.IsPow2((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void Log2Test()
        {
            Assert.Equal((ulong)0x0000000000000000, BinaryNumberHelper<ulong>.Log2((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000000, BinaryNumberHelper<ulong>.Log2((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x000000000000003E, BinaryNumberHelper<ulong>.Log2((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x000000000000003F, BinaryNumberHelper<ulong>.Log2((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x000000000000003F, BinaryNumberHelper<ulong>.Log2((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // IBitwiseOperators
        //

        [Fact]
        public static void op_BitwiseAndTest()
        {
            Assert.Equal((ulong)0x0000000000000000, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseAnd((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseAnd((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseAnd((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000000, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseAnd((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseAnd((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_BitwiseOrTest()
        {
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseOr((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseOr((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseOr((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseOr((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_BitwiseOr((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_ExclusiveOrTest()
        {
            Assert.Equal((ulong)0x0000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_ExclusiveOr((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000000, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_ExclusiveOr((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFE, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_ExclusiveOr((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000001, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_ExclusiveOr((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_ExclusiveOr((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_OnesComplementTest()
        {
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_OnesComplement((ulong)0x0000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_OnesComplement((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x8000000000000000, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_OnesComplement((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_OnesComplement((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000000, BitwiseOperatorsHelper<ulong, ulong, ulong>.op_OnesComplement((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // IComparisonOperators
        //

        [Fact]
        public static void op_GreaterThanTest()
        {
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThan((ulong)0x0000000000000000, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThan((ulong)0x0000000000000001, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThan((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThan((ulong)0x8000000000000000, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThan((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_GreaterThanOrEqualTest()
        {
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThanOrEqual((ulong)0x0000000000000000, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThanOrEqual((ulong)0x0000000000000001, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThanOrEqual((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThanOrEqual((ulong)0x8000000000000000, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_GreaterThanOrEqual((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_LessThanTest()
        {
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_LessThan((ulong)0x0000000000000000, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThan((ulong)0x0000000000000001, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThan((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThan((ulong)0x8000000000000000, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThan((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_LessThanOrEqualTest()
        {
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_LessThanOrEqual((ulong)0x0000000000000000, 1));
            Assert.True(ComparisonOperatorsHelper<ulong, ulong>.op_LessThanOrEqual((ulong)0x0000000000000001, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThanOrEqual((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThanOrEqual((ulong)0x8000000000000000, 1));
            Assert.False(ComparisonOperatorsHelper<ulong, ulong>.op_LessThanOrEqual((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        //
        // IDecrementOperators
        //

        [Fact]
        public static void op_DecrementTest()
        {
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, DecrementOperatorsHelper<ulong>.op_Decrement((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000000, DecrementOperatorsHelper<ulong>.op_Decrement((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFE, DecrementOperatorsHelper<ulong>.op_Decrement((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, DecrementOperatorsHelper<ulong>.op_Decrement((ulong)0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, DecrementOperatorsHelper<ulong>.op_Decrement((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void op_CheckedDecrementTest()
        {
            Assert.Equal((ulong)0x0000000000000000, DecrementOperatorsHelper<ulong>.op_CheckedDecrement((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFE, DecrementOperatorsHelper<ulong>.op_CheckedDecrement((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, DecrementOperatorsHelper<ulong>.op_CheckedDecrement((ulong)0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, DecrementOperatorsHelper<ulong>.op_CheckedDecrement((ulong)0xFFFFFFFFFFFFFFFF));

            Assert.Throws<OverflowException>(() => DecrementOperatorsHelper<ulong>.op_CheckedDecrement((ulong)0x0000000000000000));
        }

        //
        // IDivisionOperators
        //

        [Fact]
        public static void op_DivisionTest()
        {
            Assert.Equal((ulong)0x0000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0x0000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0x0000000000000001, 2));
            Assert.Equal((ulong)0x3FFFFFFFFFFFFFFF, DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0x7FFFFFFFFFFFFFFF, 2));
            Assert.Equal((ulong)0x4000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0x8000000000000000, 2));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0xFFFFFFFFFFFFFFFF, 2));

            Assert.Throws<DivideByZeroException>(() => DivisionOperatorsHelper<ulong, ulong, ulong>.op_Division((ulong)0x0000000000000001, 0));
        }

        [Fact]
        public static void op_CheckedDivisionTest()
        {
            Assert.Equal((ulong)0x0000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0x0000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0x0000000000000001, 2));
            Assert.Equal((ulong)0x3FFFFFFFFFFFFFFF, DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0x7FFFFFFFFFFFFFFF, 2));
            Assert.Equal((ulong)0x4000000000000000, DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0x8000000000000000, 2));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0xFFFFFFFFFFFFFFFF, 2));

            Assert.Throws<DivideByZeroException>(() => DivisionOperatorsHelper<ulong, ulong, ulong>.op_CheckedDivision((ulong)0x0000000000000001, 0));
        }

        //
        // IEqualityOperators
        //

        [Fact]
        public static void op_EqualityTest()
        {
            Assert.False(EqualityOperatorsHelper<ulong, ulong>.op_Equality((ulong)0x0000000000000000, 1));
            Assert.True(EqualityOperatorsHelper<ulong, ulong>.op_Equality((ulong)0x0000000000000001, 1));
            Assert.False(EqualityOperatorsHelper<ulong, ulong>.op_Equality((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.False(EqualityOperatorsHelper<ulong, ulong>.op_Equality((ulong)0x8000000000000000, 1));
            Assert.False(EqualityOperatorsHelper<ulong, ulong>.op_Equality((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_InequalityTest()
        {
            Assert.True(EqualityOperatorsHelper<ulong, ulong>.op_Inequality((ulong)0x0000000000000000, 1));
            Assert.False(EqualityOperatorsHelper<ulong, ulong>.op_Inequality((ulong)0x0000000000000001, 1));
            Assert.True(EqualityOperatorsHelper<ulong, ulong>.op_Inequality((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.True(EqualityOperatorsHelper<ulong, ulong>.op_Inequality((ulong)0x8000000000000000, 1));
            Assert.True(EqualityOperatorsHelper<ulong, ulong>.op_Inequality((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        //
        // IIncrementOperators
        //

        [Fact]
        public static void op_IncrementTest()
        {
            Assert.Equal((ulong)0x0000000000000001, IncrementOperatorsHelper<ulong>.op_Increment((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000002, IncrementOperatorsHelper<ulong>.op_Increment((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x8000000000000000, IncrementOperatorsHelper<ulong>.op_Increment((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000001, IncrementOperatorsHelper<ulong>.op_Increment((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000000, IncrementOperatorsHelper<ulong>.op_Increment((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void op_CheckedIncrementTest()
        {
            Assert.Equal((ulong)0x0000000000000001, IncrementOperatorsHelper<ulong>.op_CheckedIncrement((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000002, IncrementOperatorsHelper<ulong>.op_CheckedIncrement((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x8000000000000000, IncrementOperatorsHelper<ulong>.op_CheckedIncrement((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000001, IncrementOperatorsHelper<ulong>.op_CheckedIncrement((ulong)0x8000000000000000));

            Assert.Throws<OverflowException>(() => IncrementOperatorsHelper<ulong>.op_CheckedIncrement((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // IMinMaxValue
        //

        [Fact]
        public static void MaxValueTest()
        {
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, MinMaxValueHelper<ulong>.MaxValue);
        }

        [Fact]
        public static void MinValueTest()
        {
            Assert.Equal((ulong)0x0000000000000000, MinMaxValueHelper<ulong>.MinValue);
        }

        //
        // IModulusOperators
        //

        [Fact]
        public static void op_ModulusTest()
        {
            Assert.Equal((ulong)0x0000000000000000, ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0x0000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000001, ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0x0000000000000001, 2));
            Assert.Equal((ulong)0x0000000000000001, ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0x7FFFFFFFFFFFFFFF, 2));
            Assert.Equal((ulong)0x0000000000000000, ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0x8000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000001, ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0xFFFFFFFFFFFFFFFF, 2));

            Assert.Throws<DivideByZeroException>(() => ModulusOperatorsHelper<ulong, ulong, ulong>.op_Modulus((ulong)0x0000000000000001, 0));
        }

        //
        // IMultiplicativeIdentity
        //

        [Fact]
        public static void MultiplicativeIdentityTest()
        {
            Assert.Equal((ulong)0x0000000000000001, MultiplicativeIdentityHelper<ulong, ulong>.MultiplicativeIdentity);
        }

        //
        // IMultiplyOperators
        //

        [Fact]
        public static void op_MultiplyTest()
        {
            Assert.Equal((ulong)0x0000000000000000, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_Multiply((ulong)0x0000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000002, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_Multiply((ulong)0x0000000000000001, 2));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_Multiply((ulong)0x7FFFFFFFFFFFFFFF, 2));
            Assert.Equal((ulong)0x0000000000000000, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_Multiply((ulong)0x8000000000000000, 2));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_Multiply((ulong)0xFFFFFFFFFFFFFFFF, 2));
        }
        [Fact]
        public static void op_CheckedMultiplyTest()
        {
            Assert.Equal((ulong)0x0000000000000000, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_CheckedMultiply((ulong)0x0000000000000000, 2));
            Assert.Equal((ulong)0x0000000000000002, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_CheckedMultiply((ulong)0x0000000000000001, 2));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, MultiplyOperatorsHelper<ulong, ulong, ulong>.op_CheckedMultiply((ulong)0x7FFFFFFFFFFFFFFF, 2));

            Assert.Throws<OverflowException>(() => MultiplyOperatorsHelper<ulong, ulong, ulong>.op_CheckedMultiply((ulong)0x8000000000000000, 2));
            Assert.Throws<OverflowException>(() => MultiplyOperatorsHelper<ulong, ulong, ulong>.op_CheckedMultiply((ulong)0xFFFFFFFFFFFFFFFF, 2));
        }

        //
        // INumber
        //

        [Fact]
        public static void ClampTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Clamp((ulong)0x0000000000000000, 0x0001, 0x003F));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Clamp((ulong)0x0000000000000001, 0x0001, 0x003F));
            Assert.Equal((ulong)0x000000000000003F, NumberHelper<ulong>.Clamp((ulong)0x7FFFFFFFFFFFFFFF, 0x0001, 0x003F));
            Assert.Equal((ulong)0x000000000000003F, NumberHelper<ulong>.Clamp((ulong)0x8000000000000000, 0x0001, 0x003F));
            Assert.Equal((ulong)0x000000000000003F, NumberHelper<ulong>.Clamp((ulong)0xFFFFFFFFFFFFFFFF, 0x0001, 0x003F));
        }

        [Fact]
        public static void MaxTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Max((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Max((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberHelper<ulong>.Max((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000000, NumberHelper<ulong>.Max((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberHelper<ulong>.Max((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MaxNumberTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MaxNumber((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MaxNumber((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberHelper<ulong>.MaxNumber((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000000, NumberHelper<ulong>.MaxNumber((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberHelper<ulong>.MaxNumber((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MinTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberHelper<ulong>.Min((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Min((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Min((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Min((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.Min((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MinNumberTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberHelper<ulong>.MinNumber((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MinNumber((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MinNumber((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MinNumber((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberHelper<ulong>.MinNumber((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void SignTest()
        {
            Assert.Equal(0, NumberHelper<ulong>.Sign((ulong)0x0000000000000000));
            Assert.Equal(1, NumberHelper<ulong>.Sign((ulong)0x0000000000000001));
            Assert.Equal(1, NumberHelper<ulong>.Sign((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal(1, NumberHelper<ulong>.Sign((ulong)0x8000000000000000));
            Assert.Equal(1, NumberHelper<ulong>.Sign((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // INumberBase
        //

        [Fact]
        public static void OneTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.One);
        }

        [Fact]
        public static void ZeroTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.Zero);
        }

        [Fact]
        public static void AbsTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.Abs((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.Abs((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.Abs((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.Abs((ulong)0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.Abs((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void CreateCheckedFromByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<byte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<byte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateChecked<byte>(0x7F));
            Assert.Equal((ulong)0x0000000000000080, NumberBaseHelper<ulong>.CreateChecked<byte>(0x80));
            Assert.Equal((ulong)0x00000000000000FF, NumberBaseHelper<ulong>.CreateChecked<byte>(0xFF));
        }

        [Fact]
        public static void CreateCheckedFromCharTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<char>((char)0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<char>((char)0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateChecked<char>((char)0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateChecked<char>((char)0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateChecked<char>((char)0xFFFF));
        }

        [Fact]
        public static void CreateCheckedFromInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<short>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<short>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateChecked<short>(0x7FFF));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<short>(unchecked((short)0x8000)));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<short>(unchecked((short)0xFFFF)));
        }

        [Fact]
        public static void CreateCheckedFromInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<int>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<int>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateChecked<int>(0x7FFFFFFF));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<int>(unchecked((int)0x80000000)));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<int>(unchecked((int)0xFFFFFFFF)));
        }

        [Fact]
        public static void CreateCheckedFromInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<long>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<long>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<long>(0x7FFFFFFFFFFFFFFF));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<long>(unchecked((long)0x8000000000000000)));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<long>(unchecked((long)0xFFFFFFFFFFFFFFFF)));
        }

        [Fact]
        public static void CreateCheckedFromIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0x7FFFFFFFFFFFFFFF)));
                Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0x8000000000000000)));
                Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<nint>((nint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<nint>((nint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nint>((nint)0x7FFFFFFF));
                Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0x80000000)));
                Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<nint>(unchecked((nint)0xFFFFFFFF)));
            }
        }

        [Fact]
        public static void CreateCheckedFromSByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<sbyte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<sbyte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateChecked<sbyte>(0x7F));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<sbyte>(unchecked((sbyte)0x80)));
            Assert.Throws<OverflowException>(() => NumberBaseHelper<ulong>.CreateChecked<sbyte>(unchecked((sbyte)0xFF)));
        }

        [Fact]
        public static void CreateCheckedFromUInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<ushort>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<ushort>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateChecked<ushort>(0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateChecked<ushort>(0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateChecked<ushort>(0xFFFF));
        }

        [Fact]
        public static void CreateCheckedFromUInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<uint>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<uint>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateChecked<uint>(0x7FFFFFFF));
            Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateChecked<uint>(0x80000000));
            Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<uint>(0xFFFFFFFF));
        }

        [Fact]
        public static void CreateCheckedFromUInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<ulong>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<ulong>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<ulong>(0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateChecked<ulong>(0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<ulong>(0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void CreateCheckedFromUIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<nuint>(unchecked((nuint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<nuint>(unchecked((nuint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nuint>(unchecked((nuint)0x7FFFFFFFFFFFFFFF)));
                Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateChecked<nuint>(unchecked((nuint)0x8000000000000000)));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nuint>(unchecked((nuint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateChecked<nuint>((nuint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateChecked<nuint>((nuint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nuint>((nuint)0x7FFFFFFF));
                Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateChecked<nuint>((nuint)0x80000000));
                Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateChecked<nuint>((nuint)0xFFFFFFFF));
            }
        }

        [Fact]
        public static void CreateSaturatingFromByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<byte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<byte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateSaturating<byte>(0x7F));
            Assert.Equal((ulong)0x0000000000000080, NumberBaseHelper<ulong>.CreateSaturating<byte>(0x80));
            Assert.Equal((ulong)0x00000000000000FF, NumberBaseHelper<ulong>.CreateSaturating<byte>(0xFF));
        }

        [Fact]
        public static void CreateSaturatingFromCharTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<char>((char)0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<char>((char)0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateSaturating<char>((char)0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateSaturating<char>((char)0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateSaturating<char>((char)0xFFFF));
        }

        [Fact]
        public static void CreateSaturatingFromInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<short>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<short>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateSaturating<short>(0x7FFF));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<short>(unchecked((short)0x8000)));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<short>(unchecked((short)0xFFFF)));
        }

        [Fact]
        public static void CreateSaturatingFromInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<int>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<int>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<int>(0x7FFFFFFF));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<int>(unchecked((int)0x80000000)));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<int>(unchecked((int)0xFFFFFFFF)));
        }

        [Fact]
        public static void CreateSaturatingFromInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<long>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<long>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<long>(0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<long>(unchecked((long)0x8000000000000000)));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<long>(unchecked((long)0xFFFFFFFFFFFFFFFF)));
        }

        [Fact]
        public static void CreateSaturatingFromIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0x7FFFFFFFFFFFFFFF)));
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0x8000000000000000)));
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>((nint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<nint>((nint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nint>((nint)0x7FFFFFFF));
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0x80000000)));
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nint>(unchecked((nint)0xFFFFFFFF)));
            }
        }

        [Fact]
        public static void CreateSaturatingFromSByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<sbyte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<sbyte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateSaturating<sbyte>(0x7F));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<sbyte>(unchecked((sbyte)0x80)));
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<sbyte>(unchecked((sbyte)0xFF)));
        }

        [Fact]
        public static void CreateSaturatingFromUInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<ushort>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<ushort>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateSaturating<ushort>(0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateSaturating<ushort>(0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateSaturating<ushort>(0xFFFF));
        }

        [Fact]
        public static void CreateSaturatingFromUInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<uint>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<uint>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<uint>(0x7FFFFFFF));
            Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateSaturating<uint>(0x80000000));
            Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<uint>(0xFFFFFFFF));
        }

        [Fact]
        public static void CreateSaturatingFromUInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<ulong>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<ulong>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<ulong>(0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateSaturating<ulong>(0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<ulong>(0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void CreateSaturatingFromUIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nuint>(unchecked((nuint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<nuint>(unchecked((nuint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nuint>(unchecked((nuint)0x7FFFFFFFFFFFFFFF)));
                Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nuint>(unchecked((nuint)0x8000000000000000)));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nuint>(unchecked((nuint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateSaturating<nuint>((nuint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateSaturating<nuint>((nuint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nuint>((nuint)0x7FFFFFFF));
                Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateSaturating<nuint>((nuint)0x80000000));
                Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateSaturating<nuint>((nuint)0xFFFFFFFF));
            }
        }

        [Fact]
        public static void CreateTruncatingFromByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<byte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<byte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateTruncating<byte>(0x7F));
            Assert.Equal((ulong)0x0000000000000080, NumberBaseHelper<ulong>.CreateTruncating<byte>(0x80));
            Assert.Equal((ulong)0x00000000000000FF, NumberBaseHelper<ulong>.CreateTruncating<byte>(0xFF));
        }

        [Fact]
        public static void CreateTruncatingFromCharTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<char>((char)0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<char>((char)0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateTruncating<char>((char)0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateTruncating<char>((char)0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateTruncating<char>((char)0xFFFF));
        }

        [Fact]
        public static void CreateTruncatingFromInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<short>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<short>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateTruncating<short>(0x7FFF));
            Assert.Equal((ulong)0xFFFFFFFFFFFF8000, NumberBaseHelper<ulong>.CreateTruncating<short>(unchecked((short)0x8000)));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<short>(unchecked((short)0xFFFF)));
        }

        [Fact]
        public static void CreateTruncatingFromInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<int>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<int>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<int>(0x7FFFFFFF));
            Assert.Equal((ulong)0xFFFFFFFF80000000, NumberBaseHelper<ulong>.CreateTruncating<int>(unchecked((int)0x80000000)));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<int>(unchecked((int)0xFFFFFFFF)));
        }

        [Fact]
        public static void CreateTruncatingFromInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<long>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<long>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<long>(0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateTruncating<long>(unchecked((long)0x8000000000000000)));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<long>(unchecked((long)0xFFFFFFFFFFFFFFFF)));
        }

        [Fact]
        public static void CreateTruncatingFromIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0x7FFFFFFFFFFFFFFF)));
                Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0x8000000000000000)));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nint>((nint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<nint>((nint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nint>((nint)0x7FFFFFFF));
                Assert.Equal((ulong)0xFFFFFFFF80000000, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0x80000000)));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nint>(unchecked((nint)0xFFFFFFFF)));
            }
        }

        [Fact]
        public static void CreateTruncatingFromSByteTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<sbyte>(0x00));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<sbyte>(0x01));
            Assert.Equal((ulong)0x000000000000007F, NumberBaseHelper<ulong>.CreateTruncating<sbyte>(0x7F));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFF80, NumberBaseHelper<ulong>.CreateTruncating<sbyte>(unchecked((sbyte)0x80)));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<sbyte>(unchecked((sbyte)0xFF)));
        }

        [Fact]
        public static void CreateTruncatingFromUInt16Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<ushort>(0x0000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<ushort>(0x0001));
            Assert.Equal((ulong)0x0000000000007FFF, NumberBaseHelper<ulong>.CreateTruncating<ushort>(0x7FFF));
            Assert.Equal((ulong)0x0000000000008000, NumberBaseHelper<ulong>.CreateTruncating<ushort>(0x8000));
            Assert.Equal((ulong)0x000000000000FFFF, NumberBaseHelper<ulong>.CreateTruncating<ushort>(0xFFFF));
        }

        [Fact]
        public static void CreateTruncatingFromUInt32Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<uint>(0x00000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<uint>(0x00000001));
            Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<uint>(0x7FFFFFFF));
            Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateTruncating<uint>(0x80000000));
            Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<uint>(0xFFFFFFFF));
        }

        [Fact]
        public static void CreateTruncatingFromUInt64Test()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<ulong>(0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<ulong>(0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<ulong>(0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateTruncating<ulong>(0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<ulong>(0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void CreateTruncatingFromUIntPtrTest()
        {
            if (Environment.Is64BitProcess)
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nuint>(unchecked((nuint)0x0000000000000000)));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<nuint>(unchecked((nuint)0x0000000000000001)));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nuint>(unchecked((nuint)0x7FFFFFFFFFFFFFFF)));
                Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nuint>(unchecked((nuint)0x8000000000000000)));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nuint>(unchecked((nuint)0xFFFFFFFFFFFFFFFF)));
            }
            else
            {
                Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.CreateTruncating<nuint>((nuint)0x00000000));
                Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.CreateTruncating<nuint>((nuint)0x00000001));
                Assert.Equal((ulong)0x000000007FFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nuint>((nuint)0x7FFFFFFF));
                Assert.Equal((ulong)0x0000000080000000, NumberBaseHelper<ulong>.CreateTruncating<nuint>((nuint)0x80000000));
                Assert.Equal((ulong)0x00000000FFFFFFFF, NumberBaseHelper<ulong>.CreateTruncating<nuint>((nuint)0xFFFFFFFF));
            }
        }

        [Fact]
        public static void IsFiniteTest()
        {
            Assert.True(NumberBaseHelper<ulong>.IsFinite((ulong)0x0000000000000000));
            Assert.True(NumberBaseHelper<ulong>.IsFinite((ulong)0x0000000000000001));
            Assert.True(NumberBaseHelper<ulong>.IsFinite((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.True(NumberBaseHelper<ulong>.IsFinite((ulong)0x8000000000000000));
            Assert.True(NumberBaseHelper<ulong>.IsFinite((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsInfinityTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsInfinity((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsInfinity((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsInfinity((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsInfinity((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsInfinity((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsNaNTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsNaN((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNaN((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsNaN((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsNaN((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNaN((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsNegativeTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsNegative((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNegative((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsNegative((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsNegative((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNegative((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsNegativeInfinityTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsNegativeInfinity((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNegativeInfinity((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsNegativeInfinity((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsNegativeInfinity((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsNegativeInfinity((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsNormalTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsNormal((ulong)0x0000000000000000));
            Assert.True(NumberBaseHelper<ulong>.IsNormal((ulong)0x0000000000000001));
            Assert.True(NumberBaseHelper<ulong>.IsNormal((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.True(NumberBaseHelper<ulong>.IsNormal((ulong)0x8000000000000000));
            Assert.True(NumberBaseHelper<ulong>.IsNormal((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsPositiveInfinityTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsPositiveInfinity((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsPositiveInfinity((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsPositiveInfinity((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsPositiveInfinity((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsPositiveInfinity((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void IsSubnormalTest()
        {
            Assert.False(NumberBaseHelper<ulong>.IsSubnormal((ulong)0x0000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsSubnormal((ulong)0x0000000000000001));
            Assert.False(NumberBaseHelper<ulong>.IsSubnormal((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.False(NumberBaseHelper<ulong>.IsSubnormal((ulong)0x8000000000000000));
            Assert.False(NumberBaseHelper<ulong>.IsSubnormal((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void MaxMagnitudeTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MaxMagnitude((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MaxMagnitude((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.MaxMagnitude((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.MaxMagnitude((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.MaxMagnitude((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MaxMagnitudeNumberTest()
        {
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MaxMagnitudeNumber((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MaxMagnitudeNumber((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.MaxMagnitudeNumber((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x8000000000000000, NumberBaseHelper<ulong>.MaxMagnitudeNumber((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, NumberBaseHelper<ulong>.MaxMagnitudeNumber((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MinMagnitudeTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.MinMagnitude((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitude((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitude((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitude((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitude((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void MinMagnitudeNumberTest()
        {
            Assert.Equal((ulong)0x0000000000000000, NumberBaseHelper<ulong>.MinMagnitudeNumber((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitudeNumber((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitudeNumber((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitudeNumber((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000001, NumberBaseHelper<ulong>.MinMagnitudeNumber((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void TryCreateFromByteTest()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<byte>(0x00, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<byte>(0x01, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<byte>(0x7F, out result));
            Assert.Equal((ulong)0x000000000000007F, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<byte>(0x80, out result));
            Assert.Equal((ulong)0x0000000000000080, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<byte>(0xFF, out result));
            Assert.Equal((ulong)0x00000000000000FF, result);
        }

        [Fact]
        public static void TryCreateFromCharTest()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<char>((char)0x0000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<char>((char)0x0001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<char>((char)0x7FFF, out result));
            Assert.Equal((ulong)0x0000000000007FFF, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<char>((char)0x8000, out result));
            Assert.Equal((ulong)0x0000000000008000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<char>((char)0xFFFF, out result));
            Assert.Equal((ulong)0x000000000000FFFF, result);
        }

        [Fact]
        public static void TryCreateFromInt16Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<short>(0x0000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<short>(0x0001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<short>(0x7FFF, out result));
            Assert.Equal((ulong)0x0000000000007FFF, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<short>(unchecked((short)0x8000), out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<short>(unchecked((short)0xFFFF), out result));
            Assert.Equal((ulong)0x0000000000000000, result);
        }

        [Fact]
        public static void TryCreateFromInt32Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<int>(0x00000000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<int>(0x00000001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<int>(0x7FFFFFFF, out result));
            Assert.Equal((ulong)0x000000007FFFFFFF, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<int>(unchecked((int)0x80000000), out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<int>(unchecked((int)0xFFFFFFFF), out result));
            Assert.Equal((ulong)0x0000000000000000, result);
        }

        [Fact]
        public static void TryCreateFromInt64Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<long>(0x0000000000000000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<long>(0x0000000000000001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<long>(0x7FFFFFFFFFFFFFFF, out result));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<long>(unchecked((long)0x8000000000000000), out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<long>(unchecked((long)0xFFFFFFFFFFFFFFFF), out result));
            Assert.Equal((ulong)0x0000000000000000, result);
        }

        [Fact]
        public static void TryCreateFromIntPtrTest()
        {
            ulong result;

            if (Environment.Is64BitProcess)
            {
                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0x0000000000000000), out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0x0000000000000001), out result));
                Assert.Equal((ulong)0x0000000000000001, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0x7FFFFFFFFFFFFFFF), out result));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, result);

                Assert.False(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0x8000000000000000), out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.False(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0xFFFFFFFFFFFFFFFF), out result));
                Assert.Equal((ulong)0x0000000000000000, result);
            }
            else
            {
                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>((nint)0x00000000, out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>((nint)0x00000001, out result));
                Assert.Equal((ulong)0x0000000000000001, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nint>((nint)0x7FFFFFFF, out result));
                Assert.Equal((ulong)0x000000007FFFFFFF, result);

                Assert.False(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0x80000000), out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.False(NumberBaseHelper<ulong>.TryCreate<nint>(unchecked((nint)0xFFFFFFFF), out result));
                Assert.Equal((ulong)0x0000000000000000, result);
            }
        }

        [Fact]
        public static void TryCreateFromSByteTest()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<sbyte>(0x00, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<sbyte>(0x01, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<sbyte>(0x7F, out result));
            Assert.Equal((ulong)0x000000000000007F, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<sbyte>(unchecked((sbyte)0x80), out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.False(NumberBaseHelper<ulong>.TryCreate<sbyte>(unchecked((sbyte)0xFF), out result));
            Assert.Equal((ulong)0x0000000000000000, result);
        }

        [Fact]
        public static void TryCreateFromUInt16Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ushort>(0x0000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ushort>(0x0001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ushort>(0x7FFF, out result));
            Assert.Equal((ulong)0x0000000000007FFF, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ushort>(0x8000, out result));
            Assert.Equal((ulong)0x0000000000008000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ushort>(0xFFFF, out result));
            Assert.Equal((ulong)0x000000000000FFFF, result);
        }

        [Fact]
        public static void TryCreateFromUInt32Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<uint>(0x00000000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<uint>(0x00000001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<uint>(0x7FFFFFFF, out result));
            Assert.Equal((ulong)0x000000007FFFFFFF, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<uint>(0x80000000, out result));
            Assert.Equal((ulong)0x0000000080000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<uint>(0xFFFFFFFF, out result));
            Assert.Equal((ulong)0x00000000FFFFFFFF, result);
        }

        [Fact]
        public static void TryCreateFromUInt64Test()
        {
            ulong result;

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ulong>(0x0000000000000000, out result));
            Assert.Equal((ulong)0x0000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ulong>(0x0000000000000001, out result));
            Assert.Equal((ulong)0x0000000000000001, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ulong>(0x7FFFFFFFFFFFFFFF, out result));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ulong>(0x8000000000000000, out result));
            Assert.Equal((ulong)0x8000000000000000, result);

            Assert.True(NumberBaseHelper<ulong>.TryCreate<ulong>(0xFFFFFFFFFFFFFFFF, out result));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, result);
        }

        [Fact]
        public static void TryCreateFromUIntPtrTest()
        {
            ulong result;

            if (Environment.Is64BitProcess)
            {
                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0x0000000000000000), out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0x0000000000000001), out result));
                Assert.Equal((ulong)0x0000000000000001, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0x7FFFFFFFFFFFFFFF), out result));
                Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0x8000000000000000), out result));
                Assert.Equal((ulong)0x8000000000000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0xFFFFFFFFFFFFFFFF), out result));
                Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, result);
            }
            else
            {
                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>((nuint)0x00000000, out result));
                Assert.Equal((ulong)0x0000000000000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>((nuint)0x00000001, out result));
                Assert.Equal((ulong)0x0000000000000001, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>((nuint)0x7FFFFFFF, out result));
                Assert.Equal((ulong)0x000000007FFFFFFF, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0x80000000), out result));
                Assert.Equal((ulong)0x0000000080000000, result);

                Assert.True(NumberBaseHelper<ulong>.TryCreate<nuint>(unchecked((nuint)0xFFFFFFFF), out result));
                Assert.Equal((ulong)0x00000000FFFFFFFF, result);
            }
        }

        //
        // IShiftOperators
        //

        [Fact]
        public static void op_LeftShiftTest()
        {
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_LeftShift((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000002, ShiftOperatorsHelper<ulong, ulong>.op_LeftShift((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, ShiftOperatorsHelper<ulong, ulong>.op_LeftShift((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_LeftShift((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, ShiftOperatorsHelper<ulong, ulong>.op_LeftShift((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_RightShiftTest()
        {
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_RightShift((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_RightShift((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x3FFFFFFFFFFFFFFF, ShiftOperatorsHelper<ulong, ulong>.op_RightShift((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x4000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_RightShift((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, ShiftOperatorsHelper<ulong, ulong>.op_RightShift((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_UnsignedRightShiftTest()
        {
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_UnsignedRightShift((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_UnsignedRightShift((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x3FFFFFFFFFFFFFFF, ShiftOperatorsHelper<ulong, ulong>.op_UnsignedRightShift((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x4000000000000000, ShiftOperatorsHelper<ulong, ulong>.op_UnsignedRightShift((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, ShiftOperatorsHelper<ulong, ulong>.op_UnsignedRightShift((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        //
        // ISubtractionOperators
        //

        [Fact]
        public static void op_SubtractionTest()
        {
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_Subtraction((ulong)0x0000000000000000, 1));
            Assert.Equal((ulong)0x0000000000000000, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_Subtraction((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFE, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_Subtraction((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_Subtraction((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_Subtraction((ulong)0xFFFFFFFFFFFFFFFF, 1));
        }

        [Fact]
        public static void op_CheckedSubtractionTest()
        {
            Assert.Equal((ulong)0x0000000000000000, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_CheckedSubtraction((ulong)0x0000000000000001, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFE, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_CheckedSubtraction((ulong)0x7FFFFFFFFFFFFFFF, 1));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_CheckedSubtraction((ulong)0x8000000000000000, 1));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFE, SubtractionOperatorsHelper<ulong, ulong, ulong>.op_CheckedSubtraction((ulong)0xFFFFFFFFFFFFFFFF, 1));

            Assert.Throws<OverflowException>(() => SubtractionOperatorsHelper<ulong, ulong, ulong>.op_CheckedSubtraction((ulong)0x0000000000000000, 1));
        }

        //
        // IUnaryNegationOperators
        //

        [Fact]
        public static void op_UnaryNegationTest()
        {
            Assert.Equal((ulong)0x0000000000000000, UnaryNegationOperatorsHelper<ulong, ulong>.op_UnaryNegation((ulong)0x0000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, UnaryNegationOperatorsHelper<ulong, ulong>.op_UnaryNegation((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x8000000000000001, UnaryNegationOperatorsHelper<ulong, ulong>.op_UnaryNegation((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, UnaryNegationOperatorsHelper<ulong, ulong>.op_UnaryNegation((ulong)0x8000000000000000));
            Assert.Equal((ulong)0x0000000000000001, UnaryNegationOperatorsHelper<ulong, ulong>.op_UnaryNegation((ulong)0xFFFFFFFFFFFFFFFF));
        }

        [Fact]
        public static void op_CheckedUnaryNegationTest()
        {
            Assert.Equal((ulong)0x0000000000000000, UnaryNegationOperatorsHelper<ulong, ulong>.op_CheckedUnaryNegation((ulong)0x0000000000000000));

            Assert.Throws<OverflowException>(() => UnaryNegationOperatorsHelper<ulong, ulong>.op_CheckedUnaryNegation((ulong)0x0000000000000001));
            Assert.Throws<OverflowException>(() => UnaryNegationOperatorsHelper<ulong, ulong>.op_CheckedUnaryNegation((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Throws<OverflowException>(() => UnaryNegationOperatorsHelper<ulong, ulong>.op_CheckedUnaryNegation((ulong)0x8000000000000000));
            Assert.Throws<OverflowException>(() => UnaryNegationOperatorsHelper<ulong, ulong>.op_CheckedUnaryNegation((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // IUnaryPlusOperators
        //

        [Fact]
        public static void op_UnaryPlusTest()
        {
            Assert.Equal((ulong)0x0000000000000000, UnaryPlusOperatorsHelper<ulong, ulong>.op_UnaryPlus((ulong)0x0000000000000000));
            Assert.Equal((ulong)0x0000000000000001, UnaryPlusOperatorsHelper<ulong, ulong>.op_UnaryPlus((ulong)0x0000000000000001));
            Assert.Equal((ulong)0x7FFFFFFFFFFFFFFF, UnaryPlusOperatorsHelper<ulong, ulong>.op_UnaryPlus((ulong)0x7FFFFFFFFFFFFFFF));
            Assert.Equal((ulong)0x8000000000000000, UnaryPlusOperatorsHelper<ulong, ulong>.op_UnaryPlus((ulong)0x8000000000000000));
            Assert.Equal((ulong)0xFFFFFFFFFFFFFFFF, UnaryPlusOperatorsHelper<ulong, ulong>.op_UnaryPlus((ulong)0xFFFFFFFFFFFFFFFF));
        }

        //
        // IParsable and ISpanParsable
        //

        [Theory]
        [MemberData(nameof(UInt64Tests.Parse_Valid_TestData), MemberType = typeof(UInt64Tests))]
        public static void ParseValidStringTest(string value, NumberStyles style, IFormatProvider provider, ulong expected)
        {
            ulong result;

            // Default style and provider
            if ((style == NumberStyles.Integer) && (provider is null))
            {
                Assert.True(ParsableHelper<ulong>.TryParse(value, provider, out result));
                Assert.Equal(expected, result);
                Assert.Equal(expected, ParsableHelper<ulong>.Parse(value, provider));
            }

            // Default provider
            if (provider is null)
            {
                Assert.Equal(expected, NumberBaseHelper<ulong>.Parse(value, style, provider));

                // Substitute default NumberFormatInfo
                Assert.True(NumberBaseHelper<ulong>.TryParse(value, style, new NumberFormatInfo(), out result));
                Assert.Equal(expected, result);
                Assert.Equal(expected, NumberBaseHelper<ulong>.Parse(value, style, new NumberFormatInfo()));
            }

            // Default style
            if (style == NumberStyles.Integer)
            {
                Assert.Equal(expected, ParsableHelper<ulong>.Parse(value, provider));
            }

            // Full overloads
            Assert.True(NumberBaseHelper<ulong>.TryParse(value, style, provider, out result));
            Assert.Equal(expected, result);
            Assert.Equal(expected, NumberBaseHelper<ulong>.Parse(value, style, provider));
        }

        [Theory]
        [MemberData(nameof(UInt64Tests.Parse_Invalid_TestData), MemberType = typeof(UInt64Tests))]
        public static void ParseInvalidStringTest(string value, NumberStyles style, IFormatProvider provider, Type exceptionType)
        {
            ulong result;

            // Default style and provider
            if ((style == NumberStyles.Integer) && (provider is null))
            {
                Assert.False(ParsableHelper<ulong>.TryParse(value, provider, out result));
                Assert.Equal(default(ulong), result);
                Assert.Throws(exceptionType, () => ParsableHelper<ulong>.Parse(value, provider));
            }

            // Default provider
            if (provider is null)
            {
                Assert.Throws(exceptionType, () => NumberBaseHelper<ulong>.Parse(value, style, provider));

                // Substitute default NumberFormatInfo
                Assert.False(NumberBaseHelper<ulong>.TryParse(value, style, new NumberFormatInfo(), out result));
                Assert.Equal(default(ulong), result);
                Assert.Throws(exceptionType, () => NumberBaseHelper<ulong>.Parse(value, style, new NumberFormatInfo()));
            }

            // Default style
            if (style == NumberStyles.Integer)
            {
                Assert.Throws(exceptionType, () => ParsableHelper<ulong>.Parse(value, provider));
            }

            // Full overloads
            Assert.False(NumberBaseHelper<ulong>.TryParse(value, style, provider, out result));
            Assert.Equal(default(ulong), result);
            Assert.Throws(exceptionType, () => NumberBaseHelper<ulong>.Parse(value, style, provider));
        }

        [Theory]
        [MemberData(nameof(UInt64Tests.Parse_ValidWithOffsetCount_TestData), MemberType = typeof(UInt64Tests))]
        public static void ParseValidSpanTest(string value, int offset, int count, NumberStyles style, IFormatProvider provider, ulong expected)
        {
            ulong result;

            // Default style and provider
            if ((style == NumberStyles.Integer) && (provider is null))
            {
                Assert.True(SpanParsableHelper<ulong>.TryParse(value.AsSpan(offset, count), provider, out result));
                Assert.Equal(expected, result);
            }

            Assert.Equal(expected, NumberBaseHelper<ulong>.Parse(value.AsSpan(offset, count), style, provider));

            Assert.True(NumberBaseHelper<ulong>.TryParse(value.AsSpan(offset, count), style, provider, out result));
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(UInt64Tests.Parse_Invalid_TestData), MemberType = typeof(UInt64Tests))]
        public static void ParseInvalidSpanTest(string value, NumberStyles style, IFormatProvider provider, Type exceptionType)
        {
            if (value is null)
            {
                return;
            }

            ulong result;

            // Default style and provider
            if ((style == NumberStyles.Integer) && (provider is null))
            {
                Assert.False(SpanParsableHelper<ulong>.TryParse(value.AsSpan(), provider, out result));
                Assert.Equal(default(ulong), result);
            }

            Assert.Throws(exceptionType, () => NumberBaseHelper<ulong>.Parse(value.AsSpan(), style, provider));

            Assert.False(NumberBaseHelper<ulong>.TryParse(value.AsSpan(), style, provider, out result));
            Assert.Equal(default(ulong), result);
        }
    }
}
