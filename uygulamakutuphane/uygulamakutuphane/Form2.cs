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

namespace uygulamakutuphane
{
    public partial class Form2 : Form
    { 
        SqlConnection baglanti = new SqlConnection("Data Source = VAHITTIN\\SQLEXPRESS; Initial Catalog = uygulamakk; Integrated Security = True");
        public Form2(int a)
        {
            InitializeComponent();
            if (a == 1) groupBox1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Hata");
            }

            else if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "INSERT INTO KitapBilgi(KitapTuru,KitapAdi,YazarAdi,SayfaSayisi,SeriNo,YayineviID) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text +"','" + textBox4.Text + "','" + textBox5.Text + "','" + int.Parse(textBox6.Text)+ "')";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listele();
                temizle();
               
                MessageBox.Show("işlem tamam");
            }
        }

        void listele()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "select * from KitapBilgi";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "KitapBilgi");
                dataGridView1.DataSource = ds.Tables["KitapBilgi"];
                baglanti.Close();

            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "delete from KitapBilgi where KitapID=@numara";
                cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listele();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("Hata");
            }

            else if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "update KitapBilgi set KitapTuru = '" + textBox1.Text + "',KitapAdi='" + textBox2.Text + "',YazarAdi ='" + textBox3.Text + "',SayfaSayisi ='" + textBox4.Text + "',SeriNo ='" + textBox5.Text + "' where KitapID=@numara";
                cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                MessageBox.Show("güncelleme tamalandı");
                temizle();
                listele();


            }
        }

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
