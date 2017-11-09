using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class EditNotes : System.Web.UI.Page
{
    xData sql = new xData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //зарежда статусите
            Load_Ddl_Status();
            //зарежда Списък със Контактите
            Load_Ddl_Contactor();

            string EID = Request.QueryString["id"];
            ReadElements(EID);

        }
    }

    /// <summary>
    /// зарежда елементите
    /// </summary>
    /// <param name="EID"></param>

    protected void ReadElements(string EID)
    {

        string query = "Select * , cntct.FirstName from NOTES nts left join CONTACTS cntct ON cntct.ID = nts.Contact_ID where nts.ID='" + EID + "'";

        SqlDataReader dataRead = sql.ExecuteReader(query);

        if (dataRead.Read())
        {
            txtID.Text = EID;

            ddlContact.Text = dataRead["Contact_ID"].ToString().Trim();
            txtNotes.Text = dataRead["Note"].ToString().Trim();
            ddl_Status.Text = dataRead["Status"].ToString().Trim();
         
        }

        int Rezultat = sql.CloseCommand(dataRead);

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
    /// Тук се зареждата контактите на юзъра в ddl списък
    /// </summary>
    protected void Load_Ddl_Contactor()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from CONTACTS WHERE User_ID = " + Session["UserID"] + "");
        ddlContact.DataTextField = dataS.Tables[0].Columns["FirstName"].ToString();
        ddlContact.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddlContact.DataSource = dataS.Tables[0];
        ddlContact.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddlContact.Items.Insert(0, item);

    }

    /// <summary>
    /// При натискане на бутон Съхрани се ъпдейтват данните в базата
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {
            string query = "Update NOTES  Set Contact_ID='" + ddlContact.Text.Trim() + "', Note='" + txtNotes.Text.Trim() +
                "', Status='" + int.Parse(ddl_Status.Text.Trim())  + "' where ID='" + txtID.Text.Trim() + "'";

            int rezult = sql.ExecuteNonQuery(query);

            if (rezult == 1)
            {
                lblResult.Text = "Вашите данни са съхранени!";
                pnlEdit.Visible = false;
            }
            else
            {
                lblResult.Text = "Грешка  при ъпдейт на данните !!! ";
                lblResult.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception ex)
        {
            lblResult.Text = "Грешка: " + ex.Message;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }

    }
}