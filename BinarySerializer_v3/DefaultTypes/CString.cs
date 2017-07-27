using System.Text;

namespace BinarySerializer.DefaultTypes
{
    public class CString : AbstractType
    {
        string svalue1 = "";
        string svalue { get { return svalue1; } set { svalue1 = value; } }
        public new object realValue { get { return svalue; } set { svalue = (CString)value; } }
        public CString()
        {
        }
        public CString(CString value)
        {
            svalue = value.svalue;
            len = value.svalue.Length + 1;
        }
        public CString(string value)
        {
            svalue = value;
            len = value.Length + 1;
        }
        public CString(byte[] value, Encoding encoding)
        {
            svalue = encoding.GetString(value);
            len = svalue.Length + 1;
        }

        public override byte[] ToByteArray(object value, int len)
        {
            byte[] v = encoding.GetBytes(((CString)value).svalue1);
            System.Array.Resize(ref v, len);
            return v;
        }
        public override object ToData(byte[] bytes)
        {
            string v = encoding.GetString(bytes);
            return (CString)v;
        }
        
        public static implicit operator string(CString value)
        {
            return value;
        }
        public static implicit operator byte[](CString value)
        {
            return Encoding.ASCII.GetBytes(value.svalue);
        }
        public static implicit operator CString(string value)
        {
            return new CString(value);
        }
        public static implicit operator CString(byte[] value)
        {
            return new CString(value).svalue.Replace("\0","");
        }
        public byte this[int i]
        {
            get { return (byte)svalue[i]; }
        }
    }
}
