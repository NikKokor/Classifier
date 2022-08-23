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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        public void getData()
        {
            tableLayoutPanel1.Controls.Clear();

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

            int i = 0;
            foreach (DataRow row in tableAttribInt.Rows)
            {
                var cells = row.ItemArray;

                Label label = new Label();
                label.Text = cells[1].ToString();
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 0, i);

                label = new Label();
                label.Text = cells[2].ToString();
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 1, i);

                label = new Label();
                label.Text = "Нет значений";
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 2, i);

                i++;
            }

            foreach (DataRow row in tableAttribEnum.Rows)
            {
                var cells = row.ItemArray;

                Label label = new Label();
                label.Text = cells[1].ToString();
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 0, i);

                label = new Label();
                label.Text = cells[2].ToString();
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 1, i);

                label = new Label();
                label.Text = "Нет значений";
                label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                label.AutoSize = true;

                tableLayoutPanel1.Controls.Add(label, 2, i);

                i++;
            }
        }
    }
}
