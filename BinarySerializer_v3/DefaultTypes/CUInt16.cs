using System;

namespace BinarySerializer.DefaultTypes
{
    public class CUInt16 : AbstractType,IConvertible
    {
        ushort ui16value;
        public new object realValue { get { return ui16value; } set { ui16value = (CUInt16)value; } }

        public CUInt16()
        { len = 2; ui16value = 0; }
        public CUInt16(CUInt16 value) : this()
        {
            this.ui16value = value.ui16value;
        }
        public CUInt16(ushort value) : this()
        {
            this.ui16value = value;
        }
        public CUInt16(byte[] value) : this()
        {
            this.ui16value = BitConverter.ToUInt16(value, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CUInt16)BitConverter.ToUInt16(bytes, 0);
        }

        public override byte[] ToByteArray(object value, int len)
        {
            return (CUInt16)value;
        }


        public static implicit operator CUInt16(ushort value)
        {
            return new CUInt16(value);
        }
        public static implicit operator CUInt16(byte[] value)
        {
            return BitConverter.ToUInt16(value, 0);
        }
        public static implicit operator ushort(CUInt16 value)
        {
            return value.ui16value;
        }
        public static implicit operator byte[](CUInt16 value)
        {
            return BitConverter.GetBytes(value.ui16value);
        }

        public static CUInt16 operator +(CUInt16 v1, ushort v2)
        {
            return (ushort)(v1.ui16value + v2);
        }
        public static CUInt16 operator +(CUInt16 v1, CUInt16 v2)
        {
            return (ushort)(v1.ui16value + v2.ui16value);
        }

        public static CUInt16 operator -(CUInt16 v1, ushort v2)
        {
            return (ushort)(v1.ui16value - v2);
        }
        public static CUInt16 operator -(CUInt16 v1, CUInt16 v2)
        {
            return (ushort)(v1.ui16value - v2.ui16value);
        }

        public static CUInt16 operator *(CUInt16 v1, ushort v2)
        {
            return (ushort)(v1.ui16value * v2);
        }
        public static CUInt16 operator *(CUInt16 v1, CUInt16 v2)
        {
            return (ushort)(v1.ui16value * v2.ui16value);
        }

        public static CUInt16 operator /(CUInt16 v1, ushort v2)
        {
            return (ushort)(v1.ui16value / v2);
        }
        public static CUInt16 operator /(CUInt16 v1, CUInt16 v2)
        {
            return (ushort)(v1.ui16value / v2.ui16value);
        }

        public static CUInt16 operator ++(CUInt16 values)
        {
            return values.ui16value++;
        }
        public static CUInt16 operator --(CUInt16 values)
        {
            return values.ui16value++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.UInt16;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(ui16value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ui16value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ui16value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ui16value);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return ui16value;
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(ui16value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(ui16value);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(ui16value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(ui16value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(ui16value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(ui16value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(ui16value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return ui16value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
