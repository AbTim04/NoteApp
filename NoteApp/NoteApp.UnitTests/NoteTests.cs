using System;
using NUnit.Framework;
using NoteApp.Library;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        /// <summary>
        /// Экземпляр класса <see cref="Note"/> для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Метод создания пустой заметки
        /// </summary>
        public Note Note_Init()
        {
            _note = new Note();
            return _note;
        }

        [Test(Description = "Позитивный тест геттера и сеттера Name")]
        public void Title_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = "Test title for note";

            //Act
            note.Name = expected;
            var actual = note.Name;

            //Assert
            Assert.AreEqual(actual, expected,
                "Геттер или сеттер Name возвращает неправильный текст");
        }
    }
}
