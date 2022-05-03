using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using NoteApp.Library;

namespace NoteApp.UnitTests
{
    [TestFixture]
    class ProjectManagerTests
    {
        /// <summary>
        /// Экземпляр класса <see cref="Note"/> для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Экземпляр класса <see cref="Project"/> для проведения тестов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Путь к директории с тестовыми файлами
        /// </summary>
        private static string _currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Путь к корректному файлу
        /// </summary>
        private string _saveFilePath = _currentPath + @"\TestData\SavedFile.notes";

        /// <summary>
        /// Путь к корректному файлу
        /// </summary>
        private string _correctFilePath = _currentPath + @"\TestData\CorrectFile.notes";

        /// <summary>
        /// Некорректный путь к файлу
        /// </summary>
        private string _uncorrectFilePath = _currentPath + "NonExistFile.notes";

        /// <summary>
        /// Путь к повреждённому файлу
        /// </summary>
        private string _damagedFilePath = _currentPath + @"\TestData\DamagedFile.notes";

        /// <summary>
        /// Метод создания заметки
        /// с пользовательским временем создания и редактирования
        /// </summary>
        public Project Project_Init()
        {
            _note = new Note("Untitled", NotesCategory.Other, null,
                DateTime.Parse("2022/01/01"), DateTime.Parse("2022/01/01"));
            _project = new Project();
            _project.Notes.Add(_note);
            return _project;
        }

        [Test(Description = "Позитивный тест геттера Notes")]
        public void DefaultPath_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expected = Environment.GetFolderPath
               (Environment.SpecialFolder.ApplicationData)
               + @"\AbdeevTV\NoteApp\NoteApp.notes";

            //Act
            var actual = ProjectManager.DefaultPath;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер DefaultPath возвращает неправильный путь");
        }

        [Test(Description = "Позитивный тест сериализации")]
        public void SaveToFile_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var project = Project_Init();
            var expected = File.ReadAllText(_correctFilePath);

            //Act
            ProjectManager.SaveToFile(project, _saveFilePath);
            var actual = File.ReadAllText(_saveFilePath);

            //Assert
            Assert.AreEqual(expected, actual,
                "Метод SaveToFile возвращает неправильный проект");
        }

        [Test(Description = "Позитивный тест десериализации - папка существует")]
        public void LoadFromFile_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expectedProject = Project_Init();

            //Act
            var actualProject = ProjectManager.LoadFromFile(_correctFilePath);

            // Assert
            Assert.AreEqual(expectedProject.Notes.Count, actualProject.Notes.Count);
        }

        [Test(Description = "Негативный тест десериализации - папки не существует")]
        public void LoadFromFile_UncorrectPath_ReturnsNewProject()
        {
            //Setup
            var expected = new Project();

            //Act
            var actual = ProjectManager.LoadFromFile(_uncorrectFilePath);

            //Assert
            Assert.AreEqual(expected.Notes, actual.Notes,
                "Метод LoadFromFile возвращает неправильный проект");
            Assert.AreEqual(expected.SelectedNoteIndex, actual.SelectedNoteIndex,
                "Метод LoadFromFile возвращает неправильный " +
                "индекс последней просмтариеваемой заметки");
        }

        [Test(Description = "Тест десериализации если файл повреждён")]
        public void LoadFromFile_DamagedFile_ReturnsNewProject()
        {
            //Act
            var actualProject = ProjectManager.LoadFromFile(_damagedFilePath);

            //Assert
            Assert.AreEqual(actualProject.Notes.Count, 0);
            Assert.NotNull(actualProject);
        }

    }
}