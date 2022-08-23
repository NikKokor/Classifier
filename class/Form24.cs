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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
            getListClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        public void getListClass()
        {
            comboBox1.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `name` FROM `class`", db.getConnection());

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

        public void getListClassAttributs(string name)
        {
            listBox3.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `attribute` FROM `classattributs` WHERE `class` = @class", db.getConnection());
            command.Parameters.Add("@class", MySqlDbType.VarChar).Value = name;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            foreach (DataRow row in table.Rows)
            {
                var cells = row.ItemArray;
                listBox3.Items.Add(cells[0].ToString());
            }
        }

        public void getListAttribute()
        {
            listBox2.Items.Clear();
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
                bool flag = true;
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    if (listBox3.Items[i].ToString() == cells[0].ToString())
                    {
                        flag = false;
                    }
                }
                if (flag)
                    listBox2.Items.Add(cells[0].ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getListClassAttributs(comboBox1.SelectedItem.ToString());
            getListAttribute();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //>
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `classattributs`(`class`, `attribute`) VALUES (@class,@attribute)", db.getConnection());
            if (comboBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                command.Parameters.Add("@class", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
                command.Parameters.Add("@attribute", MySqlDbType.VarChar).Value = listBox2.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Выберите признак для добовления");
                return;
            }

            MySqlCommand command1 = new MySqlCommand("INSERT INTO `instance_class`(`class`, `attribute`) VALUES (@nameC,@nameA)", db.getConnection());
            command1.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
            command1.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = listBox2.SelectedItem.ToString();

            db.openConnection();

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Признак не добавлен");
                return;
            }

            if (command1.ExecuteNonQuery() != 1) { };

            db.closeConnection();

            getListClassAttributs(comboBox1.SelectedItem.ToString());
            getListAttribute();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //<
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM `classattributs` WHERE `class` = @class AND `attribute` = @attribute", db.getConnection());
            if (comboBox1.SelectedItem != null && listBox3.SelectedItem != null)
            {
                command.Parameters.Add("@class", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
                command.Parameters.Add("@attribute", MySqlDbType.VarChar).Value = listBox3.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Выберите признак для удаления");
                return;
            }

            MySqlCommand command1 = new MySqlCommand("DELETE FROM `instance_class` WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
            command1.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
            command1.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = listBox3.SelectedItem.ToString();

            db.openConnection();

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Признак не удален");
                return;
            }

            if (command1.ExecuteNonQuery() != 1) { }

            db.closeConnection();

            getListClassAttributs(comboBox1.SelectedItem.ToString());
            getListAttribute();
        }
    }
}
