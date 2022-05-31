using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            
            MoveIndicator((Control)sender);
            groupBox1.Visible = false;
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            groupBox1.Visible=false;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            groupBox1.Visible = false;
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            groupBox1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgList.ColumnCount = 2;
            dtgList.Columns[0].Name = "Id";
            dtgList.Columns[1].Name = "Ad Soyad";

        }

        private void nMiktar_ValueChanged(object sender, EventArgs e)
        {
            nMiktar.Maximum = rtxtAdaylar.Lines.Count();
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

            if (rtxtAdaylar.Lines.Count() > 0)
            {
                nMiktar.Maximum = rtxtAdaylar.Lines.Count() - 1;

            }
            else
            {
                nMiktar.Minimum = 1;
            }
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton6_Click_1(object sender, EventArgs e)
        {
            int _cekilisSay = 1;
            int cekilisSayisi = Convert.ToInt32(nMiktar.Text);

            List<string> listAday = new List<string>(rtxtAdaylar.Text.Split('\n'));

            if (rtxtAdaylar.Text == "")
            {
                MessageBox.Show("Lütfen Aday Giriniz");

            }
            else
            {
                Random uret = new Random();

                for (int i = 0; i < cekilisSayisi; i++)
                {
                    int kazananAday = uret.Next(0, listAday.Count);
                    dtgList.Rows.Add(_cekilisSay++, listAday[kazananAday]);
                    listAday.Remove(listAday[kazananAday]);

                }
            }
        }
        int _cekilisSay = 1;
        private void bunifuTileButton7_Click(object sender, EventArgs e)
        {
            rtxtAdaylar.Clear();
            dtgList.Rows.Clear();
            _cekilisSay = 1;
            nMiktar.Value = 1;
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
            groupBox1.Visible = false;

        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            MoveIndicator((Control)sender);
            groupBox1.Visible = false;
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
            Form2 f2=new Form2();
            f2.ShowDialog();
        }
    }
}
