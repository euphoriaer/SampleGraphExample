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

        private void bresenhamԲToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuID = 5;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void bresenhamֱ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //��Ƥ��
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen BackPen = new Pen(BackColor, 1);
            Pen FrontPen = new Pen(_foreColor, 1);

            if (MenuID == 1 || MenuID == 2 && PressNumber == 1)
            {
                //g.DrawLine(BackPen, FirstX, FirstY, OldX, OldY);//�ɵ����ñ���ɫ����(����)
                //g.DrawLine(FrontPen, FirstX, FirstY, e.X, e.Y);//�µ�������

                OldX = e.X;
                OldY = e.Y;
            }

            if (MenuID == 5 && PressNumber == 1)
            {
                if (!(e.X == OldX && e.Y == OldY))
                {
                    int r = (int)MathF.Sqrt((FirstX - OldX) * (FirstX - OldX) + (FirstY - OldY) * (FirstY - OldY));//�뾶

                    g.DrawEllipse(BackPen, FirstX - r, FirstY - r, 2 * r, 2 * r);//ɾ���ɵ�

                    int rNew = (int)MathF.Sqrt((FirstX - e.X) * (FirstX - e.X) + (FirstY - e.Y) * (FirstY - e.Y));//�뾶

                    g.DrawEllipse(FrontPen, FirstX - rNew, FirstY - rNew, 2 * rNew, 2 * rNew);//ɾ���ɵ�

                    OldX = e.X;
                    OldY = e.Y;
                }
            }

            if (MenuID == 31 && PressNumber > 0)
            {
                if (!(e.X == OldX && e.Y == OldY))
                {
                    g.DrawLine(BackPen, points[PressNumber - 1].X, points[PressNumber - 1].Y, OldX, OldY);//�ɵ����ñ���ɫ����(����)
                    g.DrawLine(FrontPen, points[PressNumber - 1].X, points[PressNumber - 1].Y, e.X, e.Y);//�µ�������

                    OldX = e.X;
                    OldY = e.Y;
                }
            }
        }

        //����
        private void Form1_MouseClickUpdate(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);

            if (MenuID == 31)//ɨ�������
            {
                if (e.Button == MouseButtons.Left)
                {
                    points[PressNumber].X = e.X;
                    points[PressNumber].Y = e.Y;
                    if (PressNumber > 0)//�������
                    {
                        g.DrawLine(Pens.Red, points[PressNumber - 1], points[PressNumber]);
                    }
                    PressNumber++;
                }
                if (e.Button == MouseButtons.Right)//�Ҽ���������λ��ƣ���ʼ���
                {
                    g.DrawLine(Pens.Red, points[PressNumber - 1], points[0]);
                    ScanLineFill();
                    PressNumber = 0;
                }
            }

            if (MenuID == 1)
            {
                if (PressNumber == 0)//��һ����
                {
                    FirstX = e.X;
                    FirstY = e.Y;
                    OldX = e.X;
                    OldY = e.Y;
                }
                else//�ڶ�����
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
                if (PressNumber == 0)//��һ����
                {
                    FirstX = e.X;
                    FirstY = e.Y;
                    OldX = e.X;
                    OldY = e.Y;
                }
                else//�ڶ�����
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
                    FirstX = e.Y;//Բ��
                }
                else
                {
                    //�ڶ��� �뾶
                    BresenhamCircle(FirstX, FirstY, e.X, e.Y);
                }
                PressNumber++;
                if (PressNumber >= 2)
                {
                    PressNumber = 0;
                }
            }
        }

        #region �㷨

        private void Kx_b(int x0, int y0, int x1, int y1)
        {
            //��ΪX �������Ҳ��������X0 ʼ������࣬����ֻ�ܻ��ƴ������ҵ��߶�
            if (x0 > x1)//�������������ƣ���������
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
            //ͨ������ֱ�߹�ʽ  ����λ�ã�

            float xStart = x0;
            int xEnd = x1;
            float yStart = y0;
            float step = 0.1f;

            for (; xStart < xEnd; xStart += step, yStart = k * xStart + b)//ÿ��x ����y
            {
                g.DrawRectangle(Pens.Red, xStart, yStart, 1, 1);
            }
        }

        private void DDALine_kx_b_Step(int x0, int y0, int x1, int y1)
        {
            //��ΪX �������Ҳ��������X0 ʼ������࣬����ֻ�ܻ��ƴ������ҵ��߶�
            if (x0 > x1)//�������������ƣ���������
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

            for (; xStart < xEnd; xStart += step, yStart = yStart + step * k)//ÿ��x ������λ0.1
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
            if (x0 > x1)//x0 ��˵�,�������򻥻�
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
                //��flag1 ����X�Գ�
                flag = 2;
                y0 = -y0;
                y1 = -y1;
            }

            if (x1 - x0 < y1 - y0 && y1 - y0 > 0) // dx<dy, => y=kx+b, k>0.5
            {
                //��flag1 ����y=x�Գ�,������X,Yλ��
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
                //�Ƚ�����flag3 �� flag3 ����y��Գ�
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
            for (; xlenght <= x1; xlenght++, ylength = ylength + k)//ylength=ylength+k*dx,��Ϊxÿ��ǰ����λ1������dx=1,yҲǰ��x��λ1��Ӧ�ĳ���
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
                    return;//�˵��غϣ�����
                }

                if (y0 == y1)//ˮƽ��
                {
                    if (x0 >= y1)//ʼ��x0��С�����򽻻�����
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
                    return;//�˵��غϣ�����
                }

                if (x0 == x1)//��ֱ��
                {
                    if (y0 >= y1)//ʼ��y0��С�����򽻻�����
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
            //��ΪX �������Ҳ��������X0 ʼ������࣬����ֻ�ܻ��ƴ������ҵ��߶�
            if (x0 > x1)//�������������ƣ���������
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
            for (; xStart < xEnd; xStart++, yStart = yStart + k)//ÿ��x ������λ1
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

        #endregion �㷨

        private Point[] points = new Point[100];

        private void ɨ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuID = 31;
            PressNumber = 0;
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
        }

        private void ����任ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}