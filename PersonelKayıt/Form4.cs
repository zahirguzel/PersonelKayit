using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayıt
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=zahir\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yönetici where kullaniciad= @k1 and sifre=@k2",baglanti);
            komut.Parameters.AddWithValue("@k1", txtkullanıcıadı.Text);
            komut.Parameters.AddWithValue("@k2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();// formu gizle

            }
            else
            {
                MessageBox.Show("hatalı kullanııcı adı yada şifre");
            }
            baglanti.Close();

        }
    }
}
