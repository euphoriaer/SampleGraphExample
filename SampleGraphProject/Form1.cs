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

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Red, 1);
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
                    DDALine_kx_b(pen,FirstX, FirstY, e.X, e.Y);
                }
                PressNumber++;
                if (PressNumber >= 2)
                {
                    PressNumber = 0;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //��Ƥ��
            Graphics g = CreateGraphics();
            Pen BackPen = new Pen(BackColor, 1);
            Pen FrontPen = new Pen(_foreColor, 1);

            if (MenuID == 1 && PressNumber == 1)
            {
                //g.DrawLine(BackPen, FirstX, FirstY, OldX, OldY);//�ɵ����ñ���ɫ����(����)
                //g.DrawLine(FrontPen, FirstX, FirstY, e.X, e.Y);//�µ�������
                DDALine_kx_b(BackPen,FirstX, FirstY, OldX, OldY);
                DDALine_kx_b(FrontPen,FirstX, FirstY, e.X, e.Y);
         
                OldX = e.X;
                OldY = e.Y;
            }
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

        private void DDALine_kx_b(Pen  Color,int x0, int y0, int x1, int y1)
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

            if (x1 - x0==0)
            {
                return;
            }
            float b=(-x0/(x1 - x0))*(y1-y0)+y0;
            //ͨ������ֱ�߹�ʽ  ����λ�ã�

            float xStart = x0;
            int xEnd = x1;
            float yStart = y0;
            float step = 0.1f;

            for (; xStart < xEnd; xStart += step, yStart =k*xStart+b)//ÿ��x ����y 
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
    }
}