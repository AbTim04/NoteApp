using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NoteApp.Library;

namespace NoteAppUI
{
    /// <summary>
    /// Пользовательский интерфейс для создания и редактирования заметок
    /// </summary>
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Копия редактируемого класса <see cref="Note">
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает или задает данные извне.
        /// Использует клон заметки.
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = (Note)value.Clone();

                if (_note.Name == null)
                {
                    TitleTextBox.Text = "Untitled";
                    _note.Name = TitleTextBox.Text;
                    CreatedDateTimePicker.Text = DateTime.Now.ToLongDateString();
                    ModifiedDateTimePicker.Text = DateTime.Now.ToLongDateString();
                }

                TitleTextBox.Text = _note.Name;
                CategoryComboBox.SelectedItem = _note.Category;
                CreatedDateTimePicker.Value = _note.DateCreated;
                ModifiedDateTimePicker.Value = _note.DateChanged;
                MainTextBox.Text = _note.Text;
            }
        }

        /// <summary>
        /// Создаёт экземпляр формы <see cref="NoteForm">
        /// </summary>
        public NoteForm()
        {
            InitializeComponent();

            var categories = Enum.GetValues(typeof(NotesCategory)).Cast<object>().ToArray();
            CategoryComboBox.Items.AddRange(categories);
        }

        /// <summary>
        /// Событие вызывающееся при нажатии на кнопку OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.BackColor == Color.LightSalmon)
            {
                MessageBox.Show("Name must contain no more than 50 symbols", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Событие вызывающееся при выборе категории заметок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.Category = (NotesCategory)CategoryComboBox.SelectedItem;
        }

        /// <summary>
        /// Событие вызывающееся при нажатии на кнопку Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Событие вызывающееся при изменени в поле MainTextBox
        /// (Текста заметки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.Text = MainTextBox.Text;
        }

        /// <summary>
        /// Событие вызывающееся при изменени в поле TextBox
        /// (Заголовка заметки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _note.Name = TitleTextBox.Text;

                TitleTextBox.BackColor = Color.White;
            }
            catch
            {
                TitleTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
