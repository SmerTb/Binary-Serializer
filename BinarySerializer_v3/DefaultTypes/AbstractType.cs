using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerializer.DefaultTypes
{
    public abstract class AbstractType
    {
        /// <summary>
        /// размер типа
        /// </summary>
        public int len;
        /// <summary>
        /// кодировка (устанавливаеться с BinarySerializer->encoding)
        /// </summary>
        public Encoding encoding;
        /// <summary>
        /// Реальное значение CFloat32 -> float, CInt64 -> long
        /// </summary>
        public object RealValue { get; set; }
        /// <summary>
        /// Функция преобразования типа в массив байт для записи
        /// </summary>
        /// <param name="data">значение</param>
        /// <param name="len">размер, если указан</param>
        /// <returns>массив байт для записи</returns>
        public abstract byte[] ToByteArray(object data,int len);
        /// <summary>
        /// Функция преобразования массива байт в тип
        /// </summary>
        /// <param name="value">массив байт</param>
        /// <returns>примитивный тип</returns>
        public abstract object ToData(byte[] value);
    }
}
