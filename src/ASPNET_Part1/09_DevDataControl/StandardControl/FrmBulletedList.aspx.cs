using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Demos.ASPNET.WebForms._09_DevDataControl.StandardControl
{
    public partial class FrmBulletedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            // EntLib 6.0
            //DataSet ds = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet(System.Data.CommandType.Text, "Select Distinct CategoryName From ServerType");

            // EntLib 5.0
            DataSet ds = DatabaseFactory.CreateDatabase("ConnectionString").ExecuteDataSet(
                System.Data.CommandType.Text, "Select Distinct CategoryName From ServerType");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                BulletedList1.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CategoryName"].ToString()));
            }

            // 확장 기능 : DataSet to String Array
            List<String> lst = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lst.Add(row["CategoryName"].ToString());
            }
            string[] strNames = lst.ToArray();

            // 확장 기능 : Search a string in String Array
            if (strNames.Contains("Web"))
            {
                BulletedList2.Items.Add("Web Server");
            }
            if (strNames.Contains("SQL"))
            {
                BulletedList2.Items.Add("SQL Server");
            }
            if (strNames.Contains("SharePoint"))
            {
                BulletedList2.Items.Add("SharePoint Server");
            }
            if (strNames.Contains("Windows"))
            {
                BulletedList2.Items.Add("Windows Server");
            }

        }
    }
}


//CREATE TABLE [dbo].[ServerType]
//(
//    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
//    [CategoryName] NVARCHAR(50) NULL
//)
