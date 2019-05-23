namespace POSPrinter
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.StatusStrip statusStrip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblWsClientConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileDownload = new System.Windows.Forms.ToolStripProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runOnStartUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbOrderPrinters = new System.Windows.Forms.ComboBox();
            this.lblOrderPrinter = new System.Windows.Forms.Label();
            this.btnSavePrinters = new System.Windows.Forms.Button();
            this.bgwListPrinters = new System.ComponentModel.BackgroundWorker();
            this.btnReloadPrinters = new System.Windows.Forms.Button();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWsClientConnection,
            this.fileDownload});
            statusStrip1.Location = new System.Drawing.Point(0, 209);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(273, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblWsClientConnection
            // 
            this.lblWsClientConnection.ForeColor = System.Drawing.Color.Black;
            this.lblWsClientConnection.Name = "lblWsClientConnection";
            this.lblWsClientConnection.Size = new System.Drawing.Size(97, 17);
            this.lblWsClientConnection.Text = "Not Connected...";
            // 
            // fileDownload
            // 
            this.fileDownload.Name = "fileDownload";
            this.fileDownload.Size = new System.Drawing.Size(100, 16);
            this.fileDownload.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(273, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runOnStartUp});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // runOnStartUp
            // 
            this.runOnStartUp.Name = "runOnStartUp";
            this.runOnStartUp.Size = new System.Drawing.Size(180, 22);
            this.runOnStartUp.Text = "Run on start";
            this.runOnStartUp.Click += new System.EventHandler(this.runOnStartUp_Click);
            // 
            // cmbOrderPrinters
            // 
            this.cmbOrderPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderPrinters.FormattingEnabled = true;
            this.cmbOrderPrinters.Location = new System.Drawing.Point(15, 140);
            this.cmbOrderPrinters.Name = "cmbOrderPrinters";
            this.cmbOrderPrinters.Size = new System.Drawing.Size(246, 21);
            this.cmbOrderPrinters.TabIndex = 8;
            // 
            // lblOrderPrinter
            // 
            this.lblOrderPrinter.AutoSize = true;
            this.lblOrderPrinter.Location = new System.Drawing.Point(12, 124);
            this.lblOrderPrinter.Name = "lblOrderPrinter";
            this.lblOrderPrinter.Size = new System.Drawing.Size(37, 13);
            this.lblOrderPrinter.TabIndex = 7;
            this.lblOrderPrinter.Text = "Printer";
            // 
            // btnSavePrinters
            // 
            this.btnSavePrinters.Location = new System.Drawing.Point(15, 167);
            this.btnSavePrinters.Name = "btnSavePrinters";
            this.btnSavePrinters.Size = new System.Drawing.Size(126, 34);
            this.btnSavePrinters.TabIndex = 9;
            this.btnSavePrinters.Text = "Save";
            this.btnSavePrinters.UseVisualStyleBackColor = true;
            this.btnSavePrinters.Click += new System.EventHandler(this.btnSavePrinters_Click);
            // 
            // bgwListPrinters
            // 
            this.bgwListPrinters.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwListPrinters_DoWork);
            // 
            // btnReloadPrinters
            // 
            this.btnReloadPrinters.Location = new System.Drawing.Point(147, 167);
            this.btnReloadPrinters.Name = "btnReloadPrinters";
            this.btnReloadPrinters.Size = new System.Drawing.Size(114, 34);
            this.btnReloadPrinters.TabIndex = 10;
            this.btnReloadPrinters.Text = "Reload Printers";
            this.btnReloadPrinters.UseVisualStyleBackColor = true;
            this.btnReloadPrinters.Click += new System.EventHandler(this.btnReloadPrinters_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 231);
            this.Controls.Add(this.btnReloadPrinters);
            this.Controls.Add(this.btnSavePrinters);
            this.Controls.Add(this.cmbOrderPrinters);
            this.Controls.Add(this.lblOrderPrinter);
            this.Controls.Add(statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(289, 270);
            this.MinimumSize = new System.Drawing.Size(289, 270);
            this.Name = "Form1";
            this.Text = "Needza POS Printer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runOnStartUp;
        private System.Windows.Forms.ComboBox cmbOrderPrinters;
        private System.Windows.Forms.Label lblOrderPrinter;
        private System.Windows.Forms.Button btnSavePrinters;
        public System.Windows.Forms.ToolStripStatusLabel lblWsClientConnection;
        private System.ComponentModel.BackgroundWorker bgwListPrinters;
        private System.Windows.Forms.Button btnReloadPrinters;
        private System.Windows.Forms.ToolStripProgressBar fileDownload;
    }
}

