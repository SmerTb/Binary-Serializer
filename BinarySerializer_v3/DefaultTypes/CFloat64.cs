using System;

namespace BinarySerializer.DefaultTypes
{
    public class CFloat64 : DefaultTypes.AbstractType,IConvertible
    {
        private double dvalue;
        public new object realValue { get { return dvalue; } set { dvalue = (CFloat64)value; } }

        public CFloat64()
        { len = 8; dvalue = 0; }
        public CFloat64(CFloat64 value) : this()
        {
            dvalue = value.dvalue;
        }
        public CFloat64(double value) : this()
        {
            dvalue = value;
        }
        public CFloat64(byte[] bytes) : this()
        {
            dvalue = BitConverter.ToDouble(bytes,0);
        }
        

        public override object ToData(byte[] bytes)
        {
            return (CFloat64)BitConverter.ToDouble(bytes, 0);
        }
        public override byte[] ToByteArray(object value, int len)
        {
            return (CFloat64)value;
        }


        public static implicit operator CFloat64(double value)
        {
            return new CFloat64(value);
        }
        public static implicit operator CFloat64(byte[] value)
        {
            return BitConverter.ToDouble(value, 0);
        }
        public static implicit operator double(CFloat64 value)
        {
            return value.dvalue;
        }
        public static implicit operator byte[](CFloat64 value)
        {
            return BitConverter.GetBytes(value.dvalue);
        }

        public static CFloat64 operator +(CFloat64 v1, double v2)
        {
            return v1.dvalue + v2;
        }
        public static CFloat64 operator +(CFloat64 v1, CFloat64 v2)
        {
            return v1.dvalue + v2.dvalue;
        }

        public static CFloat64 operator -(CFloat64 v1, double v2)
        {
            return v1.dvalue - v2;
        }
        public static CFloat64 operator -(CFloat64 v1, CFloat64 v2)
        {
            return v1.dvalue - v2.dvalue;
        }

        public static CFloat64 operator *(CFloat64 v1, double v2)
        {
            return v1.dvalue * v2;
        }
        public static CFloat64 operator *(CFloat64 v1, CFloat64 v2)
        {
            return v1.dvalue * v2.dvalue;
        }

        public static CFloat64 operator /(CFloat64 v1, double v2)
        {
            return v1.dvalue / v2;
        }
        public static CFloat64 operator /(CFloat64 v1, CFloat64 v2)
        {
            return v1.dvalue / v2.dvalue;
        }

        public static CFloat64 operator ++(CFloat64 values)
        {
            return values.dvalue++;
        }
        public static CFloat64 operator --(CFloat64 values)
        {
            return values.dvalue++;
        }


        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Double;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(dvalue);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(dvalue);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(dvalue);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(dvalue);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(dvalue);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(dvalue);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(dvalue);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(dvalue);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(dvalue);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(dvalue);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return dvalue;
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(dvalue);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return dvalue.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
