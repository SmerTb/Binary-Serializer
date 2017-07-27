using BinarySerializer.DefaultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerializer
{
    public partial class BinarySerializer
    {
        /// <summary>
        /// Примитивный тип?
        /// </summary>
        /// <param name="battr">Аттрибут текущего элемента</param>
        /// <returns></returns>
        protected bool IsPrimitive(BinaryAttribute attr)
        {
            //Ищем в списке примитивов тип текущего элемента
            if (primitiveList.Where(x => x.GetType() == attr.type).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Массив?
        /// </summary>
        /// <param name="battr">Аттрибут текущего элемента</param>
        /// <returns></returns>
        protected bool IsArray(BinaryAttribute attr)
        {
            // Проверяем не установлены ли значения размера массива или свойста размера массива
            if (attr.array_len == 0 && attr.array_len_member == "")
                return false;
            return true;
        }

        /// <summary>
        /// Получаем размер типа
        /// </summary>
        /// <param name="t">Тип</param>
        /// <param name="battr">Аттрибут текущего элемента</param>
        /// <returns></returns>
        protected int GetTypeLen(AbstractType t, BinaryAttribute battr)
        {
            //Получаем размер типа указанный в самом примитивном типе
            int len = t.len;
            //если он не указан/указан как 0, вычисляем
            if (len == 0)
            {
                //если размер типа указан пользователем
                if (battr.data_len != 0)
                    len = battr.data_len;
                //если пользователем указано еще и свойство содержащее размер типа то добавляем и его (мало ли что, может есть минимальный размер который должен быть, это никому не помешает)
                if (battr.data_len_member != "")
                {
                    //Получаем значение, важно что-бы это свойство находилось перед текущим свойством, если свойство существует берем его значение
                    object val = currentSerializebleObject.GetType().GetProperty(battr.data_len_member)?.GetValue(currentSerializebleObject, null);
                    //если в поля есть значение то переводим его в CInt32(в int32 нету смысла, CInt32 реализован так что имеет все нужные операторы и поля для комфортной работы, + преобразовываеться сам собой в int32 если это нужно)
                    if (val != null)
                        len += (CInt32)val;
                }
            }
            return len;
        }

        /// <summary>
        /// Получаем размер массива
        /// </summary>
        /// <param name="battr">Аттрибут текущего элемента</param>
        /// <returns></returns>
        protected int GetArrayLen(BinaryAttribute battr)
        {
            //размер массива указанный пользователем
            int len = battr.array_len;
            //если пользователем указано еще и свойство содержащее размер то добавляем и его (мало ли что, может есть минимальный размер который должен быть, это никому не помешает)
            if (battr.array_len_member != "")
            {
                //Получаем значение, важно что-бы это свойство находилось перед текущим свойством, если свойство существует берем его значение
                object val = currentSerializebleObject.GetType().GetProperty(battr.array_len_member)?.GetValue(currentSerializebleObject, null);
                //если в поля есть значение то переводим его в CInt32(в int32 нету смысла, CInt32 реализован так что имеет все нужные операторы и поля для комфортной работы, + преобразовываеться сам собой в int32 если это нужно)
                if (val != null)
                    len += (CInt32)val;
            }
            return len;
        }

        protected static Dictionary<Type, Type> compareType = new Dictionary<Type, Type>()
        {
            { typeof(short), typeof(CInt16) },
            { typeof(ushort), typeof(CUInt16) },
            { typeof(int), typeof(CInt32) },
            { typeof(uint), typeof(CUInt32) },
            { typeof(long), typeof(CInt64) },
            { typeof(ulong), typeof(CUInt64) },
        };
        /// <summary>
        /// Преобразовывает типа значения размера в тип подходящий под свойство которому оно присваивается
        /// </summary>
        /// <param name="Value">Значение</param>
        /// <param name="cType">Тип в который нужно его привести</param>
        /// <returns></returns>
        protected object ChangeLenType(object Value, Type cType)
        {
            if (!compareType.ContainsKey(Value.GetType()))
                throw new Exception();
            Type t = compareType[Value.GetType()];
            var constr = t.GetConstructor(new Type[] { Value.GetType() });
            if (constr == null)
                throw new Exception();
            return constr.Invoke(new object[] { Value });
        }

    }
}
