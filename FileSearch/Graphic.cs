using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Graphic : Form
    {

        private Stager origin;


        public Graphic(Stager stadger)
        {
            InitializeComponent();
            origin = stadger;
            this.Text = this.Text + " - " + stadger.getKey();
        }

        private void Graphic_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            origin.Change(origin.getFilePath(), textBox1.Text);
        }
    }
}
