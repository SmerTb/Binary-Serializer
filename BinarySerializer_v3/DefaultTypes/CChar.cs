﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerializer.DefaultTypes
{
    public class CByte : DefaultTypes.AbstractType, IConvertible
    {
        private byte dvalue;
        public new object realValue { get { return dvalue; } set { dvalue = (CByte)value; } }
        public CByte()
        { this.len = 1; this.dvalue = 0; }
        public CByte(CByte value) : this()
        {
            dvalue = value.dvalue;
        }
        public CByte(byte value) : this()
        {
            dvalue = value;
        }
        public CByte(byte[] bytes) : this()
        {
            dvalue = bytes[0];
        }

        public override object ToData(byte[] bytes)
        {
            return (CByte)bytes;
        }
        public override byte[] ToByteArray(object value, int len)
        {
            return (CByte)value;
        }

        #region Convert
        public TypeCode GetTypeCode()
        {
            return TypeCode.Decimal;
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
            return dvalue;
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
            return dvalue;
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
        public static implicit operator CByte(byte value)
        {
            return new CByte(value);
        }
        public static implicit operator CByte(byte[] value)
        {
            return value[0];
        }
        public static implicit operator byte(CByte value)
        {
            return value.dvalue;
        }
        public static implicit operator byte[] (CByte value)
        {
            return new byte[] { value.dvalue };
        }

        public static CByte operator +(CByte v1, byte v2)
        {
            return (CByte)v1.dvalue + v2;
        }
        public static CByte operator +(CByte v1, CByte v2)
        {
            return (CByte)v1.dvalue + v2.dvalue;
        }

        public static CByte operator -(CByte v1, byte v2)
        {
            return (CByte)v1.dvalue - v2;
        }
        public static CByte operator -(CByte v1, CByte v2)
        {
            return (CByte)v1.dvalue - v2.dvalue;
        }

        public static CByte operator *(CByte v1, byte v2)
        {
            return (CByte)v1.dvalue * v2;
        }
        public static CByte operator *(CByte v1, CByte v2)
        {
            return (CByte)v1.dvalue * v2.dvalue;
        }

        public static CByte operator /(CByte v1, byte v2)
        {
            return (CByte)v1.dvalue / v2;
        }
        public static CByte operator /(CByte v1, CByte v2)
        {
            return (CByte)v1.dvalue / v2.dvalue;
        }

        public static CByte operator ++(CByte values)
        {
            return values.dvalue++;
        }
        public static CByte operator --(CByte values)
        {
            return values.dvalue++;
        }


    }
}
