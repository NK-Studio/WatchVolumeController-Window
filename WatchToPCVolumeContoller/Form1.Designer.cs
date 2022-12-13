namespace WatchToPCVolumeController
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.WatchVolumeController = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ipv4TextBox = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WatchVolumeController
            // 
            this.WatchVolumeController.Icon = ((System.Drawing.Icon)(resources.GetObject("WatchVolumeController.Icon")));
            this.WatchVolumeController.Text = "WatchVolumeController";
            this.WatchVolumeController.Visible = true;
            this.WatchVolumeController.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(263, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 104);
            this.label1.TabIndex = 0;
            this.label1.Text = "동작 중";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipv4TextBox
            // 
            this.ipv4TextBox.BackColor = System.Drawing.Color.White;
            this.ipv4TextBox.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ipv4TextBox.Location = new System.Drawing.Point(83, 226);
            this.ipv4TextBox.Name = "ipv4TextBox";
            this.ipv4TextBox.Size = new System.Drawing.Size(649, 79);
            this.ipv4TextBox.TabIndex = 1;
            this.ipv4TextBox.Text = "label2";
            this.ipv4TextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ipv4TextBox.Click += new System.EventHandler(this.ipv4TextBox_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.BackColor = System.Drawing.Color.White;
            this.portTextBox.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.portTextBox.Location = new System.Drawing.Point(83, 330);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(649, 79);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Text = "label2";
            this.portTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipv4TextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "WatchVolumeController";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label portTextBox;

        private System.Windows.Forms.Label ipv4TextBox;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.NotifyIcon WatchVolumeController;

        #endregion
    }
}