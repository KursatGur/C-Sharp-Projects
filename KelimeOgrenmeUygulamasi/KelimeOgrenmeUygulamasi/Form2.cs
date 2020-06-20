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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\asus\Documents\dbSozluk.mdb");
        public string buttons;
        public int id;
        Random rast = new Random();
        private void Form2_Load(object sender, EventArgs e)
        {
            fr.sayac = 0;
            label2.Text = buttons;
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select turkish From Sozluk where English=@p1", baglanti);
            //komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p1", label2.Text);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label3.Text = oku[0].ToString();
            }
            baglanti.Close();

        }
        Form1 fr = new Form1();
        public Button Form1Button { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text==label3.Text)
            {
                this.BackColor = Color.Green;
                Form1Button.Enabled = false;
                Form1Button.BackColor = Color.Green;
                fr.sayac++;
                this.Close();
               
            }
            else
            {
                this.BackColor = Color.Red;
                MessageBox.Show(label3.Text,"Yanlış",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Form1Button.Enabled = false;
                Form1Button.BackColor = Color.Red;
                fr.sayac++;
                this.Close();
            }
        }
    }
}
