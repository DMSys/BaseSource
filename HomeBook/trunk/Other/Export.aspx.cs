using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Other_Export : System.Web.UI.Page
{

    xData sql = new xData();

    protected void Page_Load(object sender, EventArgs e)
    {
        string QueryString = Request.QueryString["ID"].ToString();          
        ExportInXLS(QueryString);
    }

    //Байндва грида за експорта
    protected void ExportInXLS(string QueryString)
    {

        DataTable DataTbl = new DataTable();
        string StrName    = "";

        if (QueryString != "")
        {
            int lngt = xFunctions.GetIDFromString(0, "FROM", QueryString).Length + 5;
            StrName = xFunctions.GetIDFromString(lngt + 1, " ", QueryString);
        }

        else { return; }

        try
        {
            DataTbl = sql.ExecuteToDataTable(QueryString);
            GridView1.DataSource = DataTbl;
            GridView1.DataBind();
            GridViewExportUtil.Export(StrName + ".xls", GridView1);           
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
}