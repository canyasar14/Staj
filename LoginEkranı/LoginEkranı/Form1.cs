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
namespace LoginEkranı
{
    public partial class Ana_giris : Form
    {
        public Ana_giris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=YCANN\SQLEXPRESS;Initial Catalog=c#loginekranı;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Alan Bırakmayınız..");
            }
            else
            {
                baglanti.Open();
                string user;
                string sifree;

                user = textBox1.Text;
                sifree = textBox2.Text;

                SqlCommand komut = new SqlCommand("select * from users where kullanici='" + user + "'and sifre='" + sifree + "' ", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Hosgeldinizz.. " + user + "");

                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre...");
                }

                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz..");
            }
            else
            {

                baglanti.Open();
                string user;
                string sifree;

                user = textBox1.Text;
                sifree = textBox2.Text;
                SqlCommand komut = new SqlCommand("select * from users where kullanici='" + user + "' ", baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    MessageBox.Show("Bu kullanıcı adı kullanılmaktadır lütfen başka kullanıcı adı seçiniz..");
                }
                else
                {
                    oku.Close();
                    SqlCommand ekle = new SqlCommand("insert into users(kullanici,sifre)values('" + user + "','" + sifree + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Oluşturuldu...");
                }

                baglanti.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl2.SelectedTab = tabPage2;
            textBox3.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayın!..");
            }
            else
            {
                baglanti.Open();
                string user;
                string sifree;

                user = textBox3.Text;
                sifree = textBox4.Text;
                SqlCommand sorgu = new SqlCommand("select * from users where kullanici= '" + user + "' ", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                if (oku.Read())
                {
                    oku.Close();
                    SqlCommand güncelle = new SqlCommand("update users set sifre='" + sifree + "' where kullanici='" + user + "'", baglanti);
                    güncelle.ExecuteNonQuery();
                    MessageBox.Show("Şifreniz Başarıyla Güncellendi...");
                }
                else
                {
                    MessageBox.Show("Kullanıcı adınız hatalı...");
                }

                baglanti.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
