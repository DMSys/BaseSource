using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class EditPayments : System.Web.UI.Page
{

    xData sql = new xData();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
          
            //зарежда статусите
            Load_Ddl_Status();
            //зарежда апартаментите
            Load_Ddl_Apartaments();
            //зарежда Типовете плащания
            Load_Ddl_Type_Payments();
            //зарежда Списък със Контактите
            Load_Ddl_Contactor();
            //Зарежда елементите във формата
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
        /*
        string query = "Select * , hs.Home from PAYMENTS pmn left join HOUSES hs ON hs.ID = pmn.Hous_ID " +
         " left join CONTACTS cntct ON cntct.ID = pmn.Contact_ID left join TYPE_PAYMENTS tp ON tp.ID = pmn.TypePayment_ID where pmn.ID='" + EID + "'";
        */

        string query = "SELECT  pmnts.ID ,pmnts.TypePayment_ID AS TypePayment_ID, pmnts.Contact_ID AS Contact_ID , pmnts.Hous_ID AS Hous_ID "+
            ", hs.Phone AS Phone, hs.Number AS Number , pmnts.Note AS Notes, sts.StatusName AS StatusName ,pmnts.Status AS Status " +
            ", pmnts.Payment_Name AS Payment_Name ,  pmnts.Income AS Income " +
            ", CONVERT(varchar(10) , pmnts.DatePayment ,104) AS DatePayment , sts.StatusName AS StatusName ,hs.Home AS Home, cntct.FirstName AS Contactor, " +
       "tp.TypePayment AS TypePayment FROM PAYMENTS pmnts left join STATUSES sts ON sts.ID = pmnts.Status Left join HOUSES hs ON pmnts.Hous_ID = hs.ID " +
       "Left join CONTACTS cntct ON pmnts.Contact_ID = cntct.ID Left join TYPE_PAYMENTS tp ON pmnts.TypePayment_ID = tp.ID Where pmnts.User_ID = " + Session["UserID"] + " AND pmnts.ID = '" + EID + "'";

        SqlDataReader dataRead = sql.ExecuteReader(query);

        if (dataRead.Read())
        {
            txtID.Text               = EID;
            ddl_Home.Text            = dataRead["Hous_ID"].ToString().Trim();
            txtIncome.Text           = dataRead["Income"].ToString().Trim();
            txtDatePayment.Text      = dataRead["DatePayment"].ToString();
            ddlContactor.Text        = dataRead["Contact_ID"].ToString().Trim();
            txtNotes.Text            = dataRead["Notes"].ToString().Trim();
            ddl_Status.Text          = dataRead["Status"].ToString().Trim();
            ddlTypePayment.Text      = dataRead["TypePayment_ID"].ToString().Trim();
            txtNamePayment.Text      = dataRead["Payment_Name"].ToString().Trim();
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
    /// Тук се зареждата апартаментите в ddl списък
    /// </summary>
    protected void Load_Ddl_Apartaments()
    {

        DataSet dataS           = sql.ExecuteToDataSet("select * from HOUSES WHERE User_ID = " + Session["UserID"] + "");
        ddl_Home.DataTextField  = dataS.Tables[0].Columns["Home"].ToString();
        ddl_Home.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddl_Home.DataSource     = dataS.Tables[0];
        ddl_Home.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddl_Home.Items.Insert(0, item);
    }
   
     /// <summary>
    /// Тук се зареждата типовете плащания в ddl списък
    /// </summary>
    protected void Load_Ddl_Type_Payments()
    {

        DataSet dataS                 = sql.ExecuteToDataSet("select * from TYPE_PAYMENTS");
        ddlTypePayment.DataTextField  = dataS.Tables[0].Columns["TypePayment"].ToString();
        ddlTypePayment.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddlTypePayment.DataSource     = dataS.Tables[0];
        ddlTypePayment.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddlTypePayment.Items.Insert(0, item);
    }
  
   /// <summary>
    /// Тук се зареждата контактите на юзъра в ddl списък
    /// </summary>
    protected void Load_Ddl_Contactor()
    {
    
        DataSet dataS               = sql.ExecuteToDataSet("select * from CONTACTS WHERE User_ID = " + Session["UserID"] + "");
        ddlContactor.DataTextField  = dataS.Tables[0].Columns["FirstName"].ToString();
        ddlContactor.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddlContactor.DataSource     = dataS.Tables[0];
        ddlContactor.DataBind();
        ListItem item = new ListItem("<Неуказано>", "-1");
        ddlContactor.Items.Insert(0, item);
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
            //формат на някои данни за да няма грешка при ъпдейт
            decimal priceDEC = Decimal.Parse(txtIncome.Text);
            DateTime newDateTime = xDateFormat.StringToData(txtDatePayment.Text);
            
            // ъпдейт стринга
            string query = "Update PAYMENTS  Set Hous_ID = @Hous_ID , Income = @Income , DatePayment = @DatePayment , Contact_ID = @Contact_ID, " +
             "Note = @Note , Status = @Status , TypePayment_ID = @TypePayment_ID , Payment_Name = @NamePayment where ID='" + txtID.Text.Trim() + "'";

            // извикване на GetCommand
            SqlCommand cmd = sql.GetCommand(query);

            //параметрите
            cmd.Parameters.AddWithValue("@Hous_ID", ddl_Home.Text.Trim());
            cmd.Parameters.AddWithValue("@Income" , priceDEC);
            cmd.Parameters.AddWithValue("@DatePayment", newDateTime);
            cmd.Parameters.AddWithValue("@Contact_ID", ddlContactor.Text);
            cmd.Parameters.AddWithValue("@Note", txtNotes.Text.Trim());
            cmd.Parameters.AddWithValue("@Status", ddl_Status.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@TypePayment_ID", ddlTypePayment.Text.Trim());
            cmd.Parameters.AddWithValue("@NamePayment", txtNamePayment.Text.Trim()); 
            //ъпдейтва и ако всичко е точно съобщава
            int rezult = sql.Execute(cmd);

            if (rezult == 1)
            {
                lblResult.Text = "Вашите данни са съхранени!";
                lblResult.ForeColor = System.Drawing.Color.Green;
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