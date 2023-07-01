using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace terazbedziedobrze
{
    public partial class Form1 : Form
    {
        bool przycisk = true;
        const string V = "Antek jest super";
        const string D = "Antek jest glupi";
        bool zapal = false;
        SerialPort port;
        string[] array = new string[3] { "a", "b", "c" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = V;
            foreach(string el in array)
            {
                comboBox1.Items.Add(el);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (przycisk == true) { label1.Text = V;
                przycisk = false;
            }
            else { label1.Text = D;
                przycisk = true;
            }
            Console.WriteLine(V + " i " + D);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sd = "9600";
            //Task task = new Task();
            //AOChannel myaOChannel;
            if(zapal==false)
            {
                port = new SerialPort("COM5", int.Parse(sd), Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("c");
                port.Close();
                zapal = true;
            }
            else if(zapal==true)
            {
                port = new SerialPort("COM5", int.Parse(sd), Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("b");
                port.Close();
                zapal = false;
            }
        }
    }
}
