using System.Collections.Generic;
using System.Linq;

namespace NoteApp.Library
{
    /// <summary>
    /// Хранит список всех заметок.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Возвращает список текущих заметок.
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Возвращает или задает индекс последней просматреваемой заметки
        /// </summary>
        public int SelectedNoteIndex { get; set; } = -1;

        /// <summary>
        /// Сортирует список заметок по дате последнего редактирования
        /// </summary>
        /// <param name="notes">Список заметок</param>
        /// <returns>Отсортированный по дате редактирования список заметок</returns>
        public List<Note> SortNotes(List<Note> notes)
        {
            var sortedNotes = notes.OrderByDescending(note => note.DateChanged).ToList();
            return sortedNotes;
        }

        /// <summary>
        /// Сортирует список заметок по дате редактирования, 
        /// оставляя только заметки выбранный категории
        /// </summary>
        /// <param name="notes">Список заметок</param>
        /// <param name="category">Категория заметок</param>
        /// <returns>Отсортированный по дате редактирования 
        /// Список заметок конкретной категории</returns>
        public List<Note> SortNotes(List<Note> notes, NotesCategory category)
        {
            var categoryNotes = notes.Where(note => note.Category == category).ToList();
            var sortedNotes = categoryNotes.OrderByDescending(note => note.DateChanged).ToList();
            return sortedNotes;
        }
    }
}
