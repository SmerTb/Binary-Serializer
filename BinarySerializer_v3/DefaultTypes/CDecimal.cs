using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySerializer.DefaultTypes
{
    public class CDecimal : DefaultTypes.AbstractType, IConvertible
    {
        private decimal dvalue;
        public new object RealValue { get { return dvalue; } set { dvalue = (CDecimal)value; } }
        public CDecimal()
        { this.len = 16; this.dvalue = 0; }
        public CDecimal(CDecimal value) : this()
        {
            dvalue = value.dvalue;
        }
        public CDecimal(decimal value) : this()
        {
            dvalue = value;
        }
        public CDecimal(byte[] bytes) : this()
        {
            dvalue = ToDecimal(bytes);
        }

        private static byte[] GetBytes(decimal dec)
        {
            //Load four 32 bit integers from the Decimal.GetBits function
            Int32[] bits = decimal.GetBits(dec);
            //Create a temporary list to hold the bytes
            List<byte> bytes = new List<byte>();
            //iterate each 32 bit integer
            foreach (Int32 i in bits)
            {
                //add the bytes of the current 32bit integer
                //to the bytes list
                bytes.AddRange(BitConverter.GetBytes(i));
            }
            //return the bytes list as an array
            return bytes.ToArray();
        }
        private static decimal ToDecimal(byte[] bytes)
        {
            //check that it is even possible to convert the array
            if (bytes.Count() != 16)
                throw new Exception("A decimal must be created from exactly 16 bytes");
            //make an array to convert back to int32's
            Int32[] bits = new Int32[4];
            for (int i = 0; i <= 15; i += 4)
            {
                //convert every 4 bytes into an int32
                bits[i / 4] = BitConverter.ToInt32(bytes, i);
            }
            //Use the decimal's new constructor to
            //create an instance of decimal
            return new decimal(bits);
        }

        public override object ToData(byte[] bytes)
        {
            return (CDecimal)ToDecimal(bytes);
        }
        public override byte[] ToByteArray(object value,int len)
        {
            return (CDecimal)value;
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
            return Convert.ToDouble(dvalue);
        }

        public decimal ToDecimal(IFormatProvider provider)
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
        #endregion
        public static implicit operator CDecimal(decimal value)
        {
            return new CDecimal(value);
        }
        public static implicit operator CDecimal(byte[] value)
        {
            return ToDecimal(value);
        }
        public static implicit operator decimal(CDecimal value)
        {
            return value.dvalue;
        }
        public static implicit operator byte[](CDecimal value)
        {
            return GetBytes(value.dvalue);
        }

        public static CDecimal operator +(CDecimal v1, decimal v2)
        {
            return v1.dvalue + v2;
        }
        public static CDecimal operator +(CDecimal v1, CDecimal v2)
        {
            return v1.dvalue + v2.dvalue;
        }

        public static CDecimal operator -(CDecimal v1, decimal v2)
        {
            return v1.dvalue - v2;
        }
        public static CDecimal operator -(CDecimal v1, CDecimal v2)
        {
            return v1.dvalue - v2.dvalue;
        }

        public static CDecimal operator *(CDecimal v1, decimal v2)
        {
            return v1.dvalue * v2;
        }
        public static CDecimal operator *(CDecimal v1, CDecimal v2)
        {
            return v1.dvalue * v2.dvalue;
        }

        public static CDecimal operator /(CDecimal v1, decimal v2)
        {
            return v1.dvalue / v2;
        }
        public static CDecimal operator /(CDecimal v1, CDecimal v2)
        {
            return v1.dvalue / v2.dvalue;
        }

        public static CDecimal operator ++(CDecimal values)
        {
            return values.dvalue++;
        }
        public static CDecimal operator --(CDecimal values)
        {
            return values.dvalue++;
        }


    }

}
