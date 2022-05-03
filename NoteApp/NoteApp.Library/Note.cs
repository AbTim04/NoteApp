using System;
using Newtonsoft.Json;

namespace NoteApp.Library
{
    /// <summary>
    /// Хранит название,категорию, содержание заметки,
    /// время создания и изменения.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _name = "Untitled";

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NotesCategory _category = NotesCategory.Other;

        /// <summary>
        /// Содержание заметки.
        /// </summary>
        private string _text;

        /// <summary>
        /// Время создания заметки. По умолчанию задано текущее текущее время.
        /// </summary>
        private DateTime _dateCreated = DateTime.Now;

        /// <summary>
        /// Время последнего изменения заметки.
        /// </summary>
        private DateTime _dateChanged = DateTime.Now;

        /// <summary>
        /// Возвращает или задает название заметки.
        /// Имя должно быть не более 50 символов.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length >= 50)
                {
                    throw new ArgumentException
                        ("Name must contain no more than 50 symbols");
                }
                else if (value == "")
                {
                    _name = "Untitled";
                    DateChanged = DateTime.Now;
                }
                else
                {
                    _name = value;
                    DateChanged = DateTime.Now;
                }
            }
        }

        ///<summary>
        ///Возвращает или задает категорию заметки.
        ///</summary>
        public NotesCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                DateChanged = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или задает текст заметки.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                DateChanged = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает  время создания заметки.
        /// </summary>
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }

            private set
            {
                _dateCreated = value;
            }
        }

        /// <summary>
        /// Возвращает или задает время последнего изменения.
        /// </summary>
        public DateTime DateChanged
        {
            get
            {
                return _dateChanged;
            }

            private set
            {
                _dateChanged = value;
            }
        }

        /// <summary>
        /// Конструктор класса Note.
        /// </summary>
        public Note()
        {

        }

        /// <summary>
        /// Конструктор класса Note для сериализации.
        /// </summary>
        /// <param name="name">Не более 50 символов</param>
        /// <param name="category"></param>
        /// <param name="text"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateChanged"></param>
        [JsonConstructor]
        public Note(string name, NotesCategory category, string text, DateTime dateCreated, DateTime dateChanged)
        {
            Name = name;
            Category = category;
            Text = text;
            DateCreated = dateCreated;
            DateChanged = dateChanged;
        }

        /// <summary>
        /// Реализация интерфейса IClonable
        /// </summary>
        /// <returns>Клон заметки</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


}