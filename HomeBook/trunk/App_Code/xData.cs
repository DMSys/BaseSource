using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Configuration;

/// <summary>
/// Summary description for xData
/// 
/// Пример :
/// xData sql = new xData();
/// DataTable data = sql.ExecuteToDataTable("SELECT * FROM Customers");
/// int affected = sql.ExecuteNonQuery("INSERT Customers VALUES ('Test')");
/// </summary>
/// 

public class xData
{
    private SqlConnection connection;

    public xData()
    {
        connection = new SqlConnection();
    }

    /// <summary>
    /// отваря конекшън стринга
    /// </summary>

    public void OpenConnection()
    {
        
        if (WebConfigurationManager.ConnectionStrings.Count == 0)
            throw new ArgumentNullException("Необходимо е да конфигурирате Вашия ConnectionString в Web.config.");
        else
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringDb1"].ConnectionString;
            connection.Open();
        }

    }

    /// <summary>
    /// затваря конекшън стринга
    /// </summary>

    public void CloseConnection()
    {
        if (connection != null && connection.State != ConnectionState.Closed)
            connection.Close();
    }

    /// <summary>
    /// връща DataTable
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>

    public DataTable ExecuteToDataTable(string sql)
    {
        DataTable dataTable    = new DataTable() ;
        SqlCommand command     = null;
        SqlDataAdapter adapter = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
        }
        finally
        {
            if (command != null)
                command.Dispose();

            if (adapter != null)
                adapter.Dispose();

            CloseConnection();
        }

        return dataTable;
    }

    /// <summary>
    /// Връща DataSet
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public DataSet ExecuteToDataSet(string sql)
    {
       
        DataSet dataS          = new DataSet();
        SqlCommand command     = null;
        SqlDataAdapter adapter = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(dataS);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            if (command != null)
                command.Dispose();

            if (adapter != null)
                adapter.Dispose();

            CloseConnection();
        }

        return dataS;
    }

    /// <summary>
    /// GetCommand() for Parameters with ExecuteNonQuery
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>

    public SqlCommand GetCommand(string sql)
    {
        SqlCommand command = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            return command;
        }

        finally
        { 
        
        }
    }

    /// <summary>
    /// Execute()  -> Execute with Close command for Parameters with ExecuteNonQuery
    /// </summary>
    /// <returns></returns>
    public int Execute(SqlCommand command)
    {
        try
        {
            command.ExecuteNonQuery();
            return 1;
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            if (command != null)
            {
                command.Dispose();
                CloseConnection();
                
            }          
        }
    }

    /// <summary>
    /// ExecuteNonQuery
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>

    public int ExecuteNonQuery(string sql)
    {
        SqlCommand command = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            return command.ExecuteNonQuery();
        }
       
        finally
        {
            if (command != null)
                command.Dispose();

            CloseConnection();
        }
    }


    /// <summary>
    /// Връща ExecuteReader
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>

    public SqlDataReader ExecuteReader(string sql)
    {
        SqlCommand command = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            return command.ExecuteReader();
        }

        finally
        {
          
        }
    }

    /// <summary>
    /// Затваряме конекцията при ExecuteReader()
    /// </summary>
    /// <returns></returns>
    public int CloseCommand(SqlDataReader command)
    {
       if (command != null)
           command.Dispose();
           CloseConnection();
           return 1;
       
    }

    /// <summary>
    /// ExecuteScalar
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public object ExecuteScalar(string sql)
    {
        SqlCommand command = null;

        try
        {
            if (connection.State != ConnectionState.Open)
                OpenConnection();

            command = new SqlCommand(sql, connection);
            return command.ExecuteScalar();
        }
        finally
        {
            if (command != null)
                command.Dispose();

            CloseConnection();
        }
    }
}