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
    public partial class Form25 : Form
    {
        private List<string> nameAttrib = new List<string>();
        public Form25()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `name`, `type` FROM `attribute` WHERE NAME IN( SELECT `attribute` FROM `classattributs` WHERE `class` = @nameC )", db.getConnection());
            command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();
            int i = 0;
            foreach (DataRow row in table.Rows)
            {
                var cells = row.ItemArray;

                if (cells[1] is DBNull)
                {

                }
                else if (Convert.ToInt64(cells[1]) == 1)
                {
                    command = new MySqlCommand("SELECT `attribute`,`min`,`max` FROM `instance_class` WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
                    command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
                    command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = cells[0].ToString();

                    DataTable attrib = new DataTable();

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(attrib);

                    db.closeConnection();

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
                    }
                    else
                    {
                        DataRow r = attrib.Rows[0];
                        var c = r.ItemArray;

                        if (c[1].ToString() == "")
                        {
                            button.Text = "Нет значений";
                            button.Click += new System.EventHandler(this.ButtonOnClick1); ;
                            button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                        }
                        else
                        {
                            button.Text = c[1].ToString() + " - " + c[2].ToString();
                            button.Click += new System.EventHandler(this.ButtonOnClick1);
                            button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                        }

                    }

                    tableLayoutPanel1.Controls.Add(button, 2, i);
                    i++;
                }
                else if (Convert.ToInt64(cells[1]) == 0)
                {
                    command = new MySqlCommand("SELECT `value` FROM `instance_enum` WHERE `class` = @nameC AND `attribute` = @nameA", db.getConnection());
                    command.Parameters.Add("@nameC", MySqlDbType.VarChar).Value = comboBox1.SelectedItem.ToString();
                    command.Parameters.Add("@nameA", MySqlDbType.VarChar).Value = cells[0].ToString();

                    DataTable attrib = new DataTable();

                    db.openConnection();

                    adapter.SelectCommand = command;
                    adapter.Fill(attrib);

                    db.closeConnection();

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
                            button.Text += "'" + c[0] + "' ";
                        }

                        button.Click += new System.EventHandler(this.ButtonOnClick2);
                        button.Font = new Font(button.Font.Name, 14, button.Font.Style);
                    }
                    else
                    {
                        button.Text = "Нет значений";
                        button.Click += new System.EventHandler(this.ButtonOnClick2);
                        button.Font = new Font(button.Font.Name, 16, button.Font.Style);
                    }

                    tableLayoutPanel1.Controls.Add(button, 2, i);
                    i++;
                }
            }
        }

        private void ButtonOnClick1(object sender, EventArgs eventArgs)
        {
            Button triggeredButton = (Button)sender;

            Form252 newForm = new Form252(comboBox1.SelectedItem.ToString(), triggeredButton.Name.ToString());
            newForm.Show();
            this.Close();
        }

        private void ButtonOnClick2(object sender, EventArgs eventArgs)
        {
            Button triggeredButton = (Button)sender;

            Form251 newForm = new Form251(comboBox1.SelectedItem.ToString(), triggeredButton.Name.ToString());
            newForm.Show();
            this.Close();
        }
    }
}
