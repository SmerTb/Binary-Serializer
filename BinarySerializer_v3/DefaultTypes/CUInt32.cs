using System;

namespace BinarySerializer.DefaultTypes
{
    public class CUInt32 : AbstractType,IConvertible
    {
        uint ui32value;
        public new object realValue { get { return ui32value; } set { ui32value = (CUInt32)value; } }

        public CUInt32()
        { len = 4; ui32value = 0; }
        public CUInt32(CUInt32 value) : this()
        {
            this.ui32value = value.ui32value;
        }
        public CUInt32(uint value) : this()
        {
            this.ui32value = value;
        }
        public CUInt32(byte[] value) : this()
        {
            this.ui32value = BitConverter.ToUInt32(value, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CUInt32)BitConverter.ToUInt32(bytes, 0);
        }

        public override byte[] ToByteArray(object value, int len)
        {
            return (CUInt32)value;
        }



        public static implicit operator CUInt32(uint value)
        {
            return new CUInt32(value);
        }
        public static implicit operator CUInt32(byte[] value)
        {
            return BitConverter.ToUInt32(value, 0);
        }
        public static implicit operator uint(CUInt32 value)
        {
            return value.ui32value;
        }
        public static implicit operator byte[](CUInt32 value)
        {
            return BitConverter.GetBytes(value.ui32value);
        }

        public static CUInt32 operator +(CUInt32 v1, uint v2)
        {
            return v1.ui32value + v2;
        }
        public static CUInt32 operator +(CUInt32 v1, CUInt32 v2)
        {
            return v1.ui32value + v2.ui32value;
        }

        public static CUInt32 operator -(CUInt32 v1, uint v2)
        {
            return v1.ui32value - v2;
        }
        public static CUInt32 operator -(CUInt32 v1, CUInt32 v2)
        {
            return v1.ui32value - v2.ui32value;
        }

        public static CUInt32 operator *(CUInt32 v1, uint v2)
        {
            return v1.ui32value * v2;
        }
        public static CUInt32 operator *(CUInt32 v1, CUInt32 v2)
        {
            return v1.ui32value * v2.ui32value;
        }

        public static CUInt32 operator /(CUInt32 v1, uint v2)
        {
            return v1.ui32value / v2;
        }
        public static CUInt32 operator /(CUInt32 v1, CUInt32 v2)
        {
            return v1.ui32value / v2.ui32value;
        }

        public static CUInt32 operator ++(CUInt32 values)
        {
            return values.ui32value++;
        }
        public static CUInt32 operator --(CUInt32 values)
        {
            return values.ui32value++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.UInt32;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(ui32value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ui32value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ui32value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ui32value);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(ui32value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(ui32value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return ui32value;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(ui32value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(ui32value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(ui32value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(ui32value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(ui32value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return ui32value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
