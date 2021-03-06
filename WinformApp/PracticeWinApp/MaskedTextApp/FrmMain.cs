using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskedTextApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //입사일, 주민번호는 유효한 값인지 체크 필요함
            string result = string.Empty;

            result = $"입사일 : {TxtHiredDate}\n";
            result += $"우편번호 : {TxtZipcode.Text}\n";
            result += $"주소 : {TxtAdress.Text}\n";
            result += $"휴대폰번호 : {TxtMobile.Text}\n";
            result += $"주민번호 : {TxtRedisterNumber.Text}\n";
            result += $"이메일 : {TxtEmail.Text}\n";

            MessageBox.Show(result, "개인정보", MessageBoxButtons.OK, MessageBoxIcon.Information );

        }
    }
}
