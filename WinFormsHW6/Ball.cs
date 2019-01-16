using System;
using System.Drawing;

namespace WinFormsHW6
{
    class Ball
    {
        //  	свойства Радиус, Цвет, Позиция, Скорость;
        public int Radius { get; set; }
        public Brush Color { get; set; }
        private Point point;
        public Point Point { get => point; set => point = value; }
        public int Speed { get; set; }
        private Pen pen;
        private int xLine;
        private int yLine;
        double angle; // угол


        //  	конструктор
        public Ball(int radius, Brush color, Point point, int speed)
        {
            Radius = radius;
            Color = color;
            Point = point;
            Speed = speed;
            pen = new Pen(Brushes.Black, 3);
            angle = 0;
        }
        //  	метод для рисования мяча(параметр метода – объект класса Graphics)
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(Color, Point.X, Point.Y, Radius * 2, Radius*2);
            xLine = point.X+Radius + (int)(Radius * Math.Cos(90-angle * Math.PI / 180));
            yLine = Radius - (int)(Radius * Math.Sin(90-angle * Math.PI / 180));
            gr.DrawLine(pen, Point.X + Radius, Point.Y+Radius, xLine, yLine);
        }
        //  	метод для перемещения на другую позицию
        public void Move()
        {
            point.X++;
            angle ++;
        }
        public void Refresh()
        {
            point.X = 0;
            angle = 0;
        }
    }
}
