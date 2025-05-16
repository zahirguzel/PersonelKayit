﻿using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=zahir\\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");

        private void Form3_Load(object sender, EventArgs e)
        {
            // graffik 1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Perşehir , Count(*) from Tbl_Personel group by Perşehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(dr1[0], dr1[1]);

            }
            baglanti.Close();
            // grafik 2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select Permeslek ,Avg(Permaş) from Tbl_Personel group by Permeslek" , baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maaş"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }
    }
}
