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
    public partial class FrmBooks : MetroForm

    {
        #region 전역변수 영역

        private bool IsNew = false; // false 면 수정, true면 신규

        #endregion

        #region 이벤트 영역
        public FrmBooks()
        {
            InitializeComponent();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            IsNew = true; //신규 초기화

            InitCboData(); //콤보박스 들어가는 데이터 초기화
            RefreshData(); // 테이블 조회

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;
        }

      

        private void FrmMember_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1) //-1 은 선택된 값이 없다는 의미
            {
                var selData = DgvData.Rows[e.RowIndex];

                AsignToControls(selData);
                IsNew = false; // 값 수정
            }
        }

       
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Validation 필요
            if (CheckValidation() == false) return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 값이 비어있을 때 (Validation) 유효성 체크
            if (CheckValidation() == false) return;


            SaveData();
            ClearInputs();
            RefreshData();
        }

        #endregion

        #region 커스텀 메서드 영역

        //삭제처리 프로세스
        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "DELETE FROM [dbo].[bookstbl] " +
                                         "   WHERE [Idx] = @Idx ";
                    cmd.CommandText = query;

                    var pIdx = new SqlParameter("@Idx", SqlDbType.VarChar, 8);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "삭제 성공", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MetroMessageBox.Show(this, "삭제 실패", "삭제",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류"
                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                                          , b.ISBN 
                                          , b.Price 
                                          , b.Descriptions
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

            //컬럼 데이터그리드뷰 (Division) 화면에서 안보이게 할거임
            var column = DgvData.Columns[2]; //Divison column
            column.Visible = false;
            column = DgvData.Columns[8];
            column.Visible = false;

            column = DgvData.Columns[4];
            column.Width = 250;
            column.HeaderText = "도서명";
        }

        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value;
            //selDate.Cells[3]
            TxtNames.Text = selData.Cells[4].Value.ToString();

            DtpReleaseDate.Value = (DateTime)selData.Cells[5].Value;
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescriptions.Text = selData.Cells[8].Value.ToString();


            TxtIdx.ReadOnly = true;
        }


        // 입력,수정 처리 데이터
        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    var query = "";

                    if (IsNew) // INSERT
                    {
                        query = @"INSERT INTO [dbo].[bookstbl]
                                               ([Author]
                                               ,[Division]
                                               ,[Names]
                                               ,[ReleaseDate]
                                               ,[ISBN]
                                               ,[Price]
                                               ,[Descriptions])
                                         VALUES
                                               ( @Author
                                               , @Division
                                               , @Names 
                                               , @ReleaseDate 
                                               , @ISBN
                                               , @Price
                                               , @Descriptions) ";
                    }
                    else // UPDATE
                    {
                        query = @" UPDATE [dbo].[bookstbl]
                                   SET [Author] =  @Author
                                      ,[Division] =  @Division
                                      ,[Names] =  @Names
                                      ,[ReleaseDate] =  @ReleaseDate
                                      ,[ISBN] =  @ISBN
                                      ,[Price] =  @Price
                                      ,[Descriptions] =  @Descriptions
                                 WHERE Idx = @Idx ";
                    }

                    cmd.CommandText = query;

                    var pAuthor = new SqlParameter("@Author", SqlDbType.Char, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    var pDivision = new SqlParameter("@Division", SqlDbType.NVarChar, 8);
                    pDivision.Value = CboDivision.SelectedValue;
                    cmd.Parameters.Add(pDivision);

                    var pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    var pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    var pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    var pPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                    pPrice.Value = TxtPrice.Text;
                    cmd.Parameters.Add(pPrice);

                    var pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar);
                    pDescriptions.Value = Helper.Common.ReplaceCmdText(TxtDescriptions.Text);
                    cmd.Parameters.Add(pDescriptions);

                    if (IsNew == false) // Idx 파라미터 Update일 때만 처리해줌 
                    {
                        var pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    var result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        MetroMessageBox.Show(this, "저장 실패", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류"
                  , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       // 입력값 유효성 체크 메서드
        private bool CheckValidation()
            {

            if (string.IsNullOrEmpty(TxtAuthor.Text) ||
                string.IsNullOrEmpty(TxtNames.Text) ||
                 CboDivision.SelectedIndex == -1 ||
                 DtpReleaseDate.Value == null )
            {
                MetroMessageBox.Show(this, "빈값은 처리 할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            TxtIdx.Text = TxtAuthor.Text = "";
            TxtNames.Text = TxtISBN.Text = "";
            TxtPrice.Text = TxtDescriptions.Text = "";
            CboDivision.SelectedIndex = -1; // ?
            DtpReleaseDate.Value = DateTime.Now; // 오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            IsNew = true;
        }

        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    var query = "SELECT Division, Names FROM dbo.divtbl";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var temp = new Dictionary<string, string>(); //지네릭 일반화 프로그래밍
                    while (reader.Read())
                    {
                        temp.Add(reader[0].ToString(), reader[1].ToString()); // BOO1, 공포/스릴러
                    }
                    CboDivision.DataSource = new BindingSource(temp, null); 
                    CboDivision.DisplayMember = "Value";
                    CboDivision.ValueMember = "Key";
                    CboDivision.SelectedIndex = -1;
                }
            }
            catch {}
        }

        #endregion
    }
}
