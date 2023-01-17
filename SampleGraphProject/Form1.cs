namespace SampleGraphProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private Color _backColor = Color.White;


        private Color _foreColor = Color.Black;
        public int MenuID;
        public int PressNumber;
        public int FirstNumber;
        public int FirstX;
        public int FirstY;
        public int OldX;
        public int OldY;

        private void DDALine_Click(object sender, EventArgs e)
        {
            MenuID = 1;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.GetNearestColor(BackColor);
        }

        private void MidLine_Click(object sender, EventArgs e)
        {
            MenuID = 2;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void bresenham圆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuID = 5;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void bresenham直线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //橡皮筋
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen BackPen = new Pen(BackColor, 1);
            Pen FrontPen = new Pen(_foreColor, 1);

            if (MenuID == 1 || MenuID == 2 && PressNumber == 1)
            {
                //g.DrawLine(BackPen, FirstX, FirstY, OldX, OldY);//旧的线用背景色覆盖(擦除)
                //g.DrawLine(FrontPen, FirstX, FirstY, e.X, e.Y);//新的线显性

                OldX = e.X;
                OldY = e.Y;
            }

            if (MenuID == 5 && PressNumber == 1)
            {
                if (!(e.X == OldX && e.Y == OldY))
                {
                    int r = (int)MathF.Sqrt((FirstX - OldX) * (FirstX - OldX) + (FirstY - OldY) * (FirstY - OldY));//半径

                    g.DrawEllipse(BackPen, FirstX - r, FirstY - r, 2 * r, 2 * r);//删除旧的

                    int rNew = (int)MathF.Sqrt((FirstX - e.X) * (FirstX - e.X) + (FirstY - e.Y) * (FirstY - e.Y));//半径

                    g.DrawEllipse(FrontPen, FirstX - rNew, FirstY - rNew, 2 * rNew, 2 * rNew);//删除旧的

                    OldX = e.X;
                    OldY = e.Y;
                }
            }

            if (MenuID == 31 && PressNumber > 0)
            {
                if (!(e.X == OldX && e.Y == OldY))
                {
                    g.DrawLine(BackPen, points[PressNumber - 1].X, points[PressNumber - 1].Y, OldX, OldY);//旧的线用背景色覆盖(擦除)
                    g.DrawLine(FrontPen, points[PressNumber - 1].X, points[PressNumber - 1].Y, e.X, e.Y);//新的线显性

                    OldX = e.X;
                    OldY = e.Y;
                }
            }
        }

        //绘制
        private void Form1_MouseClickUpdate(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);

            if (MenuID == 31)//扫描线填充
            {
                if (e.Button == MouseButtons.Left)
                {
                    points[PressNumber].X = e.X;
                    points[PressNumber].Y = e.Y;
                    if (PressNumber > 0)//画多边形
                    {
                        g.DrawLine(Pens.Red, points[PressNumber - 1], points[PressNumber]);
                    }
                    PressNumber++;
                }
                if (e.Button == MouseButtons.Right)//右键结束多边形绘制，开始填充
                {
                    g.DrawLine(Pens.Red, points[PressNumber - 1], points[0]);
                    ScanLineFill();
                    PressNumber = 0;
                }
            }

            if (MenuID == 1)
            {
                if (PressNumber == 0)//第一个点
                {
                    FirstX = e.X;
                    FirstY = e.Y;
                    OldX = e.X;
                    OldY = e.Y;
                }
                else//第二个点
                {
                    //g.DrawLine(pen, FirstX, FirstY, e.X, e.Y);
                    DDALine_kx_b(pen, FirstX, FirstY, e.X, e.Y);
                }
                PressNumber++;
                if (PressNumber >= 2)
                {
                    PressNumber = 0;
                }
            }

            if (MenuID == 2)
            {
                if (PressNumber == 0)//第一个点
                {
                    FirstX = e.X;
                    FirstY = e.Y;
                    OldX = e.X;
                    OldY = e.Y;
                }
                else//第二个点
                {
                    //g.DrawLine(pen, FirstX, FirstY, e.X, e.Y);
                    MidLine(pen, FirstX, FirstY, e.X, e.Y);
                }
                PressNumber++;
                if (PressNumber >= 2)
                {
                    PressNumber = 0;
                }
            }

            if (MenuID == 5)
            {
                if (PressNumber == 0)
                {
                    FirstX = e.X;
                    FirstX = e.Y;//圆心
                }
                else
                {
                    //第二点 半径
                    BresenhamCircle(FirstX, FirstY, e.X, e.Y);
                }
                PressNumber++;
                if (PressNumber >= 2)
                {
                    PressNumber = 0;
                }
            }
        }

        #region 算法

        private void Kx_b(int x0, int y0, int x1, int y1)
        {
            //因为X 从左往右步进，因此X0 始终在左侧，否则只能绘制从左往右的线段
            if (x0 > x1)//如果从右往左绘制，交换两点
            {
                int temp = x0;
                x0 = x1;
                x1 = temp;

                temp = y0;
                y0 = y1;
                y1 = temp;
            }
            Graphics g = CreateGraphics();
            float dx = x1 - x0;
            float dy = y1 - y0;

            float k = dy / dx;

            if (x1 - x0 == 0)
            {
                return;
            }
            float b = (-x0 / (x1 - x0)) * (y1 - y0) + y0;
            //通过两点直线公式  计算位置，

            float xStart = x0;
            int xEnd = x1;
            float yStart = y0;
            float step = 0.1f;

            for (; xStart < xEnd; xStart += step, yStart = k * xStart + b)//每次x 计算y
            {
                g.DrawRectangle(Pens.Red, xStart, yStart, 1, 1);
            }
        }

        private void DDALine_kx_b_Step(int x0, int y0, int x1, int y1)
        {
            //因为X 从左往右步进，因此X0 始终在左侧，否则只能绘制从左往右的线段
            if (x0 > x1)//如果从右往左绘制，交换两点
            {
                int temp = x0;
                x0 = x1;
                x1 = temp;

                temp = y0;
                y0 = y1;
                y1 = temp;
            }
            Graphics g = CreateGraphics();
            float dx = x1 - x0;
            float dy = y1 - y0;
            float k = dy / dx;

            float xStart = x0;
            int xEnd = x1;
            float yStart = y0;
            float step = 0.1f;

            for (; xStart < xEnd; xStart += step, yStart = yStart + step * k)//每次x 步进单位0.1
            {
                g.DrawRectangle(Pens.Red, xStart, yStart, 1, 1);
            }
        }

        private void MidLine(Pen pen, int firstX, int firstY, int x, int y)
        {
        }

        private void DDA_Line(int x0, int y0, int x1, int y1)
        {
            Strength(x0, ref y0, x1, ref y1);
            Horizontal(x0, y0, x1, y1);

            Graphics g = CreateGraphics();

            int flag;
            if (x0 > x1)//x0 左端点,不满足则互换
            {
                int temp = x0;
                x0 = x1;
                x1 = temp;

                temp = y0;
                y0 = y1;
                y1 = temp;
            }
            flag = 0;
            if (x1 - x0 > y1 - y0 && y1 - y0 > 0)//dx>dy,dy>0,  =>   y=kx+b, 0.5>k>0
            {
                flag = 1;
            }
            if (x1 - x0 > y0 - y1 && y1 - y0 < 0) //dx>dy,dy<0  => y=kx+b, -0.5<k<0
            {
                //与flag1 关于X对称
                flag = 2;
                y0 = -y0;
                y1 = -y1;
            }

            if (x1 - x0 < y1 - y0 && y1 - y0 > 0) // dx<dy, => y=kx+b, k>0.5
            {
                //与flag1 关于y=x对称,交换，X,Y位置
                flag = 3;
                int temp = x0;
                x0 = y0;
                y0 = temp;

                temp = y1;
                y1 = x1;
                x1 = temp;
            }

            if (x1 - x0 < y0 - y1 && y1 - y0 > 0) // dx<dy, => y=kx+b, k<-0.5
            {
                flag = 4;
                //先交换到flag3 与 flag3 关于y轴对称
                x0 = -x0;
                x1 = -x1;

                int temp = x0;
                x0 = y0;
                y0 = temp;

                temp = y1;
                y1 = x1;
                x1 = temp;
            }

            float dx = x1 - x0;
            float dy = y1 - y0;
            float k = dy / dx;

            int xlenght = 0;
            float ylength = 0f;
            for (; xlenght <= x1; xlenght++, ylength = ylength + k)//ylength=ylength+k*dx,因为x每次前进单位1，所以dx=1,y也前进x单位1对应的长度
            {
                if (flag == 1)
                {
                    g.DrawRectangle(Pens.Red, xlenght, (int)(ylength + 0.5), 1, 1);
                }
                if (flag == 2)
                {
                    g.DrawRectangle(Pens.Red, xlenght, -(int)(ylength + 0.5), 1, 1);
                }
                if (flag == 3)
                {
                    g.DrawRectangle(Pens.Red, (int)(ylength + 0.5), xlenght, 1, 1);
                }
                if (flag == 4)
                {
                    g.DrawRectangle(Pens.Red, (int)(ylength + 0.5), -xlenght, 1, 1);
                }
            }
            void Horizontal(int x0, int y0, int x1, int y1)
            {
                int length;

                float m;
                float y;
                Graphics g = CreateGraphics();

                if (x0 == x1 && y0 == y1)
                {
                    return;//端点重合，返回
                }

                if (y0 == y1)//水平线
                {
                    if (x0 >= y1)//始终x0最小，否则交换两点
                    {
                        int temp = x0;
                        x0 = x1;
                        x1 = temp;
                    }

                    for (length = x0; length < x1; length++)
                    {
                        g.DrawRectangle(Pens.Red, length, y0, 1, 1);
                        length++;
                    }
                }
            }

            void Strength(int x0, ref int y0, int x1, ref int y1)
            {
                int length;

                float m;
                float y;
                Graphics g = CreateGraphics();

                if (x0 == x1 && y0 == y1)
                {
                    return;//端点重合，返回
                }

                if (x0 == x1)//垂直线
                {
                    if (y0 >= y1)//始终y0最小，否则交换两点
                    {
                        int temp = y0;
                        y0 = y1;
                        y1 = temp;
                    }

                    for (length = y0; length < y1; length++)
                    {
                        g.DrawRectangle(Pens.Red, x1, length, 1, 1);
                        length++;
                    }
                }
            }
        }

        private void DDALine_kx_b(Pen Color, int x0, int y0, int x1, int y1)
        {
            //因为X 从左往右步进，因此X0 始终在左侧，否则只能绘制从左往右的线段
            if (x0 > x1)//如果从右往左绘制，交换两点
            {
                int temp = x0;
                x0 = x1;
                x1 = temp;

                temp = y0;
                y0 = y1;
                y1 = temp;
            }

            Graphics g = CreateGraphics();
            float dx = x1 - x0;
            float dy = y1 - y0;

            float k = dy / dx;

            int xStart = x0;
            int xEnd = x1;

            float yStart = y0;
            for (; xStart < xEnd; xStart++, yStart = yStart + k)//每次x 步进单位1
            {
                g.DrawRectangle(Color, xStart, (int)(yStart), 1, 1);
            }
        }

        private void BresenhamCircle(int x0, int y0, int x1, int y1)
        {
            int r;
            int d;
            int x;
            int y;

            Graphics g = CreateGraphics();
            r = (int)MathF.Sqrt((x1 - x0) * (x1 - x0) - (y1 - y0) * (y1 - y0));
            x = 0;
            y = r;
            d = 3 - 2 * r;

            while (x < y || x == y)
            {
                g.DrawRectangle(Pens.Blue, x + x0, y + y0, 1, 1);
                g.DrawRectangle(Pens.Red, -x + x0, y + y0, 1, 1);
                g.DrawRectangle(Pens.Green, x + x0, -y + y0, 1, 1);
                g.DrawRectangle(Pens.Yellow, -x + x0, -y + y0, 1, 1);
                g.DrawRectangle(Pens.Black, y + y0, x + y0, 1, 1);
                g.DrawRectangle(Pens.Red, -y + x0, x + y0, 1, 1);
                g.DrawRectangle(Pens.Red, y + y0, -x + y0, 1, 1);
                g.DrawRectangle(Pens.Red, -y + x0, -x + y0, 1, 1);

                x += 1;
                if (d < 0 || d == 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    y = y - 1;
                    d = d + 4 * (x - y) + 10;
                }
            }
        }

        private void ScanLineFill()
        {
        }

        #endregion 算法

        private Point[] points = new Point[100];

        private void 扫描线填充ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuID = 31;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void 仿射变换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}