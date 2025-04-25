using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        
    public Form1(Form myWindow)
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
                 new double[] {-50.0, +10.0, -50.0,
                               +10.0, -50.0, +10.0,
                               -50.0, +10.0, -50.0}
                 );
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
        }

        private void generateImage()
        {
            
            // Outer loop to iterate through rows (img)
            for (int i = 0; i < img.Length; i++)
            {
                // Inner loop to iterate through each element in the row
                for (int j = 0; j < img[i].Length; j++)
                {
                    // Accessing and printing each element of img
                    Random random = new Random();
                    img[i][j] = random.NextDouble() * 255;
                }
            }
        }

        private void singleRun()
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
            for (int i = 0; i < img2.Length; i++)
            {
                outputLevel1[i] = level1[i].Work(img2);
            }

            // Visualize middle value of neurons

            /// level one
            textBox1.Text = level1[0].mid.ToString();
            textBox2.Text = level1[1].mid.ToString();
            textBox13.Text = level1[2].mid.ToString();
            textBox14.Text = level1[3].mid.ToString();
            textBox15.Text = level1[4].mid.ToString();
            textBox16.Text = level1[5].mid.ToString();
            textBox17.Text = level1[6].mid.ToString();
            textBox18.Text = level1[7].mid.ToString();
            textBox19.Text = level1[8].mid.ToString();

            // Level two
            textBox20.Text = level2.mid.ToString();

            // Visualize output value of neurons

            // Level one 
            textBox21.Text = level1[0].output.ToString();
            textBox23.Text = level1[1].output.ToString();
            textBox24.Text = level1[2].output.ToString();
            textBox25.Text = level1[3].output.ToString();
            textBox26.Text = level1[4].output.ToString();
            textBox27.Text = level1[5].output.ToString();
            textBox28.Text = level1[6].output.ToString();
            textBox29.Text = level1[7].output.ToString();
            textBox30.Text = level1[8].output.ToString();

            // Level two
            textBox22.Text = level2.output.ToString();



            double output = level2.Work(outputLevel1);
        }

        private static void MultipleRun(Object source, ElapsedEventArgs e)
        {
            //generateImage();
            //singleRun();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Timers.Timer aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += MultipleRun;
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;
            generateImage();
            singleRun();
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
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try{
                img[0][0] = Convert.ToDouble(t.Text);
            } catch (Exception ee1)
            { 
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[0][1] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[0][2] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[1][0] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[1][1] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[1][2] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[2][0] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[2][1] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox t = sender as System.Windows.Forms.TextBox;
            try
            {
                img[2][2] = Convert.ToDouble(t.Text);
            }
            catch (Exception ee1)
            {
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Form AboutUs = new Form();
            // AboutUs.Text = "За нас";
            // AboutUs.Width = 100;
            // AboutUs.Height = 100;
            // AboutUs.Show();
        }
    }
    class Neuron
    {
        private int number;
        private double[] input;
        private double[] weight;
        public double mid;
        public double output;

        public Neuron(double[] w)
        {
            weight = w;
            number = weight.Length;
        }

        public double Work(double[] inp)
        {
            double sum = 0;
            input = inp;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * weight[i];
            }
            mid = sum;

            // Sigma function: returns a vlue between o and 1
            // output = 1 / (1 + Math.Exp(-sum));
            output = (sum > 0) ? 1 : 0;
            return output;
        }

    }
}
