using BinarySerializer.DefaultTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BinarySerializer
{
    public partial class BinarySerializer
    {
        /// <summary>
        /// Сериализация типа в массив байт
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public byte[] Serialize<T>(T value)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                SerializeToStream(value, ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Сериализация типа в указанный поток 
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="value">Значение</param>
        /// <param name="stream">Поток (должен поддерживать запись)</param>
        public void SerializeToStream<T>(T value, Stream stream)
        {
            if (!stream.CanWrite)
                throw new IOException("Поток не поддерживает запись");
            // Получаем все свойства класса
            PropertyInfo[] properties = value.GetType().GetProperties();
            // В случае с включенным авто-детектом размеров, прогоняем все свойства для того что-бы установить полям-размерам размеры зависящих свойств
            if (AutoDetectLenFields)
                foreach (var item in properties)
                {
                    // Опции для сериализации каждого отдельного свойства
                    BinaryAttribute battr = (BinaryAttribute)item.GetCustomAttributes(typeof(BinaryAttribute), false).FirstOrDefault();
                    // Если нету то идем дальше (классы могут содержать не только бинарные свойства)
                    if (battr == null)
                        continue;

                    // Если есть свойство содержащее размер типа
                    if (battr.data_len_member != string.Empty)
                    {
                        //Получаем свойство
                        PropertyInfo prop = properties.First(x => x.Name == battr.data_len_member);
                        //если свойства нету то выводим ошибку
                        if (prop == null)
                            throw new Exception($"Текущий класс {item.DeclaringType.Name} не содержит свойства {battr.data_len_member} установленого как свойство содержащее размер типа свойства {item.Name}");
                        //изменяем тип значения на подходящий полю
                        object fv = ChangeLenType(((AbstractType)item.GetValue(value, null)).len, prop.PropertyType);
                        prop.SetValue(value, fv, null);
                    }

                    if (battr.array_len_member != string.Empty)
                    {
                        //Получаем свойство
                        PropertyInfo prop = properties.First(x => x.Name == battr.array_len_member);
                        //если свойства нету то выводим ошибку
                        if (prop == null)
                            throw new Exception($"Текущий класс {item.DeclaringType.Name} не содержит свойства {battr.data_len_member} установленого как свойство содержащее размер массива свойства {item.Name}");
                        object fv = null;
                        //IList, ICollection, IEnumerable
                        //если это реально массив
                        if (item.GetValue(value, null) is Array)
                            //изменяем тип значения на подходящий полю
                            fv = ChangeLenType(((Array)item.GetValue(value, null)).Length, prop.PropertyType);
                        else
                            //если нет то надо уведомить
                            throw new Exception($"Cвойство {item.Name} в классе {item.DeclaringType.Name} не являеться массивом");
                        prop.SetValue(value, fv, null);
                    }
                }

            foreach (var item in properties)
            {
                // Опции для сериализации каждого отдельного свойства
                BinaryAttribute battr = (BinaryAttribute)item.GetCustomAttributes(typeof(BinaryAttribute), false).FirstOrDefault();
                // Если нету то идем дальше (классы могут содержать не только бинарные свойства)
                if (battr == null)
                    continue;

                // Текущий обьект для серриализации
                currentSerializebleObject = value;
                currentSerializebleProperty = item;

                // Если это массив состоящий из примитивов
                if (IsPrimitive(battr) && IsArray(battr))
                    GetArrayPrimitiveBytes(battr, stream, item.GetValue(value, null));
                // Если это примитив
                else if (IsPrimitive(battr))
                    GetPrimitiveBytes(battr, stream, item.GetValue(value, null));
                // Если это массив (не примитивов - классов)
                else if (IsArray(battr))
                    GetArrayClassBytes(battr, stream, item.GetValue(value, null));
                // Остаеться только класс
                else
                    GetClassBytes(battr, stream, item.GetValue(value, null));

            }


        }

        /// <summary>
        /// Записываем значение примитивного типа
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <param name="value">Значение</param>
        private void GetPrimitiveBytes(BinaryAttribute battr, Stream stream, object value)
        {
            // ищем этот тип в списке примитивов, т.к методы вызываються из классов что находяться в листе
            AbstractType t = primitiveList.Where(x => x.GetType() == battr.type).First();
            // получаем размер типа
            int len = GetTypeLen(t, battr);
            //устанавливаем кодировку
            t.encoding = this.encoding;
            //Проверка присутствия значения
            if (value == null)
            {
                if (AutoInitializeNullPrimitives)
                    value = Activator.CreateInstance(battr.type);
                else
                    throw new Exception($"Свойство {currentSerializebleProperty.Name} класса {currentSerializebleProperty.DeclaringType.Name} не содержит значения");
            }
            // Записываем массив байт преобразованный с помощью метода ToByteArray примитивного типа
            var v = t.ToByteArray(value, len);
            stream.Write(v, 0, len);
        }

        /// <summary>
        /// Записываем значения массива примитивных типов
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <param name="value">Значение</param>
        private void GetArrayPrimitiveBytes(BinaryAttribute battr, Stream stream, object value)
        {
            //Обьявляем полученое значение как массив обьектов
            object[] arr = (object[])value;

            // получаем размер массива с помощью атрибута
            int arrlen = GetArrayLen(battr);

            //проверка размера массива и его подгон/уведомление пользователя
            if (AutoResizeArrayPrimitives)
            {
                //Изменяем размер массива если разрешен автоподгон
                Array.Resize(ref arr, arrlen);
            }
            else
            {
                //Уведомляем пользователя о том что размеры массива не сходяться
                if(arr.Length != arrlen)
                    throw new Exception($"Размер массива {currentSerializebleProperty.Name} класса {currentSerializebleProperty.DeclaringType.Name} не равняеться заявленному");
            }

            for (int i = 0; i < arrlen; i++)
            {
                //Для записи элементов массива вызываем метод для записи значения одиночных примитивных типов
                GetPrimitiveBytes(battr, stream, arr[i]);
            }
        }

        /// <summary>
        /// Записываем значения класса
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <param name="value">Значение</param>
        private void GetClassBytes(BinaryAttribute battr, Stream stream, object value)
        {
            //Проверка присутствия значения
            if (value == null)
            {
                if (AutoInitializeNullClasses)
                    value = Activator.CreateInstance(battr.type);
                else
                    throw new Exception($"Свойство {currentSerializebleProperty.Name} класса {currentSerializebleProperty.DeclaringType.Name} не содержит значения");
            }
            SerializeToStream(value, stream);
        }

        /// <summary>
        /// Записываем значения массива классов
        /// </summary>
        /// <param name="battr">Атрибут с данными</param>
        /// <param name="stream">Текущий поток</param>
        /// <param name="value">Значение</param>
        private void GetArrayClassBytes(BinaryAttribute battr, Stream stream, object value)
        {
            object[] arr = (object[])value;
            int arrlen = GetArrayLen(battr);
            //проверка размера массива и его подгон/уведомление пользователя
            if (AutoResizeArrayClasses)
            {
                //Изменяем размер массива если разрешен автоподгон
                Array.Resize(ref arr, arrlen);
            }
            else
            {
                //Уведомляем пользователя о том что размеры массива не сходяться
                if (arr.Length != arrlen)
                    throw new Exception($"Размер массива {currentSerializebleProperty.Name} класса {currentSerializebleProperty.DeclaringType.Name} не равняеться заявленному");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                GetClassBytes(battr, stream, arr[i]);
            }
        }
    }
}
