using BinarySerializer.DefaultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BinarySerializer
{
    public partial class BinarySerializer
    {
        /// <summary>
        /// Список примитивных конечных типов для обработки байт
        /// </summary>
        private List<DefaultTypes.AbstractType> primitiveList = new List<DefaultTypes.AbstractType>();

        /// <summary>
        /// Кодировка записи/чтения файла
        /// </summary>
        public Encoding encoding = Encoding.ASCII;

        /// <summary>
        /// Автоматически записывает размеры зависимых свойств 
        /// </summary>
        public bool AutoDetectLenFields = false;

        /// <summary>
        /// Автоматически инициализирует классы при сериалзации которые пользователь по какой-то причине забыл/ не стал инициализировать
        /// </summary>
        public bool AutoInitializeNullClasses = false;

        /// <summary>
        /// Автоматически инициализирует примитивы при сериалзации которые пользователь по какой-то причине забыл/ не стал инициализировать
        /// </summary>
        public bool AutoInitializeNullPrimitives = false;

        /// <summary>
        /// Автоматически изменяет размер массивов классов при сериалзации стандартными значениями если их не хватает в массиве или слишком много для указаного размера
        /// </summary>
        public bool AutoResizeArrayClasses = false;

        /// <summary>
        /// Автоматически изменяет размер массивов примитивов при сериалзации стандартными значениями если их не хватает в массиве или слишком много для указаного размера
        /// </summary>
        public bool AutoResizeArrayPrimitives = false;

        /// <summary>
        /// Текущий обьект для сериализации, временная переменная для рекурсии
        /// </summary>
        object currentSerializebleObject = null;

        /// <summary>
        /// Текущее свойство для сериализации
        /// </summary>
        PropertyInfo currentSerializebleProperty = null;

        public BinarySerializer()
        {
            //Добавление стандартных типов которые идут вместе с BinarySerializer
            primitiveList.Add(new CFloat32());
            primitiveList.Add(new CFloat64());
            primitiveList.Add(new CDecimal());
            primitiveList.Add(new CString());
            primitiveList.Add(new CInt16());
            primitiveList.Add(new CUInt16());
            primitiveList.Add(new CInt32());
            primitiveList.Add(new CUInt32());
            primitiveList.Add(new CInt64());
            primitiveList.Add(new CUInt64());
            primitiveList.Add(new CByte());
            primitiveList.Add(new CChar());
        }
    }
}
