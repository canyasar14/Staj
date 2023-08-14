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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=YCANN\SQLEXPRESS;Initial Catalog=Veriler;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız...");
            }
            string kayıt = "insert into veri_veri(isim,soyisim,kimlikno,eğitim) values(@isim,@soyisim,@kimlik,@egitim)";

            SqlCommand komut = new SqlCommand(kayıt, baglan);
            komut.Parameters.AddWithValue("@isim", textBox1.Text);
            komut.Parameters.AddWithValue("@soyisim", textBox2.Text);
            komut.Parameters.AddWithValue("@kimlik", textBox3.Text);
            komut.Parameters.AddWithValue("@egitim", textBox4.Text);

            komut.ExecuteNonQuery();
            MessageBox.Show("Başarıyla Kayıt işleminiz gerçekleşmiştir.");
            baglan.Close();

            
        }
    }
}
