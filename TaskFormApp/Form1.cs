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

        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            string data = await ReadFileAsync(); // alt satira gecmeden dataya ihtiyac var o yuzden await kullanildi.

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

        // asenkron yapi kullanildiginda thread uzerinde asla bloklanma olmaz.
        // asenkron method geriye bi' sey dondurmeyecekse task ifadesi kullanılır. bu normal methodlarda void'e denk gelir.
        // deger dondurecekse task'in generic ifadesi icerisinde deger tipi belirtilir. 

        private async Task<string> ReadFileAsync() // asenkron method cagrimi gercekleseceginden dolayı private sonrasi async ifadesi kullanildi.
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("C:/Users/tahay/source/repos/AsynchronousMulti-Threading/TaskFormApp/dosya.txt")) // using icerisinde kullandik cunku, kullanimdan sonra bellekten silinsin.
            {
                
                Task<string> mytask = s.ReadToEndAsync();  // task string daha donecegine dair taahhut ediyor. hemen degil ama.

                // bu arada ReadToEndAsync() methodundan bagimsiz her is yapilabilir. asenkronun kullanmanin mantigi budur zaten.
                // taahut ReadToEndAsync() 'de baslar taa ki await mytask'e kadar devam eder.

                await Task.Delay(5000);

                data = await mytask; // taahhut ettigin datayi don, data'ya aktar.
                return data;
            }
        }
    }
}
