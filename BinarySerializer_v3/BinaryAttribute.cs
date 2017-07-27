using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySerializer
{
    public class BinaryAttribute : System.Attribute
    {
        /// <summary>
        /// Тип, может содержать как примитивный тип BinarySerializer так и тип класса
        /// </summary>
        internal Type type;

        /// <summary>
        /// Размер типа, устанавливаеться в инициализаторе примитивного типа
        /// </summary>
        public int data_len = 0;

        /// <summary>
        /// Имя свойства которое содержит размер типа (свойство должно находиться в текущем классе)
        /// </summary>
        public string data_len_member = "";

        /// <summary>
        /// Размер массива, работает только для типов унаследованых от интерфейса IEnumerable
        /// </summary>
        public int array_len = 0;

        /// <summary>
        /// Имя поля которое содержит размер массива (свойство должно находиться в текущем классе), работает только для типов унаследованых от интерфейса IEnumerable
        /// </summary>
        public string array_len_member = "";

        /// <summary>
        /// Инициирует атрибут для бинарного сериализатора с указаным типом
        /// </summary>
        /// <param name="type">Тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        public BinaryAttribute(Type type)
        {
            this.type = type;
        }

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом и размером типа
        ///// </summary>
        ///// <param name="type">Тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len">Размер типа, актуален для типов которые содержат в себе динамический размер байт типа String и др.</param>
        //public BinaryAttribute(Type type, int data_len = 0) : this(type)
        //{
        //    this.data_len = data_len;
        //}

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом и именем поля которое содержит размер типа
        ///// </summary>
        ///// <param name="type">Тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len_member">Имя поля которое содержит размер типа, обязательно должен находиться в текущем классе, актуален для типов которые содержат в себе динамический размер байт, типа String и др.</param>
        //public BinaryAttribute(Type type, string data_len_member = "") : this(type)
        //{
        //    this.data_len_member = data_len_member;
        //}

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом, размером типа и размером массива
        ///// </summary>
        ///// <param name="type">Тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len">Размер типа, актуален для типов которые содержат в себе динамический размер байт типа String и др.</param>
        ///// <param name="array_len">Размер массива, (только если тип наследуеться от IEnumerable)</param>
        //public BinaryAttribute(Type type, int data_len = 0, int array_len = 0) : this(type, data_len)
        //{
        //    this.array_len = array_len;
        //}

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом, именем поля которое содержит размер типа и размером массива
        ///// </summary>
        ///// <param name="type">Тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len_member">Имя поля которое содержит размер типа, обязательно должен находиться в текущем классе, актуален для типов которые содержат в себе динамический размер байт, типа String и др.</param>
        ///// <param name="array_len">Размер массива, (только если тип наследуеться от IEnumerable)</param>
        //public BinaryAttribute(Type type, string data_len_member = "", int array_len = 0) : this(type, 0, array_len)
        //{
        //    this.data_len_member = data_len_member;
        //}

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом, размером типа и свойством содержащим размер массива
        ///// </summary>
        ///// <param name="type">тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len">Размер типа, актуален для типов которые содержат в себе динамический размер байт типа String и др.</param>
        ///// <param name="array_len_member">Имя поля которое содержит размер массива, обязательно должен находиться в текущем классе, (только если тип наследуеться от IEnumerable)</param>
        //public BinaryAttribute(Type type, int data_len = 0, string array_len_member = "") : this(type, data_len)
        //{
        //    this.array_len_member = array_len_member;
        //}

        ///// <summary>
        /////  Инициирует атрибут для бинарного сериализатора с указаным типом, свойством содержащим размер типа и размером массива
        ///// </summary>
        ///// <param name="type">тип поля, может быть как примитивный тип BinarySerializer так и тип класса</param>
        ///// <param name="data_len_member">Имя поля которое содержит размер типа, обязательно должен находиться в текущем классе, актуален для типов которые содержат в себе динамический размер байт, типа String и др.</param>
        ///// <param name="array_len_member">Имя поля которое содержит размер массива, обязательно должен находиться в текущем классе, (только если тип наследуеться от IEnumerable)</param>
        //public BinaryAttribute(Type type, string data_len_member = "", string array_len_member = "") : this(type)
        //{
        //    this.data_len_member = data_len_member;
        //    this.array_len_member = array_len_member;
        //}
    }
}
