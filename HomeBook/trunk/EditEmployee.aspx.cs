using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class EditPopup : System.Web.UI.Page
{   
    
    xData sql = new xData();

    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            //зарежда статусите
            Load_Ddl_Status(); 

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

        string query = "Select * from HOUSES where ID='" + EID + "'";

        SqlDataReader dataRead = sql.ExecuteReader(query);

        if (dataRead.Read())
        {
            txtID.Text      = EID;
            txtHome.Text    = dataRead["Home"].ToString().Trim();
            txtFloor.Text   = dataRead["Floor"].ToString().Trim();
            txtPeople.Text  = dataRead["People"].ToString().Trim();
            txtNumber.Text  = dataRead["Number"].ToString().Trim();
            txtContact.Text = dataRead["Contact"].ToString().Trim();
            txtNotes.Text   = dataRead["Notes"].ToString().Trim();
            ddl_Status.Text = dataRead["Status"].ToString().Trim();
            txtPhone.Text   = dataRead["Phone"].ToString().Trim();
            txtPercent.Text = dataRead["Percent1"].ToString().Trim();
            txtEmail.Text   = dataRead["Email"].ToString().Trim();
        }

        int Rezultat = sql.CloseCommand(dataRead);

    }

    /// <summary>
    /// Тук се зареждата статусите в ddl списък
    /// </summary>
    protected void Load_Ddl_Status()
    {

        DataSet dataS             = sql.ExecuteToDataSet("select * from STATUSES");
        ddl_Status.DataTextField  = dataS.Tables[0].Columns["StatusName"].ToString();
        ddl_Status.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddl_Status.DataSource     = dataS.Tables[0];
        ddl_Status.DataBind();  
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
            string query = "Update HOUSES  Set Home='" + txtHome.Text.Trim() + "', Floor='" + txtFloor.Text.Trim() +
            "', People='" + txtPeople.Text.Trim() + "', Number='" + txtNumber.Text.Trim() + "', Contact='" + txtContact.Text.Trim() +
            "', Notes='" + txtNotes.Text.Trim() + "', Status='" + int.Parse(ddl_Status.Text.Trim()) + "', Phone='" + txtPhone.Text.Trim() +
            "', Percent1='" + txtPercent.Text.Trim() + "', Email='" + txtEmail.Text.Trim() + "' where ID='" + txtID.Text.Trim() + "'";

            int rezult = sql.ExecuteNonQuery(query);

            if (rezult == 1)
            {
                lblResult.Text = "Вашите данни са съхранени!";
                pnlEdit.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblResult.Text = "Грешка: " + ex.Message;
            lblResult.ForeColor = System.Drawing.Color.Red;
        }
   }


}