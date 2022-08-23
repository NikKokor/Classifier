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
    public partial class Form32 : Form
    {
        private DataTable selectAttrib = new DataTable();
        private DataTable enumAttrib = new DataTable();
        private List<string> correctClasses = new List<string>();

        public Form32(DataTable sA, DataTable eA)
        {
            selectAttrib = sA;
            enumAttrib = eA;
            InitializeComponent();
            getClass();
            printClass();
        }

        public void getClass()
        {
            DB db = new DB();
            DataTable classes = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `class`, `attribute`, `min`, `max` FROM `instance_class`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(classes);

            db.closeConnection();

            DataTable enums = new DataTable();

            command = new MySqlCommand("SELECT `class`, `attribute`, `value` FROM `instance_enum`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(enums);

            db.closeConnection();

            DataTable typeAttrib = new DataTable();

            command = new MySqlCommand("SELECT `name`, `type` FROM `attribute`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(typeAttrib);

            db.closeConnection();

            DataTable table = new DataTable();

            command = new MySqlCommand("SELECT `name` FROM `class`", db.getConnection());

            db.openConnection();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.closeConnection();

            if (table.Rows.Count <= 0)
            {
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                correctClasses.Add(row[0].ToString());
            }

            if (classes.Rows.Count <= 0)
            {
                return;
            }

            int k = 0;
            foreach (DataRow row in table.Rows)
            {
                bool flagClass = true;
                bool flagAttrib = false;
                int i = 0;
                while (i < classes.Rows.Count)
                {
                    if (classes.Rows[i][0].ToString() == row[0].ToString())
                    {
                        flagClass = false;
                        bool flagA = true;
                        for (int j = 0; j < selectAttrib.Rows.Count; j++)
                        {
                            if (classes.Rows[i][1].ToString() == selectAttrib.Rows[j][0].ToString())
                            {
                                flagA = false;

                                if (searchType(typeAttrib, selectAttrib.Rows[j][0].ToString()) == 1)
                                {
                                    if (!(classes.Rows[i][2] is DBNull) && !(selectAttrib.Rows[j][2] is DBNull))
                                    {
                                        if (Convert.ToInt32(classes.Rows[i][2]) > Convert.ToInt32(selectAttrib.Rows[j][2]))
                                            flagAttrib = true;
                                        if (Convert.ToInt32(classes.Rows[i][3]) < Convert.ToInt32(selectAttrib.Rows[j][3]))
                                            flagAttrib = true;
                                    }
                                    else
                                        flagAttrib = true;
                                }
                                else if (searchType(typeAttrib, selectAttrib.Rows[j][0].ToString()) == 0)
                                {
                                    List<string> listClass = searchEnumClass(enums, classes.Rows[i][0].ToString(), classes.Rows[i][1].ToString());
                                    List<string> listAttrib = searchEnumAttrib(enumAttrib, selectAttrib.Rows[j][0].ToString());

                                    if (listClass.Contains("нет")) { }
                                    else
                                    {
                                        for (int l = 0; l < listAttrib.Count; l++)
                                        {
                                            if (!listClass.Contains(listAttrib[l]))
                                            {
                                                flagAttrib = true;
                                            }
                                        }
                                    }

                                }

                            }

                        }

                        if (flagA)
                            flagAttrib = true;
                    }

                    i++;
                }

                if (flagAttrib)
                {
                    correctClasses.Remove(row[0].ToString());
                }



                if (flagClass)
                {
                    correctClasses.Remove(row[0].ToString());
                }


                k++;
            }
        }

        public int searchType(DataTable table, string attrib)
        {
            if (table.Rows.Count <= 0)
                return -1;

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == attrib)
                    return Convert.ToInt32(row[1]);
            }

            return -1;
        }

        public List<string> searchEnumClass(DataTable table, string clas, string attrib)
        {
            List<string> list = new List<string>();

            if (table.Rows.Count <= 0)
                return list;

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == clas && row[1].ToString() == attrib)
                {
                    list.Add(row[2].ToString());
                }
            }

            return list;
        }

        public List<string> searchEnumAttrib(DataTable table, string attrib)
        {
            List<string> list = new List<string>();

            if (table.Rows.Count <= 0)
                return list;

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString() == attrib)
                {
                    list.Add(row[1].ToString());
                }
            }

            return list;
        }

        public void printClass()
        {
            if (correctClasses.Count <= 0)
            {
                label2.Text = "Нет подходящих классов";
            }

            for (int i = 0; i < correctClasses.Count; i++)
            {
                listBox2.Items.Add(correctClasses[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form31 newForm = new Form31(selectAttrib, enumAttrib);
            newForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Close();
        }
    }
}
