using System;

namespace BinarySerializer.DefaultTypes
{
    public class CInt16 : AbstractType,IConvertible
    {
        short i16value;
        public new object realValue { get { return i16value; } set { i16value = (CInt16)value; } }

        public CInt16()
        { len = 2; i16value = 0; }
        public CInt16(CInt16 value) : this()
        {
            this.i16value = value.i16value;
        }
        public CInt16(short value) : this()
        {
            this.i16value = value;
        }
        public CInt16(byte[] value) : this()
        {
            this.i16value = BitConverter.ToInt16(value, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CInt16)BitConverter.ToInt16(bytes, 0);
        }

        public override byte[] ToByteArray(object value,int len)
        {
            return (CInt16)value;
        }


        public static implicit operator CInt16(short value)
        {
            return new CInt16(value);
        }
        public static implicit operator CInt16(byte[] value)
        {
            return BitConverter.ToInt16(value, 0);
        }
        public static implicit operator short(CInt16 value)
        {
            return value.i16value;
        }
        public static implicit operator byte[](CInt16 value)
        {
            return BitConverter.GetBytes(value.i16value);
        }

        public static CInt16 operator +(CInt16 v1, short v2)
        {
            return (short)(v1.i16value + v2);
        }
        public static CInt16 operator +(CInt16 v1, CInt16 v2)
        {
            return (short)(v1.i16value + v2.i16value);
        }

        public static CInt16 operator -(CInt16 v1, short v2)
        {
            return (short)(v1.i16value - v2);
        }
        public static CInt16 operator -(CInt16 v1, CInt16 v2)
        {
            return (short)(v1.i16value - v2.i16value);
        }

        public static CInt16 operator *(CInt16 v1, short v2)
        {
            return (short)(v1.i16value * v2);
        }
        public static CInt16 operator *(CInt16 v1, CInt16 v2)
        {
            return (short)(v1.i16value * v2.i16value);
        }

        public static CInt16 operator /(CInt16 v1, short v2)
        {
            return (short)(v1.i16value / v2);
        }
        public static CInt16 operator /(CInt16 v1, CInt16 v2)
        {
            return (short)(v1.i16value / v2.i16value);
        }

        public static CInt16 operator ++(CInt16 values)
        {
            return values.i16value++;
        }
        public static CInt16 operator --(CInt16 values)
        {
            return values.i16value++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Int16;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(i16value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(i16value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(i16value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return i16value;
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(i16value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(i16value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(i16value);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(i16value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(i16value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(i16value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(i16value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(i16value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return i16value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
