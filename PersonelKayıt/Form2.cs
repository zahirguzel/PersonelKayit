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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=**************;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            // Toplam peersonel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) from Tbl_Personel ", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader(); // select veri okuyucu 
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString(); // 0 ncı coloumndaki deger

            }
            baglanti.Close();

            // evli personel sayısı 
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) from Tbl_Personel Where Perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }

            baglanti.Close();
            // Bekar personel sayısı 
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) from Tbl_Personel Where Perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read()) {
                lblbekarpersonel.Text = dr3[0].ToString();
            
            }
            baglanti.Close();
            //şehir sayısı 
            baglanti.Open ();
            SqlCommand komut4 = new SqlCommand("Select Count (distinct(Perşehir)) from Tbl_Personel  ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                llblpersonelsehir.Text = dr4[0].ToString(); 
            }

            baglanti.Close ();
            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(Permaş) from Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read()) { 
            lbltoplammaas.Text = dr5[0].ToString();
            }

            baglanti.Close();
            // ortalama maaş 
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select AVG(Permaş) FROM Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6. ExecuteReader();
            while (dr6.Read())
            {
                lblortalmamaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
