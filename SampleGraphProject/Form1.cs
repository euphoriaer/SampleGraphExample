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
                    g.DrawLine(pen, FirstX, FirstY, e.X, e.Y);
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
                g.DrawLine(BackPen, FirstX, FirstY, OldX, OldY);//�ɵ����ñ���ɫ����(����)
                g.DrawLine(FrontPen, FirstX, FirstY, e.X, e.Y);//�µ�������
                OldX = e.X;
                OldY = e.Y;
            }
        }
    }
}