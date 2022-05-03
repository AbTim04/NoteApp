
namespace NoteAppUI
{
    partial class AboutForm
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
            this.components = new System.ComponentModel.Container();
            this.NoteAppLable = new System.Windows.Forms.Label();
            this.VersionLable = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.EmaleLabel = new System.Windows.Forms.Label();
            this.EmaleLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GitHubLabel = new System.Windows.Forms.Label();
            this.GitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteAppLable
            // 
            this.NoteAppLable.AutoSize = true;
            this.NoteAppLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoteAppLable.Location = new System.Drawing.Point(12, 9);
            this.NoteAppLable.Name = "NoteAppLable";
            this.NoteAppLable.Size = new System.Drawing.Size(92, 24);
            this.NoteAppLable.TabIndex = 1;
            this.NoteAppLable.Text = "NoteApp";
            // 
            // VersionLable
            // 
            this.VersionLable.AutoSize = true;
            this.VersionLable.Location = new System.Drawing.Point(16, 40);
            this.VersionLable.Name = "VersionLable";
            this.VersionLable.Size = new System.Drawing.Size(40, 13);
            this.VersionLable.TabIndex = 2;
            this.VersionLable.Text = "v 1.0.0";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(16, 80);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(104, 13);
            this.AuthorLabel.TabIndex = 3;
            this.AuthorLabel.Text = "Author: Abdeev T.V.";
            // 
            // EmaleLabel
            // 
            this.EmaleLabel.AutoSize = true;
            this.EmaleLabel.Location = new System.Drawing.Point(16, 120);
            this.EmaleLabel.Name = "EmaleLabel";
            this.EmaleLabel.Size = new System.Drawing.Size(107, 13);
            this.EmaleLabel.TabIndex = 4;
            this.EmaleLabel.Text = "e-male for feedback: ";
            // 
            // EmaleLinkLabel
            // 
            this.EmaleLinkLabel.AutoSize = true;
            this.EmaleLinkLabel.Location = new System.Drawing.Point(120, 120);
            this.EmaleLinkLabel.Name = "EmaleLinkLabel";
            this.EmaleLinkLabel.Size = new System.Drawing.Size(99, 13);
            this.EmaleLinkLabel.TabIndex = 5;
            this.EmaleLinkLabel.TabStop = true;
            this.EmaleLinkLabel.Text = "AbdeevTV@mail.ru";
            this.EmaleLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EmaleLinkLabel_LinkClicked);
            // 
            // GitHubLabel
            // 
            this.GitHubLabel.AutoSize = true;
            this.GitHubLabel.Location = new System.Drawing.Point(16, 145);
            this.GitHubLabel.Name = "GitHubLabel";
            this.GitHubLabel.Size = new System.Drawing.Size(46, 13);
            this.GitHubLabel.TabIndex = 6;
            this.GitHubLabel.Text = "GitHub: ";
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.Location = new System.Drawing.Point(60, 145);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(96, 13);
            this.GitHubLinkLabel.TabIndex = 7;
            this.GitHubLinkLabel.TabStop = true;
            this.GitHubLinkLabel.Text = "AbTim04/NoteApp";
            this.GitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "2022 Abdeev T.V.";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GitHubLinkLabel);
            this.Controls.Add(this.GitHubLabel);
            this.Controls.Add(this.EmaleLinkLabel);
            this.Controls.Add(this.EmaleLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLable);
            this.Controls.Add(this.NoteAppLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(425, 340);
            this.MinimumSize = new System.Drawing.Size(425, 340);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NoteAppLable;
        private System.Windows.Forms.Label VersionLable;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label EmaleLabel;
        private System.Windows.Forms.LinkLabel EmaleLinkLabel;
        private System.Windows.Forms.Label GitHubLabel;
        private System.Windows.Forms.LinkLabel GitHubLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}