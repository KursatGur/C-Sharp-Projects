using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace KelimeOgrenmeUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\asus\Documents\dbSozluk.mdb");
        Random rast = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8 };
            for (int i = 0; i < 8; i++)
            {
                baglanti.Open();
                int sayi;
                sayi = rast.Next(1, 2490);
                OleDbCommand komut = new OleDbCommand("Select english From sozluk where id=@p1", baglanti);
                komut.Parameters.AddWithValue("@p1", sayi);
                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    buttons[i].Text = oku[0].ToString();
                }
                baglanti.Close();
            }
        }
        public int sayac = 0;
        public void button1_Click(object sender, EventArgs e)
        {
            sayac++;
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button1.Text;
            fr.Form1Button = button1;
            fr.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button2.Text;
            fr.Form1Button = button2;
            fr.Show();
            sayac++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button3.Text;
            fr.Form1Button = button3;
            fr.Show();
            sayac++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button4.Text;
            fr.Form1Button = button4;
            fr.Show();
            sayac++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button5.Text;
            fr.Form1Button = button5;
            fr.Show();
            sayac++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button6.Text;
            fr.Form1Button = button6;
            fr.Show();
            sayac++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button7.Text;
            fr.Form1Button = button7;
            fr.Show();
            sayac++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = sayac.ToString();
            Form2 fr = new Form2();
            fr.buttons = button8.Text;
            fr.Form1Button = button8;
            fr.Show();
            sayac++;
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text==7.ToString())
            {
                button9.Enabled = true;
            }
            if(label1.Text==8.ToString())
            {
                Application.Restart();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            label1.Text = sayac.ToString();
        }
    }
}
