namespace safebox
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroToggle2 = new MetroFramework.Controls.MetroToggle();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroToggle3 = new MetroFramework.Controls.MetroToggle();
            this.metroTile5 = new MetroFramework.Controls.MetroTile();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroToggle4 = new MetroFramework.Controls.MetroToggle();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(133, 192);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 31);
            this.metroToggle1.TabIndex = 0;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle1.UseVisualStyleBackColor = true;
            // 
            // metroToggle2
            // 
            this.metroToggle2.AutoSize = true;
            this.metroToggle2.Location = new System.Drawing.Point(134, 131);
            this.metroToggle2.Name = "metroToggle2";
            this.metroToggle2.Size = new System.Drawing.Size(80, 31);
            this.metroToggle2.TabIndex = 0;
            this.metroToggle2.Text = "Off";
            this.metroToggle2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle2.UseVisualStyleBackColor = true;
            this.metroToggle2.CheckedChanged += new System.EventHandler(this.metroToggle2_CheckedChanged);
            // 
            // metroTile1
            // 
            this.metroTile1.AutoSize = true;
            this.metroTile1.BackColor = System.Drawing.Color.Transparent;
            this.metroTile1.CustomBackground = true;
            this.metroTile1.CustomForeColor = true;
            this.metroTile1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroTile1.Location = new System.Drawing.Point(50, 115);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(56, 54);
            this.metroTile1.TabIndex = 1;
            this.metroTile1.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile1.TileImage")));
            this.metroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseTileImage = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.Location = new System.Drawing.Point(29, 103);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(225, 138);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTile2.TabIndex = 2;
            // 
            // metroTile3
            // 
            this.metroTile3.AutoSize = true;
            this.metroTile3.BackColor = System.Drawing.Color.Transparent;
            this.metroTile3.CustomBackground = true;
            this.metroTile3.CustomForeColor = true;
            this.metroTile3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroTile3.Location = new System.Drawing.Point(50, 168);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(60, 67);
            this.metroTile3.TabIndex = 1;
            this.metroTile3.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile3.TileImage")));
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile3.UseTileImage = true;
            // 
            // metroTile4
            // 
            this.metroTile4.Location = new System.Drawing.Point(29, 226);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(225, 126);
            this.metroTile4.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTile4.TabIndex = 2;
            // 
            // metroToggle3
            // 
            this.metroToggle3.AutoSize = true;
            this.metroToggle3.Location = new System.Drawing.Point(133, 315);
            this.metroToggle3.Name = "metroToggle3";
            this.metroToggle3.Size = new System.Drawing.Size(80, 31);
            this.metroToggle3.TabIndex = 0;
            this.metroToggle3.Text = "Off";
            this.metroToggle3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle3.UseVisualStyleBackColor = true;
            // 
            // metroTile5
            // 
            this.metroTile5.BackColor = System.Drawing.Color.Transparent;
            this.metroTile5.CustomBackground = true;
            this.metroTile5.CustomForeColor = true;
            this.metroTile5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroTile5.Location = new System.Drawing.Point(50, 238);
            this.metroTile5.Name = "metroTile5";
            this.metroTile5.Size = new System.Drawing.Size(56, 54);
            this.metroTile5.TabIndex = 1;
            this.metroTile5.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile5.TileImage")));
            this.metroTile5.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile5.UseTileImage = true;
            // 
            // metroTile6
            // 
            this.metroTile6.BackColor = System.Drawing.Color.Transparent;
            this.metroTile6.CustomBackground = true;
            this.metroTile6.CustomForeColor = true;
            this.metroTile6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.metroTile6.Location = new System.Drawing.Point(50, 291);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(60, 67);
            this.metroTile6.TabIndex = 1;
            this.metroTile6.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTile6.TileImage")));
            this.metroTile6.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile6.UseTileImage = true;
            // 
            // metroToggle4
            // 
            this.metroToggle4.AutoSize = true;
            this.metroToggle4.Location = new System.Drawing.Point(134, 254);
            this.metroToggle4.Name = "metroToggle4";
            this.metroToggle4.Size = new System.Drawing.Size(80, 31);
            this.metroToggle4.TabIndex = 0;
            this.metroToggle4.Text = "Off";
            this.metroToggle4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle4.UseVisualStyleBackColor = true;
            this.metroToggle4.CheckedChanged += new System.EventHandler(this.metroToggle2_CheckedChanged);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.BackColor = System.Drawing.Color.Black;
            this.metroTextBox1.CustomBackground = true;
            this.metroTextBox1.CustomForeColor = true;
            this.metroTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.metroTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTextBox1.Location = new System.Drawing.Point(20, 30);
            this.metroTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(251, 53);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTextBox1.TabIndex = 3;
            this.metroTextBox1.Text = "HEEJO\'S SAFEBOX";
            this.metroTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseStyleColors = true;
            this.metroTextBox1.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.metroTextBox2.Location = new System.Drawing.Point(1, 398);
            this.metroTextBox2.Margin = new System.Windows.Forms.Padding(0);
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.Size = new System.Drawing.Size(297, 61);
            this.metroTextBox2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTextBox2.TabIndex = 4;
            this.metroTextBox2.Text = "카메라가 켜졌습니다.";
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(291, 459);
            this.ControlBox = false;
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroToggle4);
            this.Controls.Add(this.metroToggle2);
            this.Controls.Add(this.metroTile6);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.metroTile5);
            this.Controls.Add(this.metroToggle3);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroTile4);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.metroTile2);
            this.DisplayHeader = false;
            this.Font = new System.Drawing.Font("-윤고딕330", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroToggle metroToggle2;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroToggle metroToggle3;
        private MetroFramework.Controls.MetroTile metroTile5;
        private MetroFramework.Controls.MetroTile metroTile6;
        private MetroFramework.Controls.MetroToggle metroToggle4;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
    }
}

