using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Takip_Sistemi
{
    public partial class frmMüsteriEkle : Form
    {
        public frmMüsteriEkle()
        {
            InitializeComponent(); 
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-32NFA50L\SQLEXPRESS;Initial Catalog=Stok_Takip;Integrated Security=True");

        private void frmMüsteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into musteri(tc,adsoyad,telefon,adres,mail) values(@tc,@adsoyad,@telefon,@adres,@mail)",baglanti);
            komut.Parameters.AddWithValue("@tc",txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad",txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon",txtTel.Text);
            komut.Parameters.AddWithValue("@adres",txtAdres.Text);
            komut.Parameters.AddWithValue("@mail",txtMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Kaydı Tamamlandı. Başarı ile Eklendi");

            foreach( Control item in this.Controls)
            {
                if( item is TextBox )
                {
                    item.Text = "";
                }
            }

        }
    }
}
