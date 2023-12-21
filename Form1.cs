using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var points1 = GetPoints(8, -Math.PI, Math.PI);
            var s1 = Simpson(8, -Math.PI, Math.PI);

            var points2 =  GetPoints(20, -Math.PI, Math.PI);
            var s2 = Simpson(20, -Math.PI, Math.PI);


            var points3 = GetPoints(40, -Math.PI, Math.PI);
            var s3 = Simpson(40, -Math.PI, Math.PI);

            label7.Text = s1.ToString();
            label8.Text = s2.ToString();
            label9.Text = s3.ToString();

            string format = "{00.00;-00.00}";


            SeriesCollection series = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<double> zp = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<double> date = new List<double>(); //здесь будут храниться значения для оси X
            foreach (var item in points1) //Заполняем коллекции
            {
                zp.Add(item.Y);
                date.Add(item.X);
            }
            cartesianChart1.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "X",
                Labels = date.Select(x => decimal.Round((decimal)x, 2).ToString()).ToArray()
            });

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "Y";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе



            SeriesCollection series2 = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<double> zp2 = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<double> date2 = new List<double>(); //здесь будут храниться значения для оси X
            foreach (var item in points2) //Заполняем коллекции
            {
                zp2.Add(item.Y);
                date2.Add(item.X);
            }
            cartesianChart2.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart2.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "X",
                Labels = date2.Select(x => decimal.Round((decimal)x, 2).ToString()).ToArray()
            });

            LineSeries line2 = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line2.Title = "Y";
            line2.Values = zp2;

            series2.Add(line2); //Добавляем линию на график
            cartesianChart2.Series = series2; //Отрисовываем график в интерфейсе



            SeriesCollection series3 = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<double> zp3 = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<double> date3 = new List<double>(); //здесь будут храниться значения для оси X
            foreach (var item in points3) //Заполняем коллекции
            {
                zp3.Add(item.Y);
                date3.Add(item.X);
            }
            cartesianChart3.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart3.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "X",
                Labels = date3.Select(x => decimal.Round((decimal)x, 2).ToString()).ToArray()
            });

            LineSeries line3 = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line3.Title = "Y";
            line3.Values = zp3;

            series3.Add(line3); //Добавляем линию на график
            cartesianChart3.Series = series3; //Отрисовываем график в интерфейсе


            var p = 3;

            double e = 0.01;

            double res = 0;
            decimal h = 1;

            do
            {
                decimal length = (decimal)(Math.PI * 2);
                int n = (int)(length / h/2);
                int n2 = (int)(length / h);

                var temp = (Simpson(n, -Math.PI, Math.PI) - Simpson(n2, -Math.PI, Math.PI)) / (Math.Pow(2, p) - 1);

                res = Math.Abs((double)temp);

                h /= 2;
            } while (res >= e);

            label11.Text = h.ToString();
        }


        public static PointF[] GetPoints(int n, double a, double b)
        {
            var points = new List<PointF>();

            double h = (b - a) / n;
            var x = a;
            while (x <= b)
            {
                points.Add(new PointF((float)x, (float)f(x)));
                x = x + h;

            }

            points.Add(new PointF((float)x, (float)f(x)));


            return points.ToArray();
        }

        public static double Simpson(int n, double a, double b)
        {
            double h = (b - a) / n;
            double s = 0;
            var x = a + h;
            while (x < b)
            {
                s = s + 4 * f(x);
                x = x + h;
                s = s + 2 * f(x);
                x = x + h;
            }
            s = h / 3 * (s +f (a) - f(b));

            return s;
        }

        /*public static float Simpson(float h, float a, float b)
        {
            float s = 0;

            for (float i = a+h; i <= b-h; i += h)
            {
                var y = f(i);

                var f0 = f(i-h);
                var f1 = f(i);
                var f2 = f(i+h);

                var res = (h / 3) * (f0 + 4 * f1 + f2);

                s += res;
            }

            return s;
        }*/

        public static double f(double x)
        {
            var sin = Math.Sin(x);
            var sin2 = -Math.Pow(sin, 2);

            var res = Math.Pow(Math.E, sin2);

            return res;
        }
    }
}
