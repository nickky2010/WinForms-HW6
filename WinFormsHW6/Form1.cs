using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsHW6
{
    public partial class Form1 : Form
    {
        Graphics grFloor;
        Graphics grBall;
        Pen floorPen;
        Ball ball;
        public Form1()
        {
            InitializeComponent();
            floorPen = new Pen(Color.Black, 8);
            int radius = ((this.Height-60 - (int)(floorPen.Width / 2))/2);
            ball = new Ball(radius, Brushes.Green, new Point(0, 0), 1000);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            if (ball.Speed<=1000)
            {
                timer1.Interval = (int)1000 / ball.Speed;
            }
            else
            {
                timer1.Interval = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ball.Point.X + ball.Radius*2 >= 700)
            {
                ball.Refresh();
            }
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball.Point.X+ball.Radius*2<700)
            {
                ball.Move();
                this.Invalidate();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            grBall = e.Graphics;
            grFloor = e.Graphics;
            grFloor.DrawLine(floorPen, 0, this.Height-60, this.Width-179, this.Height-60);
            ball.Draw(grBall);
        }
    }
}
