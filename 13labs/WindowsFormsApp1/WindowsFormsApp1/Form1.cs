using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Timer timer = new Timer();
        double x = 0, y = 0;
        double a = 1;  // градус угла
        double t = 0;  // время
        double V = 10; // скорость
        double g = 9.8; // гравитационная постоянная
        double h;  // высота
        List<PointF> trajectoryPoints = new List<PointF>();  // список для хранения координат траектории

        public Form1()
        {
            InitializeComponent(); 
            this.Paint += new PaintEventHandler(Form1_Paint);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = false;
            timer.Interval = 50;
            this.Size = new Size(800, 600);  // устанавливает размер формы
            this.StartPosition = FormStartPosition.CenterScreen;  // позиционирует форму в центре экрана
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // получение данных от пользователя
            if (!double.TryParse(textBox1.Text, out a) || a < 0 || a > 360)  // проверка ввода угла
            {
                MessageBox.Show("Ошибка: угол должен быть числом между 0 и 360 градусами.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBox4.Text, out h) || h < 0)  // Проверка ввода высоты
            {
                MessageBox.Show("Ошибка: высота должна быть неотрицательным числом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double.TryParse(textBox2.Text, out V);  // начальная скорость
            double.TryParse(textBox3.Text, out g);  // g

            // сброс предыдущей траектории и времени
            trajectoryPoints.Clear();
            t = 0;
            chart1.Series["Series1"].Points.Clear();
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 500;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 500;
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            foreach (var point in trajectoryPoints)
            {
                //MessageBox.Show($"{point.X} {point.Y}");
                chart1.Series["Series1"].Points.AddXY((int)point.X, (int)point.Y);
            }


            // запуск таймера для отрисовки снаряда
            timer.Enabled = true;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            t += 0.01;
            double radians = a * (Math.PI / 180);  // преобразование градусов в радианы
            x = (float)(V * Math.Cos(radians) * t);
            y = (float)(V * Math.Sin(radians) * t) - (0.5 * g * (t * t)) + h;
            this.Text = x.ToString() + " " + y.ToString();
            trajectoryPoints.Add(new PointF((float)(50 * x), (float)(y)));  // сохранение текущих координат снаряда
            Invalidate();
            if (y <= 0)  // проверка, достиг ли снаряд метки 0 по горизонтали
            {
                timer.Enabled = false;  // остановка таймера, когда снаряд достигает метки 0
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 500;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 500;
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            foreach (var point in trajectoryPoints)
            {
                //MessageBox.Show($"{point.X} {point.Y}");

                chart1.Series["Series1"].Points.AddXY((int)point.X, (int)point.Y);
            }
        }
    }
}
