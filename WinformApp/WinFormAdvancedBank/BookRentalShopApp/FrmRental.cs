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
using System.Diagnostics;

namespace BookRentalShopApp
{
    public partial class FrmRental : MetroForm

    {
        #region 전역변수 영역

        private bool IsNew = false; // false 면 수정, true면 신규

        #endregion

        #region 이벤트 영역
        public FrmRental()
        {
            InitializeComponent();
        }

        private void FrmMember_Load(object sender, EventArgs e)
        {
            IsNew = true; //신규 초기화

            InitCboData(); //콤보박스 들어가는 데이터 초기화
            RefreshData(); // 테이블 조회

            DtpRantalDate.CustomFormat = "yyyy-MM-dd";
            DtpRantalDate.Format = DateTimePickerFormat.Custom;
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
                BtnSearchBook.Enabled = BtnSearchMember.Enabled = false;
                DtpRantalDate.Enabled = false;
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

                    var query = @"SELECT    r.Idx 
                                          , r.memberIdx 
	                                      , m.Names as rentalMember
                                          , r.bookIdx 
	                                      , b.Names as bookName
                                          , r.rentalDate 
                                          , r.returnDate
                                          , r.rentalState 
                                          , case  r.rentalState 
		                                        when 'R' then '대여중'
		                                        when 'T' then '반납'
		                                        else '상태없음' 
		                                        end as StateDesc
                                      FROM  dbo . rentaltbl as r
                                      INNER JOIN dbo.membertbl as m 
	                                    ON r.memberIdx = m.Idx

	                                  INNER JOIN dbo.bookstbl as b
		                                    ON r.bookIdx = b.Idx";


                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "rentaltbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "rentaltbl";
                }
            }
            catch (Exception ex)
            {

                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //컬럼 데이터그리드뷰 (Division) 화면에서 안보이게 할거임
            var column = DgvData.Columns[1]; //Divison column
            column.Visible = false;
            column = DgvData.Columns[3];
            column.Visible = false;
           

           
        }

        private void AsignToControls(DataGridViewRow selData)
        {
            TxtIdx.Text = selData.Cells[0].Value.ToString();
            selMemberIdx = (int)selData.Cells[1].Value;
            Debug.WriteLine($">>>> selMemberIdx : {selMemberIdx}");
            TxtRentalMember.Text = selData.Cells[2].Value.ToString();
            selBookIdx = (int)selData.Cells[3].Value;
            Debug.WriteLine($">>>> selBookIdx : {selBookIdx}");
            TxtBookName.Text = selData.Cells[4].Value.ToString();
            DtpRantalDate.Value = (DateTime)selData.Cells[5].Value;
            TxtReturnDate.Text = selData.Cells[6].Value == null ? "" : selData.Cells[6].Value.ToString();
            CboRentalState.SelectedValue = selData.Cells[7].Value;

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
                        query = @"INSERT INTO [dbo].[rentaltbl]
                                                   ([memberIdx]
                                                   ,[bookIdx]
                                                   ,[rentalDate]
                                                   ,[rentalState])
                                             VALUES
                                                   (@memberIdx
                                                   ,@bookIdx
                                                   ,@rentalDate
                                                   ,@rentalState) ";
                    }
                    else // UPDATE
                    {
                        query = @" UPDATE [dbo].[rentaltbl]
                                   SET [returnDate] = case @rentalState
                                                       when 'T' then GETDATE()
                                                       when 'R' then null end
                                      ,[rentalState] = @rentalState
                                 WHERE Idx = @idx ";
                     }                              

                    cmd.CommandText = query;

                    if (IsNew == true) // 신규
                    {
                        var pmemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                        pmemberIdx.Value = selMemberIdx;
                        cmd.Parameters.Add(pmemberIdx);

                        var pbookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                        pbookIdx.Value = selBookIdx;
                        cmd.Parameters.Add(pbookIdx);

                        var prentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                        prentalDate.Value = DtpRantalDate.Value;
                        cmd.Parameters.Add(prentalDate);

                        var prentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        prentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(prentalState);
                    }
                    else // 업데이트일땐 
                    {
                        var prentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        prentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(prentalState);

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

            if (string.IsNullOrEmpty(TxtRentalMember.Text) ||
                string.IsNullOrEmpty(TxtBookName.Text) ||
                 //CboDivision.SelectedIndex == -1 ||
                 DtpRantalDate.Value == null ||
                 CboRentalState.SelectedIndex < 0 )
            {
                MetroMessageBox.Show(this, "빈값은 처리 할 수 없습니다.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            selMemberIdx = selBookIdx = 0;
            selMemberName = selBookName = "";
            TxtIdx.Text = TxtRentalMember.Text =  "";
            TxtBookName.Text = "";
            DtpRantalDate.Value = DateTime.Now; // 오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            CboRentalState.SelectedIndex = -1;
           

            BtnSearchBook.Enabled = BtnSearchMember.Enabled = true;
            DtpRantalDate.Enabled = true;
            IsNew = true;
        }

        private void InitCboData()
        {
            try
            {
                var temp = new Dictionary<string, string>();
                temp.Add("R", "대여중");
                temp.Add("T", "반납");

                CboRentalState.DataSource = new BindingSource(temp, null);
                CboRentalState.DisplayMember = "Value";
                CboRentalState.ValueMember = "Key";
                CboRentalState.SelectedIndex = -1;
                
            }
            catch { }
        }

        #endregion

        private int selMemberIdx = 0; // 초기화 중요!! 항상 떠있기 때문! 선택된 회원번호
        private string selMemberName = ""; //초기화 중요!! 항상 떠있기 때문! 선택된 회원이름

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            FrmMemberPopup frm = new FrmMemberPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selMemberIdx = frm.SelIdx;
                TxtRentalMember.Text =selMemberName = frm.selName;
            }
        }

        private int selBookIdx = 0;
        private string selBookName = "";

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            FrmbooksPopup frm = new FrmbooksPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                selBookIdx = frm.SelIdx;
                TxtBookName.Text = selBookName = frm.selName;
            }
        }
    }
}
