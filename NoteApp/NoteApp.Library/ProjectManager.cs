using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp.Library
{
    /// <summary>
    /// Класс содержащий менеджер проектов.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Возвращает путь по умолчанию
        /// </summary>
        public static string DefaultPath { get; private set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\ABdeevTV\NoteApp\NoteApp.notes";

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="project">сериализуемый объект</param>
        /// <param name="filename">Название файла</param>
        public static void SaveToFile(Project project, string fileName)
        {
            //Создание папки если отсутствует
            var folder = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            //Сериализация
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Десериализация
        /// </summary>
        /// <param name="filename">Название файла</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            var readProject = new Project();

            //Если файл не найден, загрузить
            // Иначе вернуть пустой проект
            if (File.Exists(filename))
            {
                //Если файл поврежден,вернуть пустой проект
                try
                {
                    var serializer = new JsonSerializer();
                    using (var sr = new StreamReader(filename))
                    using (var reader = new JsonTextReader(sr))
                        readProject = (Project)serializer.Deserialize<Project>(reader);
                }
                catch
                {
                    return new Project();
                }
                if (readProject != null)
                {
                    return readProject;
                }
            }
            return new Project();
        }
    }
}