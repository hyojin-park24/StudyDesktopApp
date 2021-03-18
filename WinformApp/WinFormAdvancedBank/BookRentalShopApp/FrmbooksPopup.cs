using MetroFramework.Forms;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookRentalShopApp
{
    public partial class FrmbooksPopup : MetroForm

    {
        #region 전역변수 영역

        public int SelIdx { get; set; }

        public string selName { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmbooksPopup()
        {
            InitializeComponent();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            RefreshData(); // 테이블 조회
        }

        private void FrmMember_Resize(object sender, EventArgs e)
        {
          
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                   
        }
               
        #endregion

        #region 커스텀 메서드 영역

        //삭제처리 프로세스
        private void RefreshData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var query = @"SELECT	b.Idx 
                                          , b.Author 
                                          , b.Division 
	                                      , d.Names as DivName
                                          , b.Names 
                                          , b.ReleaseDate 
                                      FROM  dbo . bookstbl  as b
                                      INNER JOIN dbo.divtbl as d
	                                    ON b.Division = d.Division";


                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //컬럼 데이터그리드뷰 (Division) 화면에서 안보이게 할거임
            var column = DgvData.Columns[2]; //Divison column
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";

            column = DgvData.Columns[0];
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        #endregion

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelIdx = (int)DgvData.SelectedRows[0].Cells[0].Value;
            selName = DgvData.SelectedRows[0].Cells[4].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
