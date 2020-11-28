using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public class DBConnection
    {
        public static SqlConnection connection = new SqlConnection("Data Source = LAPTOP-FTS17DRH\\MYSERVER; " +
                " Initial Catalog = PP; Persist Security Info = true;" +
                " User ID = sa; Password = \"paralon\"");

        public DataTable dtAutorization = new DataTable("Authorization");
        public DataTable dtEmployee = new DataTable("Employee");
        public DataTable dtDismissed = new DataTable("Dismissed");
        public static Int32 ID_User = 0, ID_Feedback = 0;

        public static string
            qrAuthorization = "SELECT [ID_Authorization], [Login] as \"Логин\", [Password] as \"Пароль\", [Role] as \"Роль\" FROM [dbo].[Authorization]",
            qrEmployee = "SELECT [Authorization_ID], [Surname_Employee] as \"Фамилия сотрудника\", [Name_Employee] as \"Имя сотрудника\", [Middlename_Employee] as \"Отчество сотрудника\", [Login] as \"Логин\", [Password] as \"Пароль\", [Position] as \"Должность\", [Phone_Number] as \"Телефонный номер\", [Mail] as \"Почта\", [Role] as \"Роль\" FROM [dbo].[Employee] INNER JOIN[dbo].[Authorization] on[dbo].[Employee].[Authorization_ID]=[dbo].[Authorization].[ID_Authorization]",
            qrDismissed = "SELECT [ID_Dismissed], [Surname_Employee] as \"Фамилия сотрудника\", [Name_Employee] as \"Имя сотрудника\", [Middlename_Employee] as \"Отчество сотрудника\", [Position] as \"Должность\", [Position] as \"Должность\" FROM [dbo].[Dismissed]";


        private SqlCommand command = new SqlCommand("", connection);
        private SqlCommand command_Surname_Employee = new SqlCommand("", connection);
        private SqlCommand command_Name_Employee = new SqlCommand("", connection);
        private SqlCommand command_Middlename_Employee = new SqlCommand("", connection);
        private SqlCommand command_Email = new SqlCommand("", connection);
        public static Int32 IDrecord, IDuser, IDusers;
        public static String Login, Surname, Name, eMail, Middlename;

        public void dbEnter(string login, string password)
        {
            command.CommandText = "SELECT count(*) FROM [dbo].[Authorization] " +
                "where [Login] = '" + login + "' and [Password] = '" + password + "'";
            connection.Open();
            IDuser = Convert.ToInt32(command.ExecuteScalar().ToString());
            ID_Feedback = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        public void dbEmail(string Mail)
        {
            command.CommandText = "SELECT Authorization_ID FROM [dbo].[Employee] " +
                "where [Mail] = '" + Mail + "'";
            connection.Open();
            IDusers = Convert.ToInt32(command.ExecuteScalar().ToString());
            connection.Close();
        }

        public void dbFeedback()
        {
            command_Email.CommandText = "SELECT Mail FROM [dbo].[Employee] " +
                "where [Authorization_ID] = '%" + IDuser + "%'";
            connection.Open();
            eMail = command_Email.ExecuteScalar().ToString();
            connection.Close(); 
        }

        public void dbLogin()
        {
            command.CommandText = "SELECT Login FROM [dbo].[Authorization] " +
                "where [ID_Authorization] = '" + IDusers + "'";
            connection.Open();
            Login = command.ExecuteScalar().ToString();
            connection.Close();
        }

        private void dtFill(DataTable table, string query)
        {
            command.CommandText = query;
            connection.Open();
            table.Load(command.ExecuteReader());
            connection.Close();
        }

        public void AutorizationFill()
        {
            dtFill(dtAutorization, qrAuthorization);
        }
        public void EmployeeFill()
        {
            dtFill(dtEmployee, qrEmployee);
        }
        public void DismissedFill()
        {
            dtFill(dtDismissed, qrDismissed);
        }
    }
}