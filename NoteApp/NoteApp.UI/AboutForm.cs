using System.Windows.Forms;

namespace NoteAppUI
{
    /// <summary>
    /// Содержит сведения о приложении
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Создаёт экземпляр формы <see cref="AboutForm">
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события нажатия на ссылку
        /// на почтовый ящик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmaleLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto: Robkanov@mail.ru");
        }

        /// <summary>
        /// Обрабокта события нажатия на ссылку GitHub
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kuborga/NoteApp");
        }
    }
}
