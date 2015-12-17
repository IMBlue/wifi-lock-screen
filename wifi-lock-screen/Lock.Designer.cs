namespace wifi_lock_screen
{
    partial class Lock
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_lock = new System.Windows.Forms.PictureBox();
            this.idleCheck = new System.Windows.Forms.Timer(this.components);
            this.unlockCheck = new System.Windows.Forms.Timer(this.components);
            this.keepTop = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btn_lock)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_lock
            // 
            this.btn_lock.BackColor = System.Drawing.Color.Transparent;
            this.btn_lock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_lock.Image = global::wifi_lock_screen.Properties.Resources.lock_24px;
            this.btn_lock.Location = new System.Drawing.Point(0, 0);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(284, 261);
            this.btn_lock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btn_lock.TabIndex = 0;
            this.btn_lock.TabStop = false;
            this.btn_lock.Click += new System.EventHandler(this.btn_lock_Click);
            this.btn_lock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_lock_MouseClick);
            // 
            // idleCheck
            // 
            this.idleCheck.Enabled = true;
            this.idleCheck.Interval = 5000;
            this.idleCheck.Tick += new System.EventHandler(this.idleCheck_Tick);
            // 
            // unlockCheck
            // 
            this.unlockCheck.Enabled = true;
            this.unlockCheck.Interval = 5000;
            this.unlockCheck.Tick += new System.EventHandler(this.unlockCheck_Tick);
            // 
            // keepTop
            // 
            this.keepTop.Enabled = true;
            this.keepTop.Interval = 1;
            this.keepTop.Tick += new System.EventHandler(this.keepTop_Tick);
            // 
            // Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btn_lock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lock";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_lock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_lock;
        private System.Windows.Forms.Timer idleCheck;
        private System.Windows.Forms.Timer unlockCheck;
        private System.Windows.Forms.Timer keepTop;
    }
}

