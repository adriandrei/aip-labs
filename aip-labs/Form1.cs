using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aip_labs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Stopwatch sw;
        private double[] a;
        private double[] b;
        private double[] c;

        private void Lab2Generare_Click(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();

            a = new double[(int)Lab2Numeric.Value];
            b = new double[(int)Lab2Numeric.Value];
            c = new double[(int)Lab2Numeric.Value];

            var rand = new Random();
            for(int i = 0; i < (int)Lab2Numeric.Value; i++)
            {
                a[i] = rand.Next(1000);
                b[i] = rand.Next(1000);
                c[i] = rand.Next(1000);
            }
            sw.Stop();
            OutputArea.Text = string.Format("Lab 2 : \nS-au generat {0} coeficienti in {1}ms..", Lab2Numeric.Value, sw.ElapsedMilliseconds);
        }

        private void Lab2Secvential_Click(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();

            for(int i = 0; i < (int)Lab2Numeric.Value; i++)
            {
                var delta = b[i] * b[i] - 4 * a[i] * c[i];
                if (delta < 0)
                    continue;
                if (delta == 0)
                {
                    double result = ((-1) * b[i]) / (2 * a[i]);
                    continue;
                }
                double result1 = ((-1) * b[i] + delta) / (2 * a[i]);
                double result2 = ((-1) * b[i] - delta) / (2 * a[i]);
            }

            sw.Stop();
            OutputArea.Text += string.Format("\nSecvential in {0}ms...", sw.ElapsedMilliseconds);
        }

        private void Lab2Paralel_Click(object sender, EventArgs e)
        {
            sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, (int)Lab2Numeric.Value, i => {
                var delta = b[i] * b[i] - 4 * a[i] * c[i];
                if (delta < 0)
                    return;
                if (delta == 0)
                {
                    double result = ((-1) * b[i]) / (2 * a[i]);
                    return;
                }
                double result1 = ((-1) * b[i] + delta) / (2 * a[i]);
                double result2 = ((-1) * b[i] - delta) / (2 * a[i]);
            });

            sw.Stop();
            OutputArea.Text += string.Format("\nParalel in {0}ms...", sw.ElapsedMilliseconds);
        }
    }
}
