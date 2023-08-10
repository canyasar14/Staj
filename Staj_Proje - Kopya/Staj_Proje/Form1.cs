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

namespace Staj_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source = YCANN\SQLEXPRESS; Initial Catalog= c#loginekrani;Integrated Security= True");
        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı veya şifre girmeyi unutmayınız...");
            }
            else
            {


                baglanti.Open();
                string user;
                string sifree;

                user = textBox1.Text;
                sifree = textBox2.Text;

                SqlCommand komut = new SqlCommand("select* from users where kullanici='" + user + "'and  sifre='" + sifree + "' ", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Hoşgeldiniz..." + user + "");
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre...");
                }

                baglanti.Close();
            }
        }
    }
}
