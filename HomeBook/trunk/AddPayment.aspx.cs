using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class AddPayment : System.Web.UI.Page
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

        if (ddlContactor.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Контакт";
            pnlEdit.Visible = true;
            return true;
        }
        if (txtIncome.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Сума";
            pnlEdit.Visible = true;
            return true;
        }
        if (txtDatePayment.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Дата на плащане";
            pnlEdit.Visible = true;
            return true;
        }
        if (ddlTypePayment.Text.Trim() == "")
        {
            lblResult.Text = "Непопълнено поле: Тип на плащане";
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
            //формат на някои данни за да няма грешка при ъпдейт
            decimal priceDEC = Decimal.Parse(txtIncome.Text);
            DateTime newDateTime = xDateFormat.StringToData(txtDatePayment.Text);

            // insert стринга
            string query = "Insert into PAYMENTS (Hous_ID, Income , DatePayment , Contact_ID , Note , Status , TypePayment_ID , User_ID, Payment_Name)" +
             "values(@Hous_ID , @Income , @DatePayment, @Contact_ID , @Note ,  @Status , @TypePayment_ID , @User_ID , @NamePayment)";

            // извикване на GetCommand
            SqlCommand cmd = sql.GetCommand(query);

            //параметрите
            cmd.Parameters.AddWithValue("@Hous_ID", ddl_Home.Text.Trim());
            cmd.Parameters.AddWithValue("@Income", priceDEC);
            cmd.Parameters.AddWithValue("@DatePayment", newDateTime);
            cmd.Parameters.AddWithValue("@Contact_ID", ddlContactor.Text);
            cmd.Parameters.AddWithValue("@Note", txtNotes.Text.Trim());
            cmd.Parameters.AddWithValue("@Status", ddl_Status.Text.ToString().Trim());
            cmd.Parameters.AddWithValue("@TypePayment_ID", ddlTypePayment.Text.Trim());
            cmd.Parameters.AddWithValue("@User_ID", Session["UserID"]);
            cmd.Parameters.AddWithValue("@NamePayment", txtNamePayment.Text.Trim()); 
            //insert и ако всичко е точно съобщава
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
            lblResult.Text = "Възникна грешка при изпълнение на заявката Ви! " + ex.Message.ToString();
            lblResult.ForeColor = System.Drawing.Color.Red;
            pnlEdit.Visible = true;
        }

    }
}   

