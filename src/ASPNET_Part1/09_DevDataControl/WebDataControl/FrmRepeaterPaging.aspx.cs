using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.WebDataControl
{
    public partial class FrmRepeaterPaging : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData(1);
            }
        }

        private int pageSize = 20;

        private void DisplayData(int pageIndex)
        {
            int recordCount = 0;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks2012ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPaging", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;

                    con.Open();

                    IDataReader dr = cmd.ExecuteReader();

                    lstCustomers.DataSource = dr;
                    lstCustomers.DataBind();

                    dr.Close();
                    con.Close();

                    recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);

                    lblRecordCount.Text = recordCount.ToString();

                    ShowPager(recordCount, pageIndex); // 페이저 호출
                }
            }
        }

        private void ShowPager(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);

            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                //for (int i = 1; i <= pageCount; i++)
                for (int i = (((currentPage - 1) / (int)10) * 10 + 1); i <= ((((currentPage - 1) / (int)10) + 1) * 10); i++)
                {
                    if (i > pageCount)
                    {
                        break;
                    }
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
            }

            // 이전/다음 링크 추가: 강의 외 추가
            if (currentPage > 10)
            {
                lnkPrev.Enabled = true;
                lnkPrev.CommandArgument = Convert.ToString(((currentPage - 1) / (int)10) * 10);
            }
            else
            {
                lnkPrev.Enabled = false;
            }
            if ((((currentPage - 1) / (int)10) * 10 + 1) < pageCount)
            {
                lnkNext.Enabled = true;
                lnkNext.CommandArgument = Convert.ToString(((currentPage - 1) / (int)10) * 10 + 11);
            }
            else
            {
                lnkNext.Enabled = false;
            }


            lstPager.DataSource = pages;
            lstPager.DataBind();
        }


        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = Convert.ToInt32((sender as LinkButton).CommandArgument);
            DisplayData(pageIndex);
        }


    }
}


//-- 데이터가 조금 있는 Customer 테이블 
//Select * From [Sales].[Customer]
//Go

//-- Row_Number() 함수를 사용한 페이징 처리
//Select Row_Number() Over ( Order By [CustomerID] Asc ) As RowNumber, CustomerID, PersonID, StoreID Into #Results
//From [Sales].[Customer]
//Select Count(*) From #Results
//Select * From #Results Where RowNumber Between 1 And 20 
//Drop Table #Results
//Go

//-- 전형적인 페이징 처리 저장 프로시저
//Create Procedure GetCustomersPaging
//    @PageIndex Int = 1,
//    @PageSize Int = 10,
//    @RecordCount Int OUTPUT
//As
//    Select Row_Number() Over ( Order By [CustomerID] Asc ) As RowNumber, CustomerID, PersonID, StoreID Into #Results
//    From [Sales].[Customer]

//    Select @RecordCount = Count(*) From #Results

//    Select * From #Results Where RowNumber 
//        Between (@PageIndex - 1) * @PageSize + 1 And (((@PageIndex - 1) * @PageSize + 1) + @PageSize) - 1

//    Drop Table #Results
//Go

//-- 1페이지에서 10개 식으로 호출 + 레코드수까지 반환
//Declare @RecordCount Int
//Exec GetCustomersPaging 2, 20, @RecordCount OUTPUT
//Select @RecordCount
//Go


