using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CRUD
{
    public partial class Form1 : Form
    {
        OleDbConnection konek = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LENOVO\Documents\XII-RPL2\Ukk\CRUD\logindb.accdb");
        public Form1()
           
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            konek.Open();
            string printah = "select count(*) from tb_login where username='" + textBox_usn.Text + "' and password='" + textBox_psw.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(printah, konek);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Login Berhasil");

                data data= new data ();
                data.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah");
            }
            konek.Close();
        }

    }
}

