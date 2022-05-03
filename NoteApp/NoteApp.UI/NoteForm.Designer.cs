
namespace NoteAppUI
{
    partial class NoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.CreatedLlabel = new System.Windows.Forms.Label();
            this.CreatedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ModifiedLabel = new System.Windows.Forms.Label();
            this.ModifiedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.MainTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(10, 15);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(10, 45);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "Category:";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(65, 12);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(454, 20);
            this.TitleTextBox.TabIndex = 2;
            this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(65, 42);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(121, 21);
            this.CategoryComboBox.TabIndex = 3;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // CreatedLlabel
            // 
            this.CreatedLlabel.AutoSize = true;
            this.CreatedLlabel.Location = new System.Drawing.Point(10, 75);
            this.CreatedLlabel.Name = "CreatedLlabel";
            this.CreatedLlabel.Size = new System.Drawing.Size(47, 13);
            this.CreatedLlabel.TabIndex = 4;
            this.CreatedLlabel.Text = "Created:";
            // 
            // CreatedDateTimePicker
            // 
            this.CreatedDateTimePicker.Enabled = false;
            this.CreatedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CreatedDateTimePicker.Location = new System.Drawing.Point(65, 73);
            this.CreatedDateTimePicker.Name = "CreatedDateTimePicker";
            this.CreatedDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.CreatedDateTimePicker.TabIndex = 5;
            // 
            // ModifiedLabel
            // 
            this.ModifiedLabel.AutoSize = true;
            this.ModifiedLabel.Location = new System.Drawing.Point(175, 75);
            this.ModifiedLabel.Name = "ModifiedLabel";
            this.ModifiedLabel.Size = new System.Drawing.Size(50, 13);
            this.ModifiedLabel.TabIndex = 6;
            this.ModifiedLabel.Text = "Modified:";
            // 
            // ModifiedDateTimePicker
            // 
            this.ModifiedDateTimePicker.Enabled = false;
            this.ModifiedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ModifiedDateTimePicker.Location = new System.Drawing.Point(225, 73);
            this.ModifiedDateTimePicker.Name = "ModifiedDateTimePicker";
            this.ModifiedDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.ModifiedDateTimePicker.TabIndex = 7;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTextBox.Location = new System.Drawing.Point(13, 101);
            this.MainTextBox.Multiline = true;
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainTextBox.Size = new System.Drawing.Size(505, 280);
            this.MainTextBox.TabIndex = 8;
            this.MainTextBox.TextChanged += new System.EventHandler(this.MainTextBox_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(361, 388);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(442, 388);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 439);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.ModifiedDateTimePicker);
            this.Controls.Add(this.ModifiedLabel);
            this.Controls.Add(this.CreatedDateTimePicker);
            this.Controls.Add(this.CreatedLlabel);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.TitleLabel);
            this.MinimumSize = new System.Drawing.Size(460, 455);
            this.Name = "NoteForm";
            this.Text = "Note";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Label CreatedLlabel;
        private System.Windows.Forms.DateTimePicker CreatedDateTimePicker;
        private System.Windows.Forms.Label ModifiedLabel;
        private System.Windows.Forms.DateTimePicker ModifiedDateTimePicker;
        private System.Windows.Forms.TextBox MainTextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}