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
    public partial class Form251 : Form
    {
        private string className, attribName;
        public Form251(string _className, string _attribName)
        {
            className = _className;
            attribName = _attribName;
            InitializeComponent();
            getListEnumClassAttributs();
            getListEnum();
            label5.Text = attribName;
        }

        public void getListEnum()
        {
            listBox2.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `value` FROM `enum` WHERE `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;

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

        private void button4_Click(object sender, EventArgs e)
        {
            //<

            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Выберите значение для удаления");
                return;
            }

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM `instance_enum` WHERE `class` = @nameC AND `attribute` = @nameA AND `value` = @nameE", db.getConnection());
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = className;
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;
            command.Parameters.Add("@nameE", MySqlDbType.VarChar).Value = listBox3.SelectedItem.ToString();

            db.openConnection();

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Значение не удалено");
                return;
            }

            db.closeConnection();

            getListEnumClassAttributs();
            getListEnum();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //>
            if (listBox2.SelectedItem == null)
            { 
                MessageBox.Show("Выберите значение для добовления");
                return;
            }

            if (listBox2.SelectedItem.ToString() == "нет" && listBox3.Items.Count > 0)
            {
                MessageBox.Show("Для добавления данного значения удалите остальные");
                return;
            }

            if (listBox3.Items.Contains("нет"))
            {
                MessageBox.Show("Для добавления данного значения удалите поле со значением 'нет'");
                return;
            }

            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `instance_enum`(`class`, `attribute`, `value`) VALUES (@nameC,@nameA,@nameE)", db.getConnection());
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = className;
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;
            command.Parameters.Add("@nameE", MySqlDbType.VarChar).Value = listBox2.SelectedItem.ToString();

            db.openConnection();

            if (command.ExecuteNonQuery() != 1)
            {
                MessageBox.Show("Значение не добавлено");
                return;
            }

            db.closeConnection();

            getListEnumClassAttributs();
            getListEnum();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form25 newForm = new Form25();
            newForm.Show();
            this.Close();
        }

        public void getListEnumClassAttributs()
        {
            listBox3.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `value` FROM `instance_enum` WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = className;
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;

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
    }
}
