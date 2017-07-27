using System;

namespace BinarySerializer.DefaultTypes
{
    public class CFloat32 : DefaultTypes.AbstractType, IConvertible
    {
        private float dvalue = 0.0f;
        public new object realValue { get { return dvalue; } set { dvalue = (CFloat32)value; } }

        public CFloat32()
        {
            dvalue = 0.0f; len = 4;
        }
        public CFloat32(CFloat32 value) : this()
        {
            dvalue = value.dvalue;
        }
        public CFloat32(float value) : this()
        {
            dvalue = value;
        }
        public CFloat32(byte[] bytes) : this()
        {
            dvalue = BitConverter.ToSingle(bytes, 0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CFloat32)BitConverter.ToSingle(bytes, 0);
        }
        public override byte[] ToByteArray(object value,int len)
        {
            return (CFloat32)value;
        }


        public static implicit operator CFloat32(float value)
        {
            return new CFloat32(value);
        }
        public static implicit operator CFloat32(byte[] value)
        {
            return BitConverter.ToSingle(value, 0);
        }
        public static implicit operator float(CFloat32 value)
        {
            return value.dvalue;
        }
        public static implicit operator byte[](CFloat32 value)
        {
            return BitConverter.GetBytes(value.dvalue);
        }

        public static CFloat32 operator +(CFloat32 v1, float v2)
        {
            return v1.dvalue + v2;
        }
        public static CFloat32 operator +(CFloat32 v1, CFloat32 v2)
        {
            return v1.dvalue + v2.dvalue;
        }

        public static CFloat32 operator -(CFloat32 v1, float v2)
        {
            return v1.dvalue - v2;
        }
        public static CFloat32 operator -(CFloat32 v1, CFloat32 v2)
        {
            return v1.dvalue - v2.dvalue;
        }

        public static CFloat32 operator *(CFloat32 v1, float v2)
        {
            return v1.dvalue * v2;
        }
        public static CFloat32 operator *(CFloat32 v1, CFloat32 v2)
        {
            return v1.dvalue * v2.dvalue;
        }

        public static CFloat32 operator /(CFloat32 v1, float v2)
        {
            return v1.dvalue / v2;
        }
        public static CFloat32 operator /(CFloat32 v1, CFloat32 v2)
        {
            return v1.dvalue / v2.dvalue;
        }

        public static CFloat32 operator ++(CFloat32 values)
        {
            return values.dvalue++;
        }
        public static CFloat32 operator --(CFloat32 values)
        {
            return values.dvalue++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Single;
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
            return dvalue;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(dvalue);
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
