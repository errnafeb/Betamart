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
    public partial class data : Form
    {
        OleDbConnection koneksi = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LENOVO\Documents\XII-RPL2\Ukk\CRUD\produkdb.accdb");

        public data()
        {
            InitializeComponent();
        }
        void showData()
        {
            koneksi.Open();
            string printah = "select * from tb_produk";
            OleDbDataAdapter da = new OleDbDataAdapter(printah, koneksi);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MessageBox.Show("ID tidak boleh di isi!!!");
            }
            else {
                koneksi.Open();
                string printah = "Insert into tb_produk (nama_barang,brand,kategori,jumlah_barang, harga_barang ) values ('" + textbrg.Text + "', '" + CBbrand.Text + "', '" + CBkategori.Text + "', " + TBjumlah.Text + ", " + TBharga.Text + ")";
                OleDbCommand cmd = new OleDbCommand(printah, koneksi);
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data berhasil Disimpan");
                showData();
                clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string printah = "UPDATE tb_produk SET nama_barang='" + textbrg.Text + "', brand='" + CBbrand.Text + "', kategori='" + CBkategori.Text + "',  jumlah_barang='" + TBjumlah.Text + "', harga_barang='" +TBharga.Text +"'WHERE ID =" + textBox1.Text + "";
            OleDbCommand cmd = new OleDbCommand(printah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data berhasil Diupdate");
            showData();
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            string printah = "DELETE FROM tb_produk WHERE ID=" + textBox1.Text + "";
            OleDbCommand cmd = new OleDbCommand(printah, koneksi);
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data berhasil Dihapus");
            showData();
        }

        private void data_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void clear()
        {
            textBox1.ResetText();
            textbrg.ResetText();
            CBbrand.ResetText();
            CBkategori.ResetText();
            TBjumlah.ResetText();
            TBharga.ResetText();
        }
    }
}
