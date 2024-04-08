using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebTextToTable
{
    public partial class FrmTextToTable : System.Web.UI.Page
    {
        /// <summary>
        /// Dapper DB/Context 개체 생성 샘플
        /// </summary>
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string src = txtSourceDate.Text;
            //lblDisplay.Text = src.Replace("\r\n", "<br />");

            string[] lines = src.Split('\n');
            
            //lblDisplay.Text = lines[0];

            List<Record> records = new List<Record>();

            foreach (var line in lines)
            {
                string[] record = line.Split(',');

                if (record[0].Length > 0)
                {
                    records.Add(new Record { Name = record[0], PhoneNumber = record[1], BirthDate = record[2], AuthCode = record[3] });
                }
            }

            // records 컬렉션에 있는 데이터를 DB에 저장
            string sql = "Insert Into Records (Name, PhoneNumber, BirthDate, AuthCode) Values(@Name, @PhoneNumber, @BirthDate, @AuthCode);";
            this.db.Execute(sql, records); // 벌크인서트
        }
    }
}