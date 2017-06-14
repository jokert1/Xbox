using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        List<double> X = new List<double>();
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 0)//(Norm)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox4.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                double len = Convert.ToDouble(textBox1.Text);
                double Ave = Convert.ToDouble(textBox2.Text);
                double SQRAve = Convert.ToDouble(textBox4.Text);
                X = Generator.Norm(len,Ave,SQRAve);
            }
            if(comboBox1.SelectedIndex == 1)//(Exp)
            {
                label1.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox3.Visible = true;
                double len = Convert.ToDouble(textBox1.Text);
                double alpha = Convert.ToDouble(textBox3.Text);
                X = Generator.Exp(len,alpha);
            }
            if(comboBox1.SelectedIndex == 2)//(Log-Norm)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox4.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                double len = Convert.ToDouble(textBox1.Text);
                double Ave = Convert.ToDouble(textBox2.Text);
                double SQRAve = Convert.ToDouble(textBox4.Text);
                X = Generator.LogNorm(len,Ave,SQRAve);
            }
        }
        public List<double> GetList()
        {
            this.ShowDialog();
            if (this.DialogResult == DialogResult.OK)
                return X;
            else return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
