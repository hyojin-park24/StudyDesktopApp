using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorChangerApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Trackbar_Scroll(object sender, EventArgs e)
        {
            TxtRed.Text = TrdRed.Value.ToString();
            TxtGreen.Text = trackBar2.Value.ToString();
            TxtBlue.Text = trackBar3.Value.ToString();
            PnlResult.BackColor = Color.FromArgb(TrdRed.Value, trackBar2.Value, trackBar3.Value);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
