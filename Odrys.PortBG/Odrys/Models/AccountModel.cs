using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using Odrys.Helpers;

namespace Odrys.Models
{
    public class AccountContext : Odrys.Models.AppConfigContext
    {
        public AccountContext()
        { }

        public AccountModel GetAccount(AccountLoginModel login)
        {
            int userId = 0;
            string userPassword = "";
            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = base.SQLConnection;
                command.CommandText =
@"SELECT u.ID
       , u.PASSWORD
 FROM U_USERS u
 WHERE u.LOGIN_ID = " + ParameterString(login.LoginID) + @"
   AND u.IS_ACTIVE = 1 ";
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows)
                    {
                        if (dReader.Read())
                        {
                            userId = TryParse.ToInt32(dReader["ID"]);
                            userPassword = dReader["PASSWORD"].ToString();
                        }
                    }
                }
            }

            AccountModel account = null;
            // Проверява паролата
            if (userPassword != login.Password)
            { return null; }
            else
            {
                account = new AccountModel();
                account.ID = userId;
                account.LoginID = login.LoginID;
            }
            // Взема ролите на потребителя
            using (SQLiteCommand command = new SQLiteCommand())
            {
                command.Connection = base.SQLConnection;
                command.CommandText =
@"SELECT r.ID
       , r.ROLE_NAME
 FROM U_USER_ROLES ur
 LEFT JOIN U_ROLES r ON r.ID = ur.U_ROLE_ID
 WHERE ur.U_USER_ID = " + ParameterInt(userId);
                using (SQLiteDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows)
                    {
                        while (dReader.Read())
                        {
                            if (account.Roles == null)
                            { account.Roles = dReader["ROLE_NAME"].ToString(); }
                            else
                            { account.Roles += ";" + dReader["ROLE_NAME"].ToString(); }
                        }
                    }
                }
            }
            return account;
        }
    }

    public class AccountModel
    {
        public int ID { get; set; }

        public string LoginID { get; set; }

        public string Roles { get; set; }
    }

    public class AccountLoginModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage="*")]
        [Display(Name = "Потребител")]
        public string LoginID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Парола")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомни")]
        public bool RememberMe { get; set; }        
    }
}