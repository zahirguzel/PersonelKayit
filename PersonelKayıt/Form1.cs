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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti= new SqlConnection("sql bağlantısı");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelDataSet2.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter1.Fill(this.personelDataSet2.Tbl_Personel);
            // TODO: Bu kod satırı 'personelDataSet1.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter1.Fill(this.personelDataSet1.Tbl_Personel);
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet.Tbl_Personel);


            this.Size = new Size(968, 700);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (Perad,Persoyad,Perşehir,Permaş,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)" , baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", txtMaas.Text);
            komut.Parameters.AddWithValue("@p5",txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6",lblgizli.Text);
            komut.ExecuteNonQuery(); // ekleme sil güncellede sorguyu çalıştırmaya yarar
           
            baglanti.Close();
            MessageBox.Show("Yeni kayıt eklendi.");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) 
            {
                lblgizli.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                lblgizli.Text = "False";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtİd.Text = "";
            txtAd.Text = "";
            txtMaas.Text = "";
            txtMeslek.Text = "";
            txtSoyad.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked=false;
            cmbSehir.Text = "";
            txtAd.Focus();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // herhangi bir hücreye iki kere tıklandığında ne olsun 
            int secilen = dataGridView1.SelectedCells[0].RowIndex;// secilene o satırı atıyoruz
            txtİd.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString(); // secilen satırın ilk hücresi
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            lblgizli.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void lblgizli_TextChanged(object sender, EventArgs e)
        {
            if (lblgizli.Text == "True") {
                radioButton1.Checked = true;
            }
            if(lblgizli.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand  komutsil = new SqlCommand( "Delete From Tbl_Personel where Perid = @k1" , baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtİd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Personel set Perad = @a1 , Persoyad=@a2 , Perşehir=@a3 ,Permaş=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a7",baglanti );
            komutgüncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", txtSoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3",cmbSehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", txtMaas.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", lblgizli.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", txtİd.Text);
            komutgüncelle.ExecuteNonQuery( );
            baglanti.Close();
            MessageBox.Show("kayıt güncellendi");
        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            Form2 frm2= new Form2();
            frm2.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            Form3 frm3= new Form3();
            frm3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
