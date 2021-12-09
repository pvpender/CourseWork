using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace Курсач
{
    public partial class Form1 : Form
    {
        private PlotModel _plot;
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        public Form1()
        {
            InitializeComponent();
            _plot = new PlotModel { Title = "" };
            _plot.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1));
            this.plotView1.Model = _plot;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.plotView1.Model.Series.Clear();
            _plot.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1));
            this.plotView1.InvalidatePlot(true);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                System.Diagnostics.Debug.WriteLine(this.plotView1.Location);
                this.plotView1.Bounds = new Rectangle(this.plotView1.Location.X - 100, this.plotView1.Location.Y - 100, this.plotView1.Size.Width + 100, this.plotView1.Size.Height + 100); 
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                System.Diagnostics.Debug.WriteLine(this.plotView1.Location);
                this.plotView1.Bounds = new Rectangle(this.plotView1.Location.X + 100, this.plotView1.Location.Y + 100, this.plotView1.Size.Width - 100, this.plotView1.Size.Height - 100);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
