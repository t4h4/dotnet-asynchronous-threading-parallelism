using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThreadApp
{
    public partial class Form1 : Form
    {
        public static int Counter { get; set; } = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var aTask = Go(progressBar1);
            var bTask = Go(progressBar2);

            await Task.WhenAll(aTask, bTask);
        }

        public async Task Go(ProgressBar pb)
        {
            await Task.Run(() => { // task run ile calistirmak istegimiz kodları ayri thread icerisinde calistiririz. 
                Enumerable.Range(1, 100).ToList().ForEach(x =>
                {
                    Thread.Sleep(10);
                    // pb.Value = x; // farkli thread'den ui threade etki eden value degerine erisilemez. o yuzden asagidaki kullanim uygundur.
                    pb.Invoke((MethodInvoker)delegate { pb.Value = x; });
                });
            });           
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            btnCounter.Text = Counter++.ToString();
        }
    }
}
