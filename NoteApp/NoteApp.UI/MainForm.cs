using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using NoteApp.Library;
using Enum = System.Enum;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Класс содержащий список классов Note.
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Отсортированный список заметок.
        /// </summary>
        private List<Note> _viewedNotes = new List<Note>();

        public MainForm()
        {
            InitializeComponent();

            CategoryComboBox.Items.Add("All");
            var categories = Enum.GetValues(typeof(NotesCategory)).Cast<object>().ToArray();
            CategoryComboBox.Items.AddRange(categories);
            CategoryComboBox.SelectedItem = "All";

            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);
            RefreshListBox();

            //Выбирает последнюю просматреваемую заметку, если таковая существует в списке
            if (_viewedNotes.Count != 0)
            {
                NoteListBox.SelectedIndex = _project.SelectedNoteIndex;
            }
        }

        /// <summary>
        /// Обновляет список заметок, отображаемых на главной форме
        /// </summary>
        public void RefreshListBox()
        {
            //Производит сортировку в соответствии с выбранной категорией
            if (CategoryComboBox.SelectedItem == (object)"All")
            {
                _project.Notes = _project.SortNotes(_project.Notes);
              
                _viewedNotes = _project.Notes.ToList();
            }
            else
            {
                _viewedNotes = _project.SortNotes(_project.Notes,
                    (NotesCategory)CategoryComboBox.SelectedItem);
            }

            NoteListBox.Items.Clear();
            foreach (Note note in _viewedNotes)
            {
                NoteListBox.Items.Add(note.Name);
            }

            if (NoteListBox.Items.Count > 0)
            {
                NoteListBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Обновляет отображение правой панели главной формы.
        /// Выводит название, текст, категорию и даты выбранной заметки
        /// </summary>
        public void RefreshCurrentNote()
        {
            var selected = NoteListBox.SelectedIndex;
            if (selected == -1)
            {
                TextBox.Text = "";
                NoteTitleLabel.Text = "No title";
                NoteCategoryLabel.Text = "none";
                CreatedDateTimePicker.Value = DateTime.Now;
                ModifiedDateTimePicker.Value = DateTime.Now;
            }
            else
            {
                var currentNote = _viewedNotes[selected];
                TextBox.Text = currentNote.Text;
                NoteTitleLabel.Text = currentNote.Name;
                NoteCategoryLabel.Text = currentNote.Category.ToString();
                CreatedDateTimePicker.Value = currentNote.DateCreated;
                ModifiedDateTimePicker.Value = currentNote.DateChanged;
            }
        }

        /// <summary>
        /// Вызывает окно создания заметки
        /// </summary>
        private void AddNote()
        {
            var note = new Note();
            var noteForm = new NoteForm();
            noteForm.Note = note;
            noteForm.ShowDialog();
            if (noteForm.DialogResult == DialogResult.OK)
            {
                note = noteForm.Note;

                //Добавляет заметку в реальный список
                _project.Notes.Insert(0, note);
                //Добавляет заметку в ListBox
                NoteListBox.Items.Insert(0, note.Name);
                //Добавляет заметку в отображаемый список
                _viewedNotes.Insert(0, note);

                NoteListBox.SelectedIndex = 0;

                RefreshListBox();
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            }
        }

        /// <summary>
        /// Удаляет заметку при подтверждении
        /// </summary>
        private void RemoveNote()
        {
            var selected = NoteListBox.SelectedIndex;

            if (selected == -1)
            {
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show
                    ("Delete note?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    //Удаляет заметку в реальном списке
                    var realIndex = _project.Notes.IndexOf(_viewedNotes[selected]);
                    _project.Notes.RemoveAt(realIndex);
                    //Удаляет заметку в отображаемом  списке
                    _viewedNotes.RemoveAt(selected);
                    //Удаляет заметку в ListBox
                    NoteListBox.Items.RemoveAt(selected);

                    if (NoteListBox.Items.Count > 0)
                    {
                        NoteListBox.SelectedIndex = 0;
                    }

                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                }
            }
        }

        /// <summary>
        /// Вызывает окно редактирования заметки
        /// </summary>
        private void EditNote()
        {
            var selected = NoteListBox.SelectedIndex;

            if (selected == -1)
            {
                return;
            }
            else
            {
                var note = _viewedNotes[selected];
                var editForm = new NoteForm();
                editForm.Note = note;
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    note = editForm.Note;

                    //Заменяет заметку в реальном списке
                    var realIndex = _project.Notes.IndexOf(_viewedNotes[selected]);
                    _project.Notes.RemoveAt(realIndex);
                    _project.Notes.Insert(0, note);

                    //Заменяет заметку в отображаемом списке
                    _viewedNotes.RemoveAt(selected);
                    _viewedNotes.Insert(0, note);
                    
                    //Заменяет заметку в ListBox
                    NoteListBox.Items.RemoveAt(selected);
                    NoteListBox.Items.Insert(0, note.Name);

                    NoteListBox.SelectedIndex = 0;

                    RefreshListBox();
                    ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                }
            }
        }

        /// <summary>
        /// Событие вызывающееся при выборе категории в ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshListBox();
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие проиходящее при изменении NoteListBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие удаляющие заметку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveNote();
            }
        }

        /// <summary>
        /// Событие вызывающее окно создания заметки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddNote();
            RefreshListBox();
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие вызывающее окно изменения заметки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            EditNote();
            RefreshListBox();
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие вызывающее окно создания заметки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNote();
            RefreshListBox();
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие вызывающее окно изменения заметки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditNote();
            RefreshListBox();
            RefreshCurrentNote();
        }

        /// <summary>
        /// Событие удаляющие заметку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        /// <summary>
        /// Событие вызывающее закрытие приложения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Событие создания окна About.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.Show();
        }

        /// <summary>
        /// Событие удаляющие заметку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteNoteButton_Click(object sender, EventArgs e)
        {
            RemoveNote();
        }

        /// <summary>
        /// Событие аварийного завершения работы программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _project.SelectedNoteIndex = NoteListBox.SelectedIndex;
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }
    }
}
