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
        private PlotModel plot;
        public Form1()
        {
            InitializeComponent();
            plot = new PlotModel { Title = "" };
            plot.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1));
            this.plotView1.Model = plot;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.plotView1.Model.Series.Clear();
            plot.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1));
            this.plotView1.InvalidatePlot(true);
        }


    }
}
