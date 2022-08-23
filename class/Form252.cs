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
    public partial class Form252 : Form
    {
        private string className, attribName;
        public Form252(string _className, string _attribName)
        {
            className = _className;
            attribName = _attribName;
            InitializeComponent();
            getListMinMax();
            getValues();
            label5.Text = attribName;
        }

        public void getListMinMax()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `min`,`max`,`ed_izm` FROM `attribute` WHERE `name` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            foreach (DataRow row in table.Rows)
            {
                var cells = row.ItemArray;
                if (!(cells[0] is DBNull))
                {
                    numericUpDown1.Minimum = Convert.ToDecimal(cells[0]);
                    numericUpDown2.Minimum = Convert.ToDecimal(cells[0]);
                    numericUpDown1.Value = Convert.ToDecimal(cells[0]);
                }
                if (!(cells[1] is DBNull))
                {
                    numericUpDown1.Maximum = Convert.ToDecimal(cells[1]);
                    numericUpDown2.Maximum = Convert.ToDecimal(cells[1]);
                    numericUpDown2.Value = Convert.ToDecimal(cells[1]);
                }
                label6.Text = cells[2].ToString();
                label7.Text = cells[2].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form25 newForm = new Form25();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(numericUpDown1.Value) > Convert.ToInt64(numericUpDown2.Value))
            {
                MessageBox.Show("Начальное значение больше конечного");
                return;
            }

            if (numericUpDown1.Minimum > numericUpDown1.Value)
            {
                MessageBox.Show("Начальное значение не может быть меньше " + numericUpDown1.Minimum.ToString());
                return;
            }

            if (numericUpDown2.Maximum < numericUpDown2.Value)
            {
                MessageBox.Show("Конечное значение не может быть больше " + numericUpDown1.Maximum.ToString());
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `instance_class` SET `min`= @min, `max`= @max WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = className;
            command.Parameters.Add("@min", MySqlDbType.VarChar).Value = Convert.ToInt64(numericUpDown1.Value);
            command.Parameters.Add("@max", MySqlDbType.VarChar).Value = Convert.ToInt64(numericUpDown2.Value);

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

            Form25 newForm = new Form25();
            newForm.Show();
            this.Close();
        }

        public void getValues()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `min`,`max` FROM `instance_class` WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = className;
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = attribName;

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
        }
    }
}
