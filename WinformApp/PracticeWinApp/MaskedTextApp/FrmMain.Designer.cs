
namespace MaskedTextApp
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtHiredDate = new System.Windows.Forms.MaskedTextBox();
            this.TxtZipcode = new System.Windows.Forms.MaskedTextBox();
            this.TxtAdress = new System.Windows.Forms.MaskedTextBox();
            this.TxtMobile = new System.Windows.Forms.MaskedTextBox();
            this.TxtRedisterNumber = new System.Windows.Forms.MaskedTextBox();
            this.TxtEmail = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "입사일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "우편번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "주소";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "휴대폰번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "주민번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "이메일주소";
            // 
            // TxtHiredDate
            // 
            this.TxtHiredDate.Location = new System.Drawing.Point(90, 9);
            this.TxtHiredDate.Mask = "0000-00-00";
            this.TxtHiredDate.Name = "TxtHiredDate";
            this.TxtHiredDate.Size = new System.Drawing.Size(73, 21);
            this.TxtHiredDate.TabIndex = 6;
            this.TxtHiredDate.ValidatingType = typeof(System.DateTime);
            // 
            // TxtZipcode
            // 
            this.TxtZipcode.Location = new System.Drawing.Point(90, 40);
            this.TxtZipcode.Mask = "99999";
            this.TxtZipcode.Name = "TxtZipcode";
            this.TxtZipcode.Size = new System.Drawing.Size(39, 21);
            this.TxtZipcode.TabIndex = 7;
            this.TxtZipcode.ValidatingType = typeof(int);
            // 
            // TxtAdress
            // 
            this.TxtAdress.Location = new System.Drawing.Point(90, 71);
            this.TxtAdress.Name = "TxtAdress";
            this.TxtAdress.Size = new System.Drawing.Size(432, 21);
            this.TxtAdress.TabIndex = 8;
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(90, 102);
            this.TxtMobile.Mask = "000-9000-0000";
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.Size = new System.Drawing.Size(86, 21);
            this.TxtMobile.TabIndex = 9;
            // 
            // TxtRedisterNumber
            // 
            this.TxtRedisterNumber.Location = new System.Drawing.Point(90, 133);
            this.TxtRedisterNumber.Mask = "000000-0000000";
            this.TxtRedisterNumber.Name = "TxtRedisterNumber";
            this.TxtRedisterNumber.Size = new System.Drawing.Size(92, 21);
            this.TxtRedisterNumber.TabIndex = 10;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(90, 167);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(211, 21);
            this.TxtEmail.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(147, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "   등록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 332);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtRedisterNumber);
            this.Controls.Add(this.TxtMobile);
            this.Controls.Add(this.TxtAdress);
            this.Controls.Add(this.TxtZipcode);
            this.Controls.Add(this.TxtHiredDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "사원정보 등록";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TxtHiredDate;
        private System.Windows.Forms.MaskedTextBox TxtZipcode;
        private System.Windows.Forms.MaskedTextBox TxtAdress;
        private System.Windows.Forms.MaskedTextBox TxtMobile;
        private System.Windows.Forms.MaskedTextBox TxtRedisterNumber;
        private System.Windows.Forms.MaskedTextBox TxtEmail;
        private System.Windows.Forms.Button button1;
    }
}

