namespace FileDownloaderWizard
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            pictureBox = new PictureBox();
            downloadButton = new Button();
            refreshButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(245, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Mini-Download Manager";
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(116, 95);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(364, 178);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(128, 319);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(120, 37);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(341, 319);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(120, 37);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 411);
            Controls.Add(refreshButton);
            Controls.Add(downloadButton);
            Controls.Add(pictureBox);
            Controls.Add(titleLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private PictureBox pictureBox;
        private Button downloadButton;
        private Button refreshButton;
    }
}
