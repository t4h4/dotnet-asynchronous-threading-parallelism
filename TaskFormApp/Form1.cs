using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnReadFile_Click(object sender, EventArgs e)
        {
            string data = ReadFile();

            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("C:/Users/tahay/source/repos/AsynchronousMulti-Threading/TaskFormApp/dosya.txt")) // using icerisinde kullandik cunku, kullanimdan sonra bellekten silinsin.
            {
                Thread.Sleep(3000); // bu kisma geldiginde ui thread'i 3 saniyeligine deaktif olacka. form freeze olacak. 
                data = s.ReadToEnd(); // datayi bastan sona okuyacak.
            }

            return data;
        }
    }
}
