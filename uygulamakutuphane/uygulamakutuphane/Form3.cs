using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace uygulamakutuphane
{
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = VAHITTIN\\SQLEXPRESS; Initial Catalog = uygulamakk; Integrated Security = True");

        public Form3()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            

             if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("select * from Kullanicilarr where KullaniciAdi='" + textBox1.Text + "'and Sifre='" + textBox2.Text + "' and KullaniciTipi='" + comboBox1.Text + "'", baglanti);
               
                SqlDataReader dr = cmd.ExecuteReader();
                
                

                if (dr.Read())
                {            
                    if ( dr["KullaniciTipi"].ToString().TrimEnd()=="Admin" )
                    {
                        Form1 frm1 = new Form1();
                        frm1.Show();
                        this.Hide();
                    }
                    else if (dr["KullaniciTipi"].ToString().TrimEnd() == "Normal")
                    {
                        Form2 frm2 = new Form2(1);
                        frm2.Show();                  
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı");
                }

                baglanti.Close();
             }
            

        }
    }
    }

