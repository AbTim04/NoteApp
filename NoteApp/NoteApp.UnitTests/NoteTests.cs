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
        public void Name_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = "Test name for note";

            //Act
            note.Name = expected;
            var actual = note.Name;

            //Assert
            Assert.AreEqual(actual, expected,
                "Геттер или сеттер Name возвращает неправильный текст");
        }
        [Test(Description = "Присвоение слишком большого значения Name: " +
            "больше 50 символов")]
        public void Name_TooLongName_ThrowsException()
        {
            //Setup
            var note = Note_Init();

            //Act
            var wrongName = "1212121212121212121212121212121212121212123313dasadsdasdasdd";

            //Assert
            Assert.Throws<ArgumentException>(
                () => { note.Name = wrongName; },
                    "Должно возникать исключение, если название длиннее 50 символов");
        }

        [Test(Description = "Присвоение пустой строки в качестве Name." +
            "Должно быть заменено на Без названия")]
        public void Name_EmptyString_ReturnsUntitled()
        {
            //Setup
            var note = Note_Init();
            var expected = "Untitled";

            //Act
            note.Name = "";
            var actual = note.Name;

            //Assert
            Assert.AreEqual(actual, expected,
                "Сеттер устанавливает неправильное название заметки");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Category")]
        public void Category_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = NotesCategory.Home;

            //Act
            note.Category = expected;
            var actual = note.Category;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Category возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Text")]
        public void Text_CorrectValue_ReturnsSameValue()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var note = Note_Init();
            var expected = "Good weather";

            //Act
            note.Text = expected;
            var actual = note.Text;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Text возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Created")]
        public void Created_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = DateTime.Now;

            //Act
            var actual = note.DateCreated;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Created возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Modified")]
        public void Modified_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = DateTime.Now;

            //Act
            var actual = note.DateChanged;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Modified возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест стандартного конструктора класса Note")]
        public void NoteConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expectedName = "Untitled";
            string expectedText = null;
            var expectedCategory = NotesCategory.Other;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Act
            var actual = note;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedName, actual.Name,
                "Стандартный конструктор возвращает неправильное имя заметки");
                Assert.AreEqual(expectedText, actual.Text,
                    "Стандартный конструктор возвращает неправильный текст заметки");
                Assert.AreEqual(expectedCategory, actual.Category,
                    "Стандартный конструктор возвращает неправильную категорию заметки");
                Assert.AreEqual(expectedCreated.Minute, actual.DateCreated.Minute,
                    "Стандартный конструктор возвращает неправильное время создания заметки");
                Assert.AreEqual(expectedModified.Minute, actual.DateChanged.Minute,
                    "Стандартный конструктор возвращает неправильное время" +
                     "последнего редактирования заметки");
            });
        }

        [Test(Description = "Позитивный тест Json конструктора класса Note")]
        public void NoteJsoneConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expectedName = "TestTitle";
            var expectedText = "TestText";
            var expectedCategory = NotesCategory.Job;
            var expectedCreated = DateTime.Parse("2022/01/01");
            var expectedModified = DateTime.Parse("2022/02/01");
            var note = new Note(expectedName, expectedCategory, expectedText,
                expectedCreated, expectedModified);

            //Act
            var actual = note;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedName, actual.Name,
                    "Json конструктор возвращает неправильное имя заметки");
                Assert.AreEqual(expectedText, actual.Text,
                    "Json конструктор возвращает неправильный текст заметки");
                Assert.AreEqual(expectedCategory, actual.Category,
                    "Json конструктор возвращает неправильную категорию заметки");
                Assert.AreEqual(expectedCreated.Minute, actual.DateCreated.Minute,
                    "Json конструктор возвращает неправильное время создания заметки");
                Assert.AreEqual(expectedModified.Minute, actual.DateChanged.Minute,
                    "Json конструктор возвращает неправильное время" +
                     "последнего редактирования заметки");
            });
        }

        [Test(Description = "Позитивный тест метода Clone")]
        public void Clone_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            Note expected = note;

            //Act
            var actual = (Note)note.Clone();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expected.Name, actual.Name, "Метод Clone устанавливает " +
                                                            "неправильное значение Name");
                Assert.AreEqual(expected.Text, actual.Text, "Метод Clone устанавливает " +
               "неправильное значение Text");
                Assert.AreEqual(expected.Category, actual.Category, "Метод Clone устанавливает " +
               "неправильное значение Category");
                Assert.AreEqual(expected.DateCreated, actual.DateCreated, "Метод Clone устанавливает " +
               "неправильное значение Created");
                Assert.AreEqual(expected.DateChanged, actual.DateChanged, "Метод Clone устанавливает " +
               " неправильное значение Modified");
            });
        }
    }
}
