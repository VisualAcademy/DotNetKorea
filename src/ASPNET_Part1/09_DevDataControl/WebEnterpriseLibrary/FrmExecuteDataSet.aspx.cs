using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;

namespace WebEnterpriseLibrary
{
    public partial class FrmExecuteDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = @"
SELECT TOP 1000 [AddressID]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[City]
      ,[StateProvinceID]
      ,[PostalCode]
      ,[SpatialLocation]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2012].[Person].[Address]
";

            this.GridView1.DataSource = 
                (new DatabaseProviderFactory()).Create("ConnectionString")
                    .ExecuteDataSet(CommandType.Text, sql);
            this.GridView1.DataBind();
        }
    }
}