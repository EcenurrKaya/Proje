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

namespace SınavSistemi
{
    public partial class AdminGirisi : Form
    {
        public AdminGirisi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;


        /*void Soru()
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM SoruEkle",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            guna2DataGridView1.DataSource = tablo;
            baglanti.Close();

        }*/
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into Sorular (soru, a, b, c, d, dogru, resim) values(@soru, @a, @b, @c, @d, @dogru, @resim)";
                SqlCommand komut = new SqlCommand(kayit, baglanti);

                komut.Parameters.AddWithValue("@soru", txt_sorua.Text);
                komut.Parameters.AddWithValue("@a", txt_aa.Text);
                komut.Parameters.AddWithValue("@b", txt_ba.Text);
                komut.Parameters.AddWithValue("@c", txt_ca.Text);
                komut.Parameters.AddWithValue("@d", txt_da.Text);
                komut.Parameters.AddWithValue("@dogru", txt_dgr.Text);
                komut.Parameters.AddWithValue("@resim", Picture.Image);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi", hata.Message);
            }

            string sorgu = "DELETE FROM SoruEkle WHERE Soru=@Soru";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Soru", Convert.ToString(txt_sorua.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            //Soru();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM SoruEkle WHERE Soru=@Soru";
            komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@Soru",Convert.ToString(txt_sorua.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            //Soru();
        }

        private void AdminGirisi_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection("Data Source=DESKTOP-HVTB9LK;Integrated Security=SSPI;Initial Catalog=YazilimYapimi");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM SoruEkle", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            guna2DataGridView1.DataSource = tablo;
            baglanti.Close();
            //Soru();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_sorua.Text = guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_aa.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_ba.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_ca.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_da.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_dgr.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            //= guna2DataGridView1.CurrentRow.Cells[7].Value;

        }
    }
}
