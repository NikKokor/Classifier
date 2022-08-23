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
    public partial class Form231 : Form
    {
        private string attribute;
        public Form231(string _attribute)
        {
            attribute = _attribute;
            InitializeComponent();
            getListAttributes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form23 newForm = new Form23();
            newForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Значение признака")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Значение признака";
        }

        public void getListAttributes()
        {
            listBox1.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `value` FROM `enum` WHERE `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribute;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Значение признака" || textBox1.Text == "")
            {
                MessageBox.Show("Введите значение признака");
                return;
            }

            if (textBox1.Text[0] == ' ' || textBox1.Text[textBox1.Text.Length - 1] == ' ')
            {
                MessageBox.Show("Уберите пробелы в начале и вконце значения признака");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `enum` (`attribute`, `value`) VALUES (@nameA, @value)", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribute;
            command.Parameters.Add("@value", MySqlDbType.VarChar).Value = textBox1.Text.ToString();

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
                MessageBox.Show("Значение признака добавлено");
            else
                MessageBox.Show("Значение признака не добавлено");

            db.closeConnection();

            getListAttributes();
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

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("DELETE FROM `enum` WHERE `value` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = obj;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Значение признака удалено");
            else
                MessageBox.Show("Значение признака не удалено");

            db.closeConnection();

            getListAttributes();
        }
    }
}
