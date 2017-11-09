using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class AddPeople : System.Web.UI.Page
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
    /// Тук се зареждата апартаментите в ddl списък
    /// </summary>
    protected void Load_Ddl_Apartaments()
    {

        DataSet dataS = sql.ExecuteToDataSet("select * from HOUSES WHERE User_ID = " + Session["UserID"] + "");
        ddl_Home.DataTextField = dataS.Tables[0].Columns["Home"].ToString();
        ddl_Home.DataValueField = dataS.Tables[0].Columns["ID"].ToString();
        ddl_Home.DataSource = dataS.Tables[0];
        ddl_Home.DataBind();
    }

      /// <summary>
    /// Проверка за непопълнени полета
    /// </summary>
    protected bool ValidationField()
    {
        lblResult.ForeColor = System.Drawing.Color.Red; 

        if (ddl_Home.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Апартамент";
            pnlEdit.Visible = true;
            return true;    
        }

        if (txtFirstName.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Име";
            pnlEdit.Visible = true;
            return true;  
        }
        if (txtLastName.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Фамилия";
            pnlEdit.Visible = true;
            return true;  
        }
        if (txtAddress.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Адрес";
            pnlEdit.Visible = true;
            return true;  
        }
        if (txtContact.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Контакт";
            pnlEdit.Visible = true;
            return true;  
        }

        if (txtCity.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Град";
            pnlEdit.Visible = true;
            return true;  
        }

        return false;  
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        //проверка за попълнени полета
        if (ValidationField())
        {
            return;
        }

        try
        {
            string query = "insert into [CONTACTS] (Hous_ID, FirstName, LastName, Address, ContactTitle, Notes, Status, Phone, City, User_ID) " +
             "values(@Hous_ID, @FirstName, @LastName, @Address, @ContactTitle, @Notes, @Status, @Phone, @City, @User_ID)";

            // извикване на GetCommand
            SqlCommand insertInDataBase = sql.GetCommand(query);

            insertInDataBase.Parameters.AddWithValue("@Hous_ID", ddl_Home.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@ContactTitle", txtContact.Text.Trim());

            insertInDataBase.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Status", int.Parse(ddl_Status.Text.Trim()));
            insertInDataBase.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@City", txtCity.Text.Trim());
            insertInDataBase.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

            insertInDataBase.Parameters.AddWithValue("@User_ID", Session["UserID"]);

            //инсъртва и ако всичко е точно съобщава
            int rezult = sql.Execute(insertInDataBase);

            if (rezult == 1)
            {
                lblResult.Text      = "Вашите данни са съхранени!";
                lblResult.ForeColor = System.Drawing.Color.Green; 
                pnlEdit.Visible     = false;
            }

        }

        catch (Exception ex)
        {
            lblResult.Text      = "Възникна грешка при изпълнение на заявката Ви! " + ex.Message.ToString();
            lblResult.ForeColor = System.Drawing.Color.Red; 
            pnlEdit.Visible     = true;
        }
               
    }
}
 
