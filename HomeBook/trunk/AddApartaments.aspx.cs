using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class AddApartaments : System.Web.UI.Page
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
      
    }
    /// <summary>
    /// Проверка за непопълнени полета
    /// </summary>
    protected bool ValidationField()
    {
        lblResult.ForeColor = System.Drawing.Color.Red; 

        if (txtHome.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Апартамент";
            pnlEdit.Visible = true;
            return true;
        }

        if (txtFloor.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Етаж";
            pnlEdit.Visible = true;
            return true;
        }
        if (txtPeople.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Брой живущи";
            pnlEdit.Visible = true;
            return true;
        }
        if (txtNumber.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Номер на апартамент";
            pnlEdit.Visible = true;
            return true;
        }
        if (ddlContact.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Контакт";
            pnlEdit.Visible = true;
            return true;
        }
 
        return false;
    }

    /// <summary>
    /// При натискане на бутон Съхрани
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        //проверка за попълнени полета
        if (ValidationField())
        {
            return;
        }

        try
        {

            string query = "insert into [HOUSES] (Home, Floor, People, Number, Contact, Notes, Status, Phone, Percent1, Email, User_ID) " +
            "values(@Home, @Floor, @People, @Number, @Contact, @Notes, @Status, @Phone, @Percent1, @Email, @User_ID)";

            // извикване на GetCommand
            SqlCommand insertInDataBase = sql.GetCommand(query);

            insertInDataBase.Parameters.AddWithValue("@Home", txtHome.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Floor", txtFloor.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@People", txtPeople.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Number", txtNumber.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Contact", ddlContact.SelectedItem.Text.Trim());

            insertInDataBase.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Status", int.Parse(ddl_Status.Text.Trim()));
            insertInDataBase.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Percent1", txtPercent.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

            insertInDataBase.Parameters.AddWithValue("@User_ID", Session["UserID"]);

            //инсъртва и ако всичко е точно съобщава
            int rezult = sql.Execute(insertInDataBase);

            if (rezult == 1)
            {
                lblResult.Text = "Вашите данни са съхранени!";
                lblResult.ForeColor = System.Drawing.Color.Green; 
                pnlEdit.Visible = false;
            }
        }

        catch (Exception ex)
        {
            lblResult.Text = "Възникна грешка при изпълнение на заявката Ви! " + ex.Message.ToString();
            lblResult.ForeColor = System.Drawing.Color.Red; 
            pnlEdit.Visible = true;
        }
        

    }
}