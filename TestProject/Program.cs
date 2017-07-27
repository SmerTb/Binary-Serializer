using BinarySerializer;
using BinarySerializer.DefaultTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            for (int k = 0; k < 600; k++)
            {
                TestStructure TS = new TestStructure();
                TS.glen = 5555;
                TS.t1 = new TestStructureNumeric();
                TS.t1.t1 = 431;
                TS.t1.t2 = 433;
                TS.t1.t3 = 435;
                TS.t1.t4 = 437;
                TS.t2 = new TestStructureArray();
                TS.t2.len = 15;
                TS.t2.t1 = new CFloat32[10];
                TS.t2.t2 = new CFloat32[10];
                TS.t2.t3 = new CInt64[10];
                TS.t2.t4 = new CInt64[10];
                for (int i = 0; i < 10; i++)
                {
                    TS.t2.t1[i] = (float)r.NextDouble();
                    TS.t2.t2[i] = (float)r.NextDouble();
                    TS.t2.t3[i] = r.Next(555, 5859489);
                    TS.t2.t4[i] = r.Next(555, 5859489);
                }

                TS.t3 = new TestStructureString();
                TS.t3.len = 5;
                TS.t3.t1 = "3h4h43herhreh";
                TS.t3.t2 = new CString[5] { "3h4h43herhreh", "wy34yh", "wrh34h3wh", "aharh", "rgagrg" };
                TS.t3.t3 = "3h4h43herhreh";
                TS.t3.t4 = new CString[5] { "3h4h43herhreh", "aeherh", "rhaerhar", "rjrtj", "awegaw" }; ;
                TS.t3.t5 = new CString[1] { "rrhy5y3" };

                TS.t4 = new TestStructureNumeric[5];
                for (int i = 0; i < 5; i++)
                {
                    TS.t4[i] = new TestStructureNumeric();
                    TS.t4[i].t1 = (short)(431 + i);
                    TS.t4[i].t2 = 433 + i;
                    TS.t4[i].t3 = 435 + i;
                    TS.t4[i].t4 = 437 + i;
                }
                TS.t5 = new TestStructureArray[5];
                for (int q = 0; q < 5; q++)
                {

                    TS.t5[q] = new TestStructureArray();
                    TS.t5[q].len = 10;
                    TS.t5[q].t1 = new CFloat32[5];
                    TS.t5[q].t2 = new CFloat32[5];
                    TS.t5[q].t3 = new CInt64[5];
                    TS.t5[q].t4 = new CInt64[5];
                    for (int i = 0; i < 5; i++)
                    {
                        TS.t5[q].t1[i] = (float)r.NextDouble();
                        TS.t5[q].t2[i] = (float)r.NextDouble();
                        TS.t5[q].t3[i] = r.Next(555, 5859489);
                        TS.t5[q].t4[i] = r.Next(555, 5859489);
                    }
                }

                TS.t6 = new TestStructureString[5];
                for (int i = 0; i < 5; i++)
                {
                    TS.t6[i] = new TestStructureString();
                    TS.t6[i].len = 10;
                    TS.t6[i].t1 = "3h4h43herhreh";
                    TS.t6[i].t2 = new CString[5] { "3h4h43herhreh", "wy34yh", "wrh34h3wh", "aharh", "rgagrg" };
                    TS.t6[i].t3 = "3h4h43herhreh";
                    TS.t6[i].t4 = new CString[5] { "3h4h43herhreh", "aeherh", "rhaerhar", "rjrtj", "awegaw" }; ;
                    TS.t6[i].t5 = new CString[1] { "rrhy5y3" };
                }
                TS.tlen = 66;
                TS.t7 = new List<TestStructureNumeric>();
                for (int i = 0; i < 5; i++)
                {
                    TS.t7.Add(new TestStructureNumeric());
                    TS.t7[i].t1 = (short)(431 + i);
                    TS.t7[i].t2 = 433 + i;
                    TS.t7[i].t3 = 435 + i;
                    TS.t7[i].t4 = 437 + i;

                }
                TS.t8 = new TestStructureArray[5];
                for (int q = 0; q < 5; q++)
                {

                    TS.t8[q] = new TestStructureArray();
                    TS.t8[q].len = 10;
                    TS.t8[q].t1 = new CFloat32[5];
                    TS.t8[q].t2 = new CFloat32[5];
                    TS.t8[q].t3 = new CInt64[5];
                    TS.t8[q].t4 = new CInt64[5];
                    for (int i = 0; i < 5; i++)
                    {
                        TS.t8[q].t1[i] = (float)r.NextDouble();
                        TS.t8[q].t2[i] = (float)r.NextDouble();
                        TS.t8[q].t3[i] = r.Next(555, 5859489);
                        TS.t8[q].t4[i] = r.Next(555, 5859489);
                    }
                }

                TS.t9 = new TestStructureString[5];
                for (int i = 0; i < 5; i++)
                {
                    TS.t9[i] = new TestStructureString();
                    TS.t9[i].len = 10;
                    TS.t9[i].t1 = "3h4h43herhreh";
                    TS.t9[i].t2 = new CString[5] { "3h4h43herhreh", "wy34yh", "wrh34h3wh", "aharh", "rgagrg" };
                    TS.t9[i].t3 = "3h4h43herhreh";
                    TS.t9[i].t4 = new CString[5] { "3h4h43herhreh", "aeherh", "rhaerhar", "rjrtj", "awegaw" }; ;
                    TS.t9[i].t5 = new CString[1] { "rrhy5y3" };
                }

                BinarySerializer.BinarySerializer bs = new BinarySerializer.BinarySerializer()
                {
                    AutoResizeArrayClasses = true,
                    AutoResizeArrayPrimitives = true,
                    AutoInitializeNullClasses = true,
                    AutoInitializeNullPrimitives = true
                };
            
                System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

                using (FileStream fs = new FileStream("test.bin", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    s.Start();
                    byte[] temp = bs.Serialize<TestStructure>(TS);
                    s.Stop();
                    Console.WriteLine($"Serialize: {s.Elapsed.Milliseconds} ms.");
                    fs.Write(temp, 0, temp.Length);
                }
                TestStructure result;
                using (BinaryReader br = new BinaryReader(new FileStream("test.bin", FileMode.OpenOrCreate, FileAccess.Read)))
                {
                    s.Start();
                    result = bs.Deserialize<TestStructure>(br.ReadBytes((int)br.BaseStream.Length));
                    s.Stop();
                    Console.WriteLine($"Deserialize: {s.Elapsed.Milliseconds} ms.");
                }
            }
            Console.ReadKey();
        }
    }

    [Serializable]
    public class TestStructure
    {
        [BinaryAttribute(typeof(TestStructureNumeric))]
        public TestStructureNumeric t1 { get; set; }
        [BinaryAttribute(typeof(TestStructureArray))]
        public TestStructureArray t2 { get; set; }
        [BinaryAttribute(typeof(TestStructureString))]
        public TestStructureString t3 { get; set; }

        [BinaryAttribute(typeof(TestStructureNumeric), array_len = 5)]
        public TestStructureNumeric[] t4 { get; set; }
        [BinaryAttribute(typeof(TestStructureArray), array_len = 5)]
        public TestStructureArray[] t5 { get; set; }
        [BinaryAttribute(typeof(TestStructureString), array_len = 5)]
        public TestStructureString[] t6 { get; set; }

        [BinaryAttribute(typeof(CInt32))]
        public CInt32 tlen { get; set; }
        
        public List<TestStructureNumeric> t7 { get; set; }

        [BinaryAttribute(typeof(TestStructureNumeric), array_len_member = "tlen")]
        public TestStructureNumeric[] _t7 { get { return t7.ToArray(); } set { t7 = value.ToList(); } }

        [BinaryAttribute(typeof(TestStructureArray), array_len_member = "tlen")]
        public TestStructureArray[] t8 { get; set; }
        [BinaryAttribute(typeof(TestStructureString), array_len_member = "tlen")]
        public TestStructureString[] t9 { get; set; }
        [BinaryAttribute(typeof(CInt32))]
        public CInt32 glen { get; set; }
    }

    [Serializable]
    public class TestStructureNumeric
    {
        [BinaryAttribute(typeof(CInt16))]
        public CInt16 t1 { get; set; }
        [BinaryAttribute(typeof(CInt32))]
        public CInt32 t2 { get; set; }
        [BinaryAttribute(typeof(CInt64))]
        public CInt64 t3 { get; set; }
        [BinaryAttribute(typeof(CInt32))]
        public CInt32 t4 { get; set; }
    }

    [Serializable]
    public class TestStructureArray
    {
        [BinaryAttribute(typeof(CInt32))]
        public CInt32 len { get; set; }
        [BinaryAttribute(typeof(CFloat32), array_len = 10)]
        public CFloat32[] t1 { get; set; }
        [BinaryAttribute(typeof(CFloat32), array_len_member = "len")]
        public CFloat32[] t2 { get; set; }
        [BinaryAttribute(typeof(CInt64), array_len = 10)]
        public CInt64[] t3 { get; set; }
        [BinaryAttribute(typeof(CInt64), array_len_member = "len")]
        public CInt64[] t4 { get; set; }
    }

    [Serializable]
    public class TestStructureString
    {
        [BinaryAttribute(typeof(CInt32))]
        public CInt32 len { get; set; }

        [BinaryAttribute(typeof(CString), data_len = 10)]
        public CString t1 { get; set; }
        [BinaryAttribute(typeof(CString), data_len_member = "len", array_len = 55)]
        public CString[] t2 { get; set; }


        [BinaryAttribute(typeof(CString), data_len_member = "len")]
        public CString t3 { get; set; }
        [BinaryAttribute(typeof(CString), data_len = 10, array_len_member = "len")]
        public CString[] t4 { get; set; }

        [BinaryAttribute(typeof(CString), data_len = 10, array_len = 55)]
        public CString[] t5 { get; set; }
    }

}
