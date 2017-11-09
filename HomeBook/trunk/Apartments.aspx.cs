using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;



public partial class Apartments : System.Web.UI.Page
{
    protected string ImportString { get; set; }
 
    xData sql = new xData();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //Видимост достъпност 
        if (VisibleEnable())
            return;
      

        if (!IsPostBack)
        {           
            //зарежда статусите
            Load_Ddl_Status();

            //зарежда апартаментите
            Load_Ddl_Apartaments();

            //зарежда Списък със Контактите
            Load_Ddl_Contactor();

            //байндва грида
            DataBuilding();
        }
       
    }

    /// <summary>
    /// видимост достъпност -  aко няма потребител да не байндва грида
    /// </summary>
    protected bool VisibleEnable()
    {

        if (Session["UserID"] == null || Session["UserName"] == null)
        {
            Article3.Visible = false;
            tb_Filter.Visible = false;
            return true;
        }
        else
        {
            Article3.Visible = true;
            tb_Filter.Visible = true;
            return false;
        }

    }

    /// <summary>
    /// Тук се зареждата статусите в ddl списък
    /// </summary>
    protected void Load_Ddl_Status()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from STATUSES");
        ddl_Status.DataTextField = dataS.Tables[0].Columns["StatusName"].ToString();
        ddl_Status.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddl_Status.DataSource = dataS.Tables[0];
        ddl_Status.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddl_Status.Items.Insert(0, item);
    }

    /// <summary>
    /// Тук се зареждата апартаментите в ddl списък
    /// </summary>
    protected void Load_Ddl_Apartaments()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from HOUSES WHERE User_ID = " + Session["UserID"] + "");
        ddl_Home.DataTextField = dataS.Tables[0].Columns["Home"].ToString();
        ddl_Home.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddl_Home.DataSource = dataS.Tables[0];
        ddl_Home.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddl_Home.Items.Insert(0, item);
    }

    /// <summary>
    /// Тук се зареждата контактите на юзъра в ddl списък
    /// </summary>
    protected void Load_Ddl_Contactor()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from CONTACTS WHERE User_ID = " + Session["UserID"] + "");
        ddlContactor.DataTextField = dataS.Tables[0].Columns["FirstName"].ToString();
        ddlContactor.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddlContactor.DataSource = dataS.Tables[0];
        ddlContactor.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddlContactor.Items.Insert(0, item);
    }

    /// <summary>
    /// Зарежда данните 
    /// </summary>
    /// <returns></returns>
    private DataTable LoadData()
    {
        DataTable DataTbl = new DataTable();
        try 
        {
            DataTbl = sql.ExecuteToDataTable(InitializeSQLString());
        }
        catch (Exception ex)
        {
             new Exception("Грешка: " + ex.Message);
        }

        return DataTbl;
    }

    /// <summary>
    /// SQL String For GridView
    /// </summary>
    /// <returns></returns>
    private string InitializeSQLString() 
    {
        this.ImportString  = "";
        string xWhere      = "";

        if (!ddlContactor.Text.Equals("-1"))
        {
            xWhere = xWhere + " AND hs.Contact = '" + ddlContactor.SelectedItem.Text + "' ";
        }

        if (!ddl_Status.Text.Equals("-1"))
        {
            xWhere = xWhere + " AND hs.Status = " + ddl_Status.Text + "";
        }

        if (!ddl_Home.Text.Equals("-1"))
        {
            xWhere = xWhere + " AND hs.ID = " + ddl_Home.Text + "";
        }

        string CommandText = "SELECT * , sts.StatusName FROM HOUSES hs left join STATUSES sts ON sts.ID = hs.Status Where hs.User_ID = " + Session["UserID"] + " " + xWhere + "";

        //Инициализира SQL стринга за импорта
        this.ImportString = CommandText;

        return CommandText;
    }

    /// <summary>
    /// Байндва грида
    /// </summary>
    private void BindGrid()
    {
        GridView1.DataSource = this.LoadData();
        GridView1.DataBind();
    }

    /// <summary>
    /// Бутон Рефреш
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        DataBuilding();
    }

    /// <summary>
    /// Изтриване на реда в грида
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        try
        {
            ImageButton ImgButton = sender as ImageButton;
            GridViewRow GridVRow = ImgButton.NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(GridView1.DataKeys[GridVRow.RowIndex].Value.ToString());

            string CommandText = "delete from HOUSES where ID = " + ID;
            int rezult = sql.ExecuteNonQuery(CommandText);

            if (rezult == 1)
            {
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            new Exception("Грешка: " + ex.Message);
        }
    }

    /// <summary>
    /// Диалог преди изтриване на реда 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Конфирмация за изтриване на реда
            ImageButton ImgBtnResult = (ImageButton)e.Row.FindControl("lnkdelete");
            ImgBtnResult.OnClientClick = "return confirm('Сигурни ли сте че желаете да изтриете реда ?');";
        }
    }

    /// <summary>
    /// Проверка преди изпълнение и при стартиране 
    /// </summary>
    protected void DataBuilding()
    {
   
        this.BindGrid();

        //Центрира данните в грида
        foreach (GridViewRow row in GridView1.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                cell.Attributes.CssStyle["text-align"] = "center";
            }
        }
    }

    /// <summary>
    /// ИЗпълнява филтъра
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_applyFilter_Click(object sender, EventArgs e)
    {
        DataBuilding();
    }
}
   
    

