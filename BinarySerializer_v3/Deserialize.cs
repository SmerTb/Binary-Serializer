using BinarySerializer.DefaultTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BinarySerializer
{
    public partial class BinarySerializer
    {
        /// <summary>
        /// Дессериализация массива байт в указанный тип
        /// </summary>
        /// <typeparam name="T">Тип преобразования байт</typeparam>
        /// <param name="data">Массив байт</param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] data)
        {
            object result = null;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
            {
                result = DeserializeByStream<T>(ms);
            }
            return (T)result;
        }

        /// <summary>
        /// Дессериализация потока в указанный тип
        /// </summary>
        /// <typeparam name="T">Тип преобразования</typeparam>
        /// <param name="stream">Поток (должен поддерживать чтение)</param>
        /// <returns></returns>
        public T DeserializeByStream<T>(System.IO.Stream stream)
        {
            if (!stream.CanRead)
                throw new IOException("Поток не поддерживает чтение");
            T result = Activator.CreateInstance<T>();
            Deserialize<T>(ref result, stream);
            return result;
        }

        /// <summary>
        /// Процесс дессириализации
        /// </summary>
        /// <typeparam name="T">Тип преобразования</typeparam>
        /// <param name="result">Результат</param>
        /// <param name="stream">Поток</param>
        private void Deserialize<T>(ref T result, System.IO.Stream stream)
        {
            // Получаем все свойства класса 
            PropertyInfo[] propertyes = result.GetType().GetProperties();
            foreach (var item in propertyes)
            {
                // Опции для сериализации каждого отдельного свойства
                BinaryAttribute battr = (BinaryAttribute)item.GetCustomAttributes(typeof(BinaryAttribute), false).FirstOrDefault();
                // Если нету то идем дальше (классы могут содержать не только бинарные свойства)
                if (battr == null)
                    continue;
                // Текущий обьект для серриализации
                currentSerializebleObject = result;

                // Значение для текущей итерации
                object value = null;
                // Если это массив состоящий из примитивов
                if (IsPrimitive(battr) && IsArray(battr))
                    value = GetArrayPrimitiveValue(battr, stream);
                // Если это примитив
                else if (IsPrimitive(battr))
                    value = GetPrimitiveValue(battr, stream);
                // Если это массив (не примитивов - классов)
                else if (IsArray(battr))
                    value = GetArrayClassValue(battr, stream);
                // Остаеться только класс
                else
                    value = GetClassValue(battr, stream);

                // устанавливаем полученное значение
                item.SetValue(result, value, null);


            }
        }

        /// <summary>
        /// Получаем значение примитивного типа
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <returns>Значение примитивного типа</returns>
        private object GetPrimitiveValue(BinaryAttribute battr, System.IO.Stream stream)
        {
            // ищем этот тип в списке примитивов, т.к методы вызываються из классов что находяться в листе
            AbstractType t = primitiveList.Where(x => x.GetType() == battr.type).First();
            // получаем размер типа
            int len = GetTypeLen(t, battr);
            // читаем данные
            byte[] buffer = new byte[len];
            stream.Read(buffer, 0, len);
            //устанавливаем кодировку
            t.encoding = this.encoding;
            // возвращаем массив байт преобразованный с помощью метода ToData примитивного типа
            return t.ToData(buffer);
        }

        /// <summary>
        /// Получаем значение массива с примитивными типами
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <returns>Значение массива примитивных типов</returns>
        private object GetArrayPrimitiveValue(BinaryAttribute battr, System.IO.Stream stream)
        {
            //Создаем массив с указаным примитивным типов
            Array arr = Array.CreateInstance(battr.type, GetArrayLen(battr));
            for (int i = 0; i < arr.Length; i++)
            {
                //Для получения элементов массива вызываем метод для получения значения одиночных примитивных типов
                arr.SetValue(GetPrimitiveValue(battr, stream), i);
            }
            return arr;
        }
        /// <summary>
        /// Получаем значение класса
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <returns>Значение класса</returns>
        private object GetClassValue(BinaryAttribute battr, System.IO.Stream stream)
        {
            // вызываем метод DeserializeByStream с текущим потоком для нового класса
            MethodInfo mi = this.GetType().GetMethods().Where(x => x.Name == "DeserializeByStream").FirstOrDefault();
            // т.к тип метода у нас Generic, вызываем спец метод
            MethodInfo mi1 = mi.MakeGenericMethod(battr.type);
            // вызываем метод и возвращаем результат
            return mi1.Invoke(this, new[] { stream });
        }

        private object GetArrayClassValue(BinaryAttribute battr, System.IO.Stream stream)
        {
                //Создаем массив с указаным типом класса
                Array arr = Array.CreateInstance(battr.type, GetArrayLen(battr));
                for (int i = 0; i < arr.Length; i++)
                {
                    //Для получения элементов массива вызываем метод для получения значения одиночных классов
                    arr.SetValue(GetClassValue(battr, stream), i);
                }
                return arr;
        }
    }
}
