namespace SubtitlesResyncer
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.subtitlesTextBox = new System.Windows.Forms.TextBox();
            this.textBoxSyncMs = new System.Windows.Forms.TextBox();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.buttonResync = new System.Windows.Forms.Button();
            this.okIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.okIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.subtitlesTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.okIcon);
            this.splitContainer1.Panel2.Controls.Add(this.buttonResync);
            this.splitContainer1.Panel2.Controls.Add(this.labelSeconds);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSyncMs);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.TabIndex = 0;
            // 
            // subtitlesTextBox
            // 
            this.subtitlesTextBox.AllowDrop = true;
            this.subtitlesTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.subtitlesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subtitlesTextBox.Location = new System.Drawing.Point(0, 0);
            this.subtitlesTextBox.Multiline = true;
            this.subtitlesTextBox.Name = "subtitlesTextBox";
            this.subtitlesTextBox.ReadOnly = true;
            this.subtitlesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.subtitlesTextBox.Size = new System.Drawing.Size(800, 402);
            this.subtitlesTextBox.TabIndex = 0;
            this.subtitlesTextBox.Text = "Trascina file sottotitoli qui, o fai doppio click...";
            this.subtitlesTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.subtitlesTextBox_DragDrop);
            this.subtitlesTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.subtitlesTextBox_DragEnter);
            this.subtitlesTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.subtitlesTextBox_MouseDoubleClick);
            // 
            // textBoxSyncMs
            // 
            this.textBoxSyncMs.Location = new System.Drawing.Point(96, 9);
            this.textBoxSyncMs.Name = "textBoxSyncMs";
            this.textBoxSyncMs.Size = new System.Drawing.Size(100, 20);
            this.textBoxSyncMs.TabIndex = 0;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(12, 12);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(78, 13);
            this.labelSeconds.TabIndex = 1;
            this.labelSeconds.Text = "Variazione (ms)";
            // 
            // buttonResync
            // 
            this.buttonResync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResync.Location = new System.Drawing.Point(713, 7);
            this.buttonResync.Name = "buttonResync";
            this.buttonResync.Size = new System.Drawing.Size(75, 23);
            this.buttonResync.TabIndex = 2;
            this.buttonResync.Text = "Resync";
            this.buttonResync.UseVisualStyleBackColor = true;
            this.buttonResync.Click += new System.EventHandler(this.buttonResync_Click);
            // 
            // okIcon
            // 
            this.okIcon.Image = global::SubtitlesResyncer.Properties.Resources.ok_icon;
            this.okIcon.Location = new System.Drawing.Point(665, -2);
            this.okIcon.Name = "okIcon";
            this.okIcon.Size = new System.Drawing.Size(42, 38);
            this.okIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.okIcon.TabIndex = 3;
            this.okIcon.TabStop = false;
            this.okIcon.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Subtitles Resyncer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.okIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox subtitlesTextBox;
        private System.Windows.Forms.Button buttonResync;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.TextBox textBoxSyncMs;
        private System.Windows.Forms.PictureBox okIcon;
    }
}

