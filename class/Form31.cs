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
    public partial class Form31 : Form
    {
        private DataTable selectAttrib = new DataTable();
        private DataTable enumAttrib = new DataTable();
        private bool flagNoVoidAttrib = true;
        public Form31(DataTable sA, DataTable eA)
        {
            selectAttrib = sA;
            enumAttrib = eA;
            InitializeComponent();
            getTable(selectAttrib, enumAttrib);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        public void getTable(DataTable sA, DataTable eA)
        {
            tableLayoutPanel1.Controls.Clear();

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();

            int i = 0;
            foreach (DataRow row in sA.Rows)
            {
                var cells = row.ItemArray;

                if (cells[1] is DBNull)
                {

                }
                else if (Convert.ToInt32(cells[1]) == 1)
                {
                    DataTable attrib = new DataTable();
                    DataColumn nameAttrib = new DataColumn("name", Type.GetType("System.String"));
                    DataColumn typeAttrib = new DataColumn("type", Type.GetType("System.Int32"));
                    DataColumn minAttrib = new DataColumn("min", Type.GetType("System.Int32"));
                    DataColumn maxAttrib = new DataColumn("max", Type.GetType("System.Int32"));
                    DataColumn ed_izmAttrib = new DataColumn("ed_izm", Type.GetType("System.String"));

                    attrib.Columns.Add(nameAttrib);
                    attrib.Columns.Add(typeAttrib);
                    attrib.Columns.Add(minAttrib);
                    attrib.Columns.Add(maxAttrib);
                    attrib.Columns.Add(ed_izmAttrib);

                    attrib.Rows.Add(new object[] { cells[0], cells[1], cells[2], cells[3], cells[4] });

                    Label label = new Label();
                    label.Text = cells[0].ToString();
                    label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                    label.AutoSize = true;

                    tableLayoutPanel1.Controls.Add(label, 0, i);

                    label = new Label();
                    label.Text = "Количественный";
                    label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                    label.AutoSize = true;

                    tableLayoutPanel1.Controls.Add(label, 1, i);

                    Button button = new Button();
                    button.Name = cells[0].ToString();
                    button.AutoSize = true;

                    if (attrib.Rows.Count == 0)
                    {
                        button.Text = "Нет значений";
                        button.Click += new System.EventHandler(this.ButtonOnClick1); ;
                        button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                        flagNoVoidAttrib = false;
                    }
                    else
                    {
                        DataRow r = attrib.Rows[0];
                        var c = r.ItemArray;

                        if (c[2].ToString() == "")
                        {
                            button.Text = "Нет значений";
                            button.Click += new System.EventHandler(this.ButtonOnClick1); ;
                            button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                            flagNoVoidAttrib = false;
                        }
                        else
                        {
                            button.Text = c[2].ToString() + " - " + c[3].ToString();
                            button.Click += new System.EventHandler(this.ButtonOnClick1);
                            button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                        }

                    }

                    tableLayoutPanel1.Controls.Add(button, 2, i);
                    i++;
                }
                else if (Convert.ToInt32(cells[1]) == 0)
                {
                    DataTable attrib = new DataTable();
                    DataColumn nameEnum = new DataColumn("name", Type.GetType("System.String"));
                    DataColumn valueEnum = new DataColumn("value", Type.GetType("System.String"));

                    attrib.Columns.Add(nameEnum);
                    attrib.Columns.Add(valueEnum);

                    if (eA.Rows.Count > 0)
                    {
                        foreach (DataRow r in eA.Rows)
                        {
                            if(r[0] == cells[0])
                            attrib.Rows.Add(new object[] { r[0],r[1]});
                        }
                    }

                    Label label = new Label();
                    label.Text = cells[0].ToString();
                    label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                    label.AutoSize = true;

                    tableLayoutPanel1.Controls.Add(label, 0, i);

                    label = new Label();
                    label.Text = "Качественный";
                    label.Font = new Font(label.Font.Name, 16, label.Font.Style);
                    label.AutoSize = true;

                    tableLayoutPanel1.Controls.Add(label, 1, i);

                    Button button = new Button();
                    button.Name = cells[0].ToString();
                    button.AutoSize = true;

                    if (attrib.Rows.Count > 0)
                    {
                        foreach (DataRow r in attrib.Rows)
                        {
                            var c = r.ItemArray;
                            button.Text += "'" + c[1] + "' ";
                        }

                        button.Click += new System.EventHandler(this.ButtonOnClick2);
                        button.Font = new Font(button.Font.Name, 14, button.Font.Style);
                    }
                    else
                    {
                        button.Text = "Нет значений";
                        button.Click += new System.EventHandler(this.ButtonOnClick2);
                        button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                        flagNoVoidAttrib = false;
                    }

                    tableLayoutPanel1.Controls.Add(button, 2, i);
                    i++;
                }
            }
        }

        private void ButtonOnClick1(object sender, EventArgs eventArgs)
        {
            Button triggeredButton = (Button)sender;

            Form311 newForm = new Form311(triggeredButton.Name.ToString(), selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        private void ButtonOnClick2(object sender, EventArgs eventArgs)
        {
            Button triggeredButton = (Button)sender;

            Form312 newForm = new Form312(triggeredButton.Name.ToString(), selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(flagNoVoidAttrib)
            {
                Form32 newForm = new Form32(selectAttrib, enumAttrib);
                newForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните значения всех признаков");
            }
        }
    }
}
