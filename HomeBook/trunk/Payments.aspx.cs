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

public partial class Payments : System.Web.UI.Page
{
    xData sql = new xData();

    protected void Page_Load(object sender, EventArgs e)
    {

        lblError.Text = "";
        lblError.ForeColor = System.Drawing.Color.Red; 

        //Видимост достъпност
        if (VisibleEnable())
            return;

        if (!IsPostBack)
        {
            txtDateFrom.Text = xDateFormat.DateToStr(DateTime.Now);
            txtDateTo.Text   = xDateFormat.DateToStr(DateTime.Now);

            //зарежда статусите
            Load_Ddl_Status();
            //зарежда апартаментите
            Load_Ddl_Apartaments();
            //зарежда Типовете плащания
            Load_Ddl_Type_Payments();
            //зарежда данните в грида и прави проверка
            DataBind();
        }
        
    }

    /// <summary>
    /// видимост достъпност
    /// </summary>
    protected bool VisibleEnable()
    {

        if (Session["UserID"] == null || Session["UserName"] ==  null)
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
    /// Тук се зареждата типовете плащания в ddl списък
    /// </summary>
    protected void Load_Ddl_Type_Payments()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from TYPE_PAYMENTS");
        ddlTypePayment.DataTextField = dataS.Tables[0].Columns["TypePayment"].ToString();
        ddlTypePayment.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddlTypePayment.DataSource = dataS.Tables[0];
        ddlTypePayment.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddlTypePayment.Items.Insert(0, item);
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
    /// Байндва грида
    /// </summary>
    protected void DataBind()
    {

        // байндва грида
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
    /// Байндва грида
    /// </summary>
    private void BindGrid()
    {
        GridView1.DataSource = this.LoadData();
        GridView1.DataBind();
    }
   
 /// <summary>
    /// Зарежда данните 
    /// </summary>
    /// <returns></returns>
    private DataTable LoadData()
    {
   

        DataTable dataT = new DataTable();

        try
        {    
            /*
            string CommandText = "SELECT * , sts.StatusName ,hs.Home, cntct.FirstName AS Contactor, " +
            "tp.TypePayment FROM PAYMENTS pmnts left join STATUSES sts ON sts.ID = pmnts.Status Left join HOUSES hs ON pmnts.Hous_ID = hs.ID " +
            "Left join CONTACTS cntct ON pmnts.Contact_ID = cntct.ID Left join TYPE_PAYMENTS tp ON pmnts.TypePayment_ID = tp.ID Where pmnts.User_ID = " + Session["UserID"] + "";
            */

            string xWhere = "";

            if (!ddlTypePayment.Text.Equals("-1"))
            {
                xWhere = xWhere + " AND pmnts.TypePayment_ID = " + ddlTypePayment.Text + "";
            }

            if (!ddl_Status.Text.Equals("-1"))
            {
                xWhere = xWhere + " AND pmnts.Status = " + ddl_Status.Text + "";
            }

            if (!ddl_Home.Text.Equals("-1"))
            {
                xWhere = xWhere + " AND pmnts.Hous_ID = " + ddl_Home.Text + "";
            }

            string CommandText = "SELECT  pmnts.ID AS ID , hs.Phone AS Phone, hs.Number AS Number " +
                ", pmnts.Note AS Note, sts.StatusName AS StatusName ,pmnts.Status AS Status " +
                ", pmnts.Payment_Name AS Payment_Name ,  pmnts.Income AS Income " +
                ", CONVERT(varchar(10) , pmnts.DatePayment ,104) AS DatePayment , sts.StatusName AS StatusName ,hs.Home AS Home, cntct.FirstName AS Contactor, " +
           "tp.TypePayment AS TypePayment FROM PAYMENTS pmnts left join STATUSES sts ON sts.ID = pmnts.Status Left join HOUSES hs ON pmnts.Hous_ID = hs.ID " +
           "Left join CONTACTS cntct ON pmnts.Contact_ID = cntct.ID Left join TYPE_PAYMENTS tp ON pmnts.TypePayment_ID = tp.ID Where pmnts.User_ID = " + Session["UserID"] +
           " And pmnts.DatePayment Between '" + xDateFormat.DateStrToSQLDateStr(txtDateFrom.Text) + "' AND '" + xDateFormat.DateStrToSQLDateStr(txtDateTo.Text) + "'" + xWhere  + "";
            dataT = sql.ExecuteToDataTable(CommandText);
        }

        catch (Exception ex)
        {
           // new Exception("Грешка: " + ex.Message);
            lblError.Text = "Грешка: " + ex.Message;
        }

        return dataT;
    }

    /// <summary>
    /// Бутон Рефреш
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        DataBind();
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
            GridViewRow GridVRow  = ImgButton.NamingContainer as GridViewRow;

            int ID                = Convert.ToInt32(GridView1.DataKeys[GridVRow.RowIndex].Value.ToString());
            string CommandText    = "delete from Payments where ID = " + ID;

            int rezult            = sql.ExecuteNonQuery(CommandText);

            if (rezult == 1)
            {
                lblError.Text = "Изтриването е изпълнено успешно! ";
                lblError.ForeColor = System.Drawing.Color.Green; 
                BindGrid();
            }
        }
        catch (Exception ex)
        {
            //new Exception("Грешка: " + ex.Message);
            lblError.Text = "Грешка: " + ex.Message;
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
    /// ИЗпълнява филтъра
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_applyFilter_Click(object sender, EventArgs e)
    {
        DataBind();
    }
}