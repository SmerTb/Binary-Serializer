using System;

namespace BinarySerializer.DefaultTypes
{
    public class CInt64 : AbstractType,IConvertible
    {
        long i64value;
        public new object realValue { get { return i64value; } set { i64value = (CInt64)value; } }

        public CInt64()
        { len = 8; i64value = 0; }
        public CInt64(CInt64 value) : this()
        {
            this.i64value = value.i64value;
        }
        public CInt64(long value) : this()
        {
            this.i64value = value;
        }
        public CInt64(byte[] value) : this()
        {
            this.i64value = BitConverter.ToInt16(value, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CInt64)BitConverter.ToInt64(bytes, 0);
        }

        public override byte[] ToByteArray(object value,int len)
        {
            return (CInt64)value;
        }



        public static implicit operator CInt64(long value)
        {
            return new CInt64(value);
        }
        public static implicit operator CInt64(byte[] value)
        {
            return BitConverter.ToInt64(value, 0);
        }
        public static implicit operator long(CInt64 value)
        {
            return value.i64value;
        }
        public static implicit operator byte[](CInt64 value)
        {
            return BitConverter.GetBytes(value.i64value);
        }

        public static CInt64 operator +(CInt64 v1, long v2)
        {
            return (long)(v1.i64value + v2);
        }
        public static CInt64 operator +(CInt64 v1, CInt64 v2)
        {
            return (long)(v1.i64value + v2.i64value);
        }

        public static CInt64 operator -(CInt64 v1, long v2)
        {
            return (long)(v1.i64value - v2);
        }
        public static CInt64 operator -(CInt64 v1, CInt64 v2)
        {
            return (long)(v1.i64value - v2.i64value);
        }

        public static CInt64 operator *(CInt64 v1, long v2)
        {
            return (long)(v1.i64value * v2);
        }
        public static CInt64 operator *(CInt64 v1, CInt64 v2)
        {
            return (long)(v1.i64value * v2.i64value);
        }

        public static CInt64 operator /(CInt64 v1, long v2)
        {
            return (long)(v1.i64value / v2);
        }
        public static CInt64 operator /(CInt64 v1, CInt64 v2)
        {
            return (long)(v1.i64value / v2.i64value);
        }

        public static CInt64 operator ++(CInt64 values)
        {
            return values.i64value++;
        }
        public static CInt64 operator --(CInt64 values)
        {
            return values.i64value++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.UInt64;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(i64value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(i64value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(i64value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(i64value);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(i64value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(i64value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(i64value);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return i64value;
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(i64value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(i64value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(i64value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(i64value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return i64value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
