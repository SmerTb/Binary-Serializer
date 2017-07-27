using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerializer.DefaultTypes
{
    public class CChar : DefaultTypes.AbstractType, IConvertible
    {
        private char dvalue;
        public new object realValue { get { return dvalue; } set { dvalue = (CChar)value; } }
        public CChar()
        { this.len = 1; this.dvalue = '\0'; }
        public CChar(CChar value) : this()
        {
            dvalue = value.dvalue;
        }
        public CChar(char value) : this()
        {
            dvalue = value;
        }
        public CChar(char[] bytes) : this()
        {
            dvalue = bytes[0];
        }

        public override object ToData(byte[] bytes)
        {
            return (CChar)bytes;
        }
        public override byte[] ToByteArray(object value, int len)
        {
            return (CChar)value;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Char;
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
            return (byte)dvalue;
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
            return Convert.ToDouble(dvalue);
        }

        public byte ToDecimal(IFormatProvider provider)
        {
            return (byte)(dvalue);
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

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
        #endregion
        public static implicit operator CChar(byte value)
        {
            return new CChar(value);
        }
        public static implicit operator CChar(byte[] value)
        {
            return value[0];
        }
        public static implicit operator CChar(char value)
        {
            return new CChar(value);
        }
        public static implicit operator CChar(char[] value)
        {
            return value[0];
        }
        public static implicit operator char(CChar value)
        {
            return value.dvalue;
        }
        public static implicit operator char[] (CChar value)
        {
            return new char[] { value.dvalue };
        }

        public static implicit operator byte(CChar value)
        {
            return (byte)value.dvalue;
        }
        public static implicit operator byte[] (CChar value)
        {
            return new byte[] { (byte)value.dvalue };
        }

        public static CChar operator +(CChar v1, char v2)
        {
            return (CChar)v1.dvalue + v2;
        }
        public static CChar operator +(CChar v1, CChar v2)
        {
            return (CChar)v1.dvalue + v2.dvalue;
        }

        public static CChar operator -(CChar v1, char v2)
        {
            return (CChar)v1.dvalue - v2;
        }
        public static CChar operator -(CChar v1, CChar v2)
        {
            return (CChar)v1.dvalue - v2.dvalue;
        }

        public static CChar operator *(CChar v1, char v2)
        {
            return (CChar)v1.dvalue * v2;
        }
        public static CChar operator *(CChar v1, CChar v2)
        {
            return (CChar)v1.dvalue * v2.dvalue;
        }

        public static CChar operator /(CChar v1, char v2)
        {
            return (CChar)v1.dvalue / v2;
        }
        public static CChar operator /(CChar v1, CChar v2)
        {
            return (CChar)v1.dvalue / v2.dvalue;
        }

        public static CChar operator ++(CChar values)
        {
            return values.dvalue++;
        }
        public static CChar operator --(CChar values)
        {
            return values.dvalue++;
        }


    }
}
