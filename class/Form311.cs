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
    public partial class Form311 : Form
    {
        private string nameAttrib;
        private DataTable selectAttrib = new DataTable();
        private DataTable enumAttrib = new DataTable();
        public Form311(string nA, DataTable sA, DataTable eA)
        {
            nameAttrib = nA;
            selectAttrib = sA;
            enumAttrib = eA;
            InitializeComponent();
            getListMinMax();
            getValues();
            label5.Text = nA;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form31 newForm = new Form31(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        public void getListMinMax()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `min`,`max`,`ed_izm` FROM `attribute` WHERE `name` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = nameAttrib;

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

        public void getValues()
        {
            foreach (DataRow row in selectAttrib.Rows)
            {
                var cells = row.ItemArray;
                if (cells[0].ToString() == nameAttrib)
                {
                    if (!(cells[2] is DBNull))
                        numericUpDown1.Value = Convert.ToDecimal(cells[2]);
                    if (!(cells[3] is DBNull))
                        numericUpDown2.Value = Convert.ToDecimal(cells[3]);
                }

            }
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

            foreach (DataRow row in selectAttrib.Rows)
            {
                var cells = row.ItemArray;
                if (cells[0].ToString() == nameAttrib)
                {
                    row[2] = Convert.ToInt32(numericUpDown1.Value);
                    row[3] = Convert.ToInt32(numericUpDown2.Value);
                }
            }

            Form31 newForm = new Form31(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }
    }
}
