using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWinApp.Views
{
    public partial class FrmParant : Form
    {
        public FrmParant()
        {
            InitializeComponent();
        }

        private void FrmParant_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(800, 600);

            FrmChild frm = new FrmChild();
            this.AddOwnedForm(frm);

            frm.Show();

        }
    }
}
