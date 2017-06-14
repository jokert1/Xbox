using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using Meta.Numerics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static string TextData = "";
        List<double> X = new List<double>();
        static double sum = 0;
        double AVE = 0;
        double SQRAve = 0;
        double step = 0;
        public void logChartsDraw(Chart chart1, Chart chart2, int NumClass, List<double> X)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            int M = 0;
            X.Sort();
            double MinX = X.Min();
            double MaxX = X.Max();
            sum = X.Count;
            if (NumClass == -1)
            {
                if (X.Count <= 100 && sum > 0)
                {
                    M = Convert.ToInt32(Math.Round(Math.Sqrt(sum)));
                    if (M % 2 == 0)
                        M--;
                    step = Convert.ToDouble((MaxX - MinX) / M);
                }
                else
                {
                    M = Convert.ToInt32(Math.Round(Math.Pow(sum, 1.0 / 3.0)));
                    if (M % 2 == 0)
                        M--;
                    step = Convert.ToDouble((MaxX - MinX) / M);
                }
            }
            else
            {
                M = NumClass;
                if (M % 2 == 0)
                    M--;
                step = Convert.ToDouble((MaxX - MinX) / M);
            }
            double y = 0;
            chart1.Series.Add("Numbers");
            chart1.Series["Numbers"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Numbers"].BorderWidth = 1;
            chart1.Series["Numbers"].BorderColor = Color.Black;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].AxisX.Minimum = MinX;
            chart1.ChartAreas[0].AxisX.Maximum = MaxX;
            for (int i = 1; i <= M; i++)
            {
                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] >= X[0] + step * (i - 1) && X[b] <= X[0] + step * i)
                    {
                        YO++;
                    }
                }
                y = YO / sum;
                chart1.Series["Numbers"].Points.AddXY(X[0] + step * ((double)i - 0.5), y);
            }
            chart1.Series["Numbers"]["PointWidth"] = "1";
            chart2.Series.Add("Numbers");
            chart2.Series["Numbers"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series["Numbers"].BorderWidth = 3;
            chart2.Series["Numbers"].BorderColor = Color.Black;
            chart2.Series["Numbers"].Color = Color.Black;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart2.ChartAreas[0].AxisX.Minimum = MinX;
            chart2.ChartAreas[0].AxisX.Maximum = MaxX;
            for (int i = 0; i <= M; i++)
            {

                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] <= X[0] + step * i)
                        YO++;
                }
                y = YO / sum;
                chart2.Series.Add(Convert.ToString(i));
                chart2.Series[Convert.ToString(i)].Color = Color.Red;
                chart2.Series[Convert.ToString(i)].MarkerSize = 3;
                chart2.Series[Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart2.Series[Convert.ToString(i)].Points.AddXY(MinX + i * step - step, y);
                chart2.Series[Convert.ToString(i)].Points.AddXY(MinX + (i + 1) * step - step, y);
            }
            chart2.Series.Add("?");
            chart2.Series["?"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series["?"]["PointWidth"] = "1";
            for (int i = 0; i < X.Count; i++)
            {

                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] <= X[i])
                        YO++;
                }
                y = YO / sum;
                chart2.Series["?"].Points.AddXY(X[i], y);
            }
        }
        public void ChartsDraw(Chart chart1, Chart chart2,int NumClass,List<double> X)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            int M = 0;
            X.Sort();
            X.Min();
            double MinX = X.Min();
            double MaxX = X.Max();
            sum = X.Count;
            if (NumClass==-1)
            {
                if (X.Count <= 100 && sum > 0)
                {
                    M = Convert.ToInt32(Math.Round(Math.Sqrt(sum)));
                    if (M % 2 == 0)
                        M--;
                    step = Convert.ToDouble((MaxX - MinX) / M);
                }
                else
                {
                    M = Convert.ToInt32(Math.Round(Math.Pow(sum, 1.0 / 3.0)));
                    if (M % 2 == 0)
                        M--;
                    step = Convert.ToDouble((MaxX - MinX) / M);
                }
            }
            else
            {
                M = NumClass;
                if (M % 2 == 0)
                    M--;
                step = Convert.ToDouble((MaxX - MinX) / M);
            }
            double y = 0;
           
            chart1.Series.Add("Numbers");
            chart1.Series["Numbers"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series["Numbers"].BorderWidth = 1;
            chart1.Series["Numbers"].BorderColor = Color.Black;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart1.ChartAreas[0].AxisX.Minimum = MinX;
            chart1.ChartAreas[0].AxisX.Maximum = MaxX;
            for (int i = 1; i <= M; i++)
            {
                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] >= X[0] + step * (i - 1) && X[b] <= X[0] + step * i)
                    {
                        YO++;
                    }
                }
                y = YO / sum;
                chart1.Series["Numbers"].Points.AddXY(X[0] + step * ((double)i - 0.5), y);
            }
            chart1.Series["Numbers"]["PointWidth"] = "1";
            chart2.Series.Add("Numbers");
            chart2.Series["Numbers"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            chart2.Series["Numbers"].BorderWidth = 3;
            chart2.Series["Numbers"].BorderColor = Color.Black;
            chart2.Series["Numbers"].Color = Color.Black;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "###,##0.000";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "###,##0.000";
            chart2.ChartAreas[0].AxisX.Minimum = MinX;
            chart2.ChartAreas[0].AxisX.Maximum = MaxX;
            for (int i = 0; i <= M; i++)
            {

                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] <= X[0] + step * i)
                        YO++;
                }
                y = YO / sum;
                chart2.Series.Add(Convert.ToString(i));
                chart2.Series[Convert.ToString(i)].Color = Color.Red;
                chart2.Series[Convert.ToString(i)].MarkerSize = 3;
                chart2.Series[Convert.ToString(i)].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                chart2.Series[Convert.ToString(i)].Points.AddXY(i * step - step, y);
                chart2.Series[Convert.ToString(i)].Points.AddXY((i + 1) * step - step, y);
            }
            chart2.Series.Add("?");
            chart2.Series["?"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart2.Series["?"]["PointWidth"] = "1";
            for (int i = 0; i < X.Count; i++)
            {

                int YO = 0;
                for (int b = 0; b < X.Count; b++)
                {
                    if (X[b] <= X[i])
                        YO++;
                }
                y = YO / sum;
                chart2.Series["?"].Points.AddXY(X[i], y);
            }
        }
        public void GridWrite(DataGridView dataGridView1, DataGridView dataGridView2, int NumClass, List<double> X)
        {
            X.Sort();
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Add("No", "Номер");
            dataGridView2.Columns.Add("Element", "Значення");
            for (int i = 0; i < X.Count; i++)
            {
                dataGridView2.Rows.Add(i + 1, Math.Round(X[i],4));
            }
            AVE = Math.Round(PointMark.Ave(X), 4);
            double MED = PointMark.Med(X);
            double MAD = PointMark.Mad(X, MED);
            double disp = Math.Round(PointMark.Disp(X, AVE), 4);
            SQRAve = Math.Round(PointMark.SQRAve(disp), 4);
            double disposeSQRAve = Math.Round(PointMark.DisSqrAve(X, AVE), 4);
            double As = Math.Round(PointMark.Assimetric(X, AVE, disposeSQRAve), 4);
            double Ex = Math.Round(PointMark.Exes(X, AVE, disposeSQRAve), 4);
            double ContrEx = Math.Round(PointMark.ConterEx(Ex), 4);
            double Var_Pirson = Math.Round(PointMark.Var_Pirson(AVE, SQRAve), 4);
            double no_param_kovar = Math.Round(PointMark.No_Param_Kovar(MED, MAD), 4);
            double yolsh = Math.Round(PointMark.Yolsh(X), 4);
            double llSQRAve = Math.Round(Interval_Mark.LowLimitSQRAve(SQRAve, sum, X), 4);
            double llAVE = Math.Round(Interval_Mark.LowLimitAve(AVE, SQRAve, sum, X), 4);
            double llAs = Math.Round(Interval_Mark.LowLimitAssimetric(As, sum, X), 4);
            double llEx = Math.Round(Interval_Mark.LowLimitExes(Ex, sum, X), 4);
            double llContrEX = Math.Round(Interval_Mark.LowLimitContrExes(ContrEx, Ex, sum, X), 4);
            double llPirson = Math.Round(Interval_Mark.LowLimitPirson(Var_Pirson, sum, X), 4);
            double hlSQRAve = Math.Round(Interval_Mark.HighLimitSQRAve(SQRAve, sum, X), 4);
            double hlAVE = Math.Round(Interval_Mark.HighLimitAve(AVE, SQRAve, sum, X), 4);
            double hlAs = Math.Round(Interval_Mark.HighLimitAssimetric(As, sum, X), 4);
            double hlEx = Math.Round(Interval_Mark.HighLimitExes(Ex, sum, X), 4);
            double hlContrEX = Math.Round(Interval_Mark.HighLimitContrExes(ContrEx, Ex, sum, X), 4);
            double hlPirson = Math.Round(Interval_Mark.HighLimitPirson(Var_Pirson, sum, X),4);
            double sAve = Math.Round(Mark.sigmaAve(SQRAve, sum), 4);
            double sSQRAve = Math.Round(Mark.sigmaSQRAve(SQRAve, sum), 4);
            double sAs = Math.Round(Mark.sigmaAssimetric(sum), 4);
            double sEx = Math.Round(Mark.sigmaExes(sum), 4);
            double sContrEx = Math.Round(Mark.sigmaContrExes(Ex, sum), 4);
            double sPiroson = Math.Round(Mark.sigmaPirson(Var_Pirson, sum), 4);
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns.Add("Mark", "Оцінка");
            dataGridView1.Columns.Add("Lowlimit", "Нижня Границя");
            dataGridView1.Columns.Add("PMark", "Точкова оцінка");
            dataGridView1.Columns.Add("sigma", "σ");
            dataGridView1.Columns.Add("Highlimit", "Верхня Границя");
            dataGridView1.Rows.Add("MED", "", MED, "", "");
            dataGridView1.Rows.Add("MAD", "", MAD, "", "");
            dataGridView1.Rows.Add("Медіана середніх Уолша", "", yolsh, "", "");
            dataGridView1.Rows.Add("Середнє", llAVE, AVE, sAve, hlAVE);
            dataGridView1.Rows.Add("Дисперсія", "", disp, "", "");
            dataGridView1.Rows.Add("Середнє квадратичне відхилення", llSQRAve, SQRAve, sSQRAve, hlSQRAve);
            dataGridView1.Rows.Add("Коефіцієнт асиметрії", llAs, As, sAs, hlAs);
            dataGridView1.Rows.Add("Коефіцієнт ексцесу", llEx, Ex, sEx, hlEx);
            dataGridView1.Rows.Add("Коефіцієнт контрексцесу", llContrEX, ContrEx, sContrEx, hlContrEX);
            dataGridView1.Rows.Add("Коефіціент варіації Пірсона", llPirson, Var_Pirson, sPiroson, hlPirson);
            dataGridView1.Rows.Add("Непараметричний коефіцієнт варіації", "", no_param_kovar, "", "");
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            X.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextData = File.ReadAllText(openFileDialog.FileName);
            }
            else
                return;
            TextData = TextData.Replace("\r", " ");
            TextData = TextData.Replace("\n", " ");
            TextData = TextData.Replace("\t", " ");
            TextData = TextData.Replace("  ", " ");
            TextData = TextData.Replace(",", ".");
            string[] dat = Regex.Split(TextData, " ");
            for (int i = 0; i < dat.Length; i++)
            {
                X.Add(Convert.ToDouble(dat[i]));
            }
            int NumClass = -1;
            //if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            //{
            //    NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            //}
            ChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            X = DataChange.logA(X, sum);
            int NumClass = -1;
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            logChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
           }

        private void button4_Click(object sender, EventArgs e)
        {
            int NumClass = -1;
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                X = DataChange.powA(X, sum, Convert.ToDouble(textBox3.Text));
            }
            else
                X = DataChange.powA(X, sum);
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            logChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int NumClass = -1;
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                X = DataChange.dispA(X, sum, Convert.ToDouble(textBox2.Text));
            }
            else
                X = DataChange.dispA(X, sum);
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            logChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            X = DataChange.standartA(X, sum);
            int NumClass = -1;
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            logChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }

        private void вилученняАномалійToolStripMenuItem_Click(object sender, EventArgs e)
        {
            X = Abnormals.AbnormalsX(X, sum);
            int NumClass = -1;
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            ChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 window = new Form2();
            X = window.GetList();
            int NumClass = -1;
            if (!String.IsNullOrEmpty(classcountToolStripMenuItem.Text))
            {
                NumClass = Convert.ToInt32(classcountToolStripMenuItem.Text);
            }
            X.Sort();
            logChartsDraw(chart1, chart2, NumClass, X);
            GridWrite(dataGridView1, dataGridView2, NumClass, X);
        }

        private void нормальнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            X.Sort();
            chart1.Series.Add("1");
            chart1.Series["1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["1"].BorderWidth = 1;
            chart1.Series["1"].BorderColor = Color.Black;
            for(double x = X[0]; x < X[X.Count-1]; x+=(X[X.Count - 1] - X[0])/500)
            {
                chart1.Series["1"].Points.AddXY(x, Restore.fNorm(x, SQRAve, AVE)*step);
            }
            chart2.Series.Add("norm");
            chart2.Series["norm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["norm"].BorderWidth = 1;
            chart2.Series["norm"].BorderColor = Color.Black;
            for (double x = X[0]; x < X[X.Count - 1]; x += (X[X.Count - 1] - X[0]) / 500)
            {
                chart2.Series["norm"].Points.AddXY(x, Restore.FNorm(AVE, x, SQRAve));
            }
        }

        private void експоненціальнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            X.Sort();
            chart1.Series.Add("exp");
            chart1.Series["exp"].Color = Color.Violet;
            chart1.Series["exp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["exp"].BorderWidth = 1;
            chart1.Series["exp"].BorderColor = Color.Black;
            double D = 0;
            for (double i = X[0]; i < X.Max(); i += 0.01 * (X.Max() - X.Min()))
            {
                chart1.Series["exp"].Points.AddXY(i,Restore.fExp(X,i)*step);
            }

            chart2.Series.Add("exp");
            chart2.Series.Add("exp+");
            chart2.Series["exp+"].Color = Color.Pink;
            chart2.Series["exp+"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["exp+"].BorderWidth = 1;
            chart2.Series["exp+"].BorderColor = Color.Pink;
            chart2.Series.Add("exp-");
            chart2.Series["exp-"].Color = Color.Violet;
            chart2.Series["exp-"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["exp-"].BorderWidth = 1;
            chart2.Series["exp-"].BorderColor = Color.Violet;
            chart2.Series["exp"].Color = Color.DarkBlue;
            chart2.Series["exp"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["exp"].BorderWidth = 1;
            chart2.Series["exp"].BorderColor = Color.Black;
            double lyambda = 1 / PointMark.Ave(X);
            double nk = Quantil.NormalQuantil();
            double D_lyam = Math.Pow(lyambda, 2) / sum;
            for (double i = X[0]; i < X.Max(); i += 0.01 * (X.Max() - X.Min()))
            {
                D = Math.Pow(i, 2) * Math.Exp(-2 * lyambda * i) * (Math.Pow(lyambda, 2) / sum);
                chart2.Series["exp+"].Points.AddXY(i, Restore.FExp(X, i) + Quantil.StudentQuantil(sum, X) * Math.Sqrt(D));
                chart2.Series["exp"].Points.AddXY(i, Restore.FExp(X, i));
                chart2.Series["exp+"].Points.AddXY(i, Restore.FExp(X, i) - Quantil.StudentQuantil(sum, X) * Math.Sqrt(D));
            }
        }

        private void логарифмічноНормальнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            X.Sort();
            
            chart2.Series.Add("lognorm");
            chart2.Series["lognorm"].Color = Color.Violet;
            chart2.Series["lognorm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["lognorm"].BorderWidth = 1;
            chart2.Series["lognorm"].BorderColor = Color.Black;
            for (double i = X[0]; i < X.Max(); i += 0.01 * (X.Max() - X.Min()))
            {
                chart2.Series["lognorm"].Points.AddXY(i, Restore.FLogNorm(X, i) * step);
            }
        }
    }
}