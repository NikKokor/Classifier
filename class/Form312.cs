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
    public partial class Form312 : Form
    {
        private string nameAttrib;
        private DataTable selectAttrib = new DataTable();
        private DataTable enumAttrib = new DataTable();
        public Form312(string nA, DataTable sA, DataTable eA)
        {
            nameAttrib = nA;
            selectAttrib = sA;
            enumAttrib = eA;
            InitializeComponent();
            getListEnumAttributs();
            getListEnum();
            label5.Text = nA;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form31 newForm = new Form31(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        public void getListEnum()
        {
            listBox2.Items.Clear();
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `value` FROM `enum` WHERE `attribute` = @nameA", db.getConnection());
            command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = nameAttrib;

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

        public void getListEnumAttributs()
        {
            listBox3.Items.Clear();


            DataTable attrib = new DataTable();
            DataColumn nameEnum = new DataColumn("name", Type.GetType("System.String"));
            DataColumn valueEnum = new DataColumn("value", Type.GetType("System.String"));

            attrib.Columns.Add(nameEnum);
            attrib.Columns.Add(valueEnum);

            foreach (DataRow row in enumAttrib.Rows)
            {
                var cells = row.ItemArray;
                if (cells[0].ToString() == nameAttrib)
                    attrib.Rows.Add(new object[] { cells[0], cells[1] });
            }

            foreach (DataRow row in attrib.Rows)
            {
                var cells = row.ItemArray;
                listBox3.Items.Add(cells[1].ToString());
            }
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

            enumAttrib.Rows.Add(new object[] { nameAttrib, listBox2.SelectedItem.ToString()});

            getListEnumAttributs();
            getListEnum();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //<

            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Выберите значение для удаления");
                return;
            }

            for (int i = 0; i < enumAttrib.Rows.Count; i++)
            {
                if (enumAttrib.Rows[i].ItemArray[0].ToString() == nameAttrib && enumAttrib.Rows[i].ItemArray[1].ToString() == listBox3.SelectedItem.ToString())
                {
                    enumAttrib.Rows.RemoveAt(i);
                }
            }

            getListEnumAttributs();
            getListEnum();
        }
    }
}
