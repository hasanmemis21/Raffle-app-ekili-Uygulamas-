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
using Newtonsoft.Json;

namespace HASS_Group_v1._0
{
    public partial class jsonForm : Form
    {
        public jsonForm()
        {
            InitializeComponent();
        }
        void MoveIndicator(Control control)
        {
            indicator.Top = control.Top;
            indicator.Height = control.Height;
        }
        private void jsonForm_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
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
            xmlForm xml = new xmlForm();
            xml.Show();
            this.Hide();
        }
        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            jsonForm json = new jsonForm();
            json.Show();
            this.Hide();
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
        private void bunifuTileButton15_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pathBox.Text = openFileDialog1.FileName;
            using (StreamReader r = new StreamReader(pathBox.Text))
            {
                string json = r.ReadToEnd();
                try
                {
                    var result = JsonConvert.DeserializeObject<List<Users>>(json);
                    katilimciTablosu.DataSource = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Yanlış format türünde bir dosya seçtiniz. Lütfen tekrar deneyiniz!", "HATA!", MessageBoxButtons.OK);
                }
            }
            int katilimci = katilimciTablosu.RowCount;
            label7.Text = katilimci.ToString();
        }
        private void bunifuTileButton18_Click(object sender, EventArgs e)
        {
            pathBox.Text = openFileDialog1.FileName;
            using (StreamReader r = new StreamReader(pathBox.Text))
            {
                string json = r.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<Users>>(json);
                result.ToArray();
                Random rnd = new Random();
                List<Users> kazananLines = new List<Users>();
                List<Users> yedekLines = new List<Users>();
                for (int i = 1; i < kazananSayisi.Value + 1; i++)
                {
                    int kura = rnd.Next(1, result.Count);
                    kazananLines.Add(result[kura]);
                    result.RemoveAt(kura);
                }
                for (int i = 1; i < yedekSayisi.Value + 1; i++)
                {
                    int yedekKura = rnd.Next(1, result.Count);
                    yedekLines.Add(result[yedekKura]);
                    result.RemoveAt(yedekKura);
                }
                kazananTablosu.DataSource = kazananLines;
                yedekTablosu.DataSource = yedekLines;
            }
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            yedekSayisi.Value = kazananSayisi.Value;
        }
        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = path + @"\hass_giveaway_cikti_json.txt";
            File.Delete(fileName);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, " ----- AS TALİHLİLER -----\n");
            for (int j = 0; j < kazananTablosu.Rows.Count; j++)
            {
                List<object> ciktiList = new List<object>();
                for (int k = 0; k < kazananTablosu.Columns.Count; k++)
                {
                    ciktiList.Add(kazananTablosu.Rows[j].Cells[k].Value.ToString());
                }
                string dizi = "";
                foreach (var item in ciktiList)
                {
                    dizi = $"{dizi} {item}";
                }
                File.AppendAllText(fileName, dizi + Environment.NewLine);
            }
            File.AppendAllText(fileName, "\n ----- YEDEK TALİHLİLER -----\n");
            for (int j = 0; j < yedekTablosu.Rows.Count; j++)
            {
                List<object> ciktiList = new List<object>();
                for (int k = 0; k < yedekTablosu.Columns.Count; k++)
                {
                    ciktiList.Add(yedekTablosu.Rows[j].Cells[k].Value.ToString());
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
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
        private void bunifuTileButton17_Click(object sender, EventArgs e)
        {
            pathBox.Text = null;
            katilimciTablosu.DataSource = null;
            kazananTablosu.DataSource = null;
            yedekTablosu.DataSource = null;
            kazananSayisi.Value = 0;
            yedekSayisi.Value = 0;
            label7.Text = "0";
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
