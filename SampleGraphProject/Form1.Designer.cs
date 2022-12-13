namespace SampleGraphProject
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DDALine = new System.Windows.Forms.ToolStripMenuItem();
            this.中点直线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenham直线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中点圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenham圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维图形变换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.二维图形剪裁ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图形填充ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.投影ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.消隐ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.二维图形变换ToolStripMenuItem,
            this.二维图形剪裁ToolStripMenuItem,
            this.图形填充ToolStripMenuItem,
            this.投影ToolStripMenuItem,
            this.消隐ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1605, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DDALine,
            this.中点直线ToolStripMenuItem,
            this.bresenham直线ToolStripMenuItem,
            this.中点圆ToolStripMenuItem,
            this.bresenham圆ToolStripMenuItem,
            this.清除ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 21);
            this.toolStripMenuItem1.Text = "基本图形生成";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // DDALine
            // 
            this.DDALine.Name = "DDALine";
            this.DDALine.Size = new System.Drawing.Size(180, 22);
            this.DDALine.Text = "DDA直线";
            this.DDALine.Click += new System.EventHandler(this.DDALine_Click);
            // 
            // 中点直线ToolStripMenuItem
            // 
            this.中点直线ToolStripMenuItem.Name = "中点直线ToolStripMenuItem";
            this.中点直线ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.中点直线ToolStripMenuItem.Text = "中点直线";
            this.中点直线ToolStripMenuItem.Click += new System.EventHandler(this.MidLine_Click);
            // 
            // bresenham直线ToolStripMenuItem
            // 
            this.bresenham直线ToolStripMenuItem.Name = "bresenham直线ToolStripMenuItem";
            this.bresenham直线ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bresenham直线ToolStripMenuItem.Text = "Bresenham直线";
            this.bresenham直线ToolStripMenuItem.Click += new System.EventHandler(this.bresenham直线ToolStripMenuItem_Click);
            // 
            // 中点圆ToolStripMenuItem
            // 
            this.中点圆ToolStripMenuItem.Name = "中点圆ToolStripMenuItem";
            this.中点圆ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.中点圆ToolStripMenuItem.Text = "中点圆";
            // 
            // bresenham圆ToolStripMenuItem
            // 
            this.bresenham圆ToolStripMenuItem.Name = "bresenham圆ToolStripMenuItem";
            this.bresenham圆ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bresenham圆ToolStripMenuItem.Text = "Bresenham圆";
            this.bresenham圆ToolStripMenuItem.Click += new System.EventHandler(this.bresenham圆ToolStripMenuItem_Click);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.清除ToolStripMenuItem.Text = "清除";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.Clear_Click);
            // 
            // 二维图形变换ToolStripMenuItem
            // 
            this.二维图形变换ToolStripMenuItem.Name = "二维图形变换ToolStripMenuItem";
            this.二维图形变换ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.二维图形变换ToolStripMenuItem.Text = "二维图形变换";
            // 
            // 二维图形剪裁ToolStripMenuItem
            // 
            this.二维图形剪裁ToolStripMenuItem.Name = "二维图形剪裁ToolStripMenuItem";
            this.二维图形剪裁ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.二维图形剪裁ToolStripMenuItem.Text = "二维图形剪裁";
            // 
            // 图形填充ToolStripMenuItem
            // 
            this.图形填充ToolStripMenuItem.Name = "图形填充ToolStripMenuItem";
            this.图形填充ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.图形填充ToolStripMenuItem.Text = "图形填充";
            // 
            // 投影ToolStripMenuItem
            // 
            this.投影ToolStripMenuItem.Name = "投影ToolStripMenuItem";
            this.投影ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.投影ToolStripMenuItem.Text = "投影";
            // 
            // 消隐ToolStripMenuItem
            // 
            this.消隐ToolStripMenuItem.Name = "消隐ToolStripMenuItem";
            this.消隐ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.消隐ToolStripMenuItem.Text = "消隐";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 783);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "              ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 二维图形变换ToolStripMenuItem;
        private ToolStripMenuItem 二维图形剪裁ToolStripMenuItem;
        private ToolStripMenuItem 图形填充ToolStripMenuItem;
        private ToolStripMenuItem 投影ToolStripMenuItem;
        private ToolStripMenuItem 消隐ToolStripMenuItem;
        private ToolStripMenuItem DDALine;
        private ToolStripMenuItem 中点直线ToolStripMenuItem;
        private ToolStripMenuItem bresenham直线ToolStripMenuItem;
        private ToolStripMenuItem 中点圆ToolStripMenuItem;
        private ToolStripMenuItem bresenham圆ToolStripMenuItem;
        private ToolStripMenuItem 清除ToolStripMenuItem;
    }
}