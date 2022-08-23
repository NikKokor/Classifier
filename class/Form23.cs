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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
            getListAttributes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите признак");
                return;
            }

            if (radioButton1.Checked == true)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `attribute` SET `type`= 0 WHERE `name` = @nameA", db.getConnection());
                command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();

                db.openConnection();

                if (command.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Не удалось");
                    db.closeConnection();
                    return;
                }

                db.closeConnection();

                Form231 newForm = new Form231(comboBox1.SelectedItem.ToString());
                newForm.Show();
                this.Close();
            }
            else if(radioButton2.Checked == true)
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("UPDATE `attribute` SET `type`= 1 WHERE `name` = @nameA", db.getConnection());
                command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();

                db.openConnection();

                if (command.ExecuteNonQuery() != 1)
                {
                    MessageBox.Show("Не удалось");
                    db.closeConnection();
                    return;
                }

                db.closeConnection();

                Form232 newForm = new Form232(comboBox1.SelectedItem.ToString());
                newForm.Show();
                this.Close();
            }
            else
                MessageBox.Show("Выберите тип признака");
        }

        public void getListAttributes()
        {
            comboBox1.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `name` FROM `attribute`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            foreach (DataRow row in table.Rows)
            {
                var cells = row.ItemArray;
                comboBox1.Items.Add(cells[0].ToString());
            }
        }
    }
}
