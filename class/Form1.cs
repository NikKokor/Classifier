using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable tableAttribEnum = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `instance_class` WHERE ((CLASS, ATTRIBUTE) NOT IN(SELECT `class`, `attribute` FROM `instance_enum`)) AND ATTRIBUTE IN(SELECT `name` FROM `attribute` WHERE `type` = 0)", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(tableAttribEnum);

            db.closeConnection();

            DataTable tableAttribInt = new DataTable();

            command = new MySqlCommand("SELECT * FROM `instance_class` WHERE (`min` IS NULL OR `max` IS NULL) AND ATTRIBUTE IN(SELECT `name` FROM `attribute` WHERE `type` = 1)", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(tableAttribInt);

            db.closeConnection();

            if (tableAttribEnum.Rows.Count > 0 || tableAttribInt.Rows.Count > 0)
            {
                MessageBox.Show("Проверьте полноту базы знаний");
                return;
            }

            Form3 newForm = new Form3(null, null);
            newForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            this.Close();
        }
    }
}
