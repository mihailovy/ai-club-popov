using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRecognition
{

    public partial class Form1 : Form
    {
        public double[][] img = new double[][]
        {
            new double[] {0     , 255.0  , 0.0},
            new double[] {0.0   , 0.0    , 255.0},
            new double[] {0.0   , 255.0  , 0.0}
        };

        private Neuron[] level1 = new Neuron[9];
        private Neuron level2;
        
    public Form1()
        {
            InitializeComponent();
            level1[0] = new Neuron(
                new double[] { -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[1] = new Neuron(
                new double[] { -1.0, +100.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[2] = new Neuron(
                new double[] { -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[3] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               +100.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[4] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[5] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               -1.0, -1.0, +100.0,
                               -1.0, -1.0, -1.0}
                 );
            level1[6] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
            );
            level1[7] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, +100.0, -1.0}
            );
            level1[8] = new Neuron(
                 new double[] {-1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0,
                               -1.0, -1.0, -1.0}
                 );
            level2 = new Neuron(
                 new double[] {-125.0, +1250.0, -125.0,
                               +1250.0, -125.0, +1250.0,
                               -125.0, +1250.0, -125.0}
                 );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] img2 = new double[9];
            img2[0] = (double)img[0][0];
            img2[1] = (double)img[0][1];
            img2[2] = (double)img[0][2];
            img2[3] = (double)img[1][0];
            img2[4] = (double)img[1][1];
            img2[5] = (double)img[1][2];
            img2[6] = (double)img[2][0];
            img2[7] = (double)img[2][1];
            img2[8] = (double)img[2][2];
            textBox4.Text = "" + img2[0];
            textBox5.Text = "" + img2[1];
            textBox6.Text = "" + img2[2];
            
            textBox9.Text = "" + img2[3];
            textBox8.Text = "" + img2[4];
            textBox7.Text = "" + img2[5];

            textBox12.Text = "" + img2[6];
            textBox11.Text = "" + img2[7];
            textBox10.Text = "" + img2[8];

            double[] outputLevel1 = new double[9];
            for (int i = 0; i < img2.Length; i++) {
                outputLevel1[i] = level1[i].Work(img2);
            }
            textBox3.Text = "N0 =" + outputLevel1[0].ToString();
            textBox3.Text += ",N1 =" + outputLevel1[1].ToString();
            textBox3.Text += ",N2 =" + outputLevel1[2].ToString();
            textBox3.Text += ",N3 =" + outputLevel1[3].ToString();
            textBox3.Text += ",N4 =" + outputLevel1[4].ToString();
            textBox3.Text += ",N5 =" + outputLevel1[5].ToString();
            textBox3.Text += ",N6 =" + outputLevel1[6].ToString();
            textBox3.Text += ",N7 =" + outputLevel1[7].ToString();
            textBox3.Text += ",N8 =" + outputLevel1[8].ToString();


            double output = level2.Work(outputLevel1);
            textBox3.Text += ",O=" + output.ToString();
        }
         
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class Neuron
    {
        private int number;
        private double[] input;
        private double[] weight;
        public double mid;

        public Neuron(double[] w)
        {
            weight = w;
            number = weight.Length;
        }

        public double Work(double[] inp)
        {
            double sum = 0;
            double output;
            input = inp;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * weight[i];
            }
            mid = sum;
            output = 1 / (1 + Math.Exp(-sum));
            return output;
        }

    }
}
