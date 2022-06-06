using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASS_Group_v1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void MoveIndicator(Control control)
        {
            indicator.Top = control.Top;
            indicator.Height = control.Height;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);   
        }
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            csvForm csvForm = new csvForm();
            csvForm.Show();
            this.Hide();
        }
        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            xmlForm xmlForm = new xmlForm();
            xmlForm.Show();
            this.Hide();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);   
        }
        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        private void nMiktar_ValueChanged(object sender, EventArgs e)
        {
            kazananSayisi.Maximum = rtxtAdaylar.Lines.Count();
            yedekSayisi.Value = kazananSayisi.Value;
        }
        private void btnCekilis_Click(object sender, EventArgs e)
        {   
        }
         private void groupBox1_Enter(object sender, EventArgs e)
        {   
        }

        private void rtxtAdaylar_TextChanged(object sender, EventArgs e)
        {
            lblAdaySayisi.Text = rtxtAdaylar.Lines.Count().ToString();
        }
        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton6_Click_1(object sender, EventArgs e)
        {
            kazananTablo.Rows.Clear();
            yedekTablo.Rows.Clear();
            kazananTablo.ColumnCount = 2;
            kazananTablo.Columns[0].Name = "Id";
            kazananTablo.Columns[1].Name = "Ad Soyad";
            yedekTablo.ColumnCount = 2;
            yedekTablo.Columns[0].Name = "Id";
            yedekTablo.Columns[1].Name = "Ad Soyad";
            int _cekilisSay = 1;
            int cekilisSayisi = Convert.ToInt32(kazananSayisi.Text);
            int yedekSayi = Convert.ToInt32(yedekSayisi.Text);
            List<string> listAday = new List<string>(rtxtAdaylar.Text.Split('\n'));
            if (rtxtAdaylar.Text == "")
            {
                MessageBox.Show("Lütfen Aday Giriniz");
            }
            else
            {
                Random uret = new Random();
                for (int i = 0; i < kazananSayisi.Value; i++)
                {
                    int kura = uret.Next(0, listAday.Count);
                    kazananTablo.Rows.Add(_cekilisSay++, listAday[kura]);
                    listAday.RemoveAt(kura);
                }
                for (int i = 0; i < yedekSayisi.Value; i++)
                {
                    int yedekKura = uret.Next(0, listAday.Count);
                    yedekTablo.Rows.Add(_cekilisSay++, listAday[yedekKura]);
                    listAday.RemoveAt(yedekKura);
                }
            }
        }
        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            rtxtAdaylar.Clear();
            kazananTablo.Rows.Clear();
            yedekTablo.Rows.Clear();
            kazananTablo.Columns.Clear();
            yedekTablo.Columns.Clear();
            kazananSayisi.Value = 0;
            yedekSayisi.Value = 0;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
        }
        private void lblAdaySayisi_Click(object sender, EventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
        }
        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);   
            jsonForm jsonForm= new jsonForm();
            jsonForm.Show();
            this.Hide();
        }
        private void bunifuTileButton8_Click(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton8_Click_1(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton10_Click(object sender, EventArgs e)
        {      
        }
        private void bunifuTileButton8_Click_2(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter_1(object sender, EventArgs e)
        {
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton9_Click(object sender, EventArgs e)
        {
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton3_Click_1(object sender, EventArgs e)
        {
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = path + @"\hass_giveaway_cikti.txt";
            File.Delete(fileName);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, " ----- AS TALİHLİLER -----\n");
            for (int j = 0; j < kazananTablo.Rows.Count - 1; j++)
            {
                List<object> ciktiList = new List<object>();
                for (int k = 0; k < kazananTablo.Columns.Count; k++)
                {
                    ciktiList.Add(kazananTablo.Rows[j].Cells[k].Value.ToString());
                }
                string dizi = "";
                foreach (var item in ciktiList)
                {
                    dizi = $"{dizi} {item}";
                }
                File.AppendAllText(fileName, dizi + Environment.NewLine);
            }
            File.AppendAllText(fileName, "\n ----- YEDEK TALİHLİLER -----\n");
            for (int j = 0; j < yedekTablo.Rows.Count - 1; j++)
            {
                List<object> ciktiList = new List<object>();
                for (int k = 0; k < kazananTablo.Columns.Count; k++)
                {
                    ciktiList.Add(yedekTablo.Rows[j].Cells[k].Value.ToString());
                }
                string dizi = "";
                foreach (var item in ciktiList)
                {
                    dizi = $"{dizi} {item}";
                }
                File.AppendAllText(fileName, dizi + Environment.NewLine);
            }
            File.AppendAllText(fileName, "\n*** Çekiliş "+ hm.ToString("dd'/'MM'/'yyyy HH:mm", CultureInfo.InvariantCulture) +" tarihinde, adil bir şekilde HASS Giveaway tarafından yapılmıştır. © ***\n");
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            switch (MessageBox.Show(this, "Programı kapatmak istediğinize emin misiniz?", "Kapatılıyor..", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}
