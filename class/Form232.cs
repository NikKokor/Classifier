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
    public partial class Form232 : Form
    {
        private string attribute;
        public Form232(string _attribute)
        {
            attribute = _attribute;
            InitializeComponent();
            getValues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form23 newForm = new Form23();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Единицы измерения" || textBox1.Text == "")
            {
                MessageBox.Show("Введите eдиницы измерения");
                return;
            }

            if (textBox1.Text[0] == ' ' || textBox1.Text[textBox1.Text.Length - 1] == ' ')
            {
                MessageBox.Show("Уберите пробелы в начале и вконце единиц измерения");
                return;
            }

            if (numericUpDown1.Value.ToString() == "" || numericUpDown2.Value.ToString() == "")
            {
                MessageBox.Show("Значения не могут быть пустыми");
                return;
            }

            if (Convert.ToInt64(numericUpDown1.Value) > Convert.ToInt64(numericUpDown2.Value))
            {
                MessageBox.Show("Начальное значение больше конечного");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `attribute` SET `min`= @min, `max`= @max, `ed_izm`= @ed WHERE `name` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribute;
            command.Parameters.Add("@min", MySqlDbType.VarChar).Value = Convert.ToInt64(numericUpDown1.Value);
            command.Parameters.Add("@max", MySqlDbType.VarChar).Value = Convert.ToInt64(numericUpDown2.Value);
            command.Parameters.Add("@ed", MySqlDbType.VarChar).Value = textBox1.Text.ToString();

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Значение признака обнавлено");
            else
            {
                MessageBox.Show("Значение признака не обнавлено");
                db.closeConnection();
                return;
            }

            db.closeConnection();

            Form2 newForm = new Form2();
            newForm.Show();
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Единицы измерения")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Единицы измерения";
        }

        public void getValues()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `min`,`max`,`ed_izm` FROM `attribute` WHERE `name` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribute;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            foreach (DataRow row in table.Rows)
            {
                var cells = row.ItemArray;
                if (!(cells[0] is DBNull))
                    numericUpDown1.Value = Convert.ToDecimal(cells[0]);
                if (!(cells[1] is DBNull))
                    numericUpDown2.Value = Convert.ToDecimal(cells[1]);
            }

            textBox1.Text = table.Rows[0][2].ToString();
        }
    }
}
