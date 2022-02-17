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

namespace _16022022_TelefonRehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=localhost; Database=TelefonRehberi;user=sa;password=12345");
        
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select count(*) from Kullanici where KullaniciAdi=@ad and Sifre=@sifre",baglanti);
            komut.Parameters.AddWithValue("@ad", txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@sifre", txtsifre.Text);
            baglanti.Open();
            int sayi=(int)komut.ExecuteScalar();  //tek bir kolon dönüyorsa scalar kullanılır.
            if (sayi>0)
            {
                RehberForm r = new RehberForm();
                r.Show();
                
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            baglanti.Close();

        }
    }
}
