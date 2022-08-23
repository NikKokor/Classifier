using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @class
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form21 newForm = new Form21();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form22 newForm = new Form22();
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form23 newForm = new Form23();
            newForm.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form24 newForm = new Form24();
            newForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form25 newForm = new Form25();
            newForm.Show();
            this.Close();
        }
    }
}
