using System;

namespace BinarySerializer.DefaultTypes
{
    public class CInt32 : AbstractType,IConvertible
    {
        int i32value;
        public new object realValue {
            get {
                return i32value;
            }
            set {
                i32value = (CInt32)value;
            }
        }

        public CInt32()
        { len = 4 ;  i32value = 0; }
        public CInt32(CInt32 value) : this()
        {
            this.i32value = value.i32value; 
        }
        public CInt32(int value) : this()
        {
            this.i32value = value;
        }
        public CInt32(byte[] value) : this()
        {
            this.i32value = BitConverter.ToInt32(value,0);
        }


        public override object ToData(byte[] bytes)
        {
            return (CInt32)BitConverter.ToInt32(bytes, 0);
        }

        public override byte[] ToByteArray(object value,int len)
        {
            return (CInt32)value;
        }



        public static implicit operator CInt32(int value)
        {
            return new CInt32(value);
        }
        public static implicit operator CInt32(byte[] value)
        {
            return BitConverter.ToInt32(value,0);
        }
        public static implicit operator int(CInt32 value)
        {
            return value.i32value;
        }
        public static implicit operator byte[](CInt32 value)
        {
            return BitConverter.GetBytes(value.i32value);
        }

        public static CInt32 operator +(CInt32 v1, int v2)
        {
            return v1.i32value + v2;
        }
        public static CInt32 operator +(CInt32 v1, CInt32 v2)
        {
            return v1.i32value + v2.i32value;
        }

        public static CInt32 operator -(CInt32 v1, int v2)
        {
            return v1.i32value - v2;
        }
        public static CInt32 operator -(CInt32 v1, CInt32 v2)
        {
            return v1.i32value - v2.i32value;
        }

        public static CInt32 operator *(CInt32 v1, int v2)
        {
            return v1.i32value * v2;
        }
        public static CInt32 operator *(CInt32 v1, CInt32 v2)
        {
            return v1.i32value * v2.i32value;
        }

        public static CInt32 operator /(CInt32 v1, int v2)
        {
            return v1.i32value / v2;
        }
        public static CInt32 operator /(CInt32 v1, CInt32 v2)
        {
            return v1.i32value / v2.i32value;
        }

        public static CInt32 operator ++(CInt32 values)
        {
            return values.i32value++;
        }
        public static CInt32 operator --(CInt32 values)
        {
            return values.i32value++;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Int32;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(i32value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(i32value);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(i32value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(i32value);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(i32value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return i32value;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(i32value);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(i32value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(i32value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(i32value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(i32value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(i32value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            return i32value.ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
