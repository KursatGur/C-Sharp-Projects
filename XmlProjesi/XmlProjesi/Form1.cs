using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace XmlProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosyasi = new XmlDocument();
            xmldosyasi.Load(bugun);
            string dolaralis = xmldosyasi.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarSatis.Text = dolaralis;
            string dolarsatis = xmldosyasi.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarAlis.Text = dolarsatis;
            string euroalis = xmldosyasi.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroSatis.Text = euroalis;
            string eurosatis = xmldosyasi.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroAlis.Text = eurosatis;
            string tarih = xmldosyasi.SelectSingleNode("Tarih_Date/@Tarih").InnerXml;
            label5.Text = tarih;
            chart1.Series["Veriler"].Points.AddXY("Dolar Alış", LblDolarAlis.Text);
            chart1.Series["Veriler"].Points.AddXY("Dolar Satış", LblDolarSatis.Text);
            chart1.Series["Veriler"].Points.AddXY("Euro Alış", LblEuroAlis.Text);
            chart1.Series["Veriler"].Points.AddXY("Euro Satış", LblEuroSatis.Text);
        }

        

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");    
        }
        double kur, tutar = 0, kalan;
        int miktar;

        private void button1_Click(object sender, EventArgs e)
        {
            TxtKalan.Text = "";
            TxtTutar.Text = "";
            TxtMiktar.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Dolar Alış")
            {
                TxtKur.Text = LblDolarAlis.Text;
            }
            if (comboBox1.Text == "Dolar Bozdur")
            {
             TxtKur.Text = LblDolarSatis.Text;
            }
            if (comboBox1.Text == "Euro Alış")
            {
              TxtKur.Text = LblEuroAlis.Text;
            }
            if (comboBox1.Text == "Euro Bozdur")
            {
              TxtKur.Text = LblEuroSatis.Text;
            }
        }

        

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                kur = Convert.ToDouble(TxtKur.Text);
                miktar = Convert.ToInt32(TxtMiktar.Text);
                tutar = miktar * kur;
                TxtTutar.Text = tutar.ToString();
                
            }
            if (comboBox1.SelectedIndex==1)
            {
                kur = Convert.ToDouble(TxtKur.Text);
                miktar = Convert.ToInt32(TxtMiktar.Text);
                tutar = miktar / kur;
                TxtTutar.Text = tutar.ToString();
                TxtKalan.Text = (miktar % kur).ToString();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                kur = Convert.ToDouble(TxtKur.Text);
                miktar = Convert.ToInt32(TxtMiktar.Text);
                tutar = miktar * kur;
                TxtTutar.Text = tutar.ToString();

            }
            if (comboBox1.SelectedIndex == 3)
            {
                kur = Convert.ToDouble(TxtKur.Text);
                miktar = Convert.ToInt32(TxtMiktar.Text);
                tutar = miktar / kur;
                TxtTutar.Text = tutar.ToString();
                TxtKalan.Text = (miktar % kur).ToString();

            }

        }
    }
}
