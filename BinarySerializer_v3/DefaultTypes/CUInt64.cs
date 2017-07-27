using System;

namespace BinarySerializer.DefaultTypes
{
    public class CUInt64 : AbstractType,IConvertible
    {
        ulong ui64value;
        public new object realValue { get { return ui64value; } set { ui64value = (CUInt64)value; } }

        public CUInt64()
        { len = 8; ui64value = 0; }
        public CUInt64(CUInt64 value) : this()
        {
            this.ui64value = value.ui64value;
        }
        public CUInt64(ulong value) : this()
        {
            this.ui64value = value;
        }
        public CUInt64(byte[] value) : this()
        {
            this.ui64value = BitConverter.ToUInt64(value, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CUInt64)BitConverter.ToUInt64(bytes, 0);
        }

        public override byte[] ToByteArray(object value, int len)
        {
            return (CUInt64)value;
        }



        public static implicit operator CUInt64(ulong value)
        {
            return new CUInt64(value);
        }
        public static implicit operator CUInt64(byte[] value)
        {
            return BitConverter.ToUInt64(value, 0);
        }
        public static implicit operator ulong(CUInt64 value)
        {
            return value.ui64value;
        }
        public static implicit operator byte[](CUInt64 value)
        {
            return BitConverter.GetBytes(value.ui64value);
        }

        public static CUInt64 operator +(CUInt64 v1, ulong v2)
        {
            return (ulong)(v1.ui64value + v2);
        }
        public static CUInt64 operator +(CUInt64 v1, CUInt64 v2)
        {
            return (ulong)(v1.ui64value + v2.ui64value);
        }

        public static CUInt64 operator -(CUInt64 v1, ulong v2)
        {
            return (ulong)(v1.ui64value - v2);
        }
        public static CUInt64 operator -(CUInt64 v1, CUInt64 v2)
        {
            return (ulong)(v1.ui64value - v2.ui64value);
        }

        public static CUInt64 operator *(CUInt64 v1, ulong v2)
        {
            return (ulong)(v1.ui64value * v2);
        }
        public static CUInt64 operator *(CUInt64 v1, CUInt64 v2)
        {
            return (ulong)(v1.ui64value * v2.ui64value);
        }

        public static CUInt64 operator /(CUInt64 v1, ulong v2)
        {
            return (ulong)(v1.ui64value / v2);
        }
        public static CUInt64 operator /(CUInt64 v1, CUInt64 v2)
        {
            return (ulong)(v1.ui64value / v2.ui64value);
        }

        public static CUInt64 operator ++(CUInt64 values)
        {
            return values.ui64value++;
        }
        public static CUInt64 operator --(CUInt64 values)
        {
            return values.ui64value++;
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
            return Convert.ToChar(ui64value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ui64value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ui64value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ui64value);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(ui64value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(ui64value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(ui64value);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(ui64value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return ui64value;
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(ui64value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(ui64value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(ui64value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return ui64value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
