using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        private DataTable selectAttrib = new DataTable();
        private DataTable enumAttrib = new DataTable();

        public Form3(DataTable sA, DataTable eA)
        {
            if (sA == null)
            {
                SetTabels();
            }
            else
            {
                selectAttrib = sA;
                enumAttrib = eA;
            }

            InitializeComponent();
            getListAttribute(selectAttrib);
            getListSelectAttribute(selectAttrib);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form31 newForm = new Form31(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //<
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Выберите признак для удаления");
                return;
            }

            for (int i = 0; i < selectAttrib.Rows.Count; i++)
            {
                if (selectAttrib.Rows[i].ItemArray[0].ToString() == listBox3.SelectedItem.ToString())
                {
                    selectAttrib.Rows.RemoveAt(i);
                }
            }

            getListAttribute(selectAttrib);
            getListSelectAttribute(selectAttrib);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //>
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Выберите признак для добовления");
                return;
            }

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `name`, `type`, `ed_izm` FROM `attribute`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            int type = -1;
            string ed_izm = null;

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var cells = row.ItemArray;
                    if (cells[0].ToString() == listBox2.SelectedItem.ToString())
                        type = Convert.ToInt32(cells[1]);
                    if (cells[0].ToString() == listBox2.SelectedItem.ToString())
                        ed_izm = cells[2].ToString();
                }
            }


            selectAttrib.Rows.Add(new object[] { listBox2.SelectedItem.ToString(), type, null, null, ed_izm });

            getListAttribute(selectAttrib);
            getListSelectAttribute(selectAttrib);
        }

        public void getListAttribute(DataTable sA)
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

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var cells = row.ItemArray;
                    bool flag = true;
                    for (int i = 0; i < sA.Rows.Count; i++)
                    {
                        if (sA.Rows[i].ItemArray[0].ToString() == cells[0].ToString())
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                        listBox2.Items.Add(cells[0].ToString());
                }
            }

        }

        public void getListSelectAttribute(DataTable sA)
        {
            listBox3.Items.Clear();

            for (int i = 0; i < sA.Rows.Count; i++)
            {
                listBox3.Items.Add(sA.Rows[i].ItemArray[0].ToString());
            }
        }

        public void SetTabels()
        {
            DataColumn nameAttrib = new DataColumn("name", Type.GetType("System.String"));
            DataColumn typeAttrib = new DataColumn("type", Type.GetType("System.Int32"));
            DataColumn minAttrib = new DataColumn("min", Type.GetType("System.Int32"));
            DataColumn maxAttrib = new DataColumn("max", Type.GetType("System.Int32"));
            DataColumn ed_izmAttrib = new DataColumn("ed_izm", Type.GetType("System.String"));

            selectAttrib.Columns.Add(nameAttrib);
            selectAttrib.Columns.Add(typeAttrib);
            selectAttrib.Columns.Add(minAttrib);
            selectAttrib.Columns.Add(maxAttrib);
            selectAttrib.Columns.Add(ed_izmAttrib);

            DataColumn nameEnum = new DataColumn("name", Type.GetType("System.String"));
            DataColumn valueEnum = new DataColumn("value", Type.GetType("System.String"));

            enumAttrib.Columns.Add(nameEnum);
            enumAttrib.Columns.Add(valueEnum);
        }
    }
}
