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
    public partial class Form22 : Form
    {
        public Form22()
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Название признака")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Название признака";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Название признака")
            {
                MessageBox.Show("Введите название признака");
                return;
            }

            if (textBox1.Text[0] == ' ' || textBox1.Text[textBox1.Text.Length - 1] == ' ')
            {
                MessageBox.Show("Уберите пробелы в начале и вконце названия признака");
                return;
            }

            if (isAttributeExists(textBox1.Text))
            {
                MessageBox.Show("Признак с данным именем уже существует");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `attribute` (`name`) VALUES (@nameAttribute)", db.getConnection());

            command.Parameters.Add("@nameAttribute", MySqlDbType.VarChar).Value = textBox1.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Признак добавлен");
            else
                MessageBox.Show("Признак не добавлен");

            db.closeConnection();

            getListAttributes();
        }

        public void getListAttributes()
        {
            listBox1.Items.Clear();
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
                listBox1.Items.Add(cells[0].ToString());
            }
        }

        public bool isAttributeExists(string nameA)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `attribute` WHERE `name` = @attribute", db.getConnection());
            command.Parameters.Add("@attribute", MySqlDbType.VarChar).Value = nameA;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();
            if (table.Rows.Count > 0)
                return true;
            else
                return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            object itm = listBox1.SelectedItem;
            string obj;

            if (itm == null)
            {
                MessageBox.Show("Выберите запись для удаления");
                return;
            }
            else
                obj = itm.ToString();

            if (!isAttributeExists(obj))
            {
                MessageBox.Show("Признака с данным именем не существует");
                return;
            }



            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `attribute` WHERE `name` = @attribute", db.getConnection());
            command.Parameters.Add("@attribute", MySqlDbType.VarChar).Value = obj;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Признак удален");
            else
                MessageBox.Show("Признак не удален");

            db.closeConnection();

            getListAttributes();
        }
    }
}
