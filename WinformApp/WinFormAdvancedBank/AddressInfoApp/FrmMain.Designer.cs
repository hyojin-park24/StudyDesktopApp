
namespace AddressInfoApp
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
            this.DgvAddress = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtMobile = new System.Windows.Forms.MaskedTextBox();
            this.TxtFullName = new System.Windows.Forms.TextBox();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtIdx = new System.Windows.Forms.TextBox();
            this.BtlDelete = new System.Windows.Forms.Button();
            this.BtlUpdate = new System.Windows.Forms.Button();
            this.BtlAdd = new System.Windows.Forms.Button();
            this.BtlClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddress)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAddress
            // 
            this.DgvAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAddress.Location = new System.Drawing.Point(13, 13);
            this.DgvAddress.Name = "DgvAddress";
            this.DgvAddress.RowTemplate.Height = 23;
            this.DgvAddress.Size = new System.Drawing.Size(465, 150);
            this.DgvAddress.TabIndex = 0;
            this.DgvAddress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAddress_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtMobile);
            this.groupBox1.Controls.Add(this.TxtFullName);
            this.groupBox1.Controls.Add(this.TxtAddress);
            this.groupBox1.Controls.Add(this.TxtIdx);
            this.groupBox1.Controls.Add(this.BtlDelete);
            this.groupBox1.Controls.Add(this.BtlUpdate);
            this.groupBox1.Controls.Add(this.BtlAdd);
            this.groupBox1.Controls.Add(this.BtlClear);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 186);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "입력창";
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(53, 106);
            this.TxtMobile.Mask = "000-9000-0000";
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.Size = new System.Drawing.Size(89, 21);
            this.TxtMobile.TabIndex = 12;
            this.TxtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMobile_KeyPress);
            // 
            // TxtFullName
            // 
            this.TxtFullName.Location = new System.Drawing.Point(51, 69);
            this.TxtFullName.Name = "TxtFullName";
            this.TxtFullName.Size = new System.Drawing.Size(100, 21);
            this.TxtFullName.TabIndex = 11;
            this.TxtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFullName_KeyPress);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(50, 141);
            this.TxtAddress.MaxLength = 200;
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(254, 21);
            this.TxtAddress.TabIndex = 10;
            // 
            // TxtIdx
            // 
            this.TxtIdx.Location = new System.Drawing.Point(51, 33);
            this.TxtIdx.Name = "TxtIdx";
            this.TxtIdx.ReadOnly = true;
            this.TxtIdx.Size = new System.Drawing.Size(38, 21);
            this.TxtIdx.TabIndex = 8;
            // 
            // BtlDelete
            // 
            this.BtlDelete.Location = new System.Drawing.Point(356, 137);
            this.BtlDelete.Name = "BtlDelete";
            this.BtlDelete.Size = new System.Drawing.Size(75, 23);
            this.BtlDelete.TabIndex = 7;
            this.BtlDelete.Text = "삭제";
            this.BtlDelete.UseVisualStyleBackColor = true;
            this.BtlDelete.Click += new System.EventHandler(this.BtlDelete_Click);
            // 
            // BtlUpdate
            // 
            this.BtlUpdate.Location = new System.Drawing.Point(356, 104);
            this.BtlUpdate.Name = "BtlUpdate";
            this.BtlUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtlUpdate.TabIndex = 6;
            this.BtlUpdate.Text = "수정";
            this.BtlUpdate.UseVisualStyleBackColor = true;
            this.BtlUpdate.Click += new System.EventHandler(this.BtlUpdate_Click);
            // 
            // BtlAdd
            // 
            this.BtlAdd.Location = new System.Drawing.Point(356, 71);
            this.BtlAdd.Name = "BtlAdd";
            this.BtlAdd.Size = new System.Drawing.Size(75, 23);
            this.BtlAdd.TabIndex = 5;
            this.BtlAdd.Text = "추가";
            this.BtlAdd.UseVisualStyleBackColor = true;
            this.BtlAdd.Click += new System.EventHandler(this.BtlAdd_Click);
            // 
            // BtlClear
            // 
            this.BtlClear.Location = new System.Drawing.Point(356, 38);
            this.BtlClear.Name = "BtlClear";
            this.BtlClear.Size = new System.Drawing.Size(75, 23);
            this.BtlClear.TabIndex = 4;
            this.BtlClear.Text = "초기화";
            this.BtlClear.UseVisualStyleBackColor = true;
            this.BtlClear.Click += new System.EventHandler(this.BtlClear_Click);
            this.BtlClear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BtlClear_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "주소";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "핸드폰";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Idx";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 370);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "주소록 앱";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAddress)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtlDelete;
        private System.Windows.Forms.Button BtlUpdate;
        private System.Windows.Forms.Button BtlAdd;
        private System.Windows.Forms.Button BtlClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFullName;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtIdx;
        private System.Windows.Forms.MaskedTextBox TxtMobile;
    }
}

